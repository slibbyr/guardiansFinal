using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cuevas
{
public class tienda : Behaviour, salaI
{
    public void CambiarPiso(GameObject player, int nivel, List<GameObject> pisos)
    {
            foreach(GameObject piso in pisos){
                if(piso.CompareTag("zonaTienda")){
                    piso.SetActive(true);
                    break;
                }else{
                    piso.SetActive(false);
                }
                player.transform.position = new Vector2(-18.66f, -2.03f);
                GameObject salidaTienda = GameObject.FindWithTag("salida");
            }
    }
}
}