using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Componente;
using componente_Concreto;

public class GestorDecorador
{
    private List<Jugador> globalArrayJugador;
    private static GestorDecorador instancia;

    private GestorDecorador()
    {
        globalArrayJugador = new List<Jugador>();
    }

    public static GestorDecorador GetInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDecorador();
        }
        return instancia;
    }

    public void NuevaJugador(string pNombre, int pTipo)
    {
        Jugador p = null;
        switch (pTipo)
        {
            case 1:
                p = new JugadorVeloz(pNombre);
                break;
        }

        globalArrayJugador.Add(p);
    }

    public void DecorarJugador(int pIdJugador, int pTipoDecoracion)
    {
        Jugador p = GetJugador(pIdJugador);
        switch (pTipoDecoracion)
        {
            case 1:
                ReplaceJugadorArray(pIdJugador, new decorador_concreto.Pocion(p));
                break;
        }
    }

    public void QuitarDecorarJugador(int pIdJugador)
    {
        Jugador pDecorada = GetJugador(pIdJugador);
        ReplaceJugadorArray(pIdJugador, pDecorada);
    }

    public string PrintJugador(int pId)
    {
        Jugador pPA = GetJugador(pId);

        return pPA.GetNombre() + "\n"
              + pPA.GetVelocidad() + " km/h \n"
              + "Esta " + pPA.GetTipo();
    }

    public Jugador GetJugador(int pId)
    {
        return globalArrayJugador[pId];
    }

    public void ReplaceJugadorArray(int pId, Jugador pP)
    {
        globalArrayJugador[pId] = pP;
    }

    public void HandleDecoratorCollision()
    {
        Debug.Log("La velocidad del jugador se ha incrementado");
       
    }
}
