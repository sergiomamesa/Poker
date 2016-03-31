using System;
using Poker;
namespace MonoConsole
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Table table = new Table(5, 0);
			table.AddPlayer(new Player(500,0));
			table.AddPlayer(new Player(500,0));
			table.AddPlayer(new Player(500,0));
			table.StartGame ();
			bool expected = table.Seats[1].Player.Hand.LeftCard.Equals (null);

			Console.WriteLine (expected.ToString());

			Console.WriteLine ("Success!");
			Console.ReadLine ();
		}
	}
}
