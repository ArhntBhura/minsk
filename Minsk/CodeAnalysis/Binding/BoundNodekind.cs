namespace Minsk.CodeAnalysis.Binding
{
    internal enum BoundNodekind
    {
        // Statements
        BlockStatement,
        ExpressionStatement,
        IfStatement,
        VariableDeclaration,

        // Expressions
        UnaryExpression,
        LiteralExpression,
        BinaryExpression,
        VariableExpression,
        AssignmentExpression,
    }

}