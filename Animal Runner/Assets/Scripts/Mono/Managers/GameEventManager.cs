using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEventManager
{
    public delegate void GameEvent();
    public static event GameEvent GameStart, GameOver, LevelComplite, Retry, AddCoinEvent, AddAdCoinEvent;

	public delegate void UiEvent();
	public static event UiEvent PickLevel;

	public delegate void ActiveCoins();
	public static event ActiveCoins ActiveCoinsLevel;

	public delegate void AdRewardCoin();
	public static event AdRewardCoin AdRewardCoins;

	public delegate void UpdateRichLevel();
	public static event UpdateRichLevel UpdateLevelUI;


	public static void TriggerGameStart()
	{
		if (GameStart != null)
		{
			GameStart();
		}
	}

	public static void TriggerGameOver()
	{
		if (GameOver != null)
		{
			GameOver();
		}
	}
	
	public static void TriggerLevelComplite()
	{
		if (LevelComplite != null)
		{
			LevelComplite();
		}
	}
	
	public static void TriggerPickLevel()
	{
		if (PickLevel != null)
		{
			PickLevel();
		}
	}
	
	public static void TriggerAddCoinEvent()
	{
		if (AddCoinEvent != null)
		{
			AddCoinEvent();
		}
	}
	public static void TriggerRetry()
	{
		if (Retry != null)
		{
			Retry();
		}
	}
	
	public static void TriggerActiveCoins()
	{
		if (ActiveCoinsLevel != null)
		{
			ActiveCoinsLevel();
		}
	}
	
	public static void TriggerAddAdCoinEvent()
	{
		if (AddAdCoinEvent != null)
		{
			AddAdCoinEvent();
		}
	}
	
	public static void TriggerAddAdRewardCoinsEvent()
	{
		if (AdRewardCoins != null)
		{
			AdRewardCoins();
		}
	}
	
	public static void TriggerUpdateUILevelEvent()
	{
		if (UpdateLevelUI != null)
		{
			UpdateLevelUI();
		}
	}
}
