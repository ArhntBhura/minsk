namespace Minsk.CodeAnalysis.Binding
{
    internal enum BoundNodekind
    {
        // Statements
        BlockStatement,
        ExpressionStatement,

        // Expressions
        UnaryExpression,
        LiteralExpression,
        BinaryExpression,
        VariableExpression,
        AssignmentExpression,
    }

}