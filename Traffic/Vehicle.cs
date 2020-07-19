using System;
using System.Collections.Generic;

namespace GeektrustInTraffic
{
    public class Vehicle
    {
        private string vehicleType
        {
            get;
            set;
        }
        private double vehicleSpeed
        {
            get;
            set;
        }
        private double craterCrossingTime
        {
            get;
            set;
        }

        private List<string> supportedWeathers
        {
            get;
            set;
        }

        public Vehicle(string type, double speed, double timeTaken, List<string> weathers){
            vehicleType = type;
            vehicleSpeed = speed;
            craterCrossingTime = Math.Round(timeTaken/60,3);
            supportedWeathers = weathers;
        }

        public string GetType() { return this.vehicleType; }
        public double GetSpeed() { return this.vehicleSpeed; }
        public double GetCraterCrossTime() { return this.craterCrossingTime; }

        public List<string> GetSupportedWeather() { return this.supportedWeathers; }
    }
}
