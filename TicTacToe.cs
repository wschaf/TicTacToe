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
    class TicTacToe
    {
        private char[,] board;      //  Board is an array that stores the status of the board.
        private bool victory;       //  Victory is true if a player has won.
        private char victor;        //  Victor is either 'X', 'O', or ' '.

        //  Default constructor, populates board with '-'.
        public TicTacToe()
        {
            //  Board is an array that stores the status of the board.
            board = new char [3, 3] {   { '-' , '-' , '-' },
                                        { '-' , '-' , '-' },
                                        { '-' , '-' , '-' }
                                    };
            //  Victory is true if a player has won.
            victory = false;

            //  Victor is either 'X', 'O', or ' '.
            victor = ' ';
    }

        //  Initialized board with input char.
        public TicTacToe(char input)
        {
            //  Board is an array that stores the status of the board.
            board = new char[3, 3] {    { input , input , input },
                                        { input , input , input },
                                        { input , input , input }
                                   };

            //  Victory is true if a player has won.
            victory = false;

            //  Victor is either 'X', 'O', or ' '.
            victor = ' ';
        }

        //  Sets the location on the board at (x, y) with char z.
        public void SetSpot(int x, int y, char z)
        {
            board[x, y] = z;
        }

        //  Returns the char stored on the board at location (x, y).
        public char GetSpot(int x, int y)
        {
            return board[x, y];
        }

        //  Sets victory condition to input.
        public void SetVictory(bool input)
        {
            victory = input;
        }

        //  Returns the boolean victory conditon.
        public bool GetVictory()
        {
            return victory;
        }

        //  Sets the victorious char player. Should be 'X' or 'O'.
        public void SetVictor(char player)
        {
            victor = player;
        }

        //  Returns the char player who is victorious. Should be 'X' or 'O'.
        public char GetVictor()
        {
            return victor;
        }

        //  Prints a better looking version of the board.
        public void PrintBoard()
        {
            Console.Clear();
            Console.WriteLine("+-----------+");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"| {board[i, j]} ");
                }
                Console.Write("|\n");
                Console.WriteLine("+-----------+");
            }

        }
        
        public void Move(char player)
        {
            bool error = false;
            int row = 0;
            int column = 0;
            Console.WriteLine($"Team {player}, enter spot to place an {player}: ");
            do
            {
                do      //  X Coordinate
                {
                    Console.WriteLine("Row: ");
                    try
                    {
                        row = int.Parse(Console.ReadLine());
                        error = false;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid input.");
                        error = true;
                    }

                } while (error);

                do      //  Y Coordinate
                {
                    Console.WriteLine("Column: ");
                    try
                    {
                        column = int.Parse(Console.ReadLine());
                        error = false;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid input.");
                        error = true;
                    }

                } while (error);

                //  Check if space is occupied
                if ((GetSpot(row, column) != ' ') && (GetSpot(row, column) != '-'))
                {
                    Console.WriteLine($"The spot at ({row}, {column}) already has an {GetSpot(row, column)} in it.");
                    error = true;
                }

            } while (error);

            //  Populate the spot with the new character.
            SetSpot(row, column, player);

            //  Check to see if this was the winning move.
            VictoryCheck();
        }

        //  Checks to see if one of the conditons for victory has been met.
        //  Sets victory to true if conditons met.
        public char VictoryCheck()
        {
            SetVictory(true);
            
            //  Check if X has any in a row of three.
            if ((GetSpot(0, 0) == 'X') && ((GetSpot(0, 1) == 'X') && (GetSpot(0, 2) == 'X'))) { SetVictor('X'); return 'X'; }
            if ((GetSpot(1, 0) == 'X') && ((GetSpot(1, 1) == 'X') && (GetSpot(1, 2) == 'X'))) { SetVictor('X'); return 'X'; }
            if ((GetSpot(2, 0) == 'X') && ((GetSpot(2, 1) == 'X') && (GetSpot(2, 2) == 'X'))) { SetVictor('X'); return 'X'; }
            if ((GetSpot(0, 0) == 'X') && ((GetSpot(1, 0) == 'X') && (GetSpot(2, 0) == 'X'))) { SetVictor('X'); return 'X'; }
            if ((GetSpot(0, 1) == 'X') && ((GetSpot(1, 1) == 'X') && (GetSpot(2, 1) == 'X'))) { SetVictor('X'); return 'X'; }
            if ((GetSpot(0, 2) == 'X') && ((GetSpot(1, 2) == 'X') && (GetSpot(2, 2) == 'X'))) { SetVictor('X'); return 'X'; }
            if ((GetSpot(0, 0) == 'X') && ((GetSpot(1, 1) == 'X') && (GetSpot(2, 2) == 'X'))) { SetVictor('X'); return 'X'; }
            if ((GetSpot(2, 0) == 'X') && ((GetSpot(1, 1) == 'X') && (GetSpot(0, 2) == 'X'))) { SetVictor('X'); return 'X'; }

            //  Check if O has any in a row of three.
            if ((GetSpot(0, 0) == 'O') && ((GetSpot(0, 1) == 'O') && (GetSpot(0, 2) == 'O'))) { SetVictor('O'); return 'O'; }
            if ((GetSpot(1, 0) == 'O') && ((GetSpot(1, 1) == 'O') && (GetSpot(1, 2) == 'O'))) { SetVictor('O'); return 'O'; }
            if ((GetSpot(2, 0) == 'O') && ((GetSpot(2, 1) == 'O') && (GetSpot(2, 2) == 'O'))) { SetVictor('O'); return 'O'; }
            if ((GetSpot(0, 0) == 'O') && ((GetSpot(1, 0) == 'O') && (GetSpot(2, 0) == 'O'))) { SetVictor('O'); return 'O'; }
            if ((GetSpot(0, 1) == 'O') && ((GetSpot(1, 1) == 'O') && (GetSpot(2, 1) == 'O'))) { SetVictor('O'); return 'O'; }
            if ((GetSpot(0, 2) == 'O') && ((GetSpot(1, 2) == 'O') && (GetSpot(2, 2) == 'O'))) { SetVictor('O'); return 'O'; }
            if ((GetSpot(0, 0) == 'O') && ((GetSpot(1, 1) == 'O') && (GetSpot(2, 2) == 'O'))) { SetVictor('O'); return 'O'; }
            if ((GetSpot(2, 0) == 'O') && ((GetSpot(1, 1) == 'O') && (GetSpot(0, 2) == 'O'))) { SetVictor('O'); return 'O'; }

            //  If the entire board is covered, the game is a draw.
            if (
                (GetSpot(0, 0) != ' ') && (GetSpot(0, 0) != '-') &&
                (GetSpot(0, 1) != ' ') && (GetSpot(0, 1) != '-') &&
                (GetSpot(0, 2) != ' ') && (GetSpot(0, 2) != '-') &&
                (GetSpot(1, 0) != ' ') && (GetSpot(1, 0) != '-') &&
                (GetSpot(1, 1) != ' ') && (GetSpot(1, 1) != '-') &&
                (GetSpot(1, 2) != ' ') && (GetSpot(1, 2) != '-') &&
                (GetSpot(2, 0) != ' ') && (GetSpot(2, 0) != '-') &&
                (GetSpot(2, 1) != ' ') && (GetSpot(2, 1) != '-') &&
                (GetSpot(2, 2) != ' ') && (GetSpot(2, 2) != '-'))
            {
                SetVictory(true);
                return 'D';
            }

            //  If none of the above conditions are met, the game is not yet over.
            else
            {
                SetVictory(false);
                return 'N';
            }
        }
    }
}