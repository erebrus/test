using System;

namespace PreSpaceTycon
{
	public class Game
	{
		public RNG rng { get; private set; }
		private static Game instance = new Game ();
		public static Game get()
		{
			return instance;
		}
		public Game ()
		{
			DefaultRNG.init ();
		}
	}
}

