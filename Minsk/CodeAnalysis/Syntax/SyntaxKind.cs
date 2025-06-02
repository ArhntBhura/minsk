namespace Minsk.CodeAnalysis.Syntax
{
    public enum SyntaxKind
    {
        // Tokens
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
        OpenBraceToken,
        CloseBraceToken,
        IdentifierToken,
        BangToken,
        GreaterToken,
        LessToken,
        EqualsToken,
        GreaterorEqualsToken,
        LessorEqualsToken,
        NotEqualsToken,
        EqualsEqualsToken,
        AmpersandAmpersandToken,
        PipePipeToken,

        //Keywords
        TrueKeyword,
        FalseKeyword,
        LetKeyword,
        VarKeyword,

        // Nodes
        CompilationUnit,

        // Statements
        BlockStatement,
        ExpressionStatement,
        VariableDeclaration,

        // Expressions
        LiteralExpression,
        NameExpression,
        AssignmentExpression,
        UnaryExpression,
        BinaryExpression,
        ParenthesizedExpression,
    }
}