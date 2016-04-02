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
        public Board Board;

        public decimal Pot;

        public Table(int maxNumberPlayers, decimal pot)
        {
            if (maxNumberPlayers > MAX_NUMBER_SEATS)
                throw new Exception(String.Format("MaxNumberPlayers cannont exceed {0}", MAX_NUMBER_SEATS));

            if (maxNumberPlayers < MIN_NUMBER_PLAYERS)
                throw new Exception("MIN_NUMBER_PLAYERS cannot be greater than MaxNumberPlayers");

            MaxNumberPlayers = maxNumberPlayers;
            Pot = pot;

            Seats = SeatsList.GenerateEmptySeats(MaxNumberPlayers);
        }

        public void StartGame()
        {
            Deck = new Deck();
            Board = new Board();
            foreach (Player player in Players)
            {
                player.SetHand(Deck.GiveHand());
            }

            Board.SetBoardState();
        }

        public void Flop()
        {
            if (Board.BoardState != BoardStateType.Preflop)
                throw new Exception("The board is not in PreFlop!");

            Deck.GiveCard(); //burns card
            Board.FirstCard = Deck.GiveCard();
            Board.SecondCard = Deck.GiveCard();
            Board.ThirdCard = Deck.GiveCard();
            Board.SetBoardState();
        }

        public void Turn()
        {
            if (Board.BoardState != BoardStateType.Flop)
                throw new Exception("The board has to go through Flop first!");
            Deck.GiveCard(); //burns card
            Board.FourthCard = Deck.GiveCard();
            Board.SetBoardState();
        }

        public void River()
        {
            if (Board.BoardState != BoardStateType.Turn)
                throw new Exception("The board has to go through Turn first!");

            Deck.GiveCard(); //burns card
            Board.FifthCard = Deck.GiveCard();
            Board.SetBoardState();
        }

        public void Flop(Card firstCard, Card secondCard, Card thirdCard)
        {
            if (Board.BoardState != BoardStateType.Preflop)
                throw new Exception("The board is not in PreFlop!");

            Deck.GiveCard();
            Board.FirstCard = Deck.GiveSpecificCard(firstCard);
            Board.SecondCard = Deck.GiveSpecificCard(secondCard);
            Board.ThirdCard = Deck.GiveSpecificCard(thirdCard);
            Board.SetBoardState();
        }

        public void Turn(Card fourthCard)
        {
            if (Board.BoardState != BoardStateType.Flop)
                throw new Exception("The board has to go through Flop first!");

            Deck.GiveCard();
            Board.ThirdCard = Deck.GiveSpecificCard(fourthCard);
            Board.SetBoardState();
        }

        public void River(Card fifthCard)
        {
            if (Board.BoardState != BoardStateType.Turn)
                throw new Exception("The board has to go through Turn first!");

            Deck.GiveCard();
            Board.FifthCard = Deck.GiveSpecificCard(fifthCard);
            Board.SetBoardState();
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

        public void SetDealer(int seatNumber)
        {
            Player dealerPlayer = Seats[seatNumber].Player;
            if (dealerPlayer == null)
                throw new Exception("Sorry, selected seat is empty!");

            dealerPlayer.SetDealer();

            var smallBlindSeat = Seats.NextSeat(seatNumber);
            SetSmallBlind(smallBlindSeat);

            var bigBlindSeat = Seats.NextSeat(smallBlindSeat);
            SetBigBlind(bigBlindSeat);
        }

        private void SetBigBlind(int seatNumber)
        {
            Player bigBlindPlayer = Seats[seatNumber].Player;
            if (bigBlindPlayer == null)
                throw new Exception("Sorry, selected seat is empty!");

            bigBlindPlayer.SetBigBlind();
        }

        private void SetSmallBlind(int seatNumber)
        {
            Player smallBlindPlayer = Seats[seatNumber].Player;
            if (smallBlindPlayer == null)
                throw new Exception("Sorry, selected seat is empty!");

            smallBlindPlayer.SetSmallBlind();
        }
    }
}
