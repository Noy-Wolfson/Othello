using System;
using System.Collections.Generic;
using System.Text;

namespace B19_Ex02
{
    public enum ePlayerType
    {
        HUMAN = 0,
        COMPUTER = 1,
    }

    public class Player
    {
        private string m_Name;
        private char m_CoinType;
        private ePlayerType m_PlayerType;
        private BoardGame m_PlayerBoard;
        private int m_NumOfCoins;
        private List<Coin> m_PossibleCoin = new List<Coin>(2);

        public Player(char coinType, int boardSize)
        {
            m_Name = "Computer";
            m_NumOfCoins = 2;
            m_CoinType = coinType;
            m_PlayerBoard = new BoardGame(boardSize, m_CoinType);
            playerType = ePlayerType.COMPUTER;
        }

        public Player(string name, char coinType, int boardSize)
        {
            m_Name = name;
            m_NumOfCoins = 2;
            m_CoinType = coinType;
            m_PlayerBoard = new BoardGame(boardSize, m_CoinType);
            playerType = ePlayerType.HUMAN;
        }

        public string name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public BoardGame playerBoard
        {
            get { return m_PlayerBoard; }
            set { m_PlayerBoard = value; }
        }

        public ePlayerType playerType
        {
            get { return m_PlayerType; }
            set { m_PlayerType = value; }
        }

        public char coinType
        {
            get { return m_CoinType; }
            set { m_CoinType = value; }
        }

        public int numOfCoins
        {
            get { return m_NumOfCoins; }
            set { m_NumOfCoins = value; }
        }

        public List<Coin> possibleCoin
        {
            get { return m_PossibleCoin; }
            set { m_PossibleCoin = value; }
        }

        public bool CanMove(BoardGame i_FullBoardGame)
        {
            Coin optionCoin = new Coin();
            bool o_CanMove = false;

            for (int i = 0; i < this.m_PlayerBoard.size && o_CanMove == false; i++)
            {
                optionCoin.row = i;

                for (int j = 0; j < this.m_PlayerBoard.size && o_CanMove == false; j++)
                {
                    optionCoin.colum = j;
                    if (this.m_PlayerBoard.OptionToMove(optionCoin, this, i_FullBoardGame) > 0)
                    {
                        o_CanMove = true;
                    }
                }
            }

            return o_CanMove;
        }

        public void CreatePossibleCoinToMove(BoardGame i_FullBoardGame)
        {
            m_PossibleCoin.Clear();
            Coin coinToCheck = new Coin();
            Coin optionCoin;
            for (int i = 0; i < this.m_PlayerBoard.size; i++)
            {
                coinToCheck.row = i;

                for (int j = 0; j < this.m_PlayerBoard.size; j++)
                {
                    coinToCheck.colum = j;
                    if (this.m_PlayerBoard.OptionToMove(coinToCheck, this, i_FullBoardGame) > 0)
                    {
                        optionCoin = new Coin(coinToCheck.row, coinToCheck.colum);
                        m_PossibleCoin.Add(optionCoin);
                    }
                }
            }
        }
    }
}
