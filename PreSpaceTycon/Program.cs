using System;

namespace PreSpaceTycon
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			UniverseGenerator gen = new UniverseGenerator ();
			for (int i = 0; i < 20; i++) {
				Console.WriteLine(gen.generateStarSystem ("system " + i, 20, 45, 30));
			}
		}
	}
}
