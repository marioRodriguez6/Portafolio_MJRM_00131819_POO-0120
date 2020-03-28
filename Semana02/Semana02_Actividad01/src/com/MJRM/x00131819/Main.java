package com.MJRM.x00131819;

import java.util.ArrayList;
import java.util.Scanner;

public class Main {

    static Scanner ds = new Scanner(System.in);

    public static void main(String[] args) {
        ArrayList<Autor> authors = new ArrayList<>();
        ArrayList<Libro> books = new ArrayList<>();


        int op1 = 0;
        String ISBN, nombreB, nombreA, email;
        int paginas;
        char sexo;

        do {
            menu1();
            System.out.print("digite su opcion: ");
            op1 = ds.nextByte(); ds.nextLine();

            switch(op1){
                case 1:
                    System.out.print("ingresar ISBN del libro: "); ISBN = ds.nextLine();
                    System.out.print("Ingresar nombre del libro: "); nombreB = ds.nextLine();
                    System.out.print("ingresar el numero de paginas: "); paginas = ds.nextByte(); ds.nextLine();
                    books.add(new Libro(ISBN, nombreB, paginas));

                    System.out.println("Libro agregado con exito....");
                     break;
                case 2:
                    System.out.print("ingresar nombre del autor: "); nombreA = ds.nextLine();
                    System.out.print("Ingresar email del autor: "); email = ds.nextLine();
                    while(!email.contains("@")){
                        System.out.println("Correo incorrecto, intente de nuevo."); email = ds.nextLine();
                    }

                    System.out.print("ingresar sexo del autor (m/f): "); sexo = ds.next().charAt(0);
                    authors.add(new Autor(nombreA, email, sexo));
                    break;
                case 3:

                    System.out.println("digitar ISBN del libro a eliminar.");
                    String type = ds.nextLine();

                    books.removeIf(t -> t.eliminarLIbroISBN(type));
                    break;
                case 4:

                    System.out.println("digitar nombre de autor a eliminar.");
                    String type2 = ds.nextLine();

                    authors.removeIf(t -> t.eliminarAutor(type2));
                    break;
                case 5:
                    System.out.println(books.toString());
                    break;
                case 6:
                    System.out.println(authors.toString());
                    break;
                case 7:
                    System.out.println("saliendo del programa....");
                    break;
                default:
                    System.out.println("Opcion erronea! intente de nuevo" + "\n");
                    break;
            }
        }while(op1!=7);
    }
    static void menu1(){
        System.out.println("1. Agregar libro.");
        System.out.println("2. Agregar Autor.");
        System.out.println("3. Quitar libro. ");
        System.out.println("4. Quitar Autor. ");
        System.out.println("5. Mostrar libros. ");
        System.out.println("6. Mostrar Autores. ");
        System.out.println("7. Salir.");
    }
}
