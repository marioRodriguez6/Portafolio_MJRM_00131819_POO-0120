package com.MJRM.x00131819;

import org.w3c.dom.ls.LSOutput;

public class Main {

    public static void main(String[] args) {
	Laptop m;
	m = new Laptop();

	m.encenderLap();
	m.caraLap();

	int ram = m.Obtenerram();
	int bateria = m.Obtenerbateria();
	String marca = m.obtenerMarca();
	String procesador = m.obtenerProcesador();

		System.out.println("\n");
		System.out.println("Cambiando Marca y Procesador con getters y setters...." + "\n");

	m.setMarca("Nueva Marca...." + " Mac");
		System.out.println(m.getMarca());

	m.setProcesador("Procesador cambiado..... " + "AMD");
		System.out.println(m.getProcesador());



    }
}
