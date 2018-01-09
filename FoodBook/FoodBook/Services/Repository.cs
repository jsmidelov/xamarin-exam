using ExamApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodBook.Services
{
    public class Repository
    {
        public Repository Instance {
            get {
                if (Instance==null)
                {
                    new Repository("database.db");
                }
                return Instance;
            }
            private set { Instance = value; } }
        private readonly SQLiteAsyncConnection connection;
        public string Results { get; set; }
        public Repository(string dbPath)
        {
            //Instance = new Repository("database.db");
            connection = new SQLiteAsyncConnection(dbPath);
            
            connection.CreateTableAsync<Restaurant>().Wait();
            connection.CreateTableAsync<Dish>().Wait();
            connection.CreateTableAsync<OpenHours>().Wait();
        }

        public void Create(Restaurant item)
        {
            try
            {
                if (string.IsNullOrEmpty(item.Title))
                    throw new Exception("Title required");
                if (item.Title.Length > 250)
                    throw new Exception("Title must not exceed 250 characters");

                var linesAdded = connection.InsertAsync(item);
                Results = $"{linesAdded} copy of {item.Title} created";
            }
            catch (Exception e)
            {
                Results = $"Failed to add {item.Title ?? "untitled item"}. {e.Message}";
            }
        }

        public void Delete(Restaurant item)
        {
            try
            {
                if (connection.GetAsync<Restaurant>(item) == null)
                    throw new Exception("Item does not exist");
                
                connection.DeleteAsync(item);
            }
            catch (Exception e)
            {
                Results = $"Failed to remove {item.Title ?? "untitled item"}. {e.Message}";
                throw;
            }
        }

        public async Task<List<Restaurant>> GetAllRestaurants()
        {
            try
            {
                return await connection.Table<Restaurant>().ToListAsync();
            }
            catch (Exception e)
            {
                Results = $"Failed to retrieve data. {e.Message}";
                return new List<Restaurant>();
            }
        }

        public void Create(Dish item)
        {
            try
            {
                if (string.IsNullOrEmpty(item.Name))
                    throw new Exception("Title required");
                if (item.Name.Length > 250)
                    throw new Exception("Title must not exceed 250 characters");

                var linesAdded = connection.InsertAsync(item);
                Results = $"{linesAdded} copy of {item.Name} created";
            }
            catch (Exception e)
            {
                Results = $"Failed to add {item.Name ?? "untitled item"}. {e.Message}";
            }
        }

        public void Delete(Dish item)
        {
            try
            {
                if (connection.GetAsync<Restaurant>(item) == null)
                    throw new Exception("Item does not exist");

                connection.DeleteAsync(item);
            }
            catch (Exception e)
            {
                Results = $"Failed to remove {item.Name ?? "untitled item"}. {e.Message}";
                throw;
            }
        }

        public async Task<List<Dish>> GetCurrentDishes(Restaurant restaurant)
        {
            try
            {
                return await connection.Table<Dish>().Where(x => x.RestaurantId == restaurant.Id).ToListAsync();
            }
            catch (Exception e)
            {
                Results = $"Failed to retrieve data. {e.Message}";
                return new List<Dish>();
            }
        }
    }
}
