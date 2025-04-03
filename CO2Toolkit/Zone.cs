namespace CO2Toolkit
{
    public sealed class Zone
    {
        public string ThreeLetterCode { get; }
        public string ZoneName { get; }
        public float AverageCarbonGridIntensity { get; }
        public uint Year { get; }

        public Zone(
            string threeLetterCode, 
            string zoneName, 
            float avgCarbonGridIntensity, 
            uint year)
        {
            ThreeLetterCode = threeLetterCode;
            ZoneName = zoneName;
            AverageCarbonGridIntensity = avgCarbonGridIntensity;
            Year = year;
        }
    }
}
