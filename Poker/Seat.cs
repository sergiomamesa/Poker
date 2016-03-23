using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker
{
    public class Seat
    {
        public int SeatNumber { get; set; }
        public Player Player { get; set; }

        public Seat(int seatNumber)
        {
            SeatNumber = seatNumber;
        }

        public bool IsEmpty()
        {
            if (Player == null)
                return true;

            return false;
        }
    }

    public class SeatsList : List<Seat>
    {
        public new Seat this[int index] { get { return GetSeat(index); } }

        private Seat GetSeat(int index)
        {
            return this.ElementAt(index - 1);
        }

        internal Seat GetFreeSeat()
        {
            if (IsNoneEmpty())
                throw new Exception("Sorry, not empty seat found");

            Seat seat = this.First(i => i.IsEmpty());
            
            return seat;
        }

        internal static SeatsList GenerateEmptySeats(int MaxNumberPlayers)
        {
            var result = new SeatsList();

            for (int i = 1; i <= MaxNumberPlayers; i++)
            {
                result.Add(new Seat(i));
            }

            return result;
        }

        public bool IsAnyEmpty()
        {
            return this.Any(i => i.IsEmpty());
        }

        public bool IsNoneEmpty()
        {
            return !IsAnyEmpty();
        }
    }
}
