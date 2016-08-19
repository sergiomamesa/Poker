using NUnit.Framework;
using Poker;
using System;
using System.Linq;

namespace Test
{
    [TestFixture]
    class BoardTest
    {
        [Test]
        public void Test_StartGame_BoardStateIsPreFlop_IsTrue()
        {
            Table table = new Table(4,0);
            table.AddPlayer(new Player(500,0));
            table.AddPlayer(new Player(500,0));
            table.AddPlayer(new Player(500,0));

            table.StartGame();

            Assert.AreEqual(table.Board.BoardState, BoardStateType.Preflop);
        }

        [Test]
        public void Test_Flop_BoardStateIsFlop_IsTrue()
        {
            Table table = new Table(4,0);
            table.AddPlayer(new Player(500,0));
            table.AddPlayer(new Player(500,0));
            table.AddPlayer(new Player(500,0));

            table.StartGame();
            table.Flop();

            Assert.AreEqual(table.Board.BoardState, BoardStateType.Flop);
        }

        [Test]
        public void Test_Turn_BoardStateIsTurn_IsTrue()
        {
            Table table = new Table(4,0);
            table.AddPlayer(new Player(500,0));
            table.AddPlayer(new Player(500,0));
            table.AddPlayer(new Player(500,0));

            table.StartGame();
            table.Flop();
            table.Turn();

            Assert.AreEqual(table.Board.BoardState, BoardStateType.Turn);
        }

        [Test]
        public void Test_Turn_AfterStartGame_ThrowsException()
        {
            Table table = new Table(4,0);
            table.AddPlayer(new Player(500,0));
            table.AddPlayer(new Player(500,0));
            table.AddPlayer(new Player(500,0));

            table.StartGame();

            Exception exception = Assert.Throws<Exception>(() => table.Turn());
            Assert.AreEqual(exception.Message, "The board has to go through Flop first!");
        }

        [Test]
        public void Test_River_BoardStateIsRiver_IsTrue()
        {
            Table table = new Table(4,0);
            table.AddPlayer(new Player(500,0));
            table.AddPlayer(new Player(500,0));
            table.AddPlayer(new Player(500,0));

            table.StartGame();
            table.Flop();
            table.Turn();
            table.River();

            Assert.AreEqual(table.Board.BoardState, BoardStateType.River);
        }

        [Test]
        public void Test_River_WhenInFlop_ThrowsException()
        {
            Table table = new Table(4,0);
            table.AddPlayer(new Player(500,0));
            table.AddPlayer(new Player(500,0));
            table.AddPlayer(new Player(500,0));

            table.StartGame();
            table.Flop();

            Exception exception = Assert.Throws<Exception>(() => table.River());
            Assert.AreEqual(exception.Message, "The board has to go through Turn first!");
        }
    }
}
