using Prism.Mvvm;

namespace ViewImplementation.Models
{
   public class FoodToppings : BindableBase
   {
      private string _strFoodTopping = string.Empty;
      public string FoodTopping
      {
         get
         {
            return _strFoodTopping;
         }
         set
         {
                SetProperty(ref _strFoodTopping, value);
            }
      }
      public FoodToppings(string foodTopping)
      {
         FoodTopping = foodTopping;
      }
   }
}
