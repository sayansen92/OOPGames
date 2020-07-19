namespace GeektrustInTraffic
{
    

    public class Weather {
        private string weatherType
        {
            get;
            set;
        }
        private double changeInCraters
        {
            get;
            set;
        }

        public Weather(string name, int chg) {
            weatherType = name;
            changeInCraters = chg;
        }

        public string GetWeatherType() {
            return this.weatherType;

        }

        public double GetChangeInCraterPercentage()
        {
            return this.changeInCraters;

        }
    }
}
