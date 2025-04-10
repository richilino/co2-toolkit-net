using FluentAssertions;

namespace CO2Toolkit.Tests;

public class ZoneFactoryTest
{

    [Test]
    public void TestZoneFromSinglePowerSourceAndMedianAssumption()
    {
        var target = ZoneFactory.Create("TestZone")
             .WithPowerSource(PowerSourceRepository.Gas, 1)
             .Generate();

        target.AverageCarbonGridIntensity.Should().Be(PowerSourceRepository.Gas.MedianLifeCycleEmissions);
    }

    [Test]
    public void TestZoneFromSinglePowerSourceAndOptimisticAssumption()
    {
        var target = ZoneFactory.Create("TestZone", EmissionAssumption.Optimistic)
             .WithPowerSource(PowerSourceRepository.Gas, 1)
             .Generate();

        target.AverageCarbonGridIntensity.Should().Be(PowerSourceRepository.Gas.MinLifecycleEmissions);
    }

    [Test]
    public void TestZoneFromSinglePowerSourceAndPessimisticAssumption()
    {
        var target = ZoneFactory.Create("TestZone", EmissionAssumption.Pessimistic)
             .WithPowerSource(PowerSourceRepository.Gas, 1)
             .Generate();

        target.AverageCarbonGridIntensity.Should().Be(PowerSourceRepository.Gas.MaxLifeCycleEmissions);
    }

    [Test]
    public void TestZoneFromMultiplePowerSourcesAndMedianAssumption()
    {
        var target = ZoneFactory.Create("TestZone")
             .WithPowerSource(PowerSourceRepository.Gas, 1)
             .WithPowerSource(PowerSourceRepository.Coal, 1)
             .Generate();

        target.AverageCarbonGridIntensity.Should().Be(655);
    }

    [TestCase(EmissionAssumption.Optimistic, 1, 383.66)]
    [TestCase(EmissionAssumption.Median, 1, 444.66)]
    [TestCase(EmissionAssumption.Pessimistic, 1, 1253.33)]
    public void TestZoneFromMultiplePowerSourcesAndAssumption(
        EmissionAssumption emissionAssumption, double weight, double expected)
    {
        var target = ZoneFactory.Create("TestZone", emissionAssumption)
             .WithPowerSource(PowerSourceRepository.Gas, weight)
             .WithPowerSource(PowerSourceRepository.Coal, weight)
             .WithPowerSource(PowerSourceRepository.Hydropower, weight)
             .Generate();

        target.AverageCarbonGridIntensity.Should().BeApproximately(expected, 0.1);
    }

    [TestCase(1, 1, 1, 0.333, 0.333, 0.333)]
    [TestCase(1, 1, 1, 10, 10, 10)]
    [TestCase(2, 1, 1, 0.5, 0.25, 0.25)]
    public void TestZonesWithSimilarWeightsHaveSameEmissions(
        double w11, double w12, double w13, double w21, double w22, double w23)
    {
        var firstTarget = ZoneFactory.Create("TestZone 1")
             .WithPowerSource(PowerSourceRepository.Gas, w11)
             .WithPowerSource(PowerSourceRepository.Coal, w12)
             .WithPowerSource(PowerSourceRepository.WindOffshore, w13)
             .Generate();

        var secondTarget = ZoneFactory.Create("TestZone 2")
             .WithPowerSource(PowerSourceRepository.Gas, w21)
             .WithPowerSource(PowerSourceRepository.Coal, w22)
             .WithPowerSource(PowerSourceRepository.WindOffshore, w23)
             .Generate();

        firstTarget.AverageCarbonGridIntensity
            .Should()
            .BeApproximately(secondTarget.AverageCarbonGridIntensity, 0.1);
    }
}
