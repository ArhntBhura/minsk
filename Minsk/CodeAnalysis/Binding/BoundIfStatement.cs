namespace Minsk.CodeAnalysis.Binding
{
    internal sealed class BoundIfStatement : BoundStatement
    {
        public BoundIfStatement(BoundExpression condition, BoundStatement ifStatement, BoundStatement elseStatement)
        {
            Condition = condition;
            IfStatement = ifStatement;
            ElseStatement = elseStatement;
        }

        public override BoundNodekind Kind => BoundNodekind.IfStatement;
        public BoundExpression Condition { get; }
        public BoundStatement IfStatement { get; }
        public BoundStatement ElseStatement { get; }
    }
}