using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text coinsText;
    public TMP_Text teamText;   

    private PlayerManager playerManager;

    private static UI instance; 

    public static UI Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UI>();
                if (instance == null)
                {
                    Debug.LogError("No UI instance found in the scene.");
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
       

        healthText = GameObject.Find("HPTxt").GetComponent<TMP_Text>();
        coinsText = GameObject.Find("CoinsTxt").GetComponent<TMP_Text>();
        teamText = GameObject.Find("TeamTxt").GetComponent<TMP_Text>();

        if (healthText == null || coinsText == null || teamText == null)
        {
            Debug.LogError("One or both Text GameObjects not found or Text component missing.");
        }

        playerManager = PlayerManager.Instance;

        if (playerManager == null)
        {
            Debug.LogError("PlayerManager not found or not initialized.");
        }

        UpdateUIText();
    }

    private void UpdateUIText()
    {
        

        if (playerManager != null && healthText != null && coinsText != null)
        {
            Debug.LogWarning(playerManager.GetHeroesTeam());
            teamText.text = playerManager.GetHeroesTeam();
            healthText.text = playerManager.GetHeroCurrentHP().ToString() + "/" + playerManager.GetHeroMaxHP().ToString();
            coinsText.text = playerManager.GetCoinBalance().ToString();
        }
    }

    public void UpdateUI()
    {
        UpdateUIText();
    }

}
