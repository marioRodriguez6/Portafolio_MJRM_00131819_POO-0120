package com.MJRM.x00131819;

import java.sql.SQLOutput;

public class Main {

    public static void main(String[] args) {
	carro ds;
	ds = new carro();



        ds.iniciando();
        ds.enseñando();

        String marca = ds.enseñarMarca();
        String color = ds.enseñarColor();
        int año = ds.enseñarAño();
        int precio = ds.enseñarPrecio();

        System.out.println("Cambiando color y precio a peticion del cliente......");
        System.out.println("Cambio realizado con exito....");
        System.out.println("Nuevas especificaciones del carro" + "\n");

        ds.setColor("Rojo");
        ds.setPrecio(19000);

        String nmarca = ds.enseñarMarca();
        System.out.println("El nuevo color es: " + ds.getColor());
        int naño = ds.enseñarAño();
        System.out.println("el nuevo precio es de: " + ds.getPrecio() + " $");
    }
}
