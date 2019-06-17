using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrenShalev.Data.Interfaces;
using OrenShalev.Models;

namespace OrenShalev.Data.Repositories
{
    public class RootsRepository : IRootsRepository
    {
        private readonly AppDbContext _context;

        public RootsRepository(AppDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// update only the name of the root
        /// </summary>
        /// <param name="upRoot"></param>
        /// <returns></returns>
        public async Task<Root> UpdateRootAsync(Root upRoot)
        {
            Root refRoot = await _context.Roots.FirstOrDefaultAsync(r => r.Id == upRoot.Id);
            if (refRoot == null || refRoot == default(Root))
            {
                return null;

            }
            refRoot.Name = upRoot.Name;

            _context.Roots.Update(refRoot);
            await _context.SaveChangesAsync();
            return upRoot;

        }
    }
}
