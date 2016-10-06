using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicTacToe.Services;
using NUnit.Framework;

namespace TicTacToe.UnitTests
{

    [TestFixture]
    class NextPlayerServiceTests
    {

        [Test]
        public void TestIfPlayer1Starts()
        {
            NextPlayerService NPS = new NextPlayerService();
            Assert.AreEqual(1, NPS.Playerturn);
        }

        [Test]
        public void TestIfPlayer2After1()
        {
            NextPlayerService NPS = new NextPlayerService();
            NPS.NextPlayer();
            Assert.AreEqual(2, NPS.Playerturn);
        }

        [Test]
        public void TestIfPlayer1After2()
        {
            NextPlayerService NPS = new NextPlayerService();
            NPS.NextPlayer();
            NPS.NextPlayer();
            Assert.AreEqual(1, NPS.Playerturn);
        }

        [Test]
        public void TestIfTurnNumberCountsUp()
        {
            NextPlayerService NPS = new NextPlayerService();
            NPS.NextPlayer();
            NPS.NextPlayer();
            Assert.AreEqual(2, NPS.Turnnumber);
        }
    }
}
