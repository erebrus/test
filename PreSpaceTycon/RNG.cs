using System;

namespace PreSpaceTycon
{
	public interface RNG
	{
		int nextInt (int max);
		double nextDouble();
		bool nextBoolean();
	}
}

