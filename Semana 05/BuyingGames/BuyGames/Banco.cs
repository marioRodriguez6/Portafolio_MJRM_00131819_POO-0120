using System;
using BuyGames;

public static class Banco{
    public static void registrarTarjeta(){
        Console.Write("Número de tarjeta: ");
        string numero = Console.ReadLine();
        if(numero.Replace(" ","").Equals(""))
            throw new EmptyInputException("Escribi algo weon!!");
        numero = numero.Trim(); //Quitar espacios locos
        GestorArchivos.Anexar("Tarjetas.txt", numero);
        
        Console.WriteLine("Tarjeta creada exitosamente!");
    }
    
    public static void consultarTarjetas(){
        Console.WriteLine(GestorArchivos.Leer("Tarjetas.txt"));
    }
    
    public static bool realizarCompras(string tarjeta){
        return GestorArchivos.Buscar("Tarjetas.txt", tarjeta);
    }
}