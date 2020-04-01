package com.MJRM.x00131819;

public final class GenerarISBN {
    private static int counting = 0;
    private GenerarISBN(){}

    public static int nuevoISBN(){
        counting++;
        return counting;
    }
}