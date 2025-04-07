using System;

namespace CO2Toolkit
{
    // Using the Sustainable WebDesign Model V4
    // from https://sustainablewebdesign.org/estimating-digital-emissions/
    public sealed class CO2Calculator
    {
        // Constants for operational energy intensities (kWh/GB)
        private const double OPERATIONAL_ENERGY_INTENSITY_DATA_CENTERS = 0.055;
        private const double OPERATIONAL_ENERGY_INTENSITY_NETWORKS = 0.059;
        private const double OPERATIONAL_ENERGY_INTENSITY_USER_DEVICES = 0.080;

        // Constants for embodied energy intensities (kWh/GB)
        private const double EMBODIED_ENERGY_INTENSITY_DATA_CENTERS = 0.012;
        private const double EMBODIED_ENERGY_INTENSITY_NETWORKS = 0.013;
        private const double EMBODIED_ENERGY_INTENSITY_USER_DEVICES = 0.081;

        // Carbon intensity of global grid (gCO2e/kWh)
        private const double GLOBAL_CARBON_INTENSITY_2021 = 494;

        // Configuration values passed through the constructor
        private readonly double _greenHostingFactor;
        private readonly double _newVisitorRatio;
        private readonly double _dataCacheRatio;
        private readonly Zone _zone;

        public CO2Calculator(
            double greenHostingFactor = 0,
            double newVisitorRatio = 1,
            double dataCacheRatio = 0,
            Zone zone = null)
        {
            _greenHostingFactor = Clamp(greenHostingFactor, min: 0, max: 1);
            _newVisitorRatio = Clamp(newVisitorRatio, min: 0, max: 1);
            _dataCacheRatio = Clamp(dataCacheRatio, min: 0, max: 1);
            _zone = zone ?? ZoneRepository.World2023;
        }

        public double KilowattHoursToEmission(double kWh)
            => kWh * _zone.AverageCarbonGridIntensity;

        public double BytesToEmission(long bytesTransferred)
        {
            var gigabytesTransferred = bytesTransferred / 1_073_741_824.0;

            var opDC = CalculateOperationalEmissions(gigabytesTransferred, OPERATIONAL_ENERGY_INTENSITY_DATA_CENTERS);
            var opN = CalculateOperationalEmissions(gigabytesTransferred, OPERATIONAL_ENERGY_INTENSITY_NETWORKS);
            var opUD = CalculateOperationalEmissions(gigabytesTransferred, OPERATIONAL_ENERGY_INTENSITY_USER_DEVICES);

            var emDC = CalculateEmbodiedEmissions(gigabytesTransferred, EMBODIED_ENERGY_INTENSITY_DATA_CENTERS);
            var emN = CalculateEmbodiedEmissions(gigabytesTransferred, EMBODIED_ENERGY_INTENSITY_NETWORKS);
            var emUD = CalculateEmbodiedEmissions(gigabytesTransferred, EMBODIED_ENERGY_INTENSITY_USER_DEVICES);

            var returnVisitorRatio = 1 - _newVisitorRatio;

            var totalEmissionsPerPageView = ((opDC * (1 - _greenHostingFactor) + emDC) +
                                                (opN + emN) +
                                                (opUD + emUD)) * _newVisitorRatio +
                                                ((opDC * (1 - _greenHostingFactor) + emDC) +
                                                 (opN + emN) +
                                                 (opUD + emUD)) * returnVisitorRatio * (1 - _dataCacheRatio);

            return totalEmissionsPerPageView;
        }

        private double CalculateOperationalEmissions(double gigabytes, double energyIntensity)
            => gigabytes * energyIntensity * _zone.AverageCarbonGridIntensity;

        private double CalculateEmbodiedEmissions(double gigabytes, double energyIntensity)
            => gigabytes * energyIntensity * GLOBAL_CARBON_INTENSITY_2021;

        private double Clamp(double value, double min, double max)
            => Math.Max(Math.Min(value, max), min);
    }
}
