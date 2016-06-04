using System;

namespace PreSpaceTycon
{
	public class DefaultRNG 
	{
		private static Random rnd = null;
		private DefaultRNG ()
		{
		}

		public static void init(int seed)
		{
			rnd = new Random (seed);
		}
		public static void init()
		{
			rnd = new Random ();
		}

		public static int nextInt(int max)
		{
			return rnd.Next (max);
		}
		public static double nextDouble()
		{
			return rnd.NextDouble ();
		}
		public static bool nextBoolean()
		{
			return rnd.Next (2) == 1;
		}

	}
}

