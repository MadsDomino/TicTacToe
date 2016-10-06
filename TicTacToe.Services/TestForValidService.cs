using System;

namespace TicTacToe.UnitTests
{
    public class TestForValidService
    {
        public bool TestIfInputIsValid(int i, char [,] _GameBoard)
        {
            switch (i)
            {
                case 1:
                    return TestThisCoordinate(0, 0, _GameBoard);
                case 2:
                    return TestThisCoordinate(1, 0, _GameBoard);
                case 3:
                    return TestThisCoordinate(2, 0, _GameBoard);
                case 4:
                    return TestThisCoordinate(0, 1, _GameBoard);
                case 5:
                    return TestThisCoordinate(1, 1, _GameBoard);
                case 6:
                    return TestThisCoordinate(2, 1, _GameBoard);
                case 7:
                    return TestThisCoordinate(0, 2, _GameBoard);
                case 8:
                    return TestThisCoordinate(1, 2, _GameBoard);
                case 9:
                    return TestThisCoordinate(2, 2, _GameBoard);
                default:
                    break;
            }
            return false;
        }

        private bool TestThisCoordinate(int i, int k, char[,] _GameBoard)
        {
            if (_GameBoard[i, k] == ' ')
                return true;
            else
                return false;
        }
    }
}