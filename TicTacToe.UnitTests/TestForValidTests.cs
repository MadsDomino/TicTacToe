using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicTacToe.Services;
using NUnit.Framework;

namespace TicTacToe.UnitTests
{
    [TestFixture]
    class TestForValidTests
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

        [Test]
        public void TestFirstFieldValid()
        {
            TestForValidService valid = new TestForValidService();
            Assert.IsTrue(valid.TestIfInputIsValid(1, _gameBoard));
        }

        [Test]
        public void TestFirstFieldFalse()
        {
            TestForValidService valid = new TestForValidService();
            _gameBoard[0, 0] = 'X';
            Assert.IsFalse(valid.TestIfInputIsValid(1, _gameBoard));
        }
    }
}
