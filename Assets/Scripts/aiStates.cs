using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class aiStates : MonoBehaviour
{
	public int randomNumber;
	public Player player;
	public Text displayState;

		public enum State
	{
		Aggressive,
		Defensive,
		Berserk,
	}
	[SerializeField] private State _state;

	private void Start()
	{
		
	}

    public void Update()
    {
        if (player.currentTurn == 1)
        {
			NextState();

		}
		//Debug.Log(player.currentTurn);
    }

    private void NextState()
	{
		switch(_state)
		{
			case State.Aggressive:
			StartCoroutine(AggressiveState());
			break;
			case State.Defensive:
			StartCoroutine(DefensiveState());
			break;
			case State.Berserk:
			StartCoroutine(BerserkState());
			break;
			default:
			Debug.LogWarning(" oops something when wrong");
			break;
		}
	}




	public void Aggressive()
	{
		if (player.currentTurn == 1)
		{
			System.Random rnd = new System.Random();
			randomNumber = rnd.Next(1,10);
			if (randomNumber > 3)
			{
				player.AiDamage(player.aiDamageDone);
				
			}
			else
			{
				player.AiHealing(player.aiHealingDone);
			}
		}
	}

	public void Defensive()
	{
		if (player.currentTurn == 1)
		{
			System.Random rnd = new System.Random();
			randomNumber = rnd.Next(1,10);
			if (randomNumber > 5)
			{
				player.AiDamage(player.aiDamageDone);
			}
			else
			{
				player.AiHealing(player.aiHealingDone);
			}
		}
	}

	public void Berserk()
	{
		if (player.currentTurn == 1)
		{
			player.AiDamage(player.aiDamageDone);
		}
	}
	
	private IEnumerator AggressiveState()
	{
		Debug.Log("AggressiveState entered");
		while (_state == State.Aggressive)
		{
			displayState.text = "Enemy is currently acting Aggressive";
			if (player.aiHealth <= 60)
			{
				_state = State.Defensive;
				Debug.Log("AggressiveState exited");

			}
			Aggressive();
			yield return null;
		}
		
		
	}
	private IEnumerator DefensiveState()
	{
		Debug.Log("DefensiveState entered");
		while (_state == State.Defensive)
		{
			displayState.text = "Enemy is currently acting Defensive";
			Defensive();
			if (player.aiHealth > 59)
			{
				_state = State.Aggressive;
				Debug.Log("DefensiveState exited");
			}
			else if (player.aiHealth < 30)
			{
				_state = State.Berserk;
				Debug.Log("DefensiveState exited");

			}
			yield return null;
		}
		
		
	}
	private IEnumerator BerserkState()
	{
		displayState.text = "Enemy is currently berserk";
		Debug.Log("BerserkState entered");
		while (_state == State.Berserk)
		{
			Berserk();
			if (player.aiHealth > 29)
			{
				_state = State.Defensive;
				Debug.Log("BerserkState exited");
			}
			yield return null;
		}
		
	}
}