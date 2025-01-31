using DataLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using healthyhams.Data.Models;

namespace healthyhams.Data.Services
{
    public class SqlFoodData : IFoodData
    {
        private readonly healthyhamsContext db;

        public SqlFoodData(healthyhamsContext db)
        {
            this.db = db;
        }


        public int addFoodHistory(DateTime journalDate, int servingSize, int userId, int foodId)
        {
            UserHistory data = new UserHistory
            {
                JournalDate = journalDate,
                ServingSize = servingSize,
                UserInformationId = userId,
                FoodId = foodId,
            };

            string sql = @"insert into dbo.UserHistories (JournalDate, ServingSize, UserInformationId, FoodId, RecipeId) values (@JournalDate, @ServingSize, @UserInformationId, @FoodId, NULL);";
            return SqlDataAccess.SaveData(sql, data);
        }

        public int addRecipeHistory(DateTime journalDate, int servingSize, int userId, int recipeId)
        {
            UserHistory data = new UserHistory
            {
                JournalDate = journalDate,
                ServingSize = servingSize,
                UserInformationId = userId,
                RecipeId = recipeId,
            };

            string sql = @"insert into dbo.UserHistories (JournalDate, ServingSize, UserInformationId, FoodId, RecipeId) values (@JournalDate, @ServingSize, @UserInformationId, NULL, @RecipeId);";
            return SqlDataAccess.SaveData(sql, data);
        }

        public int addRecipeDb(string recipeName, int servingSize, int foodId, int userId)
        {
            Recipe data = new Recipe
            {
                RecipeName = recipeName,
                ServingSize = servingSize,
                FoodId = foodId,
                UserInformationId = userId,

            };

            string sql = @"insert into dbo.Recipes (RecipeName, ServingSize, FoodId, UserInformationId) values (@RecipeName, @ServingSize, @FoodId, @UserInformationId);";
            return SqlDataAccess.SaveData(sql, data);
        }

        public int addRecipe(DateTime journalDate, int servingSize, int userId, int recipeId)
        {
            throw new NotImplementedException();
        }
    }
}
