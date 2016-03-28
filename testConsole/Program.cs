using System;
using Poker;

namespace testConsole
{
	class MainClass
	{
		public static void Main (string[] args)
		{
//			Console.WriteLine ("Hello World!");

			Table table = new Table (4);
			table.AddPlayer(new Player() { Name = "Player1" });
			table.AddPlayer(new Player() { Name = "Player2" });
			table.AddPlayer(new Player() { Name = "Player3" });

			table.StartGame ();
			Console.WriteLine ("success!!");
			Console.ReadLine ();

		}
	}
}
