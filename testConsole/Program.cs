using System;
using Poker;

namespace testConsole
{
    class MainClass
    {
        public static void Main(string[] args)
        {
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

            //TODO: Pending set Dealer for knowing BB and SB
            table.SetAsDealer(6);

            Card card = new Card(SuitType.Clubs, RankType.Ace);
            table.Flop(card, card, card);
            table.Turn(card);
            table.River(card);
        }
    }
}
