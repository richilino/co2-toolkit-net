namespace CO2Toolkit
{
    public sealed class Zone
    {
        public string ThreeLetterCode { get; }
        public string Name { get; }
        public float AverageCarbonGridIntensity { get; }
        public uint Year { get; }

        public Zone(
            string threeLetterCode,
            string name,
            float avgCarbonGridIntensity,
            uint year)
        {
            ThreeLetterCode = threeLetterCode;
            Name = name;
            AverageCarbonGridIntensity = avgCarbonGridIntensity;
            Year = year;
        }
    }
}
