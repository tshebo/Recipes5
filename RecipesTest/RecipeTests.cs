namespace RecipesTest
{
    [TestClass]
    public class RecipeTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            RecipeManager recipeManager = new RecipeManager();
            Recipe recipe = new Recipe();
            recipe.Calories.Add(100);
            recipe.Calories.Add(150);
            recipe.Calories.Add(200);

            // Act
            double totalCalories = recipeManager.CalculateTotalCalories(recipe);

            // Assert
            Assert.AreEqual(450, totalCalories);
        }
    }
}