using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCountInLive : MonoBehaviour
{
    [SerializeField] private int _coinInLevel;

    public int CoinInLevel { get => _coinInLevel; set => _coinInLevel = value; }

    [SerializeField] private TextMeshProUGUI _gameOverCoinText;

    private CoinSystem coinSystem;

    private void Start()
    {
        GameEventManager.GameOver += SetGameOverCoin;
        GameEventManager.AddCoinEvent += ChangeCoin;
        coinSystem = GetComponent<CoinSystem>();
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
}
