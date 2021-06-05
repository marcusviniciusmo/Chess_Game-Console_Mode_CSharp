using JogoDeXadrezModoConsoleCSharp.tabuleiro;
using JogoDeXadrezModoConsoleCSharp.Xadrez;
using System;
using System.Collections.Generic;

namespace JogoDeXadrezModoConsoleCSharp
{
    class Tela
    {
        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            ImprimirTabuleiro(partida.Tabuleiro);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine($"Turno: {partida.Turno}");

            if (!partida.Terminada)
            {
                Console.WriteLine($"Aguardando jogada: {partida.JogadorAtual}");

                if (partida.Xeque)
                {
                    Console.WriteLine("XEQUE!");
                }
            }
            else
            {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine($"Vencedor: {partida.JogadorAtual}");
            }
        }

        public static void AlterarCorConsole(ConsoleColor corPeca, ConsoleColor corFundo)
        {
            Console.ForegroundColor = corPeca;
            Console.BackgroundColor = corFundo;
        }

        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Branca: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            AlterarCorConsole(ConsoleColor.Black, ConsoleColor.Gray);
            
            Console.Write("Pretas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            AlterarCorConsole(ConsoleColor.Gray, ConsoleColor.Black);
        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");

            foreach(Peca peca in conjunto)
            {
                Console.Write($"{peca}, ");
            }
            Console.WriteLine("]");
        }

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
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write($" {8 - i}   ");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        AlterarCorConsole(ConsoleColor.Black, ConsoleColor.Green);
                    }
                    else
                    {
                        AlterarCorConsole(ConsoleColor.Gray, ConsoleColor.Black);
                    }

                    ImprimirPeca(tabuleiro.Peca(i, j));
                    AlterarCorConsole(ConsoleColor.Gray, ConsoleColor.Black);
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
                    AlterarCorConsole(ConsoleColor.Black, ConsoleColor.Yellow);
                    Console.Write(peca);
                    AlterarCorConsole(ConsoleColor.Gray, ConsoleColor.Black);
                }

                Console.Write(" ");
            }
        }
    }
}
