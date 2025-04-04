namespace Minsk.CodeAnalysis
{
    internal static class SyntaxFacts
    {
        public static int GetBinaryOperatorPrecedence(this SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.PlusToken:
                case SyntaxKind.MinusToken:
                    return 1;

                case SyntaxKind.SlashToken:
                case SyntaxKind.StarToken:
                    return 2;

                default:
                    return 0;
            }
        }
    }
}