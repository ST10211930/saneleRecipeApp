using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProgPart3v2
{
    /// <summary>
    /// Interaction logic for NewRecipe.xaml
    /// </summary>
    public partial class NewRecipe : Window
    {
        //globals 
        List<Recipe> recipes = new List<Recipe>();
        List<RecipeName> lisrRecipeName = new List<RecipeName>();
        List<IngredientDetails> ingredients = new List<IngredientDetails>();
        List<StepDetails> listDescription = new List<StepDetails>();
        double scalingFactor = 1.0;
        public NewRecipe()
        {
            InitializeComponent();
        }
        private void AddIngreds()

        {

            //create a panel --> add boxes --> input

            StackPanel ingredPanel = new StackPanel()

            {

                Orientation = Orientation.Horizontal,

                Margin = new Thickness(0, 0, 0, 10)

            };



            TextBox textboxIngredName = new TextBox() { Width = 100 };

            TextBox textboxQuantity = new TextBox() { Width = 100 };

            TextBox textboxUnit = new TextBox() { Width = 100 };

            TextBox textboxCalories = new TextBox() { Width = 100 };

            ComboBox comboFoodGroup = new ComboBox() { Width = 100 };



            comboFoodGroup.Items.Add("Vegetables");

            comboFoodGroup.Items.Add("Fruits");

            comboFoodGroup.Items.Add("Grains");

            comboFoodGroup.Items.Add("Protein Foods");

            comboFoodGroup.Items.Add("Dairy");

            comboFoodGroup.Items.Add("Oils and Solid Fats");

            comboFoodGroup.Items.Add("Added Sugars");

            comboFoodGroup.Items.Add("Beverages");

            ingredPanel.Children.Add(new TextBlock()

            { Text = "Ingredient Name: ", VerticalAlignment = VerticalAlignment.Center });

            ingredPanel.Children.Add(textboxIngredName);



            ingredPanel.Children.Add(new TextBlock()

            { Text = "Quantity: ", VerticalAlignment = VerticalAlignment.Center });

            ingredPanel.Children.Add(textboxQuantity);



            ingredPanel.Children.Add(new TextBlock()

            { Text = "Unit: ", VerticalAlignment = VerticalAlignment.Center });

            ingredPanel.Children.Add(textboxUnit);



            ingredPanel.Children.Add(new TextBlock()

            { Text = "Calories: ", VerticalAlignment = VerticalAlignment.Center });

            ingredPanel.Children.Add(textboxCalories);



            ingredPanel.Children.Add(new TextBlock()

            { Text = "Food Group: ", VerticalAlignment = VerticalAlignment.Center });

            ingredPanel.Children.Add(comboFoodGroup);



            ingredients.Add(new IngredientDetails(textboxIngredName, textboxQuantity, textboxUnit, textboxCalories, comboFoodGroup));



            pnlDisplay.Children.Add(ingredPanel);
        }// end of AddIngreds method

        private void AddSteps()

        {

            //create a panel --> add boxes --> input

            StackPanel stepPanel = new StackPanel()

            {

                Orientation = Orientation.Horizontal,

                Margin = new Thickness(0, 0, 0, 10)

            };



            TextBox textboxSteps = new TextBox() { Width = 150, Height = 40 };

            stepPanel.Children.Add(new TextBlock()

            {

                Text = "Step: ",

                VerticalAlignment = VerticalAlignment.Center

            });

            stepPanel.Children.Add(textboxSteps);





            listDescription.Add(new StepDetails(textboxSteps)); // adds to the list



            pnlDisplay.Children.Add(stepPanel);

        }//end of AddSteps method

        private void btnEnterIngredsandSteps_Click(object sender, RoutedEventArgs e)
        {
            btnsaveanddisplay.IsEnabled = true;
            int numIngreds;
            if (int.TryParse(textboxNumIngreds.Text, out numIngreds))
            {
                for (int i = 0; i < numIngreds; i++)
                {
                    AddIngreds();
                }//for ends
            }//if ends
            textboxNumIngreds.Text = string.Empty;
            //dealing w num of steps 
            int numSteps;
            if (int.TryParse(textBoxnumSteps.Text, out numSteps))
            {
                for (int i = 0; i < numSteps; i++)
                {
                    AddSteps();

                }//for ends
            }//if ends
            textBoxnumSteps.Text = string.Empty;
            btnEnterIngredsandSteps.IsEnabled = false;
        }//end of btnEnterIngredsandSteps_Click

        private void btnsaveanddisplay_Click(object sender, RoutedEventArgs e)
        {

            {
                SearchIngred.IsEnabled = true;
                SearchFoodGroup.IsEnabled = true;
                SearchMaxCal.IsEnabled = true;

                // Create a new recipe and add it to the recipes list 
                Recipe newRecipe = new Recipe();
                newRecipe.RecipeName = textboxRecipeName.Text;
                newRecipe.Ingredients.AddRange(ingredients);
                newRecipe.Steps.AddRange(listDescription);
                recipes.Add(newRecipe);

                //clear the display and the other input fields 
                textboxRecipeName.Text = string.Empty;
                pnlDisplay.Children.Clear();
                ingredients.Clear();
                listDescription.Clear();

                //sort the name sof the recipes in alphabetical order
                recipes.Sort((r1, r2) => r1.RecipeName.CompareTo(r2.RecipeName));

                UpdateRecipeListTextBlock();
                //next stage 
                btnDisplayAllNames.IsEnabled = true;
                btnDisplayRecipe.IsEnabled = true;
                btnScale.IsEnabled = true;
                btnReset.IsEnabled = true;
                btnDelete.IsEnabled = true;
                btnsaveanddisplay.IsEnabled = false;
                btnEnterIngredsandSteps.IsEnabled = true;


            }
        }//end of  btnsaveanddisplay_Click 

        private void UpdateRecipeListTextBlock()
        {
            StringBuilder recipeListBuilder = new StringBuilder();

            for (int i = 0; i < recipes.Count; i++)
            {
                recipeListBuilder.AppendLine($"{i + 1}. {recipes[i].RecipeName}");

                double totalCalories = 0;

                recipeListBuilder.AppendLine("\nIngredients:");

                int count = 1;

                foreach (var ingredient in recipes[i].Ingredients)
                {
                    recipeListBuilder.AppendLine($"{count}) {ingredient.textboxQuantity.Text} {ingredient.textboxUnit.Text} of {ingredient.textboxIngredName.Text} (Calories: {ingredient.textboxCalories.Text}) (Food Group: {ingredient.comboFoodGroup.Text})");

                    double calories;
                    if (double.TryParse(ingredient.textboxCalories.Text, out calories))
                    {
                        totalCalories += calories;
                    }
                    else
                    {
                        // Handle the invalid calorie format case
                        recipeListBuilder.AppendLine($"Note: '{ingredient.textboxCalories.Text}' is not a valid number for calories.");
                    }

                    count++;
                }

                recipeListBuilder.AppendLine($"Total Calories: {totalCalories}");

                recipeListBuilder.AppendLine("\nSteps:");

                count = 1;

                foreach (var step in recipes[i].Steps)
                {
                    recipeListBuilder.AppendLine($"{count}) {step.textboxSteps.Text}");
                    count++;
                }

                // Add an empty line between recipes
                recipeListBuilder.AppendLine();

                if (totalCalories > 300)
                {
                    recipeListBuilder.AppendLine($"YOU HAVE EXCEEDED YOUR CALORIE INTAKE OF 300!!!\nConsuming large amounts of calories can be harmful to your health\nPlease try scaling the recipe by 0.5");
                }
                else
                {
                    recipeListBuilder.AppendLine($"\nThis recipe is under 300 calories, which is a healthy calorie limit for a meal. Eating meals under 300 calories can aid in weight loss, and can also improve mental health.");
                }
            }

            textBlockDisplay.Text = recipeListBuilder.ToString();
        }//end of UpdateRecipeListTextBlock

        private void SearchIngred_Click(object sender, RoutedEventArgs e)
        {

            {
                string searchIngredient = textboxsearchIngred.Text;

                //clear the display
                textBlockDisplay.Text = string.Empty;

                //FLITER the recipes based on ingred name
                List<Recipe> filteredRecipes = recipes.Where(recipe =>
                recipe.Ingredients.Any(ingredients => ingredients.textboxIngredName.
                Text.Equals(searchIngredient,
                StringComparison.OrdinalIgnoreCase))).ToList();

                //display
                if (filteredRecipes.Count > 0)
                {
                    StringBuilder recipeListBuilder = new StringBuilder();

                    for (int i = 0; i < filteredRecipes.Count; i++)
                    {
                        recipeListBuilder.AppendLine($"{i + 1}.{filteredRecipes[i].RecipeName}");
                    }//end for

                    textBlockDisplay.Text = recipeListBuilder.ToString();

                }//end if
                else
                {
                    MessageBox.Show("No recipes found!");
                }//end else

            }
        }//end of SearchIngred_Click

        private void SearchFoodGroup_Click(object sender, RoutedEventArgs e)
        {
            string selectedFoodGroup = comboboxsearchFoodGroup.Text;

            // Clear the display
            textBlockDisplay.Text = string.Empty;

            // Filter the recipes based on the selected food group
            List<Recipe> filteredRecipes = recipes.Where(recipe =>
                recipe.Ingredients.Any(ingredient => ingredient.comboFoodGroup.Text.Equals(selectedFoodGroup, StringComparison.OrdinalIgnoreCase))
            ).ToList();

            // Display filtered recipes
            if (filteredRecipes.Count > 0)
            {
                StringBuilder recipeListBuilder = new StringBuilder();
                for (int i = 0; i < filteredRecipes.Count; i++)
                {
                    recipeListBuilder.AppendLine($"{i + 1}. {filteredRecipes[i].RecipeName}");
                }

                textBlockDisplay.Text = recipeListBuilder.ToString();
            }
            else
            {
                MessageBox.Show("No recipes found for the selected food group!");
            }
        }//end of SearchFoodGroup_Click

        private void SearchMaxCal_Click(object sender, RoutedEventArgs e)
        {

            {
                int maxCalories;
                if (!int.TryParse(textboxMaxCal.Text, out maxCalories))
                {
                    MessageBox.Show("Please enter a valid number for maximum calories.");
                    return;
                }

                // Clear the display
                textBlockDisplay.Text = string.Empty;

                // Filter the recipes based on the maximum calories
                List<Recipe> filteredRecipes = recipes.Where(recipe =>
                    recipe.Ingredients.Sum(ingredient => int.Parse(ingredient.textboxCalories.Text)) <= maxCalories
                ).ToList();

                // Display filtered recipes
                if (filteredRecipes.Count > 0)
                {
                    StringBuilder recipeListBuilder = new StringBuilder();
                    for (int i = 0; i < filteredRecipes.Count; i++)
                    {
                        recipeListBuilder.AppendLine($"{i + 1}. {filteredRecipes[i].RecipeName}");
                    }

                    textBlockDisplay.Text = recipeListBuilder.ToString();
                }
                else
                {
                    MessageBox.Show("No recipes found within the specified calorie limit!");
                }
            }
        }//end of SearchMaxCal_Click

        private void btnDisplayRecipe_Click(object sender, RoutedEventArgs e)
        {

            {
                gridRecipeNumber.Visibility = Visibility.Visible;
                textboxDisplayrecChoice.Visibility = Visibility.Visible;
                btnDisplayRecCont.Visibility = Visibility.Visible;
            }
        }//end of btnDisplayRecipe_Click

        private void btnDisplayRecCont_Click(object sender, RoutedEventArgs e)
        {
            int displayRecChoice;
            if (int.TryParse(textboxDisplayrecChoice.Text, out displayRecChoice))
            {
                if (displayRecChoice > 0 && displayRecChoice <= recipes.Count)
                {
                    textBlockDisplay.Text = GetFormattedRecipeDisplay(displayRecChoice);
                }
                else
                {
                    MessageBox.Show("Please enter a valid recipe number.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
            }

            // Hide the input fields and button again
            HideInputElements();
        }//end of btnDisplayRecCont_Click

        private void btnDisplayAllNames_Click(object sender, RoutedEventArgs e)
        {

            {
                textBlockDisplay.Text = DisplayRecipeNamesMethod();
            }
        }//end of DisplayRecipeNamesMethod

        private string DisplayRecipeNamesMethod()
        {
            StringBuilder recipeBuilder = new StringBuilder();
            recipeBuilder.AppendLine("Recipe Names: \n");
            int nameCount = 1;

            foreach (var item in recipes)
            {
                recipeBuilder.AppendLine($"{nameCount}{": "}{item.RecipeName}");
            }//end foreach

            return recipeBuilder.ToString();

        }//end of DisplayRecipeNamesMethod


        private void btnScale_Click(object sender, RoutedEventArgs e)
        {

            {
                gridRecipeNumber.Visibility = Visibility.Visible;
                textboxDisplayrecChoice.Visibility = Visibility.Visible;
                btnScaleNext.Visibility = Visibility.Visible;
                gridScaleValue.Visibility = Visibility.Visible;

            }
        }// end of btnScale_Click

        public void ScaleRecipe(int recipeIndex, double scalingFactor)
        {
            if (recipeIndex >= 0 && recipeIndex <= recipes.Count)
            {
                //choose recipe
                Recipe selectedRecipe = recipes[recipeIndex];

                //now the scaling
                foreach (var ingredient in selectedRecipe.Ingredients)
                {
                    double quantity;

                    if (double.TryParse(ingredient.textboxQuantity.Text, out quantity))
                    {
                        quantity *= scalingFactor;
                        ingredient.textboxQuantity.Text = quantity.ToString();
                    }//end if

                    //for the calories
                    double calories;

                    if (double.TryParse(ingredient.textboxCalories.Text, out calories))
                    {
                        calories *= scalingFactor;
                        ingredient.textboxCalories.Text = calories.ToString();
                    }//end if
                }//end foreach

                textBlockDisplay.Text = GetFormattedRecipeDisplay(recipeIndex + 1);

            }//end if


        }//end of ScaleRecipe

        private string GetFormattedRecipeDisplay(int displayRecChoice)
        {
            StringBuilder recipeBuilder = new StringBuilder();

            recipeBuilder.AppendLine("Recipe Name: ");
            var selectedRecipe = recipes[displayRecChoice - 1];
            recipeBuilder.AppendLine(selectedRecipe.RecipeName);

            recipeBuilder.AppendLine("Ingredients: \n");
            double totalCalories = 0;
            int count = 1;
            foreach (var ingredient in selectedRecipe.Ingredients)
            {
                recipeBuilder.AppendLine($"{count}) {ingredient.textboxQuantity.Text} {ingredient.textboxUnit.Text} of {ingredient.textboxIngredName.Text} (Calories: {ingredient.textboxCalories.Text}) (Food Group: {ingredient.comboFoodGroup.Text})");

                double calories;
                if (double.TryParse(ingredient.textboxCalories.Text, out calories))
                {
                    totalCalories += calories;
                }
                else
                {
                    recipeBuilder.AppendLine($"Note: '{ingredient.textboxCalories.Text}' is not a valid number for calories.");
                }

                count++;
            }

            recipeBuilder.AppendLine($"Total Calories: {totalCalories}\n");

            recipeBuilder.AppendLine("Steps: ");
            count = 1;
            foreach (var step in selectedRecipe.Steps)
            {
                recipeBuilder.AppendLine($"{count}) {step.textboxSteps.Text}");
                count++;
            }

            if (totalCalories > 300)
            {
                recipeBuilder.AppendLine($"YOU HAVE EXCEEDED YOUR CALORIE INTAKE OF 300!!!\nConsuming large amounts of calories can be harmful to your health\nPlease try scaling the recipe by 0.5");
            }
            else
            {
                recipeBuilder.AppendLine($"\nThis recipe is under 300 calories, which is a healthy calorie limit for a meal. Eating meals under 300 calories can aid in weight loss, and can also improve mental health.");
            }

            return recipeBuilder.ToString();

        }// end of GetFormattedRecipeDisplay

        private void btnScaleNext_Click(object sender, RoutedEventArgs e)

        {
            int displayRecChoice;
            if (int.TryParse(textboxDisplayrecChoice.Text, out displayRecChoice))
            {
                if (displayRecChoice > 0 && displayRecChoice <= recipes.Count)
                {
                    double scaleNum;
                    if (double.TryParse(textboxScaleNum.Text, out scaleNum))
                    {
                        ScaleRecipe(displayRecChoice - 1, scaleNum);
                    }
                    else
                    {
                        MessageBox.Show("INVALID SCALE NUMBER!!!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("INVALID RECIPE CHOICE!!!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid recipe number.");
            }

            // Hide input elements
            HideInputElements();

        }//end btnScaleNext_Click
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            gridRecipeNumber.Visibility = Visibility.Visible;
            textboxDisplayrecChoice.Visibility = Visibility.Visible;
            btnResetNext.Visibility = Visibility.Visible;
        }//end of btnReset_Click

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            gridRecipeNumber.Visibility = Visibility.Visible;
            textboxDisplayrecChoice.Visibility = Visibility.Visible;
            btnDeleteNext.Visibility = Visibility.Visible;

        }//end of btnDelete_Click

        // Method for performing reset action
        private void btnResetNext_Click(object sender, RoutedEventArgs e)
        {
            int displayRecChoice;
            if (int.TryParse(textboxDisplayrecChoice.Text, out displayRecChoice))
            {
                if (displayRecChoice > 0 && displayRecChoice <= recipes.Count)
                {
                    ResetRecipe(displayRecChoice - 1);
                }
                else
                {
                    MessageBox.Show("Please enter a valid recipe number.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
            }

            // Hide input elements
            HideInputElements();
        }//end of  btnResetNext_Click

        private void btnDeleteNext_Click(object sender, RoutedEventArgs e)
        {
            int displayRecChoice;
            if (int.TryParse(textboxDisplayrecChoice.Text, out displayRecChoice))
            {
                if (displayRecChoice > 0 && displayRecChoice <= recipes.Count)
                {
                    DeleteRecipe(displayRecChoice - 1);
                }
                else
                {
                    MessageBox.Show("Please enter a valid recipe number.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
            }

            // Hide input elements
            HideInputElements();
        }//end of btnDeleteNext_Click

        private void ResetRecipe(int recipeIndex)
        {
            Recipe selectedRecipe = recipes[recipeIndex];
            foreach (var ingredient in selectedRecipe.Ingredients)
            {
                // Reset the ingredient quantities and calories to their original values
                ingredient.textboxQuantity.Text = ingredient.OriginalQuantity;
                ingredient.textboxCalories.Text = ingredient.OriginalCalories;
            }

            MessageBox.Show($"Recipe '{selectedRecipe.RecipeName}' has been reset.");
            UpdateRecipeListTextBlock();

            // Hide relevant UI elements
            HideInputElements();
        }//end of ResetRecipe

        private void DeleteRecipe(int recipeIndex)
        {
            Recipe selectedRecipe = recipes[recipeIndex];
            recipes.RemoveAt(recipeIndex);

            MessageBox.Show($"Recipe '{selectedRecipe.RecipeName}' has been deleted.");
            UpdateRecipeListTextBlock();

            // Hide relevant UI elements
            HideInputElements();
        }//end of DeleteRecipe
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWin = new MainWindow();
            this.Close();
            mainWin.Show(); 
        }

        private void HideInputElements()
        {
            gridRecipeNumber.Visibility = Visibility.Hidden;
            textboxDisplayrecChoice.Visibility = Visibility.Hidden;
            btnDisplayRecCont.Visibility = Visibility.Hidden;
            btnScaleNext.Visibility = Visibility.Hidden;
            btnResetNext.Visibility = Visibility.Hidden;
            btnDeleteNext.Visibility = Visibility.Hidden;
            gridScaleValue.Visibility = Visibility.Hidden;
        }
    }
}
