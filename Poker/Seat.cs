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
}
