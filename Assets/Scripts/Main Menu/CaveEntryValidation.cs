using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveEntryValidation : MonoBehaviour
{
    public void EntryCave()
    {
        SceneManager.LoadSceneAsync("DragonCave 1");
    }

    public void GoBackTown()
    {
        SceneManager.LoadSceneAsync("town");
    }
}
