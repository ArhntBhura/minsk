using System.Collections.Immutable;

namespace Minsk.CodeAnalysis.Binding
{
    internal sealed class BoundBlockStatement : BoundStatement
    {
        public BoundBlockStatement(ImmutableArray<BoundStatement> statements)
        {
            Statements = statements;
        }

        public override BoundNodekind Kind => BoundNodekind.BlockStatement;
        public ImmutableArray<BoundStatement> Statements { get; }
    }

}