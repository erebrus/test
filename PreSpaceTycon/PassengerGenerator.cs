using System;

namespace PreSpaceTycon
{
	public class PassengerGenerator
	{
		public StarSystem Origin { get; private set;}
		public PassengerGenerator (StarSystem s)
		{
			Origin = s;
		}

		public double GeneratePassengerTo(StarSystem d)
		{
			return GenerateNormalFlowTo (d) + GenerateTourismFlowTo (d) + GenerateMigrationTo (d);
		}

		public double GenerateNormalFlowTo(StarSystem d)
		{
			return (
				Origin.Population*Origin.OccupationRate
				+(d.Leisure+d.Culture)/2
				+d.Population
			)/4.0;
		}
		public double GenerateTourismFlowTo(StarSystem d)
		{
			return (
				Origin.Population
				+ Origin.Gdp
				+ d.Culture / 4
				+ d.Tourism * 7
			) / 11 - 2;
		}
		public double GenerateMigrationTo(StarSystem d)
		{
			if (Origin.Type == StarSystem.SystemType.PRIMARY && d.Type == StarSystem.SystemType.INDUSTRY)
				return GeneratePIMigrationFlow (d);
			if (Origin.Type == StarSystem.SystemType.INDUSTRY && d.Type == StarSystem.SystemType.SERVICES)
				return GenerateISMigrationFlow (d);
			if (Origin.Type == StarSystem.SystemType.SERVICES && d.Type == StarSystem.SystemType.PRIMARY)
				return GenerateSPMigrationFlow (d);
			return 0;
		}
		public double GeneratePIMigrationFlow(StarSystem d)
		{
			return (
				Origin.Population * Origin.OccupationRate + 
				(d.Gdp - Origin.Gdp) / 1.5 -
				(d.Population * d.OccupationRate)
			) / 3;
		}
		public double GenerateISMigrationFlow(StarSystem d)
		{
			return (
				Origin.Population * Origin.OccupationRate 
				+ (d.Gdp - Origin.Gdp) / 1.5
				- (d.Population * d.OccupationRate)
			) / 2;
		}
		public double GenerateSPMigrationFlow(StarSystem d)
		{
			return (
				Origin.Population * Origin.OccupationRate + 
				(Origin.Gdp - d.Gdp)+2*d.Leisure+d.Culture
				- (2*d.Population * d.OccupationRate)
			) / 5*.2;
		}

	}
}

