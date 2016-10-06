using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe.Services
{
    public interface IGameWinnerService
    {
        char Validate(char[,] gameBoard);
    }

    public class GameWinnerService : IGameWinnerService
    {
        private const char SymbolForNoWinner = ' ';

        public char Validate(char[,] gameBoard)
        {
            var currentWinningSymbol = CheckForThreeInARowInHorizontalRow(gameBoard);
            if (currentWinningSymbol != SymbolForNoWinner)
                return currentWinningSymbol;
            currentWinningSymbol = CheckForThreeInARowInVerticalColumn(gameBoard);
            if (currentWinningSymbol != SymbolForNoWinner)
                return currentWinningSymbol;
            currentWinningSymbol = CheckForThreeInARowDiagonally(gameBoard);
            return currentWinningSymbol;
        }

        private static char CheckForThreeInARowInVerticalColumn(char[,] gameBoard)
        {
            for (int i = 0; i <= 2; i++)
            {
                int test = 0;
                for (int k = 1; k <= 2; k++)
                {
                    if (gameBoard[k,i].Equals(gameBoard[k - 1,i]) && gameBoard[k,i] != SymbolForNoWinner)
                    {
                        test++;
                    }
                    if (test == 2)
                    {
                        return gameBoard[k, i];
                    }
                }
            }
            return SymbolForNoWinner;
        }

        private static char CheckForThreeInARowInHorizontalRow(char[,] gameBoard)
        {
            for (int i = 0; i <= 2; i++)
            {
                int test = 0;
                for (int k = 1; k <= 2; k++)
                {
                    if (gameBoard[i, k].Equals(gameBoard[i, k - 1]) && gameBoard[i, k] != SymbolForNoWinner)
                    {
                        test++;
                    }
                    if (test == 2)
                    {
                        return gameBoard[i, k];
                    }
                }
            }
            return SymbolForNoWinner;
        }

        private static char CheckForThreeInARowDiagonally(char[,] gameBoard)
        {
            var cellOneChar = gameBoard[0, 0];
            var cellTwoChar = gameBoard[1, 1];
            var cellThreeChar = gameBoard[2, 2];
            if (cellOneChar == cellTwoChar &&
                cellTwoChar == cellThreeChar)
            {
                return cellOneChar;
            }
            cellOneChar = gameBoard[0, 2];
            cellTwoChar = gameBoard[1, 1];
            cellThreeChar = gameBoard[2, 0];
            if (cellOneChar == cellTwoChar &&
                cellTwoChar == cellThreeChar)
            {
                return cellOneChar;
            }
            return SymbolForNoWinner;
        }
    }
}
