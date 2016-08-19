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
        public void Test_NewTable_SeatsEmpty_ReturnsTrue(int seatNumber)
        {
            Table table = new Table(9);
            Seat seat = table.Seats[seatNumber];

            bool isEmpty = seat.IsEmpty();

            Assert.AreEqual(isEmpty, true);
        }

        [Test]
        public void Test_IsAnyEmpty_HasSomeEmptySeats_ReturnsTrue()
        {
            Table table = new Table(5);
            table.AddPlayer(new Player(500, 0));
            table.AddPlayer(new Player(500, 0));
            table.AddPlayer(new Player(500, 0));

            bool expected = table.Seats.IsAnyEmpty();

            Assert.AreEqual(expected, true);
        }

        [Test]
        public void Test_IsNoneEmpty_HasNoneEmptySeats_ReturnsTrue()
        {
            Table table = new Table(4);
            table.AddPlayer(new Player(500, 0));
            table.AddPlayer(new Player(500, 0));
            table.AddPlayer(new Player(500, 0));
            table.AddPlayer(new Player(500, 0));

            bool expected = table.Seats.IsNoneEmpty();

            Assert.AreEqual(expected, true);
        }

        [Test]
        public void Test_AddPlayer_HasNoEmptySeats_ThrowsException()
        {
            Table table = new Table(4);
            table.AddPlayer(new Player(500, 0));
            table.AddPlayer(new Player(500, 0));
            table.AddPlayer(new Player(500, 0));
            table.AddPlayer(new Player(500, 0));

            Exception exception = Assert.Throws<Exception>(() => table.AddPlayer(new Player(500,0)));
            Assert.AreEqual(exception.Message, "Sorry, no empty seat found");
        }

        [Test]
        public void Test_AddPlayer_SeatDoesNotExist_ThrowsException()
        {
            Table table = new Table(4);

            Exception exception = Assert.Throws<Exception>(() => table.AddPlayer(new Player(500,0), 12));
            Assert.AreEqual(exception.Message, "Sorry, invalid seat number");
        }

        [Test]
        public void Test_AddPlayer_SeatNotEmpty_ThrowsException()
        {
            Table table = new Table(4);
            table.AddPlayer(new Player(500,0), 3);

            Exception exception = Assert.Throws<Exception>(() => table.AddPlayer(new Player(500,0), 3));
            Assert.AreEqual(exception.Message, "Sorry, this seat has already a player");
        }

        [Test]
        public void Test_AddPlayer_TableAlreadyContainsPlayer_ThrowsException()
        {
            Table table = new Table(4);
            var player = new Player(500, 0);
            table.AddPlayer(player);

            Exception exception = Assert.Throws<Exception>(() => table.AddPlayer(player));
            Assert.AreEqual(exception.Message, "Sorry, selected player is already playing");
        }

        [Test]
        public void Test_RemovePlayer_EmptyTable_ThrowsException()
        {
            Table table = new Table(4);
            var player = new Player(500, 0);

            Exception exception = Assert.Throws<Exception>(() => table.RemovePlayer(player));
            Assert.AreEqual(exception.Message, "This player is not sitting in the table");
        }

        [Test]
        public void Test_RemovePlayer_ByExistingPlayer_IsOk()
        {
            Table table = new Table(4);
            Player player = new Player(500, 0);
            table.AddPlayer(player);

            Assert.DoesNotThrow(() => table.RemovePlayer(player));
        }

        [Test]
        public void Test_RemovePlayer_DoesNotExist_ThrowsException()
        {
            Table table = new Table(4);
            table.AddPlayer(new Player(500,0));
            table.AddPlayer(new Player(500,0));

            Exception exception = Assert.Throws<Exception>(() => table.RemovePlayer(new Player(500,0)));
            Assert.AreEqual(exception.Message, "This player is not sitting in the table");
        }

        [Test]
        public void Test_RemovePlayer_FromEmptySeat_ThrowsException()
        {
            Table table = new Table(4);
            table.AddPlayer(new Player(500,0));
            table.AddPlayer(new Player(500,0));

            Exception exception = Assert.Throws<Exception>(() => table.RemovePlayer(3));
            Assert.AreEqual(exception.Message, "This seat is empty");
        }

        [Test]
        public void Test_RemovePlayer_FromNonExistingSeat_ThrowsException()
        {
            Table table = new Table(4);
            table.AddPlayer(new Player(500,0));
            table.AddPlayer(new Player(500,0));

            Exception exception = Assert.Throws<Exception>(() => table.RemovePlayer(8));
            Assert.AreEqual(exception.Message, "Sorry, seat not found");
        }

        [TestCase(2)]
        [TestCase(3)]
        public void Test_RemovePlayer_FromSeatNumber_IsOk(int seatNumber)
        {
            Table table = new Table(4);
            table.AddPlayer(new Player(500,0));
            table.AddPlayer(new Player(500,0));
            table.AddPlayer(new Player(500, 0));
            table.AddPlayer(new Player(500, 0));

            Assert.DoesNotThrow(() => table.RemovePlayer(seatNumber));
        }

    }
}
