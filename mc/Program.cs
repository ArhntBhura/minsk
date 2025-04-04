﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Microsoft.VisualBasic;
using Minsk.CodeAnalysis;
using Minsk.CodeAnalysis.Syntax;

namespace Minsk
{
    class Program
    {
        private static void Main()
        {
            var showTree = false;
            while (true)
            {
                Console.Write(" >");
                var line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    return;
                }

                if (line == "#showTree")
                {
                    showTree = !showTree;
                    Console.WriteLine(showTree ? "Showing parse Trees" : "Not showing parse Trees");
                    continue;
                }

                if (line == "#clr")
                {
                    Console.Clear();
                    continue;
                }

                var syntaxTree = SyntaxTree.Parse(line);
                if (showTree)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    PrettyPrint(syntaxTree.Root);
                    Console.ResetColor();
                }

                if (!syntaxTree.Diagnostics.Any())
                {
                    var evaluate = new Evaluator(syntaxTree.Root);
                    int ans = evaluate.Evaluate();
                    Console.WriteLine(ans);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    foreach (var diagnostics in syntaxTree.Diagnostics)
                        Console.WriteLine(diagnostics);
                    Console.ResetColor();
                }
            }
        }

        static void PrettyPrint(SyntaxNode node, string indent = " ", bool isLast = true)
        {
            var marker = isLast ? "└──" : "├──";
            Console.Write(indent);
            Console.Write(marker);
            Console.Write(node.Kind);

            if (node is SyntaxToken t && t.Value != null)
            {
                Console.Write(" ");
                Console.Write(t.Value);
            }

            Console.WriteLine();

            indent += isLast ? "   " : "│   ";
            var lastChild = node.GetChildren().LastOrDefault();
            foreach (var child in node.GetChildren())
            {
                PrettyPrint(child, indent, child == lastChild);
            }
        }
    }
}