namespace Minsk.CodeAnalysis.Binding
{
    internal sealed class BoundGotoStatement : BoundStatement
    {
        internal BoundGotoStatement(LabelSymbol label)
        {
            Label = label;
        }

        public override BoundNodekind Kind => BoundNodekind.GotoStatement;
        public LabelSymbol Label { get; }
    }
}