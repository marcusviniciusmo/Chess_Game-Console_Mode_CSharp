using JogoDeXadrezModoConsoleCSharp.tabuleiro;
using JogoDeXadrezModoConsoleCSharp.Xadrez;
using System;

namespace JogoDeXadrezModoConsoleCSharp
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write($" {8 - i}   ");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    ImprimirPeca(tabuleiro.Peca(i, j));
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("     A B C D E F G H");
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGreen;

            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write($" {8 - i}   ");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }

                    ImprimirPeca(tabuleiro.Peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("     A B C D E F G H");
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string str = Console.ReadLine();
            char coluna = str[0];
            int linha = int.Parse(str[1] + "");

            return new PosicaoXadrez(coluna, linha);
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor auxPecaCor = Console.ForegroundColor;
                    ConsoleColor auxFundoCor = Console.BackgroundColor;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = auxPecaCor;
                    Console.BackgroundColor = auxFundoCor;
                }

                Console.Write(" ");
            }
        }
    }
}
