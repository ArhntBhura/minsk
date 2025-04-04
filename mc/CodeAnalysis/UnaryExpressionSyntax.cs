namespace Minsk.CodeAnalysis
{
    public sealed class UnaryExpressionSyntax : ExpressionSyntax
    {
        public UnaryExpressionSyntax(SyntaxToken operatorToken, ExpressionSyntax operand)
        {
            Operand = operand;
            OperatorToken = operatorToken;
        }
        public override SyntaxKind Kind => SyntaxKind.UnaryExpression;
        public ExpressionSyntax Operand { get; }
        public SyntaxToken OperatorToken { get; }

        public override IEnumerable<SyntaxNode> GetChildren()
        {
            yield return OperatorToken;
            yield return Operand;
        }
    }
}