namespace Minsk.CodeAnalysis.Binding
{
    internal sealed class BoundUnaryExpression : BoundExpression
    {
        public BoundUnaryExpression(BoundUnaryOperatorKind operatorKind, BoundExpression operand)
        {
            OperatorKind = operatorKind;
            Operand = operand;
        }

        public override Type Type => Operand.Type;
        public override BoundNodekind Kind => BoundNodekind.UnaryExpression;
        public BoundUnaryOperatorKind OperatorKind { get; }
        public BoundExpression Operand { get; }
    }

}