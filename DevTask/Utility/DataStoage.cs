using DevTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTask.Utility
{
    public class DataStoage
    {
        public static List<Customers> GetAllCustomers() =>
            new List<Customers>
            {
                new Customers { CustomerFirstName="Mike", CustomerLastName="Turner", CustomerGender="Male", CustomerEmail="asdasdas"}
   
            };

    }
}
