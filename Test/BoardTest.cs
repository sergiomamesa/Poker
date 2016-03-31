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
        public void Test_BoardState_Is_PreFlop()
        {
            Table table = new Table(4);
            table.AddPlayer(new Player() { Name = "Player1" });
            table.AddPlayer(new Player() { Name = "Player2" });
            table.AddPlayer(new Player() { Name = "Player3" });

            table.StartGame();

            Assert.AreEqual(table.Board.BoardState, BoardStateType.Preflop);
        }

        [Test]
        public void Test_BoardState_Is_Flop()
        {
            Table table = new Table(4);
            table.AddPlayer(new Player() { Name = "Player1" });
            table.AddPlayer(new Player() { Name = "Player2" });
            table.AddPlayer(new Player() { Name = "Player3" });

            table.StartGame();
            table.Flop();

            Assert.AreEqual(table.Board.BoardState, BoardStateType.Flop);
        }

        [Test]
        public void Test_Board_State_Is_Turn()
        {
            Table table = new Table(4);
            table.AddPlayer(new Player() { Name = "Player1" });
            table.AddPlayer(new Player() { Name = "Player2" });
            table.AddPlayer(new Player() { Name = "Player3" });

            table.StartGame();
            table.Flop();
            table.Turn();

            Assert.AreEqual(table.Board.BoardState, BoardStateType.Turn);
        }

        [Test]
        public void Test_Board_Didnt_Go_Through_Flop()
        {
            Table table = new Table(4);
            table.AddPlayer(new Player() { Name = "Player1" });
            table.AddPlayer(new Player() { Name = "Player2" });
            table.AddPlayer(new Player() { Name = "Player3" });

            table.StartGame();

            Exception exception = Assert.Throws<Exception>(() => table.Turn());
            Assert.AreEqual(exception.Message, "The board has to go through Flop first!");
        }

        [Test]
        public void Test_Board_state_is_River()
        {
            Table table = new Table(4);
            table.AddPlayer(new Player() { Name = "Player1" });
            table.AddPlayer(new Player() { Name = "Player2" });
            table.AddPlayer(new Player() { Name = "Player3" });

            table.StartGame();
            table.Flop();
            table.Turn();
            table.River();

            Assert.AreEqual(table.Board.BoardState, BoardStateType.River);
        }

        [Test]
        public void Test_Board_Didnt_Go_Through_Turn()
        {
            Table table = new Table(4);
            table.AddPlayer(new Player() { Name = "Player1" });
            table.AddPlayer(new Player() { Name = "Player2" });
            table.AddPlayer(new Player() { Name = "Player3" });

            table.StartGame();
            table.Flop();

            Exception exception = Assert.Throws<Exception>(() => table.River());
            Assert.AreEqual(exception.Message, "The board has to go through Turn first!");
        }
    }
}
