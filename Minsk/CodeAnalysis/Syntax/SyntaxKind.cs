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
        IfKeyword,
        elseKeyword,
        LetKeyword,
        VarKeyword,

        // Nodes
        CompilationUnit,
        ElseClause,

        // Statements
        BlockStatement,
        VariableDeclaration,
        IfStatement,
        ExpressionStatement,

        // Expressions
        LiteralExpression,
        NameExpression,
        AssignmentExpression,
        UnaryExpression,
        BinaryExpression,
        ParenthesizedExpression,
    }
}