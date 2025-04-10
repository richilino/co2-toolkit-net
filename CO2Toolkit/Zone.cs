namespace CO2Toolkit
{
    public sealed class Zone
    {
        public string ThreeLetterCode { get; }
        public string Name { get; }
        public double AverageCarbonGridIntensity { get; }
        public uint Year { get; }

        public Zone(
            string threeLetterCode,
            string name,
            double avgCarbonGridIntensity,
            uint year)
        {
            ThreeLetterCode = threeLetterCode;
            Name = name;
            AverageCarbonGridIntensity = avgCarbonGridIntensity;
            Year = year;
        }
    }
}
