package com.MJRM.x00131819;

public class Autor {
    private String nombre;
    private String email;
    private char genero;

    public Autor(String nombre, String email, char genero) {
        this.nombre = nombre;
        this.email = email;
        this.genero = genero;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public void setGenero(char genero) {
        this.genero = genero;
    }

    public String getNombre() {
        return nombre;
    }

    public String getEmail() {
        return email;
    }

    public char getGenero() {
        return genero;
    }

    @Override
    public String toString() {
        return nombre+" ("+genero+"): "+email;
    }
}