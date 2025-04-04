using FluentAssertions;

namespace CO2Toolkit.Tests
{

    public class ZoneRepositoryTests
    {
        [Test]
        public void CountryCodesAreAllAvailable()
            => ZoneRepository.AvailableCountryIsoCodes.Should().AllSatisfy(code => ZoneRepository.ContryIsAvailable(code));

        [Test]
        public void AvgCarbonGridIntensityIsNeverZero()
            => ZoneRepository.AvailableCountryIsoCodes.Should().AllSatisfy(code
                => ZoneRepository.GetCountryByCode(code).AverageCarbonGridIntensity.Should().BeGreaterThan(0));
    }
}