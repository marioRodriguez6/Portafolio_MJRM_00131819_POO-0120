using System;
using System.Collections.Generic;
using Labo_10.Properties;

namespace Labo_10
{
    internal class Program
    {
        private delegate void Mydelegate(List<CuentaBancaria> ds);
        private static Mydelegate _accountmanagment;
        
        
        public static void Main(string[] args)
        {
            var users = new List<CuentaBancaria>();
            int opc1 = 0;
            string numTitular = "";
            double balanceCuenta = 0;

            AcManagement algoritmo = new CShowAccounts();
            
            do
            {
                Console.WriteLine(Menu1());
                Console.WriteLine("Digite la opcion deseada: ");
                opc1 = Int32.Parse(Console.ReadLine());
                switch (opc1)
                {
                    case 1:
                        Console.WriteLine("Ingrese una nueva cuenta bancaria.....");
                        
                        Console.WriteLine("ingrese nombre del titular de la cuenta:  ");
                        numTitular = Console.ReadLine();
                    
                        
                        Console.WriteLine("Digite el saldo a ingresar en la cuenta: ");
                        balanceCuenta = double.Parse(Console.ReadLine());

                        users.Add(new CuentaBancaria(numTitular,balanceCuenta));
                        break;
                    case 2:
                        algoritmo = new CShowAccounts();

                       _accountmanagment = algoritmo.Account;
                        _accountmanagment.Invoke(users);
                        
                        break;
                    case 3:
                        algoritmo = new CSumAccounts();
                        
                        _accountmanagment += algoritmo.Account;
                        _accountmanagment.Invoke(users);
                        break;
                    case 4:
                        

                        Console.WriteLine("---------");
                        
                        Action<List<CuentaBancaria>> myAccountAction = (maa) =>
                        {
                            maa.ForEach(account =>
                            {
                                    Console.WriteLine($"Nombre: {account.Name}, Saldo: ${account.ActualBalance}");
                            });
                        };

                        myAccountAction += maas =>
                        {
                            double salary = 0;

                            maas.ForEach(account =>
                            {
                                salary += account.ActualBalance;
                            });
                            
                            Console.WriteLine($"Suma de salarios: ${salary}");
                        };
                        myAccountAction.Invoke(users);

                        myAccountAction = voc =>
                        {
                            voc.ForEach(titular =>
                            {
                                if (titular.Name[0].Equals('a')  || titular.Name[0].Equals('e')
                                    || titular.Name[0].Equals('i') || titular.Name[0].Equals('o')
                                    || titular.Name[0].Equals('u'))
                                {
                                    Console.WriteLine("\n inicia con vocal..");
                                    Console.WriteLine($"Nombre: {titular.Name}, Saldo: ${titular.ActualBalance}");
                                }
                                else
                                {
                                    Console.WriteLine(" ");
                                }
                            });
                        };
                        myAccountAction.Invoke(users);
                        
                        break;
                    case 5:
                        Console.WriteLine("Saliendo del menu.....");
                        break;
                }
            } while (opc1 != 5);
        }
        //case 2 function
        public static void ShowAccounts(List<CuentaBancaria> sa)
        {
            sa.ForEach(accounts =>
            {
                Console.WriteLine($"Name: {accounts.Name}, ${accounts.ActualBalance}");
            });
        }
        
        public static void ShowSalary(List<CuentaBancaria> salary)
        {
            double salarios = 0;

            salary.ForEach(userSalary =>
            {
                salarios += userSalary.ActualBalance;
            });

            Console.WriteLine($"Suma de salarios: ${salarios}");
        }
        
        public static string Menu1()
        {
            return "----Iniciando menu---- \n 1. Agregar cuenta. \n 2. Ver cuentas almacenadas. \n 3. Ver cuentas " +
                   "almacenadas y el total de las cuentas. \n 4. Ver cuentas almacenadas, el total de las cuentas, y " +
                   "las cuentas de las personas que su nombre inicie con una vocal \n 5. Salir ";
        }
    }
}