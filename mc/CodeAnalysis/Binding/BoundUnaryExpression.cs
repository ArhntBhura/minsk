using System.Reflection.Emit;

namespace Minsk.CodeAnalysis.Binding
{
    internal sealed class BoundUnaryExpression : BoundExpression
    {
        public BoundUnaryExpression(BoundUnaryOperator op, BoundExpression operand)
        {
            Op = op;
            Operand = operand;
        }

        public override Type Type => Op.Type;
        public override BoundNodekind Kind => BoundNodekind.UnaryExpression;
        public BoundUnaryOperator Op { get; }
        public BoundExpression Operand { get; }
    }

}