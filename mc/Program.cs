using System.Data.Common;
using System.Runtime.InteropServices.Marshalling;

namespace Minsk
{
    class Program
    {
        private static void Main()
        {
            var repl = new MinskRepl();
            repl.Run();
        }
    }
}