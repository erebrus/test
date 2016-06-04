using System;
using System.Collections;
using System.Collections.Generic;

namespace PreSpaceTycon
{
	public class Distribution
	{

		private Dictionary<Int32,Int32> percentages;
		private int total;

		public Distribution(Dictionary<Int32,Int32> percentages)
		{
			setPercentages (percentages);

		}

		public void setPercentages(Dictionary<Int32,Int32> percentages) {
			this.percentages = percentages;
			total=0;
			foreach (KeyValuePair<Int32,Int32>  e in percentages)
				total+=(int)e.Value;
		}

		public int getValue()
		{
			int val = DefaultRNG.nextInt(total);
			if(val==total)
				val=total-1;
			int sum=0;
			foreach (KeyValuePair<Int32,Int32>  e in percentages)
			{
				sum+=e.Value;
				if(val<sum)
					return e.Key; 
			}
			throw new ArgumentException("total:"+total+" val:"+val);
		}
		public static Dictionary<Int32,Int32> createPercentageMap(int []values)
		{
			Dictionary<Int32,Int32> map  = new Dictionary<Int32,Int32>();
			for(int i=0;i<values.Length;i++)
			{
				map[i]=values[i];
			}

			return map;
		}
	}
}

