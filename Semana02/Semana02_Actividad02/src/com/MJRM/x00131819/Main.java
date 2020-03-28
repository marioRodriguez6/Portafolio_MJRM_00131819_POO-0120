package com.MJRM.x00131819;

import java.util.ArrayList;
import java.util.Scanner;

public class Main {

    static Scanner ds = new Scanner(System.in);

    static ArrayList <Autor> autores = new ArrayList<>();
    static ArrayList <Libro> libros = new ArrayList<>();

    public static void main(String[] args) {
        byte opc;
        do {
            menu1();
            opc = ds.nextByte();
            ds.nextLine();
            switch (opc) {
                case 1:
                    System.out.println("Nombre del Libro");     String name = ds.nextLine();
                    System.out.println("Paginas del Libro");    int pages = ds.nextInt(); ds.nextLine();

                    libros.add(new Libro(name, pages));
                    System.out.println("Libro Agregado!");
                    break;
                case 2:

                    libros.forEach(System.out::println);
                    if (libros.isEmpty())
                        System.out.println("No hay ningun libro");
                    break;
                case 3:

                    System.out.println("ISBN del libro que quieres quitar:");
                    int isbn = ds.nextInt();
                    ds.nextLine();
                    boolean ad = true;
                    for (Libro libro : libros) {
                        if (libro.getISBN() == isbn) {
                            System.out.println("Libro con ISBN " + libro.getISBN() + " se ha removido");
                            ad = false;
                        }
                    }
                    if (ad)
                        System.out.println("No se encontro el libro");
                    else
                        libros.removeIf(s -> s.getISBN() == isbn);

                    break;
                case 4:

                    System.out.println("Nombre del Autor");
                    String name1 = ds.nextLine();
                    System.out.println("Correo del Autor");
                    String mail = ds.nextLine();

                    while (!mail.contains("@")) {
                        System.out.println("Correo incorrecto, intente de nuevo.");
                        mail = ds.nextLine();
                    }

                    System.out.println("Genero del Autor");
                    System.out.println("F/M");
                    char gen = ds.next().charAt(0);
                    ds.nextLine();

                    while (gen != 'f' && gen != 'm') {
                        System.out.println("genero incorrecto, intente de nuevo.");
                        gen = ds.next().charAt(0);
                        ds.nextLine();
                    }

                    mail = mail.toLowerCase();
                    autores.add(new Autor(name1, mail, gen));
                    System.out.println("Agregando...\nAgregado!");
            break;
            case 5:
                autores.forEach(System.out::println);
                if (autores.isEmpty())
                    System.out.println("No hay ningun autor");
                break;
            case 6:
                System.out.println("Correo del autor que quieres quitar:");
                String email = ds.nextLine();
                String finalMail = email.toLowerCase();
                boolean as = true;
                for (Autor autor : autores) {
                    if (autor.getEmail().equals(finalMail)) {
                        System.out.println("Autor con correo " + autor.getEmail() + " se ha removido");
                        as = false;
                    }
                }
                if (as)
                    System.out.println("No se encontro autor");
                else
                    autores.removeIf(s -> s.getEmail().equals(finalMail));

                break;
            case 0:
                return;
            default:
                System.out.println("Opcion incorreta!");
            }
        }while(true);
    }
    static void menu1(){
        System.out.println("1. Agregar libro.");
        System.out.println("2. Mostrar libros.");
        System.out.println("3. Quitar libro. ");
        System.out.println("4. Agregar Autor. ");
        System.out.println("5. Mostrar Autor. ");
        System.out.println("6. Quitar Autores. ");
        System.out.println("7. Salir.");
        System.out.println("Opcion a escoger: ");
    }

    static void añadirAutor(){
        System.out.println("Nombre del Autor");     String name = ds.nextLine();

        System.out.println("Correo del Autor");     String mail = ds.nextLine();

        while(!mail.contains("@")){
            System.out.println("Correo incorrecto, intente de nuevo."); mail = ds.nextLine();
        }

        System.out.println("Genero del Autor");
        System.out.println("F/M");
        char gen = ds.next().charAt(0); ds.nextLine();

        while(gen != 'f' &&  gen != 'm'){
            System.out.println("genero incorrecto, intente de nuevo.");
            gen = ds.next().charAt(0); ds.nextLine();
        }

        mail = mail.toLowerCase();
        autores.add(new Autor(name, mail, gen));
        System.out.println("Agregando...\nAgregado!");
    }

}