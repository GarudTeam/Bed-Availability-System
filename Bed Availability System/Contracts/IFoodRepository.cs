using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFoodRepository
    {
        public IEnumerable<Food> GetAllFoods(bool trackChanges);

        public Food GetFood(int FoodId, bool trackChanges);
        void CreateFood(Food food);
        void DeleteFood(Food food);
        void UpdateFood(Food food);
    }
}
