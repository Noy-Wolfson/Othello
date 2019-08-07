using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace B19_Ex02
{
    public class Othelo
    {
        private Player m_CurrentPlayer;
        private BoardGame m_FullBoardGame = null;
        private Player m_XPlayer;
        private Player m_OPlayer;

        public char currentPlayer
        {
            get { return m_CurrentPlayer.coinType; }
            set { m_CurrentPlayer.coinType = value; }
        }

        public BoardGame fullBoardGame
        {
            get { return m_FullBoardGame; }
            set { m_FullBoardGame = value; }
        }

        public void Start()
        {
            int size = 0;
            UserInterface.WelcomeMassage();
            string stringSize = UserInterface.GetBoardSize();
            while (!IsValidInput(stringSize, true))
            {
                UserInterface.InvalidSizeMssage();
                stringSize = UserInterface.GetBoardSize();
            }

            size = int.Parse(stringSize);
            InitializePlayers(size);
            m_CurrentPlayer = new Player('X', size);
            m_CurrentPlayer = m_XPlayer;

            m_FullBoardGame = new BoardGame(size);
            m_FullBoardGame.BuildBoard(m_XPlayer.playerBoard.boardGame,  m_OPlayer.playerBoard.boardGame);
            UserInterface.PrintBoard(m_FullBoardGame);
            UserInterface.StartMassage(m_XPlayer, m_OPlayer);
            Game(m_XPlayer, m_OPlayer);
        }

        public void EndGame()
        {
            Environment.Exit(0);
        }

        public void GameOver()
        {
            Player winner;
            if (m_OPlayer.numOfCoins < m_XPlayer.numOfCoins)
            {
                winner = m_XPlayer;
            }
            else if (m_OPlayer.numOfCoins > m_XPlayer.numOfCoins)
            {
                winner = m_OPlayer;
            }
            else
            {
                winner = null;
                UserInterface.TieMassage();
            }

            if (winner != null)
            {
                UserInterface.WinnerName(winner);
            }

            string continueGame = UserInterface.PrintScoreAndEndGame(m_XPlayer, m_OPlayer);
            if (continueGame == "Q" || continueGame == "q")
            {
                EndGame();
            }
            else if (continueGame == "S" || continueGame == "s")
            {
                Start();
            }
        }

        public void Game(Player i_XPlayer, Player i_OPlayer)
        {
            Coin coin = new Coin();
            List<Coin> coinsToFlip = new List<Coin>(2);
            bool validCoin;
            string inputPlayer;
            Random computerChoosing = new Random();

            if (m_CurrentPlayer.playerType == ePlayerType.HUMAN)
            {
                inputPlayer = UserInterface.GetCoinFromUser();
            }
            else
            {
                int numOfPossibleCoins = m_CurrentPlayer.possibleCoin.Count;
                coin = m_CurrentPlayer.possibleCoin[computerChoosing.Next(0, numOfPossibleCoins)];
                inputPlayer = null;
            }

            while (!(inputPlayer == "Q" || inputPlayer == "q"))
            {
                m_CurrentPlayer.CreatePossibleCoinToMove(m_FullBoardGame);

                if (!m_CurrentPlayer.CanMove(m_FullBoardGame))
                {
                    SwitchTurn(m_CurrentPlayer);
                    Game(i_XPlayer, i_OPlayer);
                }

                if (m_CurrentPlayer.playerType == ePlayerType.HUMAN)
                {
                    if (IsValidInput(inputPlayer, false))
                    {
                        coin.row = int.Parse(inputPlayer[0].ToString()) - 1;
                        coin.colum = int.Parse(inputPlayer[2].ToString()) - 1;
                        validCoin = m_FullBoardGame.CheckValidCoin(coin, m_CurrentPlayer);
                        if (!validCoin)
                        {
                            UserInterface.InvalidMssage();
                            Game(m_XPlayer, m_OPlayer);
                        }
                    }
                    else
                    {
                        UserInterface.InvalidLogicMssage();
                        Game(m_XPlayer, m_OPlayer);
                    }
                }

                coin.SetSquare(m_CurrentPlayer);
                coinsToFlip = m_CurrentPlayer.playerBoard.SquersToFlip(m_CurrentPlayer, coin, m_FullBoardGame);
                m_FullBoardGame.UpdateBoard(i_XPlayer, i_OPlayer, coinsToFlip);
                if (m_CurrentPlayer.playerType == ePlayerType.COMPUTER)
                {
                    Thread.Sleep(1500);
                }

                UserInterface.PrintBoard(m_FullBoardGame);
                if (m_FullBoardGame.IsFull() || !(i_OPlayer.CanMove(m_FullBoardGame) || i_XPlayer.CanMove(m_FullBoardGame)))
                {
                    GameOver();
                }

                SwitchTurn(m_CurrentPlayer);
                m_CurrentPlayer.CreatePossibleCoinToMove(m_FullBoardGame);

                if (m_CurrentPlayer.CanMove(m_FullBoardGame))
                {
                    if (m_CurrentPlayer.playerType == ePlayerType.HUMAN)
                    {
                        inputPlayer = UserInterface.GetCoinFromUser();
                    }
                    else
                    {
                        int numOfPossibleCoins = m_CurrentPlayer.possibleCoin.Count;
                        coin = m_CurrentPlayer.possibleCoin[computerChoosing.Next(0, numOfPossibleCoins)];
                        inputPlayer = null;
                    }
                }
                else
                {
                    UserInterface.CantMoveMassage(m_CurrentPlayer);
                }
            }

            if (inputPlayer == "Q" || inputPlayer == "q")
            {
                EndGame();
            }
            else
            {
                GameOver();
            }
        }

        public bool IsValidInput(string i_InputPlayer, bool i_isSize)
        {
            bool o_ValidInput = true;

            if (i_isSize == true)
            {
                if (i_InputPlayer != "6" && i_InputPlayer != "8")
                {
                    o_ValidInput = false;
                }
            }
            else
            {
                if (i_InputPlayer.Length != 3)
                {
                    o_ValidInput = false;
                }
                else
                {
                    if (!(char.IsDigit(i_InputPlayer[0]) || char.IsDigit(i_InputPlayer[2])) || i_InputPlayer[1] != ',')
                    {
                        o_ValidInput = false;
                    }
                }
            }

            return o_ValidInput;
        }

        public void SwitchTurn(Player i_CurrentPlayer)
        {
            if (i_CurrentPlayer.coinType == 'X')
            {
                m_CurrentPlayer = m_OPlayer;
            }
            else
            {
                m_CurrentPlayer = m_XPlayer;
            }
        }

        public void InitializePlayers(int i_size)
        {
            string howManyPlayers = UserInterface.ChooseNumOfPlayers();
            string playerName1 = UserInterface.GetPlayerName();
            m_XPlayer = new Player(playerName1, 'X', i_size);
            m_OPlayer = new Player('O', i_size);

            if (int.Parse(howManyPlayers) == 2)
            {
                m_OPlayer.name = UserInterface.GetSecondPlayerName();
                m_OPlayer.playerType = ePlayerType.HUMAN;
            }
        }
    }
}