using DatabaseAccess.DataConnection;
using RazorModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Repository
{
    public class SpOutputRepository : Repository<SPOutput>, ISpOutputRepository
    {
        private readonly ApplicationDbContext _db;

        public SpOutputRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


    }
}
