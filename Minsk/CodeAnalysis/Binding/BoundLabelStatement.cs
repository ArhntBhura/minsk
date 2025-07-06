namespace Minsk.CodeAnalysis.Binding
{
    internal sealed class BoundLabelStatement : BoundStatement
    {
        internal BoundLabelStatement(LabelSymbol label)
        {
            Label = label;
        }

        public override BoundNodekind Kind => BoundNodekind.LabelStatement;
        public LabelSymbol Label { get; }
    }
}