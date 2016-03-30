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

        public IEnumerable<Player> Players { get { return Seats.Where(i => i.IsEmpty() == false).Select(i => i.Player); } }
        public SeatsList Seats;

        private Deck Deck;

        public Table(int maxNumberPlayers)
        {
            if (maxNumberPlayers > MAX_NUMBER_SEATS)
                throw new Exception(String.Format("MaxNumberPlayers cannont exceed {0}", MAX_NUMBER_SEATS));

            if (maxNumberPlayers < MIN_NUMBER_PLAYERS)
                throw new Exception("MIN_NUMBER_PLAYERS cannot be greater than MaxNumberPlayers");

            MaxNumberPlayers = maxNumberPlayers;

            Seats = SeatsList.GenerateEmptySeats(MaxNumberPlayers);
        }

        public void StartGame()
        {
            Deck = new Deck();

            foreach (Player player in Players)
            {
                player.SetHand(Deck.GiveHand());
            }
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
            if (seat.IsEmpty() == false)
                throw new Exception("Sorry, this seat has already a player");

            AddPlayer(player, seat);
        }

        private void AddPlayer(Player player, Seat seat)
        {
            if (Seats.Select(s => s.Player).Contains(player))
                throw new Exception("Sorry, selected player is already playing");

            seat.Player = player;
        }

        public void RemovePlayer(Player player)
        {
            Seat seat = Seats.Find(s => s.Player == player);
            if (seat == null)
                throw new Exception("This player is not sitting in the table");

            seat.Player = null;
        }

        public void RemovePlayer(int seatNumber)
        {
            Seat seat = Seats.Find(s => s.SeatNumber == seatNumber);
            if (seat == null)
                throw new Exception("Sorry, sit not found");

            if (seat.IsEmpty())
                throw new Exception("This seat is empty");

            seat.Player = null;
        }

        //public override string ToString()
        //{
        //    //TODO: Implement me

        //    return base.ToString();
        //}
    }
}
