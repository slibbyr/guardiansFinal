

using System;
using System.Collections;
using System.Collections.Generic;

public class Gestor_Items
{
    private Item espada;
    private Item daga;
    private Item hacha;
    private Item pocion;
    private static List<Item> itemsArray = new List<Item>();

    public Gestor_Items()
    {
        espada = new Armas("Espada", 1, 40, 1, 0.5);
        daga = new Armas("Daga", 2, 35, 1, 0.3);
        hacha = new Armas("Hacha", 4, 60, 1, 0.7);
        pocion = new Pocion("Pocion", 3, 15, 5, 10);
    }

    public void new_item(int id)
    {
        Item newItem = null;

        switch (id)
        {
            case 1:
                newItem = new Armas("Espada", 1, 40, 1, 0.5);
                break;
            case 2:
                newItem = new Armas("Daga", 2, 35, 1, 0.3);
                break;
            case 3:
                newItem = new Pocion("Poción", 3, 15, 5, 10);
                break;
            case 4:
                newItem = new Armas("Hacha", 4, 60, 1, 0.7);
                break;
            default:
                break;
        }

        if (newItem != null)
        {
            itemsArray.Add(newItem);
        }
    }

}