using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCoinsInLevel : MonoBehaviour
{
    [SerializeField] private List<Coin> _coins;
    //[SerializeField] private Coin coins;

    private void OnEnable()
    {
        ActiveCoins();
    }

    private void Awake()
    {
        ActiveCoins();
        GameEventManager.ActiveCoinsLevel += ActiveCoins;
    }

    private void ActiveCoins()
    {
        GetComponentsInChildren<Coin>(true, _coins);
        foreach (var item in _coins)
        {
            item.gameObject.SetActive(true);
        }
    }
}
