using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA2_Assignment2
{
    internal class Map
    {
        public List<Road> roads = new List<Road>();
        public List<City> cities = new List<City>();
        private List<City> visited = new List<City>();
        private List<City> notVisited = new List<City>();

        public void fillMap()
        {
            City Varna = new City("Varna");
            cities.Add(Varna);
            City Dobrich = new City("Dobrich");
            cities.Add(Dobrich);
            City Burgas = new City("Burgas");
            cities.Add(Burgas);
            City Silistra = new City("Silistra");
            cities.Add(Silistra);
            City Razgrad = new City("Razgrad");
            cities.Add(Razgrad);
            City Shumen = new City("Shumen");
            cities.Add(Shumen);
            City Yambol = new City("Yambol");
            cities.Add(Yambol);
            City Turgovishte = new City("Turgovishte");
            cities.Add(Turgovishte);
            City VelikoTurnovo = new City("Veliko Turnovo");
            cities.Add(VelikoTurnovo);
            City Plovdiv = new City("Plovdiv");
            cities.Add(Plovdiv);
            City Sofia = new City("Sofia");
            cities.Add(Sofia);
            notVisited = cities.ToList();

            Road VarnaDobrich = new Road(Varna, Dobrich, 90, 2);
            Road VarnaBurgas = new Road(Varna, Burgas, 90, 2);
            Road DobrichSilistra = new Road(Dobrich, Silistra, 90, 3);
            Road VarnaRazgrad = new Road(Varna, Razgrad, 90, 1);
            Road SilistraRazgrad = new Road(Silistra, Razgrad, 90, 1);
            Road RazgradTurgovishte = new Road(Razgrad, Turgovishte, 90, 1);
            Road TurgovishteShumen = new Road(Turgovishte, Shumen, 90, 3);
            Road VarnaShumen = new Road(Varna, Shumen, 90, 3);
            Road TurgovishteVelikoTurnovo = new Road(Turgovishte, VelikoTurnovo, 90, 5);
            Road BurgasYambol = new Road(Burgas, Yambol, 90, 5);
            Road ShumenYambol = new Road(Shumen, Yambol, 90, 2);
            Road YambolVelikoTurnovo = new Road(Yambol, VelikoTurnovo, 90, 6);
            Road VelikoTurnovoPlovdiv = new Road(VelikoTurnovo, Plovdiv, 90, 5);
            Road YambolPlovdiv = new Road(Yambol, Plovdiv, 90, 2);
            Road VelikoTurnovoSofia = new Road(VelikoTurnovo, Sofia, 90, 6);
            Road PlovdivSofia = new Road(Plovdiv, Sofia, 90, 4);
            Road BurgasShumen = new Road(Burgas, Shumen, 90, 1);
            roads.Add(VarnaDobrich);
            roads.Add(VarnaBurgas);
            roads.Add(VarnaShumen);
            roads.Add(DobrichSilistra);
            roads.Add(BurgasShumen);
            roads.Add(VarnaRazgrad);
            roads.Add(SilistraRazgrad);
            roads.Add(RazgradTurgovishte);
            roads.Add(TurgovishteShumen);
            roads.Add(TurgovishteVelikoTurnovo);
            roads.Add(BurgasYambol);
            roads.Add(ShumenYambol);
            roads.Add(YambolVelikoTurnovo);
            roads.Add(VelikoTurnovoPlovdiv);
            roads.Add(YambolPlovdiv);
            roads.Add(VelikoTurnovoSofia);
            roads.Add(PlovdivSofia);


        }
        public List<City> getNeighbours(string city)
        {
            List<City> result = new List<City>();
            foreach (var item in roads)
            {
                if (item.city1.name.Equals(city)) result.Add(item.city2);
                if (item.city2.name.Equals(city)) result.Add(item.city1);
            }
            return result;
        }
        public void doMagic(string initial)
        {
            City current = null;
            foreach (var item in cities)
            {
                if (item.name.Equals(initial)) current = item;
            }
            current.distance = 0;
            calculateShortest(initial);
        }
        public void calculateShortest(string start)
        {
            City current = null;
            foreach (var item in cities)
            {
                if (item.name.Equals(start)) current = item;
            }
            if (visited.Contains(current)) return;
            visited.Add(current);
            notVisited.Remove(current);

            List<City> neighbours = new List<City>();
            neighbours = getNeighbours(current.name);
            foreach (var neighbour in neighbours)
            {
                foreach (var road in roads)
                {
                    if ((road.city1.name.Equals(neighbour.name) && road.city2.name.Equals(current.name)) ||
                        (road.city1.name.Equals(current.name) && road.city2.name.Equals(neighbour.name)))
                    {
                        if (neighbour.distance > current.distance + road.distance)
                        {
                            neighbour.distance = current.distance + road.distance;
                            neighbour.shortestRoad = current;
                        }
                    }
                }

            }
            foreach (var neighbour in neighbours)
            {
                calculateShortest(neighbour.name);
            }

        }
        public void printFastestRoad(string initial,string destinationName)
        {
            City destination=null;
            foreach (var city in cities)
            {
                if (city.name.Equals(destinationName)) destination = city;
            }
            getRoadInternal(destination);
        }

        private void getRoadInternal(City city)
        {
            if (city == null) return;
            if (city.shortestRoad == null) return;
            City start = city;
            City other=city.shortestRoad;
            Console.WriteLine(start.name+" "+start.shortestRoad.name);
            getRoadInternal(other);
        }
    }
}
