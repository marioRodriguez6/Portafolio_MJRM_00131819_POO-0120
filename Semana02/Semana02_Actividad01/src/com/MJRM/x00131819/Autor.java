package com.MJRM.x00131819;

public class Autor {

    private String nombre, email;
    private char genero;

    public Autor(String nombre, String email, char genero) {
        this.nombre = nombre;
        this.email = email;
        this.genero = genero;
    }

    public String getNombre() {
        return nombre;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public char getGenero() {
        return genero;
    }

    @Override
    public String toString() {
        return "Autor{" +
                "nombre='" + nombre + '\'' +
                ", email='" + email + '\'' +
                ", genero=" + genero +
                '}';
    }

    public boolean eliminarAutor(String s){
        if(this.nombre.equals(s)){
            System.out.println("Autor eliminado");
            return true;
        }

        return false;
    }
}
