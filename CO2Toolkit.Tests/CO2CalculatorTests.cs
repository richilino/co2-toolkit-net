using FluentAssertions;

namespace CO2Toolkit.Tests
{
    public class CO2CalculatorTests
    {
        [Test]
        public void TestEmissionsWithNoBytes()
        {
            var calculator = new CO2Calculator();

            var dataTransferredBytes = 0;
            var result = calculator.BytesToEmission(dataTransferredBytes);

            result.Should().BeApproximately(0, 0.1);
        }

        [Test]
        public void TestEmissionsWithStandardConfig()
        {
            var calculator = new CO2Calculator(zone: ZoneRepository.World2021);

            var dataTransferredBytes = 1_073_741_824;
            var result = calculator.BytesToEmission(dataTransferredBytes);

            result.Should().BeApproximately(148.3, 0.1);
        }

        [Test]
        public void TestEmissionsWithPartialGreenHosting()
        {
            var calculator = new CO2Calculator(greenHostingFactor: 0.5, zone: ZoneRepository.World2021);

            var dataTransferredBytes = 1_073_741_824;
            var result = calculator.BytesToEmission(dataTransferredBytes);

            result.Should().BeApproximately(134.7, 0.1);
        }

        [Test]
        public void TestEmissionsWithGreenHosting()
        {
            var calculator = new CO2Calculator(greenHostingFactor: 1, zone: ZoneRepository.World2021);

            var dataTransferredBytes = 1_073_741_824;
            var result = calculator.BytesToEmission(dataTransferredBytes);

            result.Should().BeApproximately(121.03, 0.1);
        }
    }

}