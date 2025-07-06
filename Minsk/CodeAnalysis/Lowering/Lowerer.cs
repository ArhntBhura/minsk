using System.Collections.Immutable;
using Minsk.CodeAnalysis.Binding;
using Minsk.CodeAnalysis.Syntax;
namespace Minsk.CodeAnalysis.Lowering
{
    internal sealed class Lowerer : BoundTreeWriter
    {
        private int _labelCount;
        private Lowerer() { }

        private LabelSymbol GenerateLabel()
        {
            var name = $"Label{++_labelCount}";
            return new LabelSymbol(name);
        }

        public static BoundBlockStatement Lower(BoundStatement statement)
        {
            var lowerer = new Lowerer();
            var result = lowerer.RewriteStatement(statement);
            return Flatten(result);
        }

        private static BoundBlockStatement Flatten(BoundStatement statement)
        {
            var builder = ImmutableArray.CreateBuilder<BoundStatement>();
            var stack = new Stack<BoundStatement>();
            stack.Push(statement);

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                if (current is BoundBlockStatement block)
                {
                    foreach (var s in block.Statements.Reverse())
                        stack.Push(s);
                }
                else
                {
                    builder.Add(current);
                }
            }

            return new BoundBlockStatement(builder.ToImmutable());
        }

        protected override BoundStatement RewriteIfStatement(BoundIfStatement node)
        {
            if (node.ElseStatement == null)
            {
                // if (condition)
                //      ifStatement
                // ----->
                // gotoFalse condition end
                // ifStatement
                // end
                var endLabel = GenerateLabel();
                var gotoFalse = new BoundConditionalGotoStatement(endLabel, node.Condition, true);
                var endLabelStatement = new BoundLabelStatement(endLabel);
                var result = new BoundBlockStatement(ImmutableArray.Create<BoundStatement>(gotoFalse, node.IfStatement, endLabelStatement));
                return RewriteStatement(result);
            }
            else
            {
                // if (condition)
                //      ifStatement
                // else
                //      elseStatement
                //
                // ----->
                // gotoFalse condition else
                // ifStatement
                // goto end
                // else
                // elseStatement
                // end

                var elseLabel = GenerateLabel();
                var endLabel = GenerateLabel();

                var gotoFalse = new BoundConditionalGotoStatement(elseLabel, node.Condition, true);
                var gotoEndStatement = new BoundGotoStatement(endLabel);
                var elseLabelStatement = new BoundLabelStatement(elseLabel);
                var endLabelStatement = new BoundLabelStatement(endLabel);
                var result = new BoundBlockStatement(ImmutableArray.Create<BoundStatement>(
                    gotoFalse,
                    node.IfStatement,
                    gotoEndStatement,
                    elseLabelStatement,
                    node.ElseStatement,
                    endLabelStatement
                ));
                return RewriteStatement(result);
            }
        }

        protected override BoundStatement RewriteWhileStatement(BoundWhileStatement node)
        {
            // while (condition)
            //      body
            //
            // -------->
            //
            // goto check
            // continue
            // body
            // check
            // gotoTrue condition continue
            // end

            var continueLabel = GenerateLabel();
            var checkLabel = GenerateLabel();
            var endLabel = GenerateLabel();

            var gotoCheck = new BoundGotoStatement(checkLabel);
            var continueLabelStatement = new BoundLabelStatement(continueLabel);
            var checkLabelStatement = new BoundLabelStatement(checkLabel);
            var gotoTrue = new BoundConditionalGotoStatement(continueLabel, node.Condition, false);
            var endLabelStatement = new BoundLabelStatement(endLabel);

            var result = new BoundBlockStatement(ImmutableArray.Create<BoundStatement>(
                gotoCheck,
                continueLabelStatement,
                node.Body,
                checkLabelStatement,
                gotoTrue,
                endLabelStatement
            ));

            return RewriteStatement(result);
        }

        protected override BoundStatement RewriteForStatement(BoundForStatement node)
        {
            // for i = lower to upper
            //      body
            // 
            // ----> lowered to
            // {
            //      var i = lower
            //      while(i <= upper) {
            //          body
            //          i = i + 1
            //      }
            // }
            var variableDeclaration = new BoundVariableDeclaration(node.Variable, node.LowerBound);
            var variableExpression = new BoundVariableExpression(node.Variable);
            var condition = new BoundBinaryExpression(
                variableExpression,
                BoundBinaryOperator.Bind(SyntaxKind.LessorEqualsToken, typeof(int), typeof(int)),
                node.UpperBound
            );

            var increment = new BoundExpressionStatement(
                new BoundAssignmentExpression(
                    node.Variable,
                    new BoundBinaryExpression(
                        variableExpression,
                        BoundBinaryOperator.Bind(SyntaxKind.PlusToken, typeof(int), typeof(int)),
                        new BoundLiteralExpression(1))
                )
            );
            var whileBody = new BoundBlockStatement(ImmutableArray.Create<BoundStatement>(node.Body, increment));
            var whileStatement = new BoundWhileStatement(condition, whileBody);
            var result = new BoundBlockStatement(ImmutableArray.Create<BoundStatement>(variableDeclaration, whileStatement));

            return RewriteStatement(result);
        }
    }
}