namespace Minsk.CodeAnalysis.Syntax
{
    public sealed class ParenthesizedExpressionSyntax : ExpressionSyntax
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
    }
}