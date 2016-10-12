using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicTacToe.Services;
using NUnit.Framework;

namespace TicTacToe.UnitTests
{
    [TestFixture]
    class EasyAITests
    {
        private IGameWinnerService _gameWinnerService;
        private char[,] _gameBoard;

        [SetUp]
        public void SetupUnitTests()
        {
            _gameWinnerService = new GameWinnerService();
            _gameBoard = new char[3, 3]
                  {
                      {' ', ' ', ' '},
                      {' ', ' ', ' '},
                      {' ', ' ', ' '}
                  };
        }

        private void ClearBoard()
        {
            for (int rowIndex = 0; rowIndex <= 2; rowIndex++)
                for (int columIndex = 0; columIndex <= 2; columIndex++)
                    _gameBoard[columIndex, rowIndex] = ' ';
        }

        [Test]
        public void EasyAIReturnsAMove()
        {
            int AIMove = EasyAI.MoveSet();
            bool AIMoveIsWithinArrayBorders = false;

            Assert.AreNotEqual(AIMove, null);
            if (AIMove < 10 && AIMove > 0)
                AIMoveIsWithinArrayBorders = true;
            Assert.IsTrue(AIMoveIsWithinArrayBorders);
        }

        [Test]
        public void BlockingHorizontalRowsTest()
        {
            for (int rowIndex = 0; rowIndex <= 2; rowIndex++)
            {
                _gameBoard[0, rowIndex] = 'X';
                _gameBoard[1, rowIndex] = 'X';
                Assert.AreEqual(3 + (rowIndex * 3), EasyAI.MoveSet());
                ClearBoard();

                _gameBoard[0, rowIndex] = 'X';
                _gameBoard[2, rowIndex] = 'X';
                Assert.AreEqual(2 + (rowIndex * 3), EasyAI.MoveSet());
                ClearBoard();

                _gameBoard[1, rowIndex] = 'X';
                _gameBoard[2, rowIndex] = 'X';
                Assert.AreEqual(1 + (rowIndex * 3), EasyAI.MoveSet());
            }
        }

        [Test]
        public void BlockingVerticalColumsTest()
        {
            for (int columIndex = 0; columIndex <= 2; columIndex++)
            {
                _gameBoard[columIndex, 0] = 'X';
                _gameBoard[columIndex, 1] = 'X';
                Assert.AreEqual(7 + columIndex, EasyAI.MoveSet());
                ClearBoard();

                _gameBoard[columIndex, 0] = 'X';
                _gameBoard[columIndex, 2] = 'X';
                Assert.AreEqual(4 + columIndex, EasyAI.MoveSet());
                ClearBoard();

                _gameBoard[columIndex, 1] = 'X';
                _gameBoard[columIndex, 2] = 'X';
                Assert.AreEqual(1 + columIndex, EasyAI.MoveSet());
            }
        }

        [Test]
        public void BlockingDiagonalDownToLeft()
        {
            _gameBoard[0, 0] = 'X';
            _gameBoard[1, 1] = 'X';
            Assert.AreEqual(9, EasyAI.MoveSet());
            ClearBoard();

            _gameBoard[1, 1] = 'X';
            _gameBoard[2, 2] = 'X';
            Assert.AreEqual(1, EasyAI.MoveSet());
            ClearBoard();

            _gameBoard[0, 0] = 'X';
            _gameBoard[2, 2] = 'X';
            Assert.AreEqual(5, EasyAI.MoveSet());
        }

        [Test]
        public void BlockingDiagonalDownToRight()
        {
            _gameBoard[0, 2] = 'X';
            _gameBoard[1, 1] = 'X';
            Assert.AreEqual(3, EasyAI.MoveSet());
            ClearBoard();

            _gameBoard[0, 2] = 'X';
            _gameBoard[2, 0] = 'X';
            Assert.AreEqual(5, EasyAI.MoveSet());
            ClearBoard();

            _gameBoard[1, 1] = 'X';
            _gameBoard[2, 0] = 'X';
            Assert.AreEqual(7, EasyAI.MoveSet());
        }

        [Test]
        public void TestIfAIMoveIsValid()
        {
            TestForValidService valid = new TestForValidService();
            Assert.IsTrue(valid.TestIfInputIsValid(EasyAI.MoveSet(), _gameBoard));

            for (int columIndex = 0; columIndex <= 2; columIndex++)
                for (int rowIndex = 0; rowIndex <= 2; rowIndex++)
                    _gameBoard[columIndex, rowIndex] = 'X';

            Assert.IsFalse(valid.TestIfInputIsValid(EasyAI.MoveSet(), _gameBoard));
        }
    }
}
