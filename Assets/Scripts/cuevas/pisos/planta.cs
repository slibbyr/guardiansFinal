using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cuevas
{
public class planta : Behaviour, salaI
{
    public void CambiarPiso(GameObject player, int nivel, List<GameObject> pisos)
    {
            int cont=0;
            foreach(GameObject piso in pisos){
                if(cont == nivel){
                    piso.SetActive(true);
                    break;
                }else{
                    piso.SetActive(false);
                    cont++;
                }
                player.transform.position = new Vector2(-18.66f, -2.03f);
            }
        }
    }
}