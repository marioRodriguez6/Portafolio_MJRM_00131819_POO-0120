namespace Labo_10
{
    public class CuentaBancaria
    {

        public readonly string Name;
        public double ActualBalance;


        public CuentaBancaria(string name = " ", double actualBalance = 0)
        {
            Name = name;
            ActualBalance = actualBalance;
        }
    }
}