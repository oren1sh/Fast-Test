using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrenShalev.Data.Interfaces;
using OrenShalev.Models;

namespace OrenShalev.Data.Repositories
{
    public class ChaptersRepository : IChaptersRepository
    {
        private readonly AppDbContext _context;

        public ChaptersRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// get all Chapters and roots
        /// </summary>
        /// <returns></returns>
        public async Task<List<Chapter>> GetAllChaptersAsync()
        {
            return await _context.Chapters.Include(c => c.Roots).ToListAsync();

        }
    }
}
