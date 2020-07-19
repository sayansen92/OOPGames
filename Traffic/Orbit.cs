namespace GeektrustInTraffic
{
    public class Orbit {
        private string orbitName {
            get;
            set; 
        }
        private double orbitLength {
            get;
            set;
        }
        private double orbitCraters {
            get;
            set;
        }

        
        public Orbit(string orbit_name, double dist, double craters) {
            //Console.WriteLine("Name:{0}, distance:{1}, craters:{2}",a,b,c);
            orbitName = orbit_name;
            orbitLength = dist;
            orbitCraters = craters;
        }

        public string GetOrbitName() {
            return this.orbitName;
        }
        public double GetOrbitLength()
        {
            return this.orbitLength;
        }
        public double GetOrbitCraters()
        {
            return this.orbitCraters;
        }

       
    }
}
