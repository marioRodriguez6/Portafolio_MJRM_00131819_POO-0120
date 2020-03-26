package com.MJRM.x00131819;

public class carro {
    private String marca;
    private String color;
    public int año;
    public int precio;

    public carro(){
        marca = "Jeep";
        color = "Negro Mate";
        precio = 20500;
        año = 2020;
    }

    public carro(String marca, String color, int año, int precio){
        this.marca = marca;
        this.color = color;
        this.año = año;
        this.precio = precio;
    }

    //metodos
    public void iniciando(){
        System.out.println("Bienvenido a Grupo Q....");
    }

    public void enseñando(){
        System.out.println("Le mostraremos las caracteristicas su auto Señor. \n");
    }

    public String enseñarMarca(){
        System.out.println("la marca de su carro es: " + marca);
        return this.marca;
    }

    public String enseñarColor(){
        System.out.println("el color de su carro es: " + color);
        return this.color;
    }

    public int enseñarAño(){
        System.out.println("El carro es año: " + año);
        return this.año;
    }

    public int enseñarPrecio(){
        System.out.println("El precio del carro es de: " + precio + "  $\n");
        return this.precio;
    }
        //getters y setters
        public String getColor() {
            return color;
        }

        public void setColor(String color) {
            this.color = color;
        }

        public int getPrecio() {
            return precio;
        }

        public void setPrecio(int precio) {
            this.precio = precio;
        }
}

