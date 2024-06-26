﻿using System.Collections;

using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    
    
    
    private int currentCharacterIndex = 0;
    private const int maxCharacters = 4;

    public GameObject[] playerPrefab;
    public GameObject[] enemyPrefab;

    
    

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;
    

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;
    public string DragonCave_1;

    private CommandInvoker _invoker;

    public int randomNumber;
    

    void Start()
    {
        randomNumber = Random.Range(0, 3);
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    

    public void ChangeScene()
    {
        SceneManager.LoadScene(DragonCave_1);
    }

    IEnumerator SetupBattle()
    {
        
        SpawnCharater();

        GameObject enemyGO = Instantiate(enemyPrefab[randomNumber], enemyBattleStation);
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
        dialogueText.text = "Que vas a hacer?";
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

    public void OnChangeButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerChange());
    }



    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }



    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }


    public void ChangeScenes()
    {
        _invoker.InvokeCommand();
    }

}


//command
public interface Command
{
    void Execute();
}


public class SceneCommand : Command

{
    public string DragonCave_1;

    public void Execute()
    {
        SceneManager.LoadScene(DragonCave_1);

    }
}


public class CommandInvoker : MonoBehaviour
{
    private Command _command;

    public void SetCommand(Command command)
    {
        _command = command;
    }

    public void InvokeCommand()
    {
        _command.Execute();
    }
}


