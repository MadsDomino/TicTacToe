using System;

namespace TicTacToe.Services
{
    interface IEasyAIService
    {
        int MoveSet(char[,] _gameBoard);
    }

    public class EasyAIService : IEasyAIService
    {
        public int MoveSet(char[,] _gameBoard)
        {
            int AIMove = 0;

            AIMove = TestForHorizontalBlock(_gameBoard);
            if (AIMove != 0)
                return AIMove;

            AIMove = TestForVerticalBlock(_gameBoard);
            if (AIMove != 0)
                return AIMove;

            AIMove = TestForDiagonalBlock(_gameBoard);
            if (AIMove != 0)
                return AIMove;

            return GenerateARandomMove();
        }

        private int TestForHorizontalBlock(char[,] _gameBoard)
        {
            for(int rowIndex = 0; rowIndex <= 2; rowIndex++)
            {
                for(int columIndex = 0; columIndex <= 1; columIndex++)
                {
                    if (_gameBoard[columIndex, rowIndex] == _gameBoard[columIndex + 1, rowIndex] && _gameBoard[columIndex, rowIndex] != ' ')
                    {
                        if (columIndex == 0)
                            return ConvertCoordinatesToInt(2, rowIndex);
                        if (columIndex == 1)
                            return ConvertCoordinatesToInt(0, rowIndex);
                    }
                }
                if (_gameBoard[0, rowIndex] == _gameBoard[2, rowIndex] && _gameBoard[0, rowIndex] != ' ')
                    return ConvertCoordinatesToInt(1, rowIndex);
            }
            return 0;
        }

        private int TestForVerticalBlock(char[,] _gameBoard)
        {
            for (int columIndex = 0; columIndex <= 2; columIndex++)
            {
                for (int rowIndex = 0; rowIndex <= 1; rowIndex++)
                {
                    if (_gameBoard[columIndex, rowIndex] == _gameBoard[columIndex, rowIndex + 1] && _gameBoard[columIndex, rowIndex] != ' ')
                    {
                        if (rowIndex == 0)
                            return ConvertCoordinatesToInt(columIndex, 2);
                        if (rowIndex == 1)
                            return ConvertCoordinatesToInt(columIndex, 0);
                    }
                }
                if (_gameBoard[columIndex, 0] == _gameBoard[columIndex, 2] && _gameBoard[columIndex, 0] != ' ')
                    return ConvertCoordinatesToInt(columIndex, 1);
            }
            return 0;
        }

        private int TestForDiagonalBlock(char[,] _gameBoard)
        {
            int AIMove = 0;
            AIMove = TestDownRight(_gameBoard);
            if (AIMove != 0)
                return AIMove;
            AIMove = TestDownLeft(_gameBoard);
            return AIMove;
        }

        private int TestDownRight(char[,] _gameBoard)
        {
            if (_gameBoard[0, 0] == _gameBoard[1, 1] && _gameBoard[0, 0] != ' ' && _gameBoard[2, 2] == ' ')
                return 9;

            if (_gameBoard[1, 1] == _gameBoard[2, 2] && _gameBoard[1, 1] != ' ' && _gameBoard[0, 0] == ' ')
                return 1;

            if (_gameBoard[0, 0] == _gameBoard[2, 2] && _gameBoard[0, 0] != ' ' && _gameBoard[1, 1] == ' ')
                return 5;

            return 0;
        }

        private int TestDownLeft(char[,] _gameBoard)
        {
            if (_gameBoard[2, 0] == _gameBoard[1, 1] && _gameBoard[2, 0] != ' ' && _gameBoard[0, 2] == ' ')
                return 7;

            if (_gameBoard[1, 1] == _gameBoard[0, 2] && _gameBoard[1, 1] != ' ' && _gameBoard[2, 0] == ' ')
                return 3;

            if (_gameBoard[2, 0] == _gameBoard[0, 2] && _gameBoard[2, 0] != ' ' && _gameBoard[1, 1] == ' ')
                return 5;

            return 0;
        }

        private int GenerateARandomMove()
        {
            Random r = new Random();
            return r.Next(1, 9);
        }

        private int ConvertCoordinatesToInt(int columIndex, int rowIndex)
        {
            return columIndex + (rowIndex * 3) + 1;
        }

        public EasyAIService()
        {

        }
    }
}