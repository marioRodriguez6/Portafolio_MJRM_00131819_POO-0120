using System;
using System.Collections.Generic;

namespace Labo_10.Properties
{
    public class CSumAccounts: AcManagement
    {
        public void Account(List<CuentaBancaria> ds)
        {
            double salarios = 0;
            
            ds.ForEach(accounts =>
            {
                Console.WriteLine($"Name: {accounts.Name}, ${accounts.ActualBalance}");
            });
            

            ds.ForEach(userSalary =>
            {
                salarios += userSalary.ActualBalance;
            });

            Console.WriteLine($"Suma de salarios: ${salarios}");
        }
    }
}