namespace CO2Toolkit
{
    // Using the Sustainable WebDesign Model V4
    // from https://sustainablewebdesign.org/estimating-digital-emissions/
    public sealed class CO2Calculator
    {
        // Constants for operational energy intensities (kWh/GB)
        private const double OperationalEnergyIntensityDataCenters = 0.055;
        private const double OperationalEnergyIntensityNetworks = 0.059;
        private const double OperationalEnergyIntensityUserDevices = 0.080;

        // Constants for embodied energy intensities (kWh/GB)
        private const double EmbodiedEnergyIntensityDataCenters = 0.012;
        private const double EmbodiedEnergyIntensityNetworks = 0.013;
        private const double EmbodiedEnergyIntensityUserDevices = 0.081;

        // Carbon intensity of grid (gCO2e/kWh)
        private const double GridCarbonIntensity = 494;

        // Configuration values passed through the constructor
        private readonly double _greenHostingFactor;
        private readonly double _newVisitorRatio;
        private readonly double _dataCacheRatio;

        public CO2Calculator(
            double greenHostingFactor = 0, 
            double newVisitorRatio = 1, 
            double dataCacheRatio = 0)
        {
            _greenHostingFactor = greenHostingFactor;
            _newVisitorRatio = newVisitorRatio;
            _dataCacheRatio = dataCacheRatio;
        }

        public double BytesToEmission(long bytesTransferred)
        {
            var gigabytesTransferred = bytesTransferred / 1_073_741_824.0;

            var opDC = CalculateEmissions(gigabytesTransferred, OperationalEnergyIntensityDataCenters);
            var opN = CalculateEmissions(gigabytesTransferred, OperationalEnergyIntensityNetworks);
            var opUD = CalculateEmissions(gigabytesTransferred, OperationalEnergyIntensityUserDevices);

            var emDC = CalculateEmissions(gigabytesTransferred, EmbodiedEnergyIntensityDataCenters);
            var emN = CalculateEmissions(gigabytesTransferred, EmbodiedEnergyIntensityNetworks);
            var emUD = CalculateEmissions(gigabytesTransferred, EmbodiedEnergyIntensityUserDevices);

            var returnVisitorRatio = 1 - _newVisitorRatio;

            var totalEmissionsPerPageView = ((opDC * (1 - _greenHostingFactor) + emDC) +
                                                (opN + emN) +
                                                (opUD + emUD)) * _newVisitorRatio +
                                                ((opDC * (1 - _greenHostingFactor) + emDC) +
                                                 (opN + emN) +
                                                 (opUD + emUD)) * returnVisitorRatio * (1 - _dataCacheRatio);

            return totalEmissionsPerPageView;
        }

        private double CalculateEmissions(double gigabytes, double energyIntensity)
        {
            return gigabytes * energyIntensity * GridCarbonIntensity;
        }
    }
}
