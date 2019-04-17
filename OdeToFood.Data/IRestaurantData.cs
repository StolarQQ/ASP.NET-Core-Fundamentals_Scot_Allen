using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name = null);
        Restaurant GetRestaurantsById(int id);
    }

    public class InMemoryIRestaurantData : IRestaurantData
    {
        private List<Restaurant> restaurants;

        public InMemoryIRestaurantData()
        {
            restaurants = new List<Restaurant>
            {
                new Restaurant{ Id = 1, CuisineType = CuisineType.Mexican, Location = "Warsaw", Name = "Mexco" },
                new Restaurant{ Id = 2, CuisineType = CuisineType.Italian, Location = "Katowice", Name = "Ezuo" },
                new Restaurant{ Id = 3, CuisineType = CuisineType.Indian, Location = "Gliwice", Name = "Armani" }
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return restaurants.Where(x => string.IsNullOrEmpty(name) || x.Name.StartsWith(name))
                .OrderBy(x => x.Name);
        }

        public Restaurant GetRestaurantsById(int id)
        {
            return restaurants.FirstOrDefault(x => x.Id == id);
        }
    }
}