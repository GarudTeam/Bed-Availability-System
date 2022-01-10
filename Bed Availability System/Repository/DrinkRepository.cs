using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
   public class DrinkRepository: RepositoryBase<Drink>, IDrinkRepository
    {
        public DrinkRepository(RepositoryContext repositoryContext)
 : base(repositoryContext)
        {
        }


        public void CreateDrink(Drink drink)
        {
            Create(drink);
        }

        public void DeleteDrink(Drink drink)
        {
            Delete(drink);
        }

        public IEnumerable<Drink> GetAllDrinks(bool trackChanges) =>

            FindAll(trackChanges).OrderBy(d => d.Id).ToList();


        public Drink GetDrink(int drinkId, bool trackChanges) =>

            FindByCondition(d => d.Id.Equals(drinkId), trackChanges).SingleOrDefault();



        void IDrinkRepository.UpdateDrink(Drink drink)
        {
            Update(drink);
        }

    }
}
