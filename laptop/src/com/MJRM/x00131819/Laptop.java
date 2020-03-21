package com.MJRM.x00131819;

import java.io.Serializable;

public class Laptop {
    private String marca;
    private String procesador;
    private int bateria;
    private int ram;

    //constructores
    public Laptop(){
        marca = "Lenovo";
        procesador = "Ryzen";
        bateria = 11000;
        ram = 16;
    }

    public Laptop (String marca, String procesador, int bateria, int ram){
        this.marca = marca;
        this.procesador = procesador;
        this.bateria = bateria;
        this.ram = ram;
    }

    //Metodos
    public void encenderLap(){
        System.out.println("Encendiendo la laptop.....");
    }

    public void caraLap(){
        System.out.println("Enseñando caracteristicas de su laptop.....\n");
    }

    //atributos

    public int Obtenerram(){
        System.out.println("Ram en su computadora: " + ram + " G");
        return this.ram;
    }

    public int Obtenerbateria(){
        System.out.println("Potencia de bateria en su computadora: " + bateria + "Mh");
        return this.bateria;
    }

     public String obtenerMarca(){
        System.out.println("La marca de su laptop es: " + marca);
        return this.marca;
        }

     public String obtenerProcesador(){
        System.out.println("El procesador de su laptop es: " + procesador);
        return this.procesador;
    }

    public String getMarca() {
        return marca;
    }

    public void setMarca(String marca) {
        this.marca = marca;
    }

    public String getProcesador() {
        return procesador;
    }

    public void setProcesador(String procesador) {
        this.procesador = procesador;
    }
}
