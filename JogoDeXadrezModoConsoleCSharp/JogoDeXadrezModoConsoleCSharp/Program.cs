using JogoDeXadrezModoConsoleCSharp.tabuleiro;
using JogoDeXadrezModoConsoleCSharp.Xadrez;
using System;

namespace JogoDeXadrezModoConsoleCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Tabuleiro tabuleiro = new Tabuleiro(8, 8);

                //tabuleiro.ColocarPeca(new Torre(Cor.Preta, tabuleiro), new Posicao(0, 0));
                //tabuleiro.ColocarPeca(new Torre(Cor.Preta, tabuleiro), new Posicao(1, 3));
                //tabuleiro.ColocarPeca(new Rei(Cor.Preta, tabuleiro), new Posicao(2, 4));

                //Tela.ImprimirTabuleiro(tabuleiro);
                PosicaoXadrez posicaoXadrez = new PosicaoXadrez('c', 7);
                Console.WriteLine(posicaoXadrez);
                Console.WriteLine(posicaoXadrez.ToPosicao());
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
