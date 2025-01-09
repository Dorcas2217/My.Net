using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopPlaces
{
    public class PlacesData
    {
        public IList<Place> PlacesList { get; set; }

        public PlacesData()
        {
            string pathProject = Environment.CurrentDirectory;
            Place p1 = new(pathProject + "/photos/bruxelles.jpg", "Bruxelles");
            Place p2 = new (pathProject + "/photos/paris.jpg", "Paris");
            Place p3 = new (pathProject + "/photos/moscou.jpg", "Moscou");
            Place p4 = new (pathProject + "/photos/amsterdam.jpg", "Amsterdam");
            Place p5 = new (pathProject + "/photos/newyork.jpg", "New York");

            PlacesList = new List<Place>();
            PlacesList.Add(p1);
            PlacesList.Add(p2);
            PlacesList.Add(p3);
            PlacesList.Add(p4);
            PlacesList.Add(p5);

        }
    }
}
