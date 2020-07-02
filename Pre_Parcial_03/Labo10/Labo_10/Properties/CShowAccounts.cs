using System;
using System.Collections.Generic;

namespace Labo_10.Properties
{
    public class CShowAccounts: AcManagement
    {
        public void Account(List<CuentaBancaria> ds)
        {
            ds.ForEach(accounts =>
            {
                Console.WriteLine($"Name: {accounts.Name}, ${accounts.ActualBalance}");
            });
        }
    }
}