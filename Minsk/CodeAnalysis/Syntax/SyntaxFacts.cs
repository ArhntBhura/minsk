using System.Reflection.Metadata.Ecma335;

namespace Minsk.CodeAnalysis.Syntax
{
    public static class SyntaxFacts
    {
        public static int GetUnaryOperatorPrecedence(this SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.PlusToken:
                case SyntaxKind.MinusToken:
                case SyntaxKind.BangToken:
                case SyntaxKind.TildeToken:
                    return 6;
                default:
                    return 0;
            }
        }

        public static int GetBinaryOperatorPrecedence(this SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.PlusToken:
                case SyntaxKind.MinusToken:
                    return 5;

                case SyntaxKind.SlashToken:
                case SyntaxKind.StarToken:
                    return 4;

                case SyntaxKind.EqualsEqualsToken:
                case SyntaxKind.NotEqualsToken:
                case SyntaxKind.LessToken:
                case SyntaxKind.GreaterToken:
                case SyntaxKind.LessorEqualsToken:
                case SyntaxKind.GreaterorEqualsToken:
                    return 3;

                case SyntaxKind.AmpersandToken:
                case SyntaxKind.AmpersandAmpersandToken:
                    return 2;

                case SyntaxKind.PipeToken:
                case SyntaxKind.PipePipeToken:
                case SyntaxKind.HatToken:
                    return 1;

                default:
                    return 0;
            }
        }

        public static IEnumerable<SyntaxKind> GetUnaryOperatorKinds()
        {
            var kinds = (SyntaxKind[])Enum.GetValues(typeof(SyntaxKind));
            foreach (var kind in kinds)
            {
                if (GetUnaryOperatorPrecedence(kind) > 0)
                    yield return kind;
            }
        }

        public static IEnumerable<SyntaxKind> GetBinaryOperatorKinds()
        {
            var kinds = (SyntaxKind[])Enum.GetValues(typeof(SyntaxKind));
            foreach (var kind in kinds)
            {
                if (GetBinaryOperatorPrecedence(kind) > 0)
                    yield return kind;
            }
        }

        public static SyntaxKind GetKeywordKind(string text)
        {
            switch (text)
            {
                case "true":
                    return SyntaxKind.TrueKeyword;
                case "false":
                    return SyntaxKind.FalseKeyword;
                case "if":
                    return SyntaxKind.IfKeyword;
                case "else":
                    return SyntaxKind.elseKeyword;
                case "let":
                    return SyntaxKind.LetKeyword;
                case "var":
                    return SyntaxKind.VarKeyword;
                case "to":
                    return SyntaxKind.ToKeyword;
                case "while":
                    return SyntaxKind.WhileKeyword;
                case "for":
                    return SyntaxKind.ForKeyword;
                default:
                    return SyntaxKind.IdentifierToken;
            }
        }

        public static string GetText(SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.PlusToken:
                    return "+";
                case SyntaxKind.MinusToken:
                    return "-";
                case SyntaxKind.StarToken:
                    return "*";
                case SyntaxKind.SlashToken:
                    return "/";
                case SyntaxKind.TildeToken:
                    return "~";
                case SyntaxKind.HatToken:
                    return "^";
                case SyntaxKind.OpenParenthesisToken:
                    return "(";
                case SyntaxKind.CloseParenthesisToken:
                    return ")";
                case SyntaxKind.OpenBraceToken:
                    return "{";
                case SyntaxKind.CloseBraceToken:
                    return "}";
                case SyntaxKind.BangToken:
                    return "!";
                case SyntaxKind.GreaterToken:
                    return ">";
                case SyntaxKind.LessToken:
                    return "<";
                case SyntaxKind.EqualsToken:
                    return "=";
                case SyntaxKind.AmpersandToken:
                    return "&";
                case SyntaxKind.PipeToken:
                    return "|";
                case SyntaxKind.NotEqualsToken:
                    return "!=";
                case SyntaxKind.GreaterorEqualsToken:
                    return ">=";
                case SyntaxKind.LessorEqualsToken:
                    return "<=";
                case SyntaxKind.EqualsEqualsToken:
                    return "==";
                case SyntaxKind.AmpersandAmpersandToken:
                    return "&&";
                case SyntaxKind.PipePipeToken:
                    return "||";
                case SyntaxKind.TrueKeyword:
                    return "true";
                case SyntaxKind.FalseKeyword:
                    return "false";
                case SyntaxKind.IfKeyword:
                    return "if";
                case SyntaxKind.elseKeyword:
                    return "else";
                case SyntaxKind.LetKeyword:
                    return "let";
                case SyntaxKind.VarKeyword:
                    return "var";
                case SyntaxKind.ToKeyword:
                    return "to";
                case SyntaxKind.WhileKeyword:
                    return "while";
                case SyntaxKind.ForKeyword:
                    return "for";
                default:
                    return null;
            }
        }
    }
}