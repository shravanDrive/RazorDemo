using RazorModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Repository
{
	public interface IFoodTypeRepository : IRepository<FoodType>
	{
		void Update(FoodType obj);
	}
}
