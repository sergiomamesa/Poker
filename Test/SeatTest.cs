using NUnit.Framework;
using Poker;
using System;

namespace Test
{
    [TestFixture]
    public class SeatTest
    {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(6)]
        [TestCase(8)]
        [TestCase(9)]
        public void Test_Generated_Seats_Are_Empty(int seatNumber)
        {
            Table table = new Table(9);
            Seat seat = table.Seats[seatNumber];

            bool isEmpty = seat.IsEmpty();

            Assert.AreEqual(isEmpty, true);
        }

        [Test]
        public void Test_Table_Has_Some_Empty_Seats()
        {
            Table table = new Table(5);
            table.AddPlayer(new Player() { Name = "Player1" });
            table.AddPlayer(new Player() { Name = "Player2" });
            table.AddPlayer(new Player() { Name = "Player3" });

            bool expected = table.Seats.IsAnyEmpty();

            Assert.AreEqual(expected, true);
        }

        [Test]
        public void Test_Table_Has_None_Empty_Seats()
        {
            Table table = new Table(4);
            table.AddPlayer(new Player() { Name = "Player1" });
            table.AddPlayer(new Player() { Name = "Player2" });
            table.AddPlayer(new Player() { Name = "Player3" });
            table.AddPlayer(new Player() { Name = "Player4" });

            bool expected = table.Seats.IsNoneEmpty();

            Assert.AreEqual(expected, true);
        }

        [Test]
        public void Test_Table_Has_No_Empty_Seats()
        {
            Table table = new Table(4);
            table.AddPlayer(new Player() { Name = "Player1" });
            table.AddPlayer(new Player() { Name = "Player2" });
            table.AddPlayer(new Player() { Name = "Player3" });
            table.AddPlayer(new Player() { Name = "Player4" });

            Exception exception = Assert.Throws<Exception>(() => table.AddPlayer(new Player() { Name = "Player5" }));
            Assert.AreEqual(exception.Message, "Sorry, not empty seat found");
        }

        [Test]
        public void Test_Table_AddPlayer_Specific_Seat()
        {
            Table table = new Table(4);

            Exception exception = Assert.Throws<Exception>(() => table.AddPlayer(new Player() { Name = "Player" }, 12));
            Assert.AreEqual(exception.Message, "Sorry, invalid seat number");
        }

        [Test]
        public void Test_Table_AddPlayer_Already_Player_Sitting()
        {
            Table table = new Table(4);
            table.AddPlayer(new Player() { Name = "Player" }, 3);

            Exception exception = Assert.Throws<Exception>(() => table.AddPlayer(new Player() { Name = "Player" }, 3));
            Assert.AreEqual(exception.Message, "Sorry, this seat has already a player");
        }

        [Test]
        public void Test_Table_Already_Contains_Player()
        {
            Table table = new Table(4);
            var player = new Player() { Name = "Player" };
            table.AddPlayer(player);

            Exception exception = Assert.Throws<Exception>(() => table.AddPlayer(player));
            Assert.AreEqual(exception.Message, "Sorry, selected player is already playing");
        }

        [Test]
        public void Test_Remove_Player_Empty_Table()
        {
            Table table = new Table(4);
            var player = new Player() { Name = "Player1" };

            Exception exception = Assert.Throws<Exception>(() => table.RemovePlayer(player));
            Assert.AreEqual(exception.Message, "This player is not sitting in the table");
        }

        [Test]
        public void Test_Remove_Player_By_Player()
        {
            Table table = new Table(4);
            Player player = new Player() { Name = "Player1" };
            table.AddPlayer(player);

            Assert.DoesNotThrow(() => table.RemovePlayer(player));
        }

        [Test]
        public void Test_Remove_Player_Does_Not_Exist()
        {
            Table table = new Table(4);
            table.AddPlayer(new Player() { Name = "Player1" });
            table.AddPlayer(new Player() { Name = "Player2" });

            Exception exception = Assert.Throws<Exception>(() => table.RemovePlayer(new Player() { Name = "Player3" }));
            Assert.AreEqual(exception.Message, "This player is not sitting in the table");
        }

        [Test]
        public void Test_Remove_Player_From_Empty_Seat()
        {
            Table table = new Table(4);
            table.AddPlayer(new Player() { Name = "Player1" });
            table.AddPlayer(new Player() { Name = "Player2" });

            Exception exception = Assert.Throws<Exception>(() => table.RemovePlayer(3));
            Assert.AreEqual(exception.Message, "This seat is empty");
        }

        [Test]
        public void Test_Remove_Player_From_Non_Existing_Seat()
        {
            Table table = new Table(4);
            table.AddPlayer(new Player() { Name = "Player1" });
            table.AddPlayer(new Player() { Name = "Player2" });

            Exception exception = Assert.Throws<Exception>(() => table.RemovePlayer(8));
            Assert.AreEqual(exception.Message, "Sorry, sit not found");
        }

        [Test]
        public void Test_Remove_Player_From_Seat_Number()
        {
            Table table = new Table(4);
            table.AddPlayer(new Player() { Name = "Player1" });
            table.AddPlayer(new Player() { Name = "Player2" });

            Assert.DoesNotThrow(() => table.RemovePlayer(2));
        }

    }
}
