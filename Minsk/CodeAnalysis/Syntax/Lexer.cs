using Minsk.CodeAnalysis.Text;

namespace Minsk.CodeAnalysis.Syntax
{
    internal sealed class Lexer
    {
        private readonly DiagnosticBag _diagnostics = new DiagnosticBag();
        private readonly SourceText _text;

        private int _start;
        private SyntaxKind _kind;
        private int _position;
        private object _value;

        public Lexer(SourceText text)
        {
            _text = text;
        }
        public DiagnosticBag Diagnostics => _diagnostics;
        private char Current => Peek(0);
        private char LookAhead => Peek(1);

        private char Peek(int offset)
        {
            int index = _position + offset;
            if (index >= _text.Length)
                return '\0';
            return _text[index];
        }

        public SyntaxToken Lex()
        {
            _start = _position;
            _kind = SyntaxKind.BadToken;
            _value = null;

            switch (Current)
            {
                case '\0':
                    _kind = SyntaxKind.EndOfFileToken;
                    break;
                case '+':
                    _position++;
                    _kind = SyntaxKind.PlusToken;
                    break;
                case '-':
                    _position++;
                    _kind = SyntaxKind.MinusToken;
                    break;
                case '*':
                    _position++;
                    _kind = SyntaxKind.StarToken;
                    break;
                case '/':
                    _position++;
                    _kind = SyntaxKind.SlashToken;
                    break;
                case '~':
                    _position++;
                    _kind = SyntaxKind.TildeToken;
                    break;
                case '^':
                    _position++;
                    _kind = SyntaxKind.HatToken;
                    break;
                case '(':
                    _position++;
                    _kind = SyntaxKind.OpenParenthesisToken;
                    break;
                case ')':
                    _position++;
                    _kind = SyntaxKind.CloseParenthesisToken;
                    break;
                case '{':
                    _position++;
                    _kind = SyntaxKind.OpenBraceToken;
                    break;
                case '}':
                    _position++;
                    _kind = SyntaxKind.CloseBraceToken;
                    break;
                case '!':
                    _position++;
                    if (Current != '=')
                    {
                        _kind = SyntaxKind.BangToken;
                    }
                    else
                    {
                        _position++;
                        _kind = SyntaxKind.NotEqualsToken;
                    }
                    break;
                case '>':
                    _position++;
                    if (Current != '=')
                    {
                        _kind = SyntaxKind.GreaterToken;
                    }
                    else
                    {
                        _position++;
                        _kind = SyntaxKind.GreaterorEqualsToken;
                    }
                    break;
                case '<':
                    _position++;
                    if (Current != '=')
                    {
                        _kind = SyntaxKind.LessToken;
                    }
                    else
                    {
                        _position++;
                        _kind = SyntaxKind.LessorEqualsToken;
                    }
                    break;
                case '&':
                    _position++;
                    if (Current != '&')
                    {
                        _kind = SyntaxKind.AmpersandToken;
                    }
                    else
                    {
                        _position++;
                        _kind = SyntaxKind.AmpersandAmpersandToken;
                    }
                    break;
                case '|':
                    _position++;
                    if (Current != '|')
                    {
                        _kind = SyntaxKind.PipeToken;
                    }
                    else
                    {
                        _position++;
                        _kind = SyntaxKind.PipePipeToken;
                    }
                    break;
                case '=':
                    _position++;
                    if (Current != '=')
                    {
                        _kind = SyntaxKind.EqualsToken;
                    }
                    else
                    {
                        _position++;
                        _kind = SyntaxKind.EqualsEqualsToken;
                    }
                    break;
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    ReadNumberToken();
                    break;
                case ' ':
                case '\t':
                case '\r':
                case '\n':
                    ReadWhiteSpace();
                    break;
                default:
                    if (char.IsLetter(Current))
                    {
                        ReadIdentifierOrKeyword();
                    }
                    else if (char.IsWhiteSpace(Current))
                    {
                        ReadWhiteSpace();
                    }
                    else
                    {
                        _diagnostics.ReportBadCharacter(_position, Current);
                        _position++;
                    }
                    break;
            }

            var length = _position - _start;
            var text = SyntaxFacts.GetText(_kind);
            if (text == null)
                text = _text.ToString(_start, length);

            return new SyntaxToken(_kind, _start, text, _value);
        }

        private void ReadIdentifierOrKeyword()
        {
            while (char.IsLetter(Current))
                _position++;
            var length = _position - _start;
            var text = _text.ToString(_start, length);
            _kind = SyntaxFacts.GetKeywordKind(text);
        }

        private void ReadNumberToken()
        {
            while (char.IsDigit(Current))
                _position++;
            var length = _position - _start;
            var text = _text.ToString(_start, length);
            if (!int.TryParse(text, out var value))
                _diagnostics.ReportInvalidNumber(new TextSpan(_start, length), text, typeof(int));

            _value = value;
            _kind = SyntaxKind.NumberToken;
        }

        private void ReadWhiteSpace()
        {
            while (char.IsWhiteSpace(Current))
                _position++;
            _kind = SyntaxKind.WhitespaceToken;
        }
    }
}