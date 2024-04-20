using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincipalDecorador : MonoBehaviour
{
    static GestorDecorador gestor;

    static void Main(string[] args)
    {
        gestor = GestorDecorador.GetInstancia();

        DecorarJugadores();

        Console.ReadLine();
    }

    static void DecorarJugadores()
    {
        Printer("Decoramos los personajes.\n");
        gestor.DecorarJugador(0, 1);
    }

    static void Printer(string pData)
    {
        Debug.Log(pData);
    }
}