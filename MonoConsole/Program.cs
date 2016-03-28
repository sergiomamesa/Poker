using System;
using Poker;
namespace MonoConsole
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Table table = new Table(5);
			table.AddPlayer(new Player() { Name = "Player1" });
			table.AddPlayer(new Player() { Name = "Player2" });
			table.AddPlayer(new Player() { Name = "Player3" });
			table.StartGame ();
			bool expected = table.Seats [1].Player.Hand.LeftCard.Equals (null);

			Console.WriteLine (expected.ToString());

			Console.WriteLine ("Success!");
			Console.ReadLine ();
		}
	}
}
