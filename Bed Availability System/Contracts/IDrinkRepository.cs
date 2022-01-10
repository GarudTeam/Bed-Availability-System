using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDrinkRepository
    {
        public IEnumerable<Drink> GetAllDrinks(bool trackChanges);
      
        public Drink GetDrink(int drinkId, bool trackChanges);
        void CreateDrink(Drink drink);
        void DeleteDrink(Drink drink);
       
        void UpdateDrink(Drink drink);
    }
}
