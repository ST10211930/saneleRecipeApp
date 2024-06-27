using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgPart3v2
{
    public class Recipe
    {
        //properties
        public string RecipeName { get; set; }
        public List<IngredientDetails> Ingredients { get; set; }
        public List<StepDetails> Steps { get; set; }


        //constructor 
        public Recipe()
        {
            Ingredients = new List<IngredientDetails>();

            Steps = new List<StepDetails>();
        }
    }
}
