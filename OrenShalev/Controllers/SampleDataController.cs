using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrenShalev.Data;
using OrenShalev.Data.Interfaces;
using OrenShalev.Models;

namespace OrenShalev.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly AppDbContext _context;

        private readonly IRootsRepository _roots;

        private readonly IChaptersRepository _chapters;

        public SampleDataController(AppDbContext context, IRootsRepository roots, IChaptersRepository chapters)
        {
            _context = context;
            _roots = roots;
            _chapters = chapters;
        }

        /// <summary>
        /// get all the data
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<List<Chapter>> GetChaptersAsync()
        {
            return await _chapters.GetAllChaptersAsync();

        }

        /// <summary>
        /// update the root name;
        /// </summary>
        /// <param name="upRoot"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<Root> UpdateCarAsync([FromBody]Root upRoot)
        {
            try
            {
                return await _roots.UpdateRootAsync(upRoot);
            }
            catch (Exception)
            {

            }
            return null;
        }



    }
}
