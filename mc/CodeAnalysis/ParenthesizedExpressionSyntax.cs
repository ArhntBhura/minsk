namespace Minsk.CodeAnalysis
{
    sealed class ParenthesizedExpressionSyntax : ExpressionSyntax
    {
        public ParenthesizedExpressionSyntax(SyntaxToken left, ExpressionSyntax expression, SyntaxToken right)
        {
            Left = left;
            Right = right;
            Expression = expression;
        }

        public SyntaxToken Left { get; }
        public SyntaxToken Right { get; }
        public ExpressionSyntax Expression { get; }

        public override SyntaxKind Kind => SyntaxKind.ParenthesizedExpression;

        public override IEnumerable<SyntaxNode> GetChildren()
        {
            yield return Left;
            yield return Expression;
            yield return Right;
        }
    }
}