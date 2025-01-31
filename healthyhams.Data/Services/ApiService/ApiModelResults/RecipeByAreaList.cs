using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using healthyhams.Data.Services.ApiService.ApiModels;

namespace healthyhams.Data.Services.ApiService.ApiModelResults
{

    [Serializable]
    public class RecipeByAreaList
    {
        [JsonProperty("meals")]
        public IEnumerable<RecipeByAreaApiModel> Recipes { get; set; }
    }
}
