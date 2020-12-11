using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCountInLive : MonoBehaviour
{
    [SerializeField] private int _coinInLevel;

    public int CoinInLevel { get => _coinInLevel; set => _coinInLevel = value; }

    [SerializeField] private TextMeshProUGUI _gameOverCoinText;

    [SerializeField] private TextMeshProUGUI _WinCoinText;
    [SerializeField] private TextMeshProUGUI _WinCoinTextReward;
    [SerializeField] private TextMeshProUGUI _WinCoinTextNotReward;
    [SerializeField] private TextMeshProUGUI _WinCoinTextRewardPanel;

    private CoinSystem coinSystem;

    [Header("Coin Multiply")]
    [SerializeField] private int _coinMulti;

    private void Start()
    {
        GameEventManager.GameOver += SetGameOverCoin;
        GameEventManager.AddCoinEvent += ChangeCoin;
        GameEventManager.LevelComplite += SetWinCoin;
        GameEventManager.AddAdCoinEvent += AdChangeCoin;
        coinSystem = GetComponent<CoinSystem>();
    }

    private void AdChangeCoin()
    {
        coinSystem.AddCoin(_coinInLevel * _coinMulti);
        coinSystem.UpdateUICoin();
        _coinInLevel = 0;
    }

    private void ChangeCoin()
    {
        coinSystem.AddCoin(_coinInLevel);
        coinSystem.UpdateUICoin();
        _coinInLevel = 0;
    }

    private void SetGameOverCoin()
    {
        _gameOverCoinText.text = "Coin: " + _coinInLevel;
    }
    
    private void SetWinCoin()
    {
        _WinCoinText.text = "Coin: " + _coinInLevel;
        _WinCoinTextReward.text = "REWARD " + _coinInLevel * _coinMulti;
        _WinCoinTextNotReward.text = "GET REWARD " + _coinInLevel;
        _WinCoinTextRewardPanel.text = "YOU GET " + _coinInLevel * _coinMulti + " coins!";
    }
}
