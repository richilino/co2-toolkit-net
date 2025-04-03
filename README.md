# CO2Toolkit NuGet Package

## Overview

The **CO2Toolkit** NuGet package provides an easy way to estimate the carbon emissions associated with the consumption of digital content. This package uses the Sustainable WebDesign Model V4 from [Sustainable Web Design](https://sustainablewebdesign.org/estimating-digital-emissions/) to calculate the carbon footprint based on various factors such as the amount of data transferred, the energy efficiency of data centres, networks and user devices, and the carbon intensity of the grid.

With the growing need for more sustainable digital practices, this package provides a simple and accurate way to estimate the environmental impact of digital assets, making it easier to assess and optimise the carbon emissions associated with web-based applications.

## Usage

### CO2Calculator Class

The core functionality of this package is provided by the `CO2Calculator` class, which can be used to calculate the carbon emissions for data transfers.

```csharp
using CO2Toolkit;

var co2Calculator = new CO2Calculator();

// Example: Estimate emissions for 1 GB of data transfer
var bytesTransferred = 1_073_741_824;
var emissions = co2Calculator.BytesToEmission(bytesTransferred);

Console.WriteLine($"Estimated CO2 emissions: {emissions} grams");
```

## License

This package is licensed under the MIT License. See the [LICENSE](LICENSE.md) file for more details.

## Contributions

Contributions are welcome! Please fork this repository, create a branch for your feature or fix, and submit a pull request.

---

For more details on digital emissions and the Sustainable Web Design Model, please visit [Sustainable Web Design](https://sustainablewebdesign.org/).
