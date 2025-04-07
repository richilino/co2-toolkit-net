namespace CO2Toolkit
{
    public class ZoneFactory
    {
        private readonly string _name;
        private readonly EmissionAssumption _emissionAssumption;

        private double _weightSum = 0;
        private double _weightedEmissionSum = 0;
        private double _avgEmission = 0;

        private ZoneFactory(string name, EmissionAssumption emissionAssumption)
        {
            _name = name;
            _emissionAssumption = emissionAssumption;
        }

        public static ZoneFactory Create(
            string name,
            EmissionAssumption emissionAssumption = EmissionAssumption.Median)
            => new ZoneFactory(name, emissionAssumption);

        public ZoneFactory WithPowerSource(PowerSource powerSource, double weight)
        {
            _weightedEmissionSum += SelectEmissionFromAssumption(powerSource) * weight;
            _weightSum += weight;
            _avgEmission = _weightedEmissionSum / _weightSum;
            return this;
        }

        public Zone Generate()
            => new Zone(string.Empty, _name, _avgEmission, 0);

        private double SelectEmissionFromAssumption(PowerSource powerSource)
        {
            if (_emissionAssumption.Equals(EmissionAssumption.Optimistic))
                return powerSource.MinLifecycleEmissions;
            if (_emissionAssumption.Equals(EmissionAssumption.Pessimistic))
                return powerSource.MaxLifeCycleEmissions;

            return powerSource.MedianLifeCycleEmissions;
        }

    }
}
