using JogoDeXadrezModoConsoleCSharp.tabuleiro;
using System;

namespace JogoDeXadrezModoConsoleCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tabuleiro = new Tabuleiro(8, 8);

            Tela.ImprimirTabuleiro(tabuleiro);

            Console.ReadLine();
        }
    }
}
