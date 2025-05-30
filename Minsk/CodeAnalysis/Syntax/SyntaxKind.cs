namespace Minsk.CodeAnalysis.Syntax
{
    public enum SyntaxKind
    {
        //Tokens
        BadToken,
        EndOfFileToken,
        WhitespaceToken,
        NumberToken,
        PlusToken,
        MinusToken,
        StarToken,
        SlashToken,
        OpenParenthesisToken,
        CloseParenthesisToken,
        IdentifierToken,
        BangToken,
        EqualsToken,
        NotEqualsToken,
        EqualsEqualsToken,
        AmpersandAmpersandToken,
        PipePipeToken,

        //Keywords
        TrueKeyword,
        FalseKeyword,

        // Nodes
        CompilationUnit,

        //Expressions
        LiteralExpression,
        NameExpression,
        AssignmentExpression,
        UnaryExpression,
        BinaryExpression,
        ParenthesizedExpression,
    }
}