namespace Minsk.CodeAnalysis.Binding
{
    internal sealed class BoundVariableExpression : BoundExpression
    {
        public BoundVariableExpression(VariableSymbol variable)
        {
            Variable = variable;
        }

        public override Type Type => Variable.Type;
        public override BoundNodekind Kind => BoundNodekind.NameExpression;
        public VariableSymbol Variable { get; }
    }

}