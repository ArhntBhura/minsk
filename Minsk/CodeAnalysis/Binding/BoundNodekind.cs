namespace Minsk.CodeAnalysis.Binding
{
    internal enum BoundNodekind
    {
        // Statements
        BlockStatement,
        VariableDeclaration,
        IfStatement,
        LabelStatement,
        GotoStatement,
        ConditionalGotoStatement,
        WhileStatement,
        ForStatement,
        ExpressionStatement,

        // Expressions
        UnaryExpression,
        LiteralExpression,
        BinaryExpression,
        VariableExpression,
        AssignmentExpression,
    }

}