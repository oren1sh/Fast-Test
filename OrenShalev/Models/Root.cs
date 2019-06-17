using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OrenShalev.Models
{
    [Table("CommodityRoots")]
    public class Root:BaseModel
    {
        
        public int CommodityChapterId { get; set; }
        [JsonIgnore]
        public virtual Chapter CommodityChapter { get; set; }




    }
}
