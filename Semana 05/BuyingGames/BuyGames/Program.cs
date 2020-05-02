using System;
namespace BuyGames
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      bool continuar = true;
      do
      {
        int opcion = 0;
        try
        {
          Console.Write(menu());
          opcion = Convert.ToInt32(Console.ReadLine());
          switch (opcion)
          {
            case 1:
              Banco.registrarTarjeta();
              break;
            case 2:
              Banco.consultarTarjetas();
              break;
            case 3:
              ConsolaJuegos.comprarJuego();
              break;
            case 4:
              ConsolaJuegos.jugar();
              break;
            case 5:
              continuar = false;
              break;
            default:
              Console.WriteLine("Opcion errónea!");
              break;
          }
        }
        catch (FormatException) {
          Console.WriteLine("Digite un numero porfavor!");
          opcion = 7;
        }
        catch (EmptyInputException exc) {
          Console.WriteLine(exc);
        }
        catch (NotExistingCardException exc) {
          Console.WriteLine(exc);
        }
      }while(continuar);
      Console.WriteLine("\nSaliendo.");
    }
    static string menu(){
      return "\nBienvenido:\n" +
             "1) Registrar tarjeta (banco).\n" +
             "2) Consultar tarjetas (banco).\n" +
             "3) Comprar videojuego (consola).\n" +
             "4) Jugar videojuego (consola).\n" +
             "5) Salir.\n" +
             "Opción elegida: ";
    }
  }
}