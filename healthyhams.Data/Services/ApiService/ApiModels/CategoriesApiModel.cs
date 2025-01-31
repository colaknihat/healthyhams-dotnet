using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace healthyhams.Data
{
    [Serializable]
    public class CategoriesApiModel
    {
        [JsonProperty("strCategory")]
        public string Category { get; set; }
    }
}
