using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private GameObject _startPoint;
	private PlayerController _playerController;

	[SerializeField] private GameObject _gameOverPanel;
	[SerializeField] private GameObject _levelComplitePanel;
	[SerializeField] private GameObject _coinPanel;

	private SfxController _sfxController;

	public int _currentLevel;

	void Start()
	{
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
		GameEventManager.LevelComplite += LevelComplite;
		GameEventManager.Retry += Retry;

		_playerController = FindObjectOfType<PlayerController>();
		_sfxController = FindObjectOfType<SfxController>();
		Time.timeScale = 0;
	}


	private void GameStart()
	{
		print("Игра началась");
		Time.timeScale = 1;
		_playerController.gameObject.transform.position = _startPoint.transform.position;
		_coinPanel.SetActive(false);
	}

	private void LevelComplite()
	{
		print("Уровень пройден");
		_sfxController.PlayWinClip();
		_levelComplitePanel.SetActive(true);
		PlayerPrefs.SetInt("levelReached", _currentLevel + 1);
		PlayerPrefs.Save();
		GameEventManager.TriggerUpdateUILevelEvent();
		Time.timeScale = 0;
	}

	private void GameOver()
	{
		print("Игра закончилась");
		_sfxController.PlayGameOverClip();
		_gameOverPanel.SetActive(true);
		Time.timeScale = 0;
	}
	
	private void Retry()
	{
		Time.timeScale = 1;
		_sfxController.PlayClickClip();
		_playerController.gameObject.transform.position = _startPoint.transform.position;
	}
}
