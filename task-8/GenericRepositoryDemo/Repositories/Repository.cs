using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GenericRepositoryDemo.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly List<T> _items = new List<T>();

        public async Task AddAsync(T entity)
        {
            await Task.Run(() =>
            {
                _items.Add(entity);
            });
        }

        public async Task<T?> GetByRollnoAsync(string rollno)
        {
            return await Task.Run(() =>
            {
                return _items.FirstOrDefault(item =>
                {
                    var rollnoProperty = item.GetType().GetProperty("RollNo");
                    return rollnoProperty != null && (string)rollnoProperty.GetValue(item) == rollno;
                });
            });
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.Run(() => _items.ToList());
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() =>
            {
                var rollnoProperty = entity.GetType().GetProperty("Rollno");
                if (rollnoProperty != null)
                {
                    string? rollno = (string?)rollnoProperty.GetValue(entity);
                    var existingItem = _items.FirstOrDefault(item =>
                    {
                        var itemRollnoProperty = item.GetType().GetProperty("Rollno");
                        return itemRollnoProperty != null && (string)itemRollnoProperty.GetValue(item) == rollno;
                    });

                    if (existingItem != null)
                    {
                        int index = _items.IndexOf(existingItem);
                        _items[index] = entity;
                        Console.WriteLine("Entity updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Entity not found.");
                    }
                }
            });
        }

        public async Task<bool> DeleteAsync(string rollno)
        {
            return await Task.Run(() =>
            {
                var item = _items.FirstOrDefault(x =>
                {
                    var rollnoProperty = x.GetType().GetProperty("RollNo");
                    return rollnoProperty != null && (string)rollnoProperty.GetValue(x) == rollno;
                });

                if (item != null)
                {
                    _items.Remove(item);
                    Console.WriteLine("Entity deleted successfully.");
                    return true;
                }

                Console.WriteLine("Entity not found.");
                return false;
            });
        }
    }
}
