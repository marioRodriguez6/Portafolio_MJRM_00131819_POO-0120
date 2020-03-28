package com.MJRM.x00131819;

public class Libro {

    private int ISBN;
    private String nombre;
    private int paginas;

    public Libro(String nombre, int paginas) {
        this.ISBN = GenerarISBN.nuevoISBN();
        this.nombre = nombre;
        this.paginas = paginas;
    }

    public int getISBN() {
        return ISBN;
    }

    public String getNombre() {
        return nombre;
    }

    public int getPaginas() {
        return paginas;
    }

    @Override
    public String toString() {
        return ISBN+": "+nombre+" (" +paginas+")    ";
    }

}