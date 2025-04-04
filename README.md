[![OpenSSF Scorecard](https://api.scorecard.dev/projects/github.com/richilino/co2-toolkit-net/badge)](https://scorecard.dev/viewer/?uri=github.com/richilino/co2-toolkit-net)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](/LICENSE.md)

# CO2 Toolkit for DotNet

The **CO2Toolkit** NuGet package provides an easy way to estimate the carbon emissions associated with the consumption of digital content. This package uses the Sustainable Web Design Model V4 from [Sustainable Web Design](https://sustainablewebdesign.org/estimating-digital-emissions/) to calculate the carbon footprint based on various factors such as the amount of data transferred, the energy efficiency of data centres, networks and user devices, and the carbon intensity of the grid.

With the growing need for more sustainable digital practices, this package provides a simple and accurate way to estimate the environmental impact of digital assets, making it easier to assess and optimise the carbon emissions associated with modern .NET applications.

## Usage

### CO2Calculator Class

The core functionality of this package is provided by the `CO2Calculator` class, which can be used to calculate the carbon emissions for data transfers.

```csharp
using CO2Toolkit;

// Calculation based on World Average Carbon Grid Emissions (2023)
var co2Calculator = new CO2Calculator();

// Example: Estimate emissions for 1 GB of data transfer
var bytesTransferred = 1_073_741_824;
var emissions = co2Calculator.BytesToEmission(bytesTransferred);

Console.WriteLine($"Estimated CO2e emissions: {emissions} grams");
```

Calculations can be further adjusted by passing the following options:
- **greenHostingFactor [0-1]**: A value of 0 means 0% of your hosting provider's used power comes from renewable or zero-carbon sources. Conversely, a value of 1 means 100% of your hosting provider's used power comes from renewable or zero-carbon sources
- **newVisitorRatio [0-1]**: A value that represents the number of website visitors who have never visited your page.
- **dataCacheRatio [0-1]**: The ratio of data that is cached for returning visitors.

```csharp
var co2Calculator = new CO2Calculator(
    greenHostingFactor: 0.4, // 40% of power from renewables
    newVisitorRatio: 0.5, // 50% of users have never been on your site
    dataCacheRatio: 0.75 // 75% of content is cached for returning users
    );
```


If you need a more accurate calculation based on a certain geography, check if your desired region is available in the `ZoneRepository`. This will change the CO2 intensity for the _Operational Energy_ needed to transfer data.

```csharp
using CO2Toolkit;

// Calculation based on German Average Carbon Grid Emissions 
var co2Calculator = new CO2Calculator(zone: ZoneRepository.Germany);

// Example: Estimate emissions for 1 GB of data transfer
var bytesTransferred = 1_073_741_824;
var emissions = co2Calculator.BytesToEmission(bytesTransferred);

Console.WriteLine($"Estimated CO2e emissions: {emissions} grams (${ZoneRepository.Germany.Name}, ${ZoneRepository.Germany.Year})");
```

## Acknowledements

All calculations are based on averaged (yearly) CO2 intensity data from the [Ember Electricity Data Explorer (CC-BY-4.0)](https://ember-energy.org/) and are implemented using the [Sustainable Web Design Model (Version 4)](https://sustainablewebdesign.org/).

## License

This package is licensed under the MIT License. See the [LICENSE](LICENSE.md) file for more details.

## Contributions

Contributions are welcome! Please read [Contributing](/CONTRIBUTING.md) to see how you can help improve this package!
