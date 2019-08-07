using System;
using System.Collections.Generic;
using System.Text;

namespace B19_Ex02
{
    public class BoardGame
    {
        private int m_Size;
        j
        private char[,] m_BoardGame = null;

        public BoardGame(int size, char coinType)
        {
            m_Size = size;
            m_BoardGame = new char[size, size];
            if (coinType == 'O')
            {
                m_BoardGame[size / 2, size / 2] = coinType;
                m_BoardGame[(size / 2) - 1, (size / 2) - 1] = coinType;
            }
            else
            {
                m_BoardGame[size / 2, (size / 2) - 1] = coinType;
                m_BoardGame[(size / 2) - 1, size / 2] = coinType;
            }
        }

        public BoardGame(int size)
        {
            m_Size = size;
            m_BoardGame = new char[size, size];
        }

        public int size
        {
            get { return m_Size; }

            set { m_Size = value; }
        }

        public char[,] boardGame
        {
            get { return m_BoardGame; }
            set { m_BoardGame = value; }
        }

        public void UpdateBoard(Player i_XPlayer, Player i_OPlayer, List<Coin> i_CoinsToFlip)
        {
            i_XPlayer.playerBoard.FlipCoins(i_XPlayer, i_CoinsToFlip);
            i_OPlayer.playerBoard.FlipCoins(i_OPlayer, i_CoinsToFlip);
            this.BuildBoard(i_XPlayer.playerBoard.boardGame, i_OPlayer.playerBoard.boardGame);
        }

        public int OptionToMove(Coin i_OptionCoin, Player i_Player, BoardGame i_FullBoardGame)
        {
            int coinsToFlip = 0;
            int rowDirection;
            int columDirection;
            int distance;
            bool isEmpty = true;
            Coin tempCoin = new Coin();

            if (!i_FullBoardGame.IsEmptySquare(i_OptionCoin))
            {
                isEmpty = false;
            }

            for (rowDirection = -1; rowDirection <= 1 && isEmpty; rowDirection++)
            {
                for (columDirection = -1; columDirection <= 1; columDirection++)
                {
                    if (!(rowDirection == 0 && columDirection == 0))
                    {
                        distance = 1;
                        tempCoin.row = i_OptionCoin.row + rowDirection;
                        tempCoin.colum = i_OptionCoin.colum + columDirection;

                        while (IsInBoard(tempCoin) && IsRival(tempCoin, i_Player.coinType, i_FullBoardGame))
                        {
                            distance++;
                            tempCoin.row += rowDirection;
                            tempCoin.colum += columDirection;
                        }

                        if (distance > 1 && IsInBoard(tempCoin) && !IsRival(tempCoin, i_Player.coinType, i_FullBoardGame) && !IsEmptySquare(tempCoin))
                        {
                            coinsToFlip += distance - 1;
                        }
                    }
                }
            }

            return coinsToFlip;
        }

        public List<Coin> SquersToFlip(Player i_CurrentPlayer, Coin i_InputCoin, BoardGame i_FullBoardGame)
        {
            List<Coin> o_ListOfSquersToFlip = new List<Coin>(2);

            int coinsToFlip = 0;
            int rowDirection;
            int columDirection;
            int distance;
            int sumCoinsToFlip = 0;
            Coin tempCoin = new Coin();
            Coin coinToFlip;
            for (rowDirection = -1; rowDirection <= 1; rowDirection++)
            {
                for (columDirection = -1; columDirection <= 1; columDirection++)
                {
                    if (!(rowDirection == 0 && columDirection == 0))
                    {
                        distance = 1;
                        tempCoin.row = i_InputCoin.row + rowDirection;
                        tempCoin.colum = i_InputCoin.colum + columDirection;

                        while (IsInBoard(tempCoin) && IsRival(tempCoin, i_CurrentPlayer.coinType, i_FullBoardGame))
                        {
                            distance++;
                            tempCoin.row += rowDirection;
                            tempCoin.colum += columDirection;
                        }

                        if (distance > 1 && IsInBoard(tempCoin) && !IsRival(tempCoin, i_CurrentPlayer.coinType, i_FullBoardGame) && !IsEmptySquare(tempCoin))
                        {
                            coinsToFlip += distance - 1;
                            sumCoinsToFlip += distance - 1;
                            tempCoin.row -= rowDirection;
                            tempCoin.colum -= columDirection;
                            do
                            {
                                coinToFlip = new Coin(tempCoin.row, tempCoin.colum);
                                o_ListOfSquersToFlip.Add(coinToFlip);
                                coinsToFlip--;
                                tempCoin.row -= rowDirection;
                                tempCoin.colum -= columDirection;
                            }
                            while (coinsToFlip > 0);
                        }
                    }
                }
            }

            return o_ListOfSquersToFlip;
        }

        public void FlipCoins(Player i_Player, List<Coin> i_CoinsToFlip)
        {
            int sizeArray = i_CoinsToFlip.Count;
            bool isCurrentPlayer = true;
            foreach (var coin in i_CoinsToFlip)
            {
                if (i_Player.playerBoard.boardGame[coin.row, coin.colum] == '\0')
                {
                    coin.SetSquare(i_Player);
                }
                else
                {
                    coin.CleanSquare(i_Player);
                    isCurrentPlayer = false;
                }
            }

            if (isCurrentPlayer)
            {
                i_Player.numOfCoins += sizeArray + 1;
            }
            else
            {
                i_Player.numOfCoins -= sizeArray;
            }
        }

        public bool CheckValidCoin(Coin i_Coin, Player i_Player)
        {
            bool o_Validity = false;

            foreach (var coin in i_Player.possibleCoin)
            {
                if (i_Coin.IsEqualPoints(coin))
                {
                    o_Validity = true;
                }
            }

            return o_Validity;
        }

        public bool IsInBoard(Coin i_Coin)
        {
            bool o_IsInBoard = true;

            if (i_Coin.row < 0 || i_Coin.colum < 0 || i_Coin.row >= m_Size || i_Coin.colum >= m_Size)
            {
                o_IsInBoard = false;
            }

            return o_IsInBoard;
        }

        public bool IsEmptySquare(Coin i_Coin)
        {
            return m_BoardGame[i_Coin.row, i_Coin.colum] == '\0';
        }

        public bool IsRival(Coin i_Coin, char i_CurrentPlayer, BoardGame i_FullBoard) // הורדתי סוגריים
        {
            return i_FullBoard.m_BoardGame[i_Coin.row, i_Coin.colum] != i_CurrentPlayer && !i_FullBoard.IsEmptySquare(i_Coin);
        }

        public void ClearBoard()
        {
            for (int i = 0; i < m_Size; i++)
            {
                for (int j = 0; j < m_Size; j++)
                {
                    m_BoardGame[i, j] = '\0';
                }
            }
        }

        public bool IsFull()
        {
            bool o_IsFull = true;

            for (int i = 0; i < m_Size && o_IsFull == true; i++)
            {
                for (int j = 0; j < m_Size && o_IsFull == true; j++)
                {
                    if (m_BoardGame[i, j] == '\0')
                    {
                        o_IsFull = false;
                    }
                }
            }

            return o_IsFull;
        }

        public void BuildBoard(char[,] i_BoardPlayer1, char[,] i_BoardPlayer2)
        {
            ClearBoard();
            for (int i = 0; i < m_Size; i++)
            {
                for (int j = 0; j < m_Size; j++)
                {
                    if (i_BoardPlayer1[i, j] != '\0')
                    {
                        m_BoardGame[i, j] = i_BoardPlayer1[i, j];
                    }
                    else if (i_BoardPlayer2[i, j] != '\0')
                    {
                        m_BoardGame[i, j] = i_BoardPlayer2[i, j];
                    }
                }
            }
        }
    }
}
