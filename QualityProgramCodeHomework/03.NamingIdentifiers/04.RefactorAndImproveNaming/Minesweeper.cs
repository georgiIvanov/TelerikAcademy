using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
	public class Minesweeper
	{
        static Random rng = new Random();
        static int maxRows = 5;
        static int maxCols = 10;
        static int minesToPlace = 15;

		static void Main(string[] args)
		{
			string command = string.Empty;
			char[,] playField = CreatePlayField(maxRows, maxCols);
			char[,] mineField = PlaceMines(maxRows, maxCols, minesToPlace);
			bool openedMine = false;
			List<ScoreEntry> highScores = new List<ScoreEntry>();
			int row = 0, col = 0, counter = 0;
			bool newGame = true, gameWon = false;
			int squaresToOpen = maxRows * maxCols - minesToPlace;

			do
			{
				if (newGame)
				{
					Console.WriteLine(GameMessages.INITIAL_MESSAGE);
					DrawMineField(playField);
					newGame = false;
				}

				Console.Write(GameMessages.ENTER_ROW_COLUMN);
				command = Console.ReadLine().Trim();

				if (command.Length >= 3)
				{
                    if (CheckIfValidTurn(command, playField, ref row, ref col))
					{
						command = "turn";
					}
				}
				switch (command)
				{
					case "top":
						ShowHighScores(highScores);
						break;
					case "restart":
                        ResetGame(ref playField, ref mineField, ref openedMine, ref counter, ref newGame);
						DrawMineField(playField);
						newGame = false;
						break;
					case "exit":
						Console.WriteLine(GameMessages.BYE_MESSAGE);
						break;
					case "turn":
						if (mineField[row, col] != '*')
						{
							if (mineField[row, col] == '-')
							{
								OpenSquareAtCoords(playField, mineField, row, col);
								counter++;
							}
							if (squaresToOpen == counter)
							{
								gameWon = true;
							}
							else
							{
								DrawMineField(playField);
							}
						}
						else
						{
							openedMine = true;
						}
						break;
					default:
						Console.WriteLine(GameMessages.INVALID_COMMAND);
						break;
				}
				if (openedMine)
				{
					DrawMineField(mineField);
                    Console.Write(string.Format(GameMessages.ON_DEATH, counter));
					string playerName = Console.ReadLine();

                    SaveScore(highScores, counter, playerName);
					ShowHighScores(highScores);

                    ResetGame(ref playField, ref mineField, ref openedMine, ref counter, ref newGame);
				}
				if (gameWon)
				{
                    Console.WriteLine(string.Format(GameMessages.ON_WIN_CONGRATULATIONS, squaresToOpen));
					DrawMineField(mineField);
					Console.WriteLine(GameMessages.ON_WIN_ENTERNAME);

					string playerName = Console.ReadLine();
                    SaveScore(highScores, counter, playerName);
					ShowHighScores(highScores);

                    ResetGame(ref playField, ref mineField, ref openedMine, ref counter, ref newGame);
				}
			}
			while (command != "exit");

			Console.WriteLine(GameMessages.EXIT_MESSAGE);
			Console.Read();
		}

        private static bool CheckIfValidTurn(string command, char[,] playField, ref int row, ref int col)
        {
            bool isValidTurn = true;
            string[] splitCommand = command.Split();
            if(splitCommand.Length != 2)
            {
                return false;
            }

            if (!int.TryParse(splitCommand[0], out row) || row > maxRows - 1 || row < 0)
            {
                isValidTurn = false;
            }
            else if(!int.TryParse(splitCommand[1].ToString(), out col) || col > maxCols - 1 || col < 0)
            {
                isValidTurn = false;
            }
            return isValidTurn;
        }

        private static void ResetGame(ref char[,] playField, ref char[,] mineField, ref bool openedMine, ref int counter, ref bool newGame)
        {
            playField = CreatePlayField(maxRows, maxCols);
            mineField = PlaceMines(maxRows, maxCols, minesToPlace);
            counter = 0;
            openedMine = false;
            newGame = true;
        }

        private static void SaveScore(List<ScoreEntry> highScores, int counter, string playerName)
        {
            ScoreEntry playerScore = new ScoreEntry(playerName, counter);
            if (highScores.Count < 5)
            {
                highScores.Add(playerScore);
            }
            else
            {
                for (int i = 0; i < highScores.Count; i++)
                {
                    if (highScores[i].GetScorePoints < playerScore.GetScorePoints)
                    {
                        highScores.Insert(i, playerScore);
                        highScores.RemoveAt(highScores.Count - 1);
                        break;
                    }
                }
            }
            highScores.Sort((ScoreEntry r1, ScoreEntry r2) => r2.GetName.CompareTo(r1.GetName));
            highScores.Sort((ScoreEntry r1, ScoreEntry r2) => r2.GetScorePoints.CompareTo(r1.GetScorePoints));
        }

		private static void ShowHighScores(List<ScoreEntry> highScores)
		{
			Console.WriteLine(GameMessages.SCORE_OPEN);
			if (highScores.Count > 0)
			{
				for (int i = 0; i < highScores.Count; i++)
				{
					Console.WriteLine(string.Format(GameMessages.SCORE_ENTRY,
                        i + 1, highScores[i].GetName, highScores[i].GetScorePoints));
				}
				Console.WriteLine();
			}
			else
			{
				Console.WriteLine(GameMessages.SCORE_EMPTY);
			}
		}

		private static void OpenSquareAtCoords(char[,] playField, char[,] mineField, int row, int col)
		{
			char numberAtSquare = NumberAtSquare(mineField, row, col);
			mineField[row, col] = numberAtSquare;
			playField[row, col] = numberAtSquare;
		}

		private static void DrawMineField(char[,] field)
		{
			int maxRows = field.GetLength(0);
			int maxCols = field.GetLength(1);
			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");
			for (int i = 0; i < maxRows; i++)
			{
				Console.Write("{0} | ", i);
				for (int j = 0; j < maxCols; j++)
				{
					Console.Write(string.Format("{0} ", field[i, j]));
				}
				Console.Write("|");
				Console.WriteLine();
			}
			Console.WriteLine("   ---------------------\n");
		}

		private static char[,] CreatePlayField(int maxRows, int maxCols)
		{
			char[,] board = new char[maxRows, maxCols];
			for (int i = 0; i < maxRows; i++)
			{
				for (int j = 0; j < maxCols; j++)
				{
					board[i, j] = '?';
				}
			}

			return board;
		}

		private static char[,] PlaceMines(int maxRows, int maxCols, int minesToPlace)
		{
			
			char[,] mineField = new char[maxRows, maxCols];

			for (int i = 0; i < maxRows; i++)
			{
				for (int j = 0; j < maxCols; j++)
				{
					mineField[i, j] = '-';
				}
			}

			List<int> mines = new List<int>();
            

			while (mines.Count < minesToPlace)
			{
				int placementParameter = rng.Next(50);
				if (!mines.Contains(placementParameter))
				{
					mines.Add(placementParameter);
				}
			}

			foreach (int placementParameter in mines)
			{
				int col = (placementParameter / maxCols);
				int row = (placementParameter % maxCols);
				if (row == 0 && placementParameter != 0)
				{
					col--;
					row = maxCols;
				}
				else
				{
					row++;
				}
				mineField[col, row - 1] = '*';
			}

			return mineField;
		}

		private static char NumberAtSquare(char[,] mineField, int squareRow, int squareCol)
		{
			int squareNumber = 0;
			int maxRows = mineField.GetLength(0);
			int maxCols = mineField.GetLength(1);

			if (squareRow - 1 >= 0)
			{
				if (mineField[squareRow - 1, squareCol] == '*')
				{ 
					squareNumber++; 
				}
			}
			if (squareRow + 1 < maxRows)
			{
				if (mineField[squareRow + 1, squareCol] == '*')
				{ 
					squareNumber++; 
				}
			}
			if (squareCol - 1 >= 0)
			{
				if (mineField[squareRow, squareCol - 1] == '*')
				{ 
					squareNumber++;
				}
			}
			if (squareCol + 1 < maxCols)
			{
				if (mineField[squareRow, squareCol + 1] == '*')
				{ 
					squareNumber++;
				}
			}
			if ((squareRow - 1 >= 0) && (squareCol - 1 >= 0))
			{
				if (mineField[squareRow - 1, squareCol - 1] == '*')
				{ 
					squareNumber++; 
				}
			}
			if ((squareRow - 1 >= 0) && (squareCol + 1 < maxCols))
			{
				if (mineField[squareRow - 1, squareCol + 1] == '*')
				{ 
					squareNumber++; 
				}
			}
			if ((squareRow + 1 < maxRows) && (squareCol - 1 >= 0))
			{
				if (mineField[squareRow + 1, squareCol - 1] == '*')
				{ 
					squareNumber++; 
				}
			}
			if ((squareRow + 1 < maxRows) && (squareCol + 1 < maxCols))
			{
				if (mineField[squareRow + 1, squareCol + 1] == '*')
				{ 
					squareNumber++; 
				}
			}
			return char.Parse(squareNumber.ToString());
		}
	}
}
