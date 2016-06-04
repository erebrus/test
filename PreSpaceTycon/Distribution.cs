using System;
using System.Collections;

namespace PreSpaceTycon
{
	public class Distribution
	{

		private Hashtable percentages;
		private int total;

		public Distribution(Hashtable percentages)
		{
			this.percentages=percentages;
		}

		public void setPercentages(Hashtable percentages) {
			this.percentages = percentages;
			total=0;
			foreach (DictionaryEntry  e in percentages)
				total+=(int)e.Value;
		}

		public int getValue()
		{
			int val = DefaultRNG.nextInt(total);
			if(val==total)
				val=total-1;
			int sum=0;
			foreach (DictionaryEntry  e in percentages)
			{
				sum+=(int)e.Value;
				if(val<sum)
					return (int)e.Key; 
			}
			throw new ArgumentException("total:"+total+" val:"+val);
		}
		public static Hashtable createPercentageMap(int []values)
		{
			Hashtable map  = new Hashtable();
			for(int i=0;i<values.Length;i++)
			{
				map[i]=values[i];
			}

			return map;
		}
	}
}

