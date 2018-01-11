using ExamApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodBook.Services
{
    public class Repository
    {
        private readonly SQLiteAsyncConnection connection;
        public string Results { get; set; }

        public Repository(string dbPath)
        {
            connection = new SQLiteAsyncConnection(dbPath);
            
            connection.CreateTableAsync<Restaurant>();
            connection.CreateTableAsync<Dish>();
            connection.CreateTableAsync<OpenHours>();
        }

        public async Task Create(Restaurant item)
        {
            try
            {
                if (string.IsNullOrEmpty(item.Title))
                    throw new Exception("Title required");
                if (item.Title.Length > 250)
                    throw new Exception("Title must not exceed 250 characters");

                var linesAdded = await connection.InsertAsync(item);
                Results = $"{linesAdded} copy of {item.Title} created";
            }
            catch (Exception e)
            {
                Results = $"Failed to add {item.Title ?? "untitled item"}. {e.Message}";
            }
        }

        public async Task Update(Restaurant item)
        {
            try
            {
                if (string.IsNullOrEmpty(item.Title))
                    throw new Exception("Title required");
                if (item.Title.Length > 250)
                    throw new Exception("Title must not exceed 250 characters");

                var linesAdded = await connection.UpdateAsync(item);
                Results = $"{linesAdded} copy of {item.Title} updated";
            }
            catch (Exception e)
            {
                Results = $"Failed to update {item.Title ?? "untitled item"}. {e.Message}";
            }
        }

        public async Task Delete(Restaurant item)
        {
            try
            {
                if (connection.GetAsync<Restaurant>(item) == null)
                    throw new Exception("Item does not exist");
                
                await connection.DeleteAsync(item);
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

        public async Task Create(Dish item)
        {
            try
            {
                if (string.IsNullOrEmpty(item.Name))
                    throw new Exception("Title required");
                if (item.Name.Length > 250)
                    throw new Exception("Title must not exceed 250 characters");

                var linesAdded = await connection.InsertAsync(item);
                Results = $"{linesAdded} copy of {item.Name} created";
            }
            catch (Exception e)
            {
                Results = $"Failed to add {item.Name ?? "untitled item"}. {e.Message}";
            }
        }

        public async Task Delete(Dish item)
        {
            try
            {
                if (connection.GetAsync<Restaurant>(item) == null)
                    throw new Exception("Item does not exist");

                await connection.DeleteAsync(item);
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

        public async Task Create(List<OpenHours> list)
        {
            try
            {
                foreach (var item in list)
                {
                    if (string.IsNullOrEmpty(item.RestaurantId))
                        throw new Exception($"All Open Hours must have a RestaurantId string, which {item.Weekday} lacks");
                }

                var linesAdded = await connection.InsertAllAsync(list);
                Results = $"{linesAdded} OpenHours created";
            }
            catch (Exception e)
            {
                Results = $"Failed to add OpenHours. {e.Message}";
            }
        }
        public async Task<List<OpenHours>> GetCurrentOpenHours(Restaurant restaurant)
        {
            try
            {
                return await connection.Table<OpenHours>().Where(x => x.RestaurantId == restaurant.Id).ToListAsync();
            }
            catch (Exception e)
            {
                Results = $"Failed to retrieve data. {e.Message}";
                return new List<OpenHours>();
            }
        }
        // Intentionally leaving out Update and Delete for now, as editing opening hours is not a feature I have time to add before deadline.
    }
}
