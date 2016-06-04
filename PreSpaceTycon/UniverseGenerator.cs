using System;

namespace PreSpaceTycon
{
	public class UniverseGenerator
	{
		public UniverseGenerator ()
		{
			DefaultRNG.init ();
		}

		public StarSystem generateStarSystem(string name, int bs, int bi, int bp)
		{
			StarSystem ret = new StarSystem();
			ret.Id = IdGenerator.getNextId ();
			ret.Name=name;

			int points=4+DefaultRNG.nextInt(5);
			ret.Size=points;
			ret.Population = points*2+DefaultRNG.nextInt(2);
			ret.X=DefaultRNG.nextInt(50);
			ret.Y=DefaultRNG.nextInt(50);
			while(points>0)
			{
				Distribution d = new Distribution(Distribution.createPercentageMap(new int[]{bs,bi,bp}));
				int selection = d.getValue();
				switch(selection)
				{
				case 0:
					ret.Services++;
					if(bs<72 && bi>10 && bp>10)
					{
						bs+=8;
						bi-=4;
						bp-=4;
					}					

					break;
				case 1:
					ret.Industry++;
					if(bi<82 && bs>3 && bp>3)
					{
						bi+=8;
						bs-=4;
						bp-=4;
					}					
					break;
				case 2:
					ret.Primary++;
					if(bp<82 && bs>3 && bi>3)
					{
						bp+=8;
						bi-=4;
						bs-=4;
					}

					break;
				default:
					throw new ArgumentException("Invalid distribution. Should never happen.");
				}

				points--;

			}
			ret.Leisure=2*ret.Services-2*ret.Industry+3*ret.Primary+DefaultRNG.nextInt(5);
			ret.Culture=3*ret.Services-ret.Industry+DefaultRNG.nextInt(5);
			ret.Tourism=3*ret.Primary+ret.Leisure+ret.Culture-5*ret.Industry+DefaultRNG.nextInt(10);
			ret.Tolerance=DefaultRNG.nextInt(5)+ret.Culture;
			ret.Inhabitability=DefaultRNG.nextInt(10)+ret.Leisure*3-2*ret.Industry;
			ret.Gdp = DefaultRNG.nextInt (5) + 3 * ret.Services + ret.Industry - ret.Primary;
			if(ret.Leisure<0)
				ret.Leisure=0;
			if(ret.Culture<0)
				ret.Culture=0;
			if(ret.Tolerance<0)
				ret.Tolerance=0;
			if(ret.Tourism<0)
				ret.Tourism=0;
			if(ret.Inhabitability<ret.Population+2)
				ret.Inhabitability=(ret.Population+2);
			if(ret.Gdp<1)
				ret.Gdp=1;
			return ret;
		}
	}



}

