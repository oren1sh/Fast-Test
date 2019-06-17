using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrenShalev.Models
{
    [Table("CommodityChapters")]
    public class Chapter:BaseModel
    {
        public List<Root> Roots { get; set; }


    }
}
