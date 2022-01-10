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
    public class FoodRepository : RepositoryBase<Food>, IFoodRepository
    {
        public FoodRepository(RepositoryContext repositoryContext)
 : base(repositoryContext)
        {
        }


        public void CreateFood(Food food)
        {
            Create(food);
        }

        public void DeleteFood(Food food)
        {
            Delete(food);
        }

        public IEnumerable<Food> GetAllFoods(bool trackChanges) =>

            FindAll(trackChanges).OrderBy(d => d.Id).ToList();


        public Food GetFood(int FoodId, bool trackChanges) =>

            FindByCondition(d => d.Id.Equals(FoodId), trackChanges).SingleOrDefault();



        void IFoodRepository.UpdateFood(Food Food)
        {
            Update(Food);
        }
    }
}
