using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace healthyhams.Data.Services.ApiService.ApiModels
{

    [Serializable]
    public class RecipeByAreaApiModel
    {

        [JsonProperty("strMeal")]
        public string Title { get; set; }


        [JsonProperty("strMealThumb")]
        public string Picture { get; set; }

        [JsonProperty("idMeal")]
        public int Id { get; set; }

    }
}