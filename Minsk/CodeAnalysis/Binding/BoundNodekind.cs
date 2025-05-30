namespace Minsk.CodeAnalysis.Binding
{
    internal enum BoundNodekind
    {
        // Statements
        BlockStatement,
        ExpressionStatement,
        VariableDeclaration,

        // Expressions
        UnaryExpression,
        LiteralExpression,
        BinaryExpression,
        VariableExpression,
        AssignmentExpression,
    }

}