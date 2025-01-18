﻿using System.Diagnostics;

namespace PokerAlgo
{
	class Program
	{
		private static int _debuVerbosity = Algo._debugVerbosity;

		static void Main(string[] args)
		{
			int executions = 1;
			int inputVerbosity;
			if(args.Length < 1){}
			else if(args.Length == 2 && int.TryParse(args[1], out executions))
			{
				inputVerbosity = 0;
				int.TryParse(args[0], out inputVerbosity);
				if ((inputVerbosity == 0 || inputVerbosity == 1 || inputVerbosity == 2) && executions < 2)
				{
					Algo._debugVerbosity = inputVerbosity;
				}
			}
			else if (args.Length == 1 && int.TryParse(args[0], out inputVerbosity))
			{
				if ((inputVerbosity == 0 || inputVerbosity == 1 || inputVerbosity == 2))
				{
					Algo._debugVerbosity = inputVerbosity;
				}
			}
			else
			{
				throw new Exception("Please Enter Valid Arguments {Number of Executions} {Verbosity Level}");
			}

			Stopwatch watch;
			watch = Stopwatch.StartNew();

			for (int execIndex = 0; execIndex < executions; execIndex++)
			{
				Deck deck = new();
				List<Card> communityCards = new List<Card>();

				List<Player> players = new List<Player>
				{
					new Player("Tom", deck.NextCard(), deck.NextCard()),
					new Player("Matt", deck.NextCard(), deck.NextCard()),
					new Player("Ben", deck.NextCard(), deck.NextCard()),
					new Player("Sam", deck.NextCard(), deck.NextCard()),
					new Player("Jim", deck.NextCard(), deck.NextCard()),
				};

				if (_debuVerbosity > 0)
				{
					Console.WriteLine("--- 🚀 Game Starts");
					Console.WriteLine("--- 😎 Players:");
					foreach (Player p in players)
					{
						Console.WriteLine("\t" + p);
					}
				}

				for (int i = 0; i < 5; i++)
				{
					communityCards.Add(deck.NextCard());
				}

				if (_debuVerbosity > 0)
				{
					Console.Write("\n--- 🃏 Community Cards:\n\t\t");
					foreach (Card c in communityCards)
					{
						Console.Write($"{c} ");
					}
					Console.WriteLine();
				}


				// ! Main Code Execution
				List<Player> winners = Algo.GetWinners(players, communityCards);

				if (_debuVerbosity > 0)
				{
					Console.BackgroundColor = ConsoleColor.Blue;
					Console.ForegroundColor = ConsoleColor.Black;
					Console.Write("🥇 Program.Main() Winners:");
					Console.ResetColor();
					Console.WriteLine();
					foreach (Player p in winners)
					{
						Console.BackgroundColor = ConsoleColor.Yellow;
						Console.ForegroundColor = ConsoleColor.Black;
						Console.Write($"\t {p.Name} ");
						Console.BackgroundColor = ConsoleColor.Green;
						Console.Write($" {p.WinningHand.Type} ");
						Console.BackgroundColor = ConsoleColor.Gray;
						Console.Write(string.Join(' ', p.WinningHand.Cards) + " ");
						Console.ResetColor();
						Console.WriteLine();
						Console.WriteLine();
					}
				}
				// Testing testing = new();
				// !
			}

			watch.Stop();
			Console.WriteLine();
			Console.BackgroundColor = ConsoleColor.Blue;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.Write(executions == 1 ? $" 🕜 Execution Time: {watch.ElapsedMilliseconds}ms " : $" 🕜 Execution Time ({executions} Execs): {watch.ElapsedMilliseconds}ms (Avg {watch.ElapsedMilliseconds/(float)executions}ms)");
			Console.ResetColor();
		}
	}
}

/*
! Current output: Players, Community, Winning Hand for each player.

! ISSUES:
! 

TODO
TODO: Add early break to BreakTies() and BreakTieCommunityLessThanFiveCards() when the winner is the one on the left. Split the list to prevent useless loop runs.
TODO: Update tests and create tests for other methods.

? Future Ideas 
? Make PerformFinderTest more modular. That or make a new Testing system using Attributes and Reflection. Make testing suite?
? Implement custom Exceptions.
? I should make the Algo a nuget package and upload it.
? Full House Logic: The check for Full House could be simplified by directly evaluating the number of threeKinds and pairs. Less branching. if (threeKinds.Count >= 3 && pairs.Count >= 2) { ... }
? Use SortedSet for storing cards when order matters to avoid additional sorting operations.
? Add multiple executions in main method for easier testing.
? Use extensions for better code readability.

* Notes
* "WinningHand nullable? It has been giving me a headache with the warnings." Turns out, it's a good programming pattern.
* 

* Changes
* Removed PlayerWinningObj class.
* Changed and renamed TestObject to HandEvalUnitTest.
* Rewrote Testing class.
* Rewrote Tests for EvaluateFlush.
* Removed IsWinner property from Player.
* 
*/