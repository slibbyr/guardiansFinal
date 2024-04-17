using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
public enum CharacterState { ALIVE, DEAD }

public class BattleSystem : MonoBehaviour
{

    private int currentCharacterIndex = 0;
    private const int maxCharacters = 4;

    public GameObject[] playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;
    

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;
    public CharacterState characterState;

    public string DragonCave_1;


    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        SpawnCharater();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = "Un " + enemyUnit.unitName + " se acerca...";

        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }
    void SpawnCharater()
    {
        GameObject playerGO = Instantiate(playerPrefab[currentCharacterIndex], playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        playerHUD.SetHUD(playerUnit);

        playerGO.transform.parent = transform;

    }


    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage, enemyUnit.defense);

        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "El ataque fue exitoso";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }



    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.unitName + " ataca!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage, playerUnit.defense);

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {

            GameObject currentPlayer = playerPrefab[currentCharacterIndex];
            playerUnit = currentPlayer.GetComponent<Unit>();


            GameObject nextPlayer = playerPrefab[(currentCharacterIndex + 1) % maxCharacters];
            playerUnit = nextPlayer.GetComponent<Unit>();

            if (playerUnit.currentHP > 0)
            {
                StartCoroutine(PlayerChangeDead());
            }
            else
            {
                state = BattleState.LOST;
                EndBattle();
            }

        }
        else
        {

            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }

    }
    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(DragonCave_1);

    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "Has ganado el combate";
            ChangeScene();
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "Has sido derrotado";
        }
    }

    void PlayerTurn()
    {

        dialogueText.text = "Escogue tu accion:";
    }

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(5);

        playerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text = "Te has curado";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    IEnumerator PlayerChange()
    {
        Destroy(transform.GetChild(0).gameObject);
        currentCharacterIndex = (currentCharacterIndex + 1) % maxCharacters;

        SpawnCharater();

        dialogueText.text = "Cambio de personaje";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    IEnumerator PlayerChangeDead()
    {
        Destroy(transform.GetChild(0).gameObject);
        currentCharacterIndex = (currentCharacterIndex + 1) % maxCharacters;

        SpawnCharater();

        dialogueText.text = "Cambio de personaje";

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }



    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void OnChangeButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerChange());
    }



    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }

}
