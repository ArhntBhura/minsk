namespace Minsk.CodeAnalysis.Syntax
{
    public sealed class NameExpressionSyntax : ExpressionSyntax
    {
        public NameExpressionSyntax(SyntaxToken identiferToken)
        {
            IdentiferToken = identiferToken;
        }

        public override SyntaxKind Kind => SyntaxKind.NameExpression;
        public SyntaxToken IdentiferToken { get; }

        public override IEnumerable<SyntaxNode> GetChildren()
        {
            yield return IdentiferToken;
        }
    }
}