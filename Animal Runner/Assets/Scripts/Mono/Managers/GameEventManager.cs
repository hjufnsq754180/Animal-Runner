using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEventManager
{
    public delegate void GameEvent();
    public static event GameEvent GameStart, GameOver, LevelComplite, Retry, AddCoinEvent;

	public delegate void UiEvent();
	public static event UiEvent PickLevel;



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
}
