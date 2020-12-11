using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinSystem : MonoBehaviour
{
    [SerializeField] private int coinCount;
    [SerializeField] private TextMeshProUGUI coinCountText;

    private void Start()
    {
        coinCount = PlayerPrefs.GetInt("coinCount", 0);
        UpdateUICoin();
    }

    public void AddCoin(int coin)
    {
        coinCount += coin;
        PlayerPrefs.SetInt("coinCount", coinCount);
    }
    
    public void RemoveCoin(int coin)
    {
        coinCount -= coin;
        PlayerPrefs.SetInt("coinCount", coinCount);
    }

    public void UpdateUICoin()
    {
        coinCountText.text = coinCount.ToString();
        PlayerPrefs.SetInt("coinCount", coinCount);
    }
}
