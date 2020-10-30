using System.Collections.ObjectModel;
using Prism.Mvvm;

namespace ViewImplementation.Models
{
   public class FoodItems : BindableBase
   {
      private ObservableCollection<FoodToppings> toppings;
      public FoodItems(string foodName)
      {
         FoodItem = foodName;
         toppings = new ObservableCollection<FoodToppings>()
         {
         };
      }
      public ObservableCollection<FoodToppings> Toppings
      {
         get
         {
            return toppings;
         }
         set
         {
                SetProperty(ref toppings, value);
            }
      }
      public string FoodItem { get; set; }

      public void addTopping(string topping)
      {
         bool exists = false;
         if (Toppings.Count > 0)
         {
            foreach (var foodt in Toppings)
            {
               if (foodt.FoodTopping == topping)
               {
                  Toppings.Remove(foodt);
                  exists = true;
                  break;
               }
            }
         }

         if (!exists)
            Toppings.Add(new FoodToppings(topping));
      }
   }
}
