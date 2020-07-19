using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace GeektrustInTraffic
{
    class Program
    {
        private static List<Orbit> orbits;
        private static List<Vehicle> vehicles;
        private static List<Weather> weathers;
        static void Main(string[] args)
        {
            //Initialise all the Vehicle, Orbit and Weather objects
            GetReady();

            //Read the first line from input file 
            string[] inputs = File.ReadLines(args[0]).ToList()[0].Split(" ");

            if (inputs.Length > 0)
            {
                double[] speedLimits = { double.Parse(inputs[1]), double.Parse(inputs[2]) };

                //Process data and save output
                Console.WriteLine(Process(inputs[0], speedLimits));
            }
        }

        private static string Process(string inputWeather, double[] speedLimits)
        {
            string output = "";

            double minimumTimeTtaken = -1;
            try
            {
                //Get all vehicles which support the weather
                IEnumerable<Vehicle> IEVehiclesList = GetAllVehiclesFor(inputWeather);
                if (IEVehiclesList.Count() != 0)//if no such vehicle found, return empty result
                {
                    //Get the weather object for input weather
                    Weather weather = weathers.Find(x => x.GetWeatherType().Equals(inputWeather, StringComparison.CurrentCultureIgnoreCase));
                    int i = 0;
                    //Console.WriteLine(weather.getType());

                    foreach (Orbit orbit in orbits)//O(n)
                    {
                        //Get actual no. of craters for an orbit for a weather
                        double craters = orbit.GetOrbitCraters() + (weather.GetChangeInCraterPercentage() / 100) * orbit.GetOrbitCraters();
                        //Console.WriteLine("{0}:{1}->{2}", orbit.getOrbitName(), orbit.getOrbitCraters(),craters);
                        foreach (Vehicle vehicle in IEVehiclesList)//O(m)
                        {
                            //Get he minimum between Vehicle speed and orbit speed
                            //if vehicle speed> orbit speed, take output speed as orbit speed
                            //if vehicle speed< orbit speed, take output speed as vehicle speed
                            double timeTaken = Math.Round(orbit.GetOrbitLength() / Math.Min(vehicle.GetSpeed(), speedLimits[i]) + craters * vehicle.GetCraterCrossTime(), 3);
                            //Console.WriteLine("{0}:{1}:{2}hr", orbit.getOrbitName(), vehicle.getType(), timeTaken);
                            //if minimumTimeTtaken is getting updated first time or
                            //if new minimumTimeTtaken is avaailable
                            if (minimumTimeTtaken < 0|| timeTaken < minimumTimeTtaken)
                            {
                                minimumTimeTtaken = timeTaken;
                                output = string.Concat(vehicle.GetType()," ",orbit.GetOrbitName());
                            }
                            
                        }
                        i++;//check the next orbit's max speed limit given as input
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            return output;
        }

        //GetAllVehiclesFor(): returns a list of vehicles which are compatible to a given weather type
        //Input: <string> weather
        //Output: List of Vehicles
        private static IEnumerable<Vehicle> GetAllVehiclesFor(string inputWeather)
        {
            foreach (Vehicle vehicle in vehicles)
            {
                foreach(string weather in vehicle.GetSupportedWeather())
                    if (string.Equals(weather, inputWeather, StringComparison.CurrentCultureIgnoreCase))
                        yield return vehicle;
            }
        }

        //GetReady(): creates and initializes static list of objects of type: Orbit, Vehicle, Weather
        private static void GetReady()
        {
            orbits = new List<Orbit>();
            orbits.Add(new Orbit("ORBIT1", 18, 20));
            orbits.Add(new Orbit("Orbit2", 20, 10));


            /*foreach (var orb in orbits)
            {
                Console.WriteLine("{0},{1}mm,{2}", orb.getOrbitName(), orb.getOrbitDist(), orb.getOrbitCraters());
            }
            */
            vehicles = new List<Vehicle>();
            vehicles.Add(new Vehicle("Bike", 10, 2, new List<string> { "Sunny", "Windy" }));
            vehicles.Add(new Vehicle("Tuktuk", 12, 1, new List<string> { "Sunny", "Rainy" }));
            vehicles.Add(new Vehicle("CAR", 20, 3, new List<string> { "Sunny", "Rainy", "Windy" }));

            /*foreach (var vehicle in vehicles)
            {
                Console.WriteLine("{0}:{1}mmph,{2}min to cross a crater, [{3}]", vehicle.getType(), vehicle.getSpeed(), vehicle.getCraterCrossTime(), string.Join(",", vehicle.getSupportedWeather()));
            }*/


            weathers = new List<Weather>();
            weathers.Add(new Weather("Sunny", -10));
            weathers.Add(new Weather("Rainy", 20));
            weathers.Add(new Weather("WINDY", 0));

            /*foreach (var obj in weathers)
            {
                Console.WriteLine("{0}: Change in craters: {1}%", obj.getType(), obj.getCraterChange());
            }*/
        }
    }
}
