using DAL.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.repositories
{
    public class BaseRepository
    {
        private readonly AppDBContext _context;

        public BaseRepository(AppDBContext context)
        {
            _context = context;
        }
    }
}
