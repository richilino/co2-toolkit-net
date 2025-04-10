namespace CO2Toolkit
{
    // Data Source: IPCC (2014), ANNEX III, Table A.III.2: Emissions of selected electricity supply technologies (gCO2eq/kWh)
    // available at https://www.ipcc.ch/site/assets/uploads/2018/02/ipcc_wg3_ar5_annex-iii.pdf
    public static class PowerSourceRepository
    {
        public static PowerSource Coal = new PowerSource("Coal (PC)", 740, 820, 910);
        public static PowerSource Gas = new PowerSource("Gas (Combined Cycle)", 410, 490, 650);
        public static PowerSource BiomassCofiring = new PowerSource("Biomass (cofiring)", 620, 740, 890);
        public static PowerSource BiomassDedicated = new PowerSource("GBiomass (dedicated)", 130, 230, 420);
        public static PowerSource Geothermal = new PowerSource("Geothermal", 6, 38, 79);
        public static PowerSource Hydropower = new PowerSource("Hydropower", 1, 24, 2200);
        public static PowerSource Nuclear = new PowerSource("Nuclear", 3.7, 12, 110);
        public static PowerSource SolarConcentrated = new PowerSource("Solar (concentrated)", 8.8, 27, 63);
        public static PowerSource SolarRooftop = new PowerSource("Solar (rooftop)", 26, 41, 60);
        public static PowerSource SolarUtility = new PowerSource("Solar (utility)", 18, 48, 180);
        public static PowerSource WindOnshore = new PowerSource("Wind (onshore)", 7.0, 11, 56);
        public static PowerSource WindOffshore = new PowerSource("Wind (onshore)", 8, 12, 35);
    }
}
