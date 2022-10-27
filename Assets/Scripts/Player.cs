using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Player : MonoBehaviour
{
    public int playerHealth;
    public int aiHealth = 90 ;
    public Text playerHealthText;
    public Text aiHealthText;
    public int maxPlayerHealth = 90;
    public int maxAiHealth = 90;
    public int currentTurn;
    public int aiDamageDone = 15;
    public int aiHealingDone = 10;

    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        playerHealthText.text = playerHealth.ToString() + " health remaining";
        aiHealthText.text = aiHealth.ToString() + " health remaining";

    }

    public void PlayerDamage(int aiDamageTaken)                                 //player attacking
    {
        if (aiHealth - aiDamageTaken < 0 )
        {
            aiHealth = 0;
        }
        else
        {
            aiHealth -= aiDamageTaken;
        }
        currentTurn = 1;
        UpdateUI();
    }

    public void AiDamage(int playerDamageTaken)                                 //ai attacking
    {
        if (playerHealth - playerDamageTaken < 0)
        {
            playerHealth = 0;
        }
        else
        {
            playerHealth -= playerDamageTaken;
        }
        currentTurn = 0;
        UpdateUI();
    }

    public void PlayerHealing(int playerHealed)                                 //player healing
    {
        if (playerHealth + playerHealed > maxPlayerHealth)
        {
            playerHealth = maxPlayerHealth;
        }
        else
        {
            playerHealth += playerHealed;
        }
        currentTurn = 1;
        UpdateUI();
    }

    public void AiHealing(int aiHealed)                                             //ai healing
    {
        if (aiHealth + aiHealed > maxAiHealth)
        {
            aiHealth = maxAiHealth;
        }
        else
        {
            aiHealth += aiHealed;
        }
        currentTurn = 0;
        UpdateUI();
    }
}
