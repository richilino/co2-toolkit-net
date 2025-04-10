namespace CO2Toolkit
{
    public sealed class PowerSource
    {
        public string Name { get; }
        public double MinLifecycleEmissions { get; }
        public double MedianLifeCycleEmissions { get; }
        public double MaxLifeCycleEmissions { get; }

        public PowerSource(string name,
            double minLifecycleEmissions,
            double medianLifeCycleEmissions,
            double maxLifeCycleEmissions)
        {
            Name = name;
            MinLifecycleEmissions = minLifecycleEmissions;
            MedianLifeCycleEmissions = medianLifeCycleEmissions;
            MaxLifeCycleEmissions = maxLifeCycleEmissions;
        }
    }
}
