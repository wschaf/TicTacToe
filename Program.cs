/*
 * William Schaffer
 * MSSA CAD 1 ISTA 220
 * EX 10 A Tic Tac Toe
 * 02 May 2020
 * 
 * Implement Tic Tac Toe using a 3 x 3 char array.
 * 
 * 
*/


using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Functionality is performed by the Tic Tac Toe class.
            TicTacToe main = new TicTacToe();

            //  Functionality for playing the game.
            do
            {
                main.PrintBoard();
                main.Move('X');
                main.PrintBoard();
                if (main.GetVictory()) break;
                main.Move('O');
            } while (!main.GetVictory());

            main.PrintBoard();

            //  Output the winning player.
            switch (main.GetVictor())
            {
                case 'X':
                    Console.WriteLine("X Wins.");
                    break;

                case 'O':
                    Console.WriteLine("O Wins.");
                    break;

                default:
                    Console.WriteLine("Draw.");
                    break;
            }
        }
    }
}
