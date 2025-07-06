namespace Minsk.CodeAnalysis.Binding
{
    internal sealed class BoundConditionalGotoStatement : BoundStatement
    {
        internal BoundConditionalGotoStatement(LabelSymbol label, BoundExpression condition, bool jumpIfFalse = false)
        {
            Label = label;
            Condition = condition;
            JumpIfFalse = jumpIfFalse;
        }

        public override BoundNodekind Kind => BoundNodekind.ConditionalGotoStatement;
        public LabelSymbol Label { get; }
        public BoundExpression Condition { get; }
        public bool JumpIfFalse { get; }
    }
}