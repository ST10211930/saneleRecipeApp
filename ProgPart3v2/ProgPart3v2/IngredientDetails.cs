﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProgPart3v2
{
    public class IngredientDetails
    {
        //constructor 
        public IngredientDetails(TextBox textboxIngredName,
            TextBox textboxQuantity,
            TextBox textboxUnit,
            TextBox textboxCalories,
            ComboBox comboFoodGroup)
        {
            this.textboxIngredName = textboxIngredName;
            this.textboxQuantity = textboxQuantity;
            this.textboxUnit = textboxUnit;
            this.textboxCalories = textboxCalories;
            this.comboFoodGroup = comboFoodGroup;
        }

        //properties 
        public TextBox textboxIngredName { get; set; }
        public TextBox textboxQuantity { get; set; }
        public TextBox textboxUnit { get; set; }
        public TextBox textboxCalories { get; set; }
        public ComboBox comboFoodGroup { get; set; }
    }
}
