using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Repository
{
	public interface IUnitOfWork
	{
		ICategoryRepository Category { get; }
		IFoodTypeRepository FoodType { get; }
		IMenuItemRepository MenuItem { get; }
        ISpOutputRepository SpOutput { get; }
        void Save();
	}
}
