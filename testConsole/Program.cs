using System;
using Poker;

namespace testConsole
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //var table = Table.CreateTable(seatsNumber, currentPot);
            //table.SeatPlayer(stackSize, seatNumber);
            //table.SeatPlayer(stackSize, seatNumber);
            //table.SeatPlayer(stackSize, seatNumber);
            //table.SeatPlayer(stackSize, seatNumber);
            //When Player is Me
            //var player = new Player(stackSize, seatNumber, true);
            //player.Sethand(LeftCard, RightCard);
            //table.Seatlayer(player);

            //table.SetDealer(seatNumber);

            //table.Flop(card, card, card);
            //table.Turn(card);
            //table.River(card);

            Player player1 = new Player(500, 0);
            Player player2 = new Player(300, 0);
            Player player3 = new Player(200, 0);
            Player player4 = new Player(350, 0, true);
            Player player5 = new Player(30, 0);

            Table table = new Table(9, 300);
            table.AddPlayer(player1, 1);
            table.AddPlayer(player2, 3);
            table.AddPlayer(player3, 4);
            table.AddPlayer(player4, 6);
            table.AddPlayer(player5, 7);

            table.SetDealer(6);

            Card card = new Card(SuitType.Clubs, RankType.Ace);
            table.Flop(card, card, card);
            table.Turn(card);
            table.River(card);
        }
    }
}
