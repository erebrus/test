using System;

namespace PreSpaceTycon
{
	public class StarSystem
	{
		public enum SystemType {PRIMARY, INDUSTRY, SERVICES}
		public int Id { get; set;}
		public string Name{ get; set;}
		public int Services{ get; set;}
		public int Industry{ get; set;}
		public int Primary{ get; set;}
		public int Tolerance{ get; set;}
		public int Culture{ get; set;}
		public int Leisure{ get; set;}
		public int Tourism{ get; set;}
		public int Inhabitability{ get; set;}
		public int Gdp{ get; set;}
		public SystemType Type {
			get {
				if (Services >= Industry && Services >= Primary)
					return SystemType.SERVICES;
				if (Industry >= Primary && Primary >= Services)
					return SystemType.INDUSTRY;
				return SystemType.PRIMARY;
			}
		}
		public double OccupationRate{
			get{
				return Population / (double)Size;
			}
		}


		public int Size{ get; set;}
		public int Population{ get; set;}

		public int X{ get; set;}
		public int Y{ get; set;}

		public StarSystem ()
		{
			
		}


		public override string ToString()
		{
			return string.Format ("[{0}-{1}:({2},{3},{4})]", Id, Name, Services, Industry, Primary);
		}
	}
}

