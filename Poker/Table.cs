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

        private int MaxNumberPlayers;
        private int MinNumberPlayers;

        private List<Player> Players;
        public SeatsList Seats;

        public Table(int maxNumberPlayers, int minNumberPlayers)
        {
            if (maxNumberPlayers > MAX_NUMBER_SEATS)
                throw new Exception(String.Format("MaxNumberPlayers cannont exceed {0}", MAX_NUMBER_SEATS));

            if (maxNumberPlayers < minNumberPlayers)
                throw new Exception("MinNumberPlayers cannot be greater than MaxNumberPlayers");

            MaxNumberPlayers = maxNumberPlayers;
            MinNumberPlayers = minNumberPlayers;

            Players = new List<Player>();
            Seats = SeatsList.GenerateEmptySeats(MaxNumberPlayers);
        }

        public void AddPlayer(Player player)
        {
            Seat freeSeat = Seats.GetFreeSeat();

            AddPlayer(player, freeSeat);
        }

        private void AddPlayer(Player player, Seat seat)
        {
            if (Seats.IsNoneEmpty())
                throw new Exception("No seats empty on this table");

            if (Seats.Select(i => i.Player).Contains(player))
                throw new Exception("Sorry, selected player is already playing");

            if (seat.Status == SeatStatus.Playing)
                throw new Exception("Sorry this seat has already a player");

            seat.Player = player;
        }
    }
}
