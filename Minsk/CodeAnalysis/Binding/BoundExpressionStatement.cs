namespace Minsk.CodeAnalysis.Binding
{
    internal sealed class BoundExpressionStatement : BoundStatement
    {
        public BoundExpressionStatement(BoundExpression expression)
        {
            Expression = expression;
        }

        public override BoundNodekind Kind => BoundNodekind.ExpressionStatement;
        public BoundExpression Expression { get; }
    }

}