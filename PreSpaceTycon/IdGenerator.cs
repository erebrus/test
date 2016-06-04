using System;

namespace PreSpaceTycon
{
	public class IdGenerator
	{
		private int currentId=0;

		private static IdGenerator instance = new IdGenerator();
		public IdGenerator ()
		{
		}
		public void setCurrentId(int newId)
		{
			currentId = newId;
		}
		public int next()
		{
			currentId++;
			return currentId;
		}
		public static int getNextId()
		{
			return instance.next ();
		}
	}
}

