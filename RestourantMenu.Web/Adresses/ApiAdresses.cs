using System.Collections.Generic;

namespace RestourantMenu.Web.Adresses
{
    public class ApiAddresses
    {
        public ApiAddresses()
        {
            CategoryAddress = "http://localhost:5000/api/Category";
            FoodAddress = "http://localhost:5000/api/Food";
            TodaysFoodAddress = "http://localhost:5000/api/TodaysFood";
        }

        public string CategoryAddress { get; set; }
        public string FoodAddress { get; set; }
        public string TodaysFoodAddress { get; set; }
    }
    


}
