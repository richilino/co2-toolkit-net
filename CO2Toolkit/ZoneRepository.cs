using System.Collections.Generic;

namespace CO2Toolkit
{
    // Source: Ember Electricity Data Explorer, ember-energy.org
    // All their content is released under a Creative Commons Attribution Licence (CC-BY-4.0)
    public static class ZoneRepository
    {
        private static readonly Dictionary<string, Zone> _isoCodeZoneMap
            = new Dictionary<string, Zone>()
            {
                { "AFG", new Zone("AFG", "Afghanistan", 123.71f, 2023) },
                { "ALB", new Zone("ALB", "Albania", 24.42f, 2023) },
                { "DZA", new Zone("DZA", "Algeria", 633.65f, 2023) },
                { "ASM", new Zone("ASM", "American Samoa", 647.06f, 2023) },
                { "AGO", new Zone("AGO", "Angola", 167.22f, 2023) },
                { "ATG", new Zone("ATG", "Antigua and Barbuda", 611.11f, 2023) },
                { "ARG", new Zone("ARG", "Argentina", 353.96f, 2023) },
                { "ARM", new Zone("ARM", "Armenia", 262.43f, 2023) },
                { "ABW", new Zone("ABW", "Aruba", 550.00f, 2022) },
                { "AUS", new Zone("AUS", "Australia", 556.30f, 2023) },
                { "AUT", new Zone("AUT", "Austria", 102.62f, 2024) },
                { "AZE", new Zone("AZE", "Azerbaijan", 669.99f, 2023) },
                { "BHR", new Zone("BHR", "Bahrain", 902.41f, 2023) },
                { "BGD", new Zone("BGD", "Bangladesh", 683.12f, 2023) },
                { "BRB", new Zone("BRB", "Barbados", 600.00f, 2023) },
                { "BLR", new Zone("BLR", "Belarus", 313.62f, 2024) },
                { "BEL", new Zone("BEL", "Belgium", 117.58f, 2024) },
                { "BLZ", new Zone("BLZ", "Belize", 155.56f, 2023) },
                { "BEN", new Zone("BEN", "Benin", 590.00f, 2023) },
                { "BMU", new Zone("BMU", "Bermuda", 640.63f, 2023) },
                { "BTN", new Zone("BTN", "Bhutan", 24.19f, 2023) },
                { "BOL", new Zone("BOL", "Bolivia", 489.11f, 2023) },
                { "BIH", new Zone("BIH", "Bosnia Herzegovina", 637.20f, 2024) },
                { "BWA", new Zone("BWA", "Botswana", 849.42f, 2023) },
                { "BRA", new Zone("BRA", "Brazil", 96.40f, 2023) },
                { "BRN", new Zone("BRN", "Brunei Darussalam", 892.67f, 2023) },
                { "BGR", new Zone("BGR", "Bulgaria", 264.21f, 2024) },
                { "BFA", new Zone("BFA", "Burkina Faso", 554.91f, 2023) },
                { "BDI", new Zone("BDI", "Burundi", 230.77f, 2023) },
                { "CPV", new Zone("CPV", "Cabo Verde", 480.00f, 2022) },
                { "KHM", new Zone("KHM", "Cambodia", 470.59f, 2023) },
                { "CMR", new Zone("CMR", "Cameroon", 285.71f, 2023) },
                { "CAN", new Zone("CAN", "Canada", 165.15f, 2023) },
                { "TCD", new Zone("TCD", "Chad", 615.39f, 2022) },
                { "CHL", new Zone("CHL", "Chile", 301.93f, 2023) },
                { "CHN", new Zone("CHN", "China", 583.61f, 2023) },
                { "COL", new Zone("COL", "Colombia", 268.97f, 2023) },
                { "CRI", new Zone("CRI", "Costa Rica", 24.77f, 2023) },
                { "HRV", new Zone("HRV", "Croatia", 174.48f, 2024) },
                { "CUB", new Zone("CUB", "Cuba", 638.98f, 2023) },
                { "CYP", new Zone("CYP", "Cyprus", 512.24f, 2024) },
                { "CZE", new Zone("CZE", "Czechia", 413.86f, 2024) },
                { "DNK", new Zone("DNK", "Denmark", 143.30f, 2024) },
                { "DJI", new Zone("DJI", "Djibouti", 450.00f, 2023) },
                { "DMA", new Zone("DMA", "Dominica", 600.00f, 2023) },
                { "ECU", new Zone("ECU", "Ecuador", 176.28f, 2023) },
                { "EGY", new Zone("EGY", "Egypt", 574.04f, 2023) },
                { "SLV", new Zone("SLV", "El Salvador", 118.46f, 2023) },
                { "GNQ", new Zone("GNQ", "Equatorial Guinea", 605.10f, 2023) },
                { "ERI", new Zone("ERI", "Eritrea", 590.91f, 2023) },
                { "EST", new Zone("EST", "Estonia", 341.02f, 2024) },
                { "SWZ", new Zone("SWZ", "Eswatini", 142.86f, 2023) },
                { "ETH", new Zone("ETH", "Ethiopia", 23.55f, 2023) },
                { "FJI", new Zone("FJI", "Fiji", 278.26f, 2023) },
                { "FIN", new Zone("FIN", "Finland", 72.25f, 2024) },
                { "FRA", new Zone("FRA", "France", 44.18f, 2024) },
                { "GUF", new Zone("GUF", "French Guiana", 204.08f, 2022) },
                { "PYF", new Zone("PYF", "French Polynesia", 436.62f, 2022) },
                { "GAB", new Zone("GAB", "Gabon", 429.47f, 2023) },
                { "GEO", new Zone("GEO", "Georgia", 168.06f, 2023) },
                { "DEU", new Zone("DEU", "Germany", 344.14f, 2024) },
                { "GHA", new Zone("GHA", "Ghana", 452.86f, 2023) },
                { "GIB", new Zone("GIB", "Gibraltar", 590.91f, 2023) },
                { "GRC", new Zone("GRC", "Greece", 319.76f, 2024) },
                { "GRL", new Zone("GRL", "Greenland", 111.11f, 2022) },
                { "GRD", new Zone("GRD", "Grenada", 666.67f, 2022) },
                { "GLP", new Zone("GLP", "Guadeloupe", 493.90f, 2022) },
                { "GUM", new Zone("GUM", "Guam", 611.11f, 2022) },
                { "GTM", new Zone("GTM", "Guatemala", 272.66f, 2023) },
                { "GIN", new Zone("GIN", "Guinea", 182.72f, 2023) },
                { "GUY", new Zone("GUY", "Guyana", 634.33f, 2023) },
                { "HTI", new Zone("HTI", "Haiti", 534.65f, 2022) },
                { "HND", new Zone("HND", "Honduras", 289.50f, 2023) },
                { "HKG", new Zone("HKG", "Hong Kong", 681.99f, 2023) },
                { "HUN", new Zone("HUN", "Hungary", 182.82f, 2024) },
                { "ISL", new Zone("ISL", "Iceland", 28.33f, 2023) },
                { "IND", new Zone("IND", "India", 713.01f, 2023) },
                { "IDN", new Zone("IDN", "Indonesia", 682.43f, 2023) },
                { "IRQ", new Zone("IRQ", "Iraq", 689.40f, 2023) },
                { "IRL", new Zone("IRL", "Ireland", 279.70f, 2024) },
                { "ISR", new Zone("ISR", "Israel", 567.26f, 2023) },
                { "ITA", new Zone("ITA", "Italy", 287.53f, 2024) },
                { "JAM", new Zone("JAM", "Jamaica", 561.25f, 2022) },
                { "JPN", new Zone("JPN", "Japan", 493.59f, 2023) },
                { "JOR", new Zone("JOR", "Jordan", 539.21f, 2022) },
                { "KAZ", new Zone("KAZ", "Kazakhstan", 821.90f, 2023) },
                { "KEN", new Zone("KEN", "Kenya", 96.95f, 2023) },
                { "KIR", new Zone("KIR", "Kiribati", 500.00f, 2022) },
                { "XKX", new Zone("XKX", "Kosovo", 958.72f, 2024) },
                { "KWT", new Zone("KWT", "Kuwait", 636.91f, 2023) },
                { "KGZ", new Zone("KGZ", "Kyrgyzstan", 150.77f, 2023) },
                { "LVA", new Zone("LVA", "Latvia", 136.22f, 2024) },
                { "LBN", new Zone("LBN", "Lebanon", 369.47f, 2023) },
                { "LSO", new Zone("LSO", "Lesotho", 20.83f, 2022) },
                { "LBR", new Zone("LBR", "Liberia", 435.90f, 2023) },
                { "LBY", new Zone("LBY", "Libya", 830.53f, 2023) },
                { "LTU", new Zone("LTU", "Lithuania", 139.34f, 2024) },
                { "LUX", new Zone("LUX", "Luxembourg", 134.62f, 2024) },
                { "MAC", new Zone("MAC", "Macao", 448.98f, 2022) },
                { "MDG", new Zone("MDG", "Madagascar", 477.27f, 2022) },
                { "MWI", new Zone("MWI", "Malawi", 54.65f, 2022) },
                { "MYS", new Zone("MYS", "Malaysia", 607.88f, 2023) },
                { "MDV", new Zone("MDV", "Maldives", 611.77f, 2023) },
                { "MLI", new Zone("MLI", "Mali", 394.50f, 2023) },
                { "MLT", new Zone("MLT", "Malta", 484.16f, 2024) },
                { "MTQ", new Zone("MTQ", "Martinique", 516.78f, 2022) },
                { "MRT", new Zone("MRT", "Mauritania", 481.71f, 2022) },
                { "MUS", new Zone("MUS", "Mauritius", 633.03f, 2023) },
                { "MEX", new Zone("MEX", "Mexico", 492.34f, 2023) },
                { "MDA", new Zone("MDA", "Moldova", 631.68f, 2024) },
                { "MNG", new Zone("MNG", "Mongolia", 785.08f, 2023) },
                { "MNE", new Zone("MNE", "Montenegro", 413.51f, 2024) },
                { "MSR", new Zone("MSR", "Montserrat", 1000.00f, 2022) },
                { "MAR", new Zone("MAR", "Morocco", 616.82f, 2023) },
                { "MOZ", new Zone("MOZ", "Mozambique", 127.81f, 2023) },
                { "MMR", new Zone("MMR", "Myanmar", 588.95f, 2023) },
                { "NAM", new Zone("NAM", "Namibia", 47.62f, 2023) },
                { "NRU", new Zone("NRU", "Nauru", 750.00f, 2023) },
                { "NPL", new Zone("NPL", "Nepal", 23.36f, 2022) },
                { "NLD", new Zone("NLD", "Netherlands", 253.31f, 2024) },
                { "NCL", new Zone("NCL", "New Caledonia", 585.76f, 2022) },
                { "NZL", new Zone("NZL", "New Zealand", 104.42f, 2023) },
                { "NIC", new Zone("NIC", "Nicaragua", 288.33f, 2023) },
                { "NGA", new Zone("NGA", "Nigeria", 508.82f, 2023) },
                { "MKD", new Zone("MKD", "North Macedonia", 568.97f, 2024) },
                { "NOR", new Zone("NOR", "Norway", 30.75f, 2024) },
                { "OMN", new Zone("OMN", "Oman", 545.88f, 2023) },
                { "PAK", new Zone("PAK", "Pakistan", 425.69f, 2023) },
                { "PAN", new Zone("PAN", "Panama", 258.74f, 2023) },
                { "PNG", new Zone("PNG", "Papua New Guinea", 513.74f, 2023) },
                { "PRY", new Zone("PRY", "Paraguay", 24.86f, 2023) },
                { "PER", new Zone("PER", "Peru", 300.53f, 2023) },
                { "POL", new Zone("POL", "Poland", 614.98f, 2024) },
                { "PRT", new Zone("PRT", "Portugal", 112.29f, 2024) },
                { "PRI", new Zone("PRI", "Puerto Rico", 660.80f, 2023) },
                { "QAT", new Zone("QAT", "Qatar", 602.65f, 2023) },
                { "REU", new Zone("REU", "Reunion", 525.22f, 2022) },
                { "ROU", new Zone("ROU", "Romania", 245.55f, 2024) },
                { "RWA", new Zone("RWA", "Rwanda", 301.89f, 2023) },
                { "KNA", new Zone("KNA", "Saint Kitts and Nevis", 636.36f, 2022) },
                { "LCA", new Zone("LCA", "Saint Lucia", 650.00f, 2022) },
                { "SPM", new Zone("SPM", "Saint Pierre and Miquelon", 600.00f, 2022) },
                { "VCT", new Zone("VCT", "Saint Vincent and the Grenadines", 600.00f, 2023) },
                { "WSM", new Zone("WSM", "Samoa", 400.00f, 2023) },
                { "STP", new Zone("STP", "Sao Tome and Principe", 555.56f, 2022) },
                { "SAU", new Zone("SAU", "Saudi Arabia", 696.31f, 2023) },
                { "SEN", new Zone("SEN", "Senegal", 535.40f, 2023) },
                { "SRB", new Zone("SRB", "Serbia", 673.16f, 2024) },
                { "SYC", new Zone("SYC", "Seychelles", 571.43f, 2023) },
                { "SLE", new Zone("SLE", "Sierra Leone", 47.62f, 2023) },
                { "SGP", new Zone("SGP", "Singapore", 500.87f, 2023) },
                { "SVK", new Zone("SVK", "Slovakia", 96.49f, 2024) },
                { "SVN", new Zone("SVN", "Slovenia", 227.65f, 2024) },
                { "SLB", new Zone("SLB", "Solomon Islands", 636.36f, 2023) },
                { "SOM", new Zone("SOM", "Somalia", 523.81f, 2023) },
                { "ZAF", new Zone("ZAF", "South Africa", 709.69f, 2023) },
                { "KOR", new Zone("KOR", "South Korea", 432.11f, 2023) },
                { "SSD", new Zone("SSD", "South Sudan", 610.17f, 2023) },
                { "ESP", new Zone("ESP", "Spain", 146.15f, 2024) },
                { "SUR", new Zone("SUR", "Suriname", 383.18f, 2023) },
                { "SWE", new Zone("SWE", "Sweden", 35.82f, 2024) },
                { "CHE", new Zone("CHE", "Switzerland", 36.60f, 2024) },
                { "TWN", new Zone("TWN", "Taiwan", 644.40f, 2023) },
                { "TJK", new Zone("TJK", "Tajikistan", 87.50f, 2023) },
                { "THA", new Zone("THA", "Thailand", 549.85f, 2023) },
                { "TGO", new Zone("TGO", "Togo", 478.26f, 2023) },
                { "TON", new Zone("TON", "Tonga", 571.43f, 2023) },
                { "TTO", new Zone("TTO", "Trinidad and Tobago", 682.11f, 2023) },
                { "TUN", new Zone("TUN", "Tunisia", 560.36f, 2023) },
                { "TUR", new Zone("TUR", "Turkey", 469.70f, 2024) },
                { "TKM", new Zone("TKM", "Turkmenistan", 1306.30f, 2023) },
                { "UGA", new Zone("UGA", "Uganda", 57.39f, 2022) },
                { "UKR", new Zone("UKR", "Ukraine", 162.13f, 2024) },
                { "ARE", new Zone("ARE", "United Arab Emirates", 492.70f, 2023) },
                { "GBR", new Zone("GBR", "United Kingdom", 210.89f, 2024) },
                { "USA", new Zone("USA", "United States of America", 392.85f, 2023) },
                { "URY", new Zone("URY", "Uruguay", 115.68f, 2023) },
                { "UZB", new Zone("UZB", "Uzbekistan", 1121.18f, 2023) },
                { "VUT", new Zone("VUT", "Vanuatu", 500.00f, 2023) },
                { "VNM", new Zone("VNM", "Viet Nam", 472.47f, 2023) },
                { "ESH", new Zone("ESH", "Western Sahara", 666.67f, 2009) },
                { "YEM", new Zone("YEM", "Yemen", 586.32f, 2023) },
                { "ZMB", new Zone("ZMB", "Zambia", 111.00f, 2023) },
                { "ZWE", new Zone("ZWE", "Zimbabwe", 298.44f, 2023) },
            };

        public static IEnumerable<string> AvailableCountryIsoCodes
            = _isoCodeZoneMap.Keys;

        // World
        public static Zone World2000 = new Zone(string.Empty, "World", 527.27f, 2000);
        public static Zone World2010 = new Zone(string.Empty, "World", 543.84f, 2010);
        public static Zone World2019 = new Zone(string.Empty, "World", 505.47f, 2019);
        public static Zone World2021 = new Zone(string.Empty, "World", 494.70f, 2021);
        public static Zone World2023 = new Zone(string.Empty, "World", 484.40f, 2023);

        // Institutions
        public static Zone G20 = new Zone(string.Empty, "G20", 481.51f, 2023);
        public static Zone G7 = new Zone(string.Empty, "G7", 353.61f, 2023);
        public static Zone OECD = new Zone(string.Empty, "OECD", 349.67f, 2023);
        public static Zone EU = new Zone(string.Empty, "Eu", 213.31f, 2024);

        // Regions
        public static Zone Africa = new Zone(string.Empty, "Africa", 541.36f, 2023);
        public static Zone Asean = new Zone(string.Empty, "Asean", 570.01f, 2023);
        public static Zone Asia = new Zone(string.Empty, "Asia", 590.39f, 2023);
        public static Zone Europe = new Zone(string.Empty, "Europe", 284.31f, 2024);
        public static Zone LatinAmerica = new Zone(string.Empty, "Latinamerica and Caribbean", 258.14f, 2023);
        public static Zone Middleeast = new Zone(string.Empty, "Middleeast", 641.21f, 2023);
        public static Zone Northamerica = new Zone(string.Empty, "Northamerica", 363.32f, 2023);
        public static Zone Oceania = new Zone(string.Empty, "Oceania", 494.76f, 2023);

        // Main
        public static Zone Afghanistan = _isoCodeZoneMap["AFG"];
        public static Zone Albania = _isoCodeZoneMap["ALB"];
        public static Zone Algeria = _isoCodeZoneMap["DZA"];
        public static Zone AmericanSamoa = _isoCodeZoneMap["ASM"];
        public static Zone Angola = _isoCodeZoneMap["AGO"];
        public static Zone AntiguaAndBarbuda = _isoCodeZoneMap["ATG"];
        public static Zone Argentina = _isoCodeZoneMap["ARG"];
        public static Zone Armenia = _isoCodeZoneMap["ARM"];
        public static Zone Aruba = _isoCodeZoneMap["ABW"];
        public static Zone Australia = _isoCodeZoneMap["AUS"];
        public static Zone Austria = _isoCodeZoneMap["AUT"];
        public static Zone Azerbaijan = _isoCodeZoneMap["AZE"];
        public static Zone Bahrain = _isoCodeZoneMap["BHR"];
        public static Zone Bangladesh = _isoCodeZoneMap["BGD"];
        public static Zone Barbados = _isoCodeZoneMap["BRB"];
        public static Zone Belarus = _isoCodeZoneMap["BLR"];
        public static Zone Belgium = _isoCodeZoneMap["BEL"];
        public static Zone Belize = _isoCodeZoneMap["BLZ"];
        public static Zone Benin = _isoCodeZoneMap["BEN"];
        public static Zone Bermuda = _isoCodeZoneMap["BMU"];
        public static Zone Bhutan = _isoCodeZoneMap["BTN"];
        public static Zone Bolivia = _isoCodeZoneMap["BOL"];
        public static Zone BosniaHerzegovina = _isoCodeZoneMap["BIH"];
        public static Zone Botswana = _isoCodeZoneMap["BWA"];
        public static Zone Brazil = _isoCodeZoneMap["BRA"];
        public static Zone BruneiDarussalam = _isoCodeZoneMap["BRN"];
        public static Zone Bulgaria = _isoCodeZoneMap["BGR"];
        public static Zone BurkinaFaso = _isoCodeZoneMap["BFA"];
        public static Zone Burundi = _isoCodeZoneMap["BDI"];
        public static Zone CaboVerde = _isoCodeZoneMap["CPV"];
        public static Zone Cambodia = _isoCodeZoneMap["KHM"];
        public static Zone Cameroon = _isoCodeZoneMap["CMR"];
        public static Zone Canada = _isoCodeZoneMap["CAN"];
        public static Zone Chad = _isoCodeZoneMap["TCD"];
        public static Zone Chile = _isoCodeZoneMap["CHL"];
        public static Zone China = _isoCodeZoneMap["CHN"];
        public static Zone Colombia = _isoCodeZoneMap["COL"];
        public static Zone CostaRica = _isoCodeZoneMap["CRI"];
        public static Zone Croatia = _isoCodeZoneMap["HRV"];
        public static Zone Cuba = _isoCodeZoneMap["CUB"];
        public static Zone Cyprus = _isoCodeZoneMap["CYP"];
        public static Zone Czechia = _isoCodeZoneMap["CZE"];
        public static Zone Denmark = _isoCodeZoneMap["DNK"];
        public static Zone Djibouti = _isoCodeZoneMap["DJI"];
        public static Zone Dominica = _isoCodeZoneMap["DMA"];
        public static Zone Ecuador = _isoCodeZoneMap["ECU"];
        public static Zone Egypt = _isoCodeZoneMap["EGY"];
        public static Zone ElSalvador = _isoCodeZoneMap["SLV"];
        public static Zone EquatorialGuinea = _isoCodeZoneMap["GNQ"];
        public static Zone Eritrea = _isoCodeZoneMap["ERI"];
        public static Zone Estonia = _isoCodeZoneMap["EST"];
        public static Zone Eswatini = _isoCodeZoneMap["SWZ"];
        public static Zone Ethiopia = _isoCodeZoneMap["ETH"];
        public static Zone Fiji = _isoCodeZoneMap["FJI"];
        public static Zone Finland = _isoCodeZoneMap["FIN"];
        public static Zone France = _isoCodeZoneMap["FRA"];
        public static Zone FrenchGuiana = _isoCodeZoneMap["GUF"];
        public static Zone FrenchPolynesia = _isoCodeZoneMap["PYF"];
        public static Zone Gabon = _isoCodeZoneMap["GAB"];
        public static Zone Georgia = _isoCodeZoneMap["GEO"];
        public static Zone Germany = _isoCodeZoneMap["DEU"];
        public static Zone Ghana = _isoCodeZoneMap["GHA"];
        public static Zone Gibraltar = _isoCodeZoneMap["GIB"];
        public static Zone Greece = _isoCodeZoneMap["GRC"];
        public static Zone Greenland = _isoCodeZoneMap["GRL"];
        public static Zone Grenada = _isoCodeZoneMap["GRD"];
        public static Zone Guadeloupe = _isoCodeZoneMap["GLP"];
        public static Zone Guam = _isoCodeZoneMap["GUM"];
        public static Zone Guatemala = _isoCodeZoneMap["GTM"];
        public static Zone Guinea = _isoCodeZoneMap["GIN"];
        public static Zone Guyana = _isoCodeZoneMap["GUY"];
        public static Zone Haiti = _isoCodeZoneMap["HTI"];
        public static Zone Honduras = _isoCodeZoneMap["HND"];
        public static Zone HongKong = _isoCodeZoneMap["HKG"];
        public static Zone Hungary = _isoCodeZoneMap["HUN"];
        public static Zone Iceland = _isoCodeZoneMap["ISL"];
        public static Zone India = _isoCodeZoneMap["IND"];
        public static Zone Indonesia = _isoCodeZoneMap["IDN"];
        public static Zone Iraq = _isoCodeZoneMap["IRQ"];
        public static Zone Ireland = _isoCodeZoneMap["IRL"];
        public static Zone Israel = _isoCodeZoneMap["ISR"];
        public static Zone Italy = _isoCodeZoneMap["ITA"];
        public static Zone Jamaica = _isoCodeZoneMap["JAM"];
        public static Zone Japan = _isoCodeZoneMap["JPN"];
        public static Zone Jordan = _isoCodeZoneMap["JOR"];
        public static Zone Kazakhstan = _isoCodeZoneMap["KAZ"];
        public static Zone Kenya = _isoCodeZoneMap["KEN"];
        public static Zone Kiribati = _isoCodeZoneMap["KIR"];
        public static Zone Kosovo = _isoCodeZoneMap["XKX"];
        public static Zone Kuwait = _isoCodeZoneMap["KWT"];
        public static Zone Kyrgyzstan = _isoCodeZoneMap["KGZ"];
        public static Zone Latvia = _isoCodeZoneMap["LVA"];
        public static Zone Lebanon = _isoCodeZoneMap["LBN"];
        public static Zone Lesotho = _isoCodeZoneMap["LSO"];
        public static Zone Liberia = _isoCodeZoneMap["LBR"];
        public static Zone Libya = _isoCodeZoneMap["LBY"];
        public static Zone Lithuania = _isoCodeZoneMap["LTU"];
        public static Zone Luxembourg = _isoCodeZoneMap["LUX"];
        public static Zone Macao = _isoCodeZoneMap["MAC"];
        public static Zone Madagascar = _isoCodeZoneMap["MDG"];
        public static Zone Malawi = _isoCodeZoneMap["MWI"];
        public static Zone Malaysia = _isoCodeZoneMap["MYS"];
        public static Zone Maldives = _isoCodeZoneMap["MDV"];
        public static Zone Mali = _isoCodeZoneMap["MLI"];
        public static Zone Malta = _isoCodeZoneMap["MLT"];
        public static Zone Martinique = _isoCodeZoneMap["MTQ"];
        public static Zone Mauritania = _isoCodeZoneMap["MRT"];
        public static Zone Mauritius = _isoCodeZoneMap["MUS"];
        public static Zone Mexico = _isoCodeZoneMap["MEX"];
        public static Zone Moldova = _isoCodeZoneMap["MDA"];
        public static Zone Mongolia = _isoCodeZoneMap["MNG"];
        public static Zone Montenegro = _isoCodeZoneMap["MNE"];
        public static Zone Montserrat = _isoCodeZoneMap["MSR"];
        public static Zone Morocco = _isoCodeZoneMap["MAR"];
        public static Zone Mozambique = _isoCodeZoneMap["MOZ"];
        public static Zone Myanmar = _isoCodeZoneMap["MMR"];
        public static Zone Namibia = _isoCodeZoneMap["NAM"];
        public static Zone Nauru = _isoCodeZoneMap["NRU"];
        public static Zone Nepal = _isoCodeZoneMap["NPL"];
        public static Zone Netherlands = _isoCodeZoneMap["NLD"];
        public static Zone NewCaledonia = _isoCodeZoneMap["NCL"];
        public static Zone NewZealand = _isoCodeZoneMap["NZL"];
        public static Zone Nicaragua = _isoCodeZoneMap["NIC"];
        public static Zone Nigeria = _isoCodeZoneMap["NGA"];
        public static Zone NorthMacedonia = _isoCodeZoneMap["MKD"];
        public static Zone Norway = _isoCodeZoneMap["NOR"];
        public static Zone Oman = _isoCodeZoneMap["OMN"];
        public static Zone Pakistan = _isoCodeZoneMap["PAK"];
        public static Zone Panama = _isoCodeZoneMap["PAN"];
        public static Zone PapuaNewGuinea = _isoCodeZoneMap["PNG"];
        public static Zone Paraguay = _isoCodeZoneMap["PRY"];
        public static Zone Peru = _isoCodeZoneMap["PER"];
        public static Zone Poland = _isoCodeZoneMap["POL"];
        public static Zone Portugal = _isoCodeZoneMap["PRT"];
        public static Zone PuertoRico = _isoCodeZoneMap["PRI"];
        public static Zone Qatar = _isoCodeZoneMap["QAT"];
        public static Zone Reunion = _isoCodeZoneMap["REU"];
        public static Zone Romania = _isoCodeZoneMap["ROU"];
        public static Zone Rwanda = _isoCodeZoneMap["RWA"];
        public static Zone SaintKitts = _isoCodeZoneMap["KNA"];
        public static Zone SaintLucia = _isoCodeZoneMap["LCA"];
        public static Zone SaintPierre = _isoCodeZoneMap["SPM"];
        public static Zone SaintVincent = _isoCodeZoneMap["VCT"];
        public static Zone Samoa = _isoCodeZoneMap["WSM"];
        public static Zone SaoTomeandPrincipe = _isoCodeZoneMap["STP"];
        public static Zone SaudiArabia = _isoCodeZoneMap["SAU"];
        public static Zone Senegal = _isoCodeZoneMap["SEN"];
        public static Zone Serbia = _isoCodeZoneMap["SRB"];
        public static Zone Seychelles = _isoCodeZoneMap["SYC"];
        public static Zone SierraLeone = _isoCodeZoneMap["SLE"];
        public static Zone Singapore = _isoCodeZoneMap["SGP"];
        public static Zone Slovakia = _isoCodeZoneMap["SVK"];
        public static Zone Slovenia = _isoCodeZoneMap["SVN"];
        public static Zone SolomonIslands = _isoCodeZoneMap["SLB"];
        public static Zone Somalia = _isoCodeZoneMap["SOM"];
        public static Zone SouthAfrica = _isoCodeZoneMap["ZAF"];
        public static Zone SouthKorea = _isoCodeZoneMap["KOR"];
        public static Zone SouthSudan = _isoCodeZoneMap["SSD"];
        public static Zone Spain = _isoCodeZoneMap["ESP"];
        public static Zone Suriname = _isoCodeZoneMap["SUR"];
        public static Zone Sweden = _isoCodeZoneMap["SWE"];
        public static Zone Switzerland = _isoCodeZoneMap["CHE"];
        public static Zone Taiwan = _isoCodeZoneMap["TWN"];
        public static Zone Tajikistan = _isoCodeZoneMap["TJK"];
        public static Zone Thailand = _isoCodeZoneMap["THA"];
        public static Zone Togo = _isoCodeZoneMap["TGO"];
        public static Zone Tonga = _isoCodeZoneMap["TON"];
        public static Zone TrinidadAndTobago = _isoCodeZoneMap["TTO"];
        public static Zone Tunisia = _isoCodeZoneMap["TUN"];
        public static Zone Turkey = _isoCodeZoneMap["TUR"];
        public static Zone Turkmenistan = _isoCodeZoneMap["TKM"];
        public static Zone Uganda = _isoCodeZoneMap["UGA"];
        public static Zone Ukraine = _isoCodeZoneMap["UKR"];
        public static Zone UnitedArabEmirates = _isoCodeZoneMap["ARE"];
        public static Zone UnitedKingdom = _isoCodeZoneMap["GBR"];
        public static Zone UnitedStates = _isoCodeZoneMap["USA"];
        public static Zone Uruguay = _isoCodeZoneMap["URY"];
        public static Zone Uzbekistan = _isoCodeZoneMap["UZB"];
        public static Zone Vanuatu = _isoCodeZoneMap["VUT"];
        public static Zone VietNam = _isoCodeZoneMap["VNM"];
        public static Zone WesternSahara = _isoCodeZoneMap["ESH"];
        public static Zone Yemen = _isoCodeZoneMap["YEM"];
        public static Zone Zambia = _isoCodeZoneMap["ZMB"];
        public static Zone Zimbabwe = _isoCodeZoneMap["ZWE"];

        public static bool ContryIsAvailable(string isoCode)
            => _isoCodeZoneMap.ContainsKey(isoCode);

        public static Zone GetCountryByCode(string isoCode)
            => _isoCodeZoneMap[isoCode];
    }
}
