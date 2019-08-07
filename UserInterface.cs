using System;
using System.Collections.Generic;
using System.Text;

namespace B19_Ex02
{
    public static class UserInterface
    {
        public static void WelcomeMassage()
        {
            Console.WriteLine("Welcome To Otelo game!!! \nPress Q anytime for exit");
        }

        public static string GetBoardSize()
        {
            Console.WriteLine("Please choose board size: press 6 for 6x6 or 8 for 8x8");
            return Console.ReadLine();
        }

        public static void StartMassage(Player i_XPlayer, Player i_OPlayer)
        {
            Console.WriteLine(i_XPlayer.name + " is X, " + i_OPlayer.name + " is O");
            Console.WriteLine("Good Luck!\n" + i_XPlayer.name + " is starting");
        }

        public static void TieMassage()
        {
            Console.WriteLine("It's a tie!");
        }

        public static void WinnerName(Player i_Winner)
        {
            Console.WriteLine("The winner is: " + i_Winner.name);
        }

        public static string PrintScoreAndEndGame(Player i_XPlayer, Player i_OPlayer)
        {
            Console.WriteLine(i_XPlayer.name + " score: " + i_XPlayer.numOfCoins.ToString());
            Console.WriteLine(i_OPlayer.name + " score: " + i_OPlayer.numOfCoins.ToString());
            Console.WriteLine("To exit press Q, to play again press S");
            return Console.ReadLine();
        }

        public static string GetCoinFromUser()
        {
            Console.WriteLine("Please enter place you want to put your coin, as the follow format: row,colum");
            return Console.ReadLine();
        }

        public static void InvalidMssage()
        {
            Console.WriteLine("Invalid place! Try again");
        }

        public static void InvalidSizeMssage()
        {
            Console.WriteLine("Invalid size! Try again");
        }

        public static void InvalidLogicMssage()
        {
            Console.WriteLine("Invalid input! Try again");
        }

        public static void CantMoveMassage(Player i_Player)
        {
            Console.WriteLine(i_Player.name + " can't move. Switch turn");
        }

        public static string ChooseNumOfPlayers()
        {
            Console.WriteLine("Are you 2 players or 1?");
            return Console.ReadLine();
        }

        public static string GetPlayerName()
        {
            Console.WriteLine("What is your name?");
            return Console.ReadLine();
        }

        public static string GetSecondPlayerName()
        {
            Console.WriteLine("What is second player name?");
            return Console.ReadLine();
        }

        public static void PrintBoard(BoardGame i_FullBoardGame)
        {
            Console.Clear();
            Console.Write(" ");
            StringBuilder rowToPrint = new StringBuilder();

            for (int i = 1; i <= i_FullBoardGame.size; i++)
            {
                rowToPrint.Append("   ");
                rowToPrint.Append(i);
            }

            Console.WriteLine(rowToPrint);
            rowToPrint.Remove(0, rowToPrint.Length);
            rowToPrint.Append("   ");

            for (int i = 0; i < i_FullBoardGame.size * 4; i++)
            {
                rowToPrint.Append("=");
            }

            Console.WriteLine(rowToPrint);
            rowToPrint.Remove(0, rowToPrint.Length);

            for (int i = 0; i < i_FullBoardGame.size; i++)
            {
                rowToPrint.Append(i + 1);
                rowToPrint.Append(" | ");

                for (int j = 0; j < i_FullBoardGame.size; j++)
                {
                    if (i_FullBoardGame.boardGame[i, j] == 0)
                    {
                        rowToPrint.Append("  | ");
                    }
                    else
                    {
                        rowToPrint.Append(i_FullBoardGame.boardGame[i, j]);
                        rowToPrint.Append(" | ");
                    }
                }

                Console.WriteLine(rowToPrint);
                rowToPrint.Remove(0, rowToPrint.Length);
                rowToPrint.Append("   ");

                for (int k = 0; k < i_FullBoardGame.size * 4; k++)
                {
                    rowToPrint.Append("=");
                }

                Console.WriteLine(rowToPrint);
                rowToPrint.Remove(0, rowToPrint.Length);
            }
        }
    }
}