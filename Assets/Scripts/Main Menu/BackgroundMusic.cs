using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic bgmusic;

    private void Awake()
    {
        if (bgmusic == null)
        {
            Destroy(gameObject);
        }
        else
        {
            bgmusic = this;
        }
        DontDestroyOnLoad(gameObject);
    }

}
