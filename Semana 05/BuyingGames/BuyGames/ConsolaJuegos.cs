using System;
using BuyGames;

public static class ConsolaJuegos{
    public static void comprarJuego(){
        Console.Write("Número de tarjeta: ");
        string numero = Console.ReadLine();
        if(numero.Replace(" ","").Equals(""))
            throw new EmptyInputException("Escribi algo Weon!");
        numero = numero.Trim(); //Quitar espacios locos
        
        if(Banco.realizarCompras(numero)){
            Console.Write("Nombre del juego: ");
            string juego = Console.ReadLine();
            if(juego.Replace(" ","").Equals(""))
                throw new EmptyInputException("Escribi algo weon!!");
            juego = juego.Trim(); //Quitar espacios locos
            
            GestorArchivos.Anexar("Juegos.txt", juego);
            
            Console.WriteLine("Juego comprado exitosamente!");
        }
        else
          throw new NotExistingCardException("Revisa si ingresaste bien la tarjeta");
    }
    
    public static void jugar(){
        Console.Write("Nombre del juego: ");
        string juego = Console.ReadLine();
        
        if(GestorArchivos.Buscar("Juegos.txt", juego))
            Console.WriteLine("Listo para jugar!");
        else
            Console.WriteLine("Primero debe comprar el juego :(");
    }
}