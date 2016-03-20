using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Table
    {
        private const int MAX_NUMBER_SEATS = 9;
        private const int MIN_NUMBER_PLAYERS = 2;

        private int MaxNumberPlayers;

        private List<Player> Players;
        public SeatsList Seats;

        public Table(int maxNumberPlayers)
        {
            if (maxNumberPlayers > MAX_NUMBER_SEATS)
                throw new Exception(String.Format("MaxNumberPlayers cannont exceed {0}", MAX_NUMBER_SEATS));

            if (maxNumberPlayers < MIN_NUMBER_PLAYERS)
                throw new Exception("MIN_NUMBER_PLAYERS cannot be greater than MaxNumberPlayers");

            MaxNumberPlayers = maxNumberPlayers;

            Players = new List<Player>();
            Seats = SeatsList.GenerateEmptySeats(MaxNumberPlayers);
        }

        public void AddPlayer(Player player)
        {
            Seat freeSeat = Seats.GetFreeSeat();

            AddPlayer(player, freeSeat);
        }

        public void AddPlayer(Player player, int seatNumber)
        {
            if (seatNumber > MaxNumberPlayers)
                throw new Exception("Sorry, invalid seat number");

            Seat seat = Seats[seatNumber];

            AddPlayer(player, seatNumber);
        }

        private void AddPlayer(Player player, Seat seat)
        {
            if (seat.IsEmpty() == false)
                throw new Exception("Sorry, this seat has already a player");

            if (Seats.Select(i => i.Player).Contains(player))
                throw new Exception("Sorry, selected player is already playing");

            seat.Player = player;
        }

        public override string ToString()
        {
            //TODO: Implement me

            return base.ToString();
        }
    }
}
