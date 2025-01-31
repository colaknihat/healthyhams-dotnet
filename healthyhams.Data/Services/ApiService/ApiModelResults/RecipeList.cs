using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using healthyhams.Data.Models;

namespace healthyhams.Data
{
    [Serializable]
    public class RecipeList
    {
        [JsonProperty("meals")]
        public IEnumerable<RecipeApiModel> Recipes { get; set; }
    }

}
