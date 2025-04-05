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

        [TestCase(0, -1)]
        [TestCase(0.5, 0.5)]
        [TestCase(1, 2)]
        public void TestOptionsClampingForGreenHostingFactor(double first, double second)
        {
            var firstCalc = new CO2Calculator(greenHostingFactor: first);
            var secondCalc = new CO2Calculator(greenHostingFactor: second);

            var dataTransferredBytes = 500_000;
            var first_result = firstCalc.BytesToEmission(dataTransferredBytes);
            var second_result = secondCalc.BytesToEmission(dataTransferredBytes);

            first_result.Should().Be(second_result);
        }

        [TestCase(0, -1)]
        [TestCase(0.5, 0.5)]
        [TestCase(1, 2)]
        public void TestOptionsClampingForNewVisitorRatio(double first, double second)
        {
            var firstCalc = new CO2Calculator(newVisitorRatio: first);
            var secondCalc = new CO2Calculator(newVisitorRatio: second);

            var dataTransferredBytes = 500_000;
            var first_result = firstCalc.BytesToEmission(dataTransferredBytes);
            var second_result = secondCalc.BytesToEmission(dataTransferredBytes);

            first_result.Should().Be(second_result);
        }

        [TestCase(0, -1)]
        [TestCase(0.5, 0.5)]
        [TestCase(1, 2)]
        public void TestOptionsClampingForDataCacheRatioo(double first, double second)
        {
            var firstCalc = new CO2Calculator(dataCacheRatio: first);
            var secondCalc = new CO2Calculator(dataCacheRatio: second);

            var dataTransferredBytes = 500_000;
            var first_result = firstCalc.BytesToEmission(dataTransferredBytes);
            var second_result = secondCalc.BytesToEmission(dataTransferredBytes);

            first_result.Should().Be(second_result);
        }
    }

}