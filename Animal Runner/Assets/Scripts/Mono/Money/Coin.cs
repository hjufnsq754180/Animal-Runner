using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            var a = FindObjectOfType<CoinCountInLive>();
            a.CoinInLevel += coinValue;
            var coinSfx = FindObjectOfType<SfxController>();
            coinSfx.PlayCoinClip();
            gameObject.SetActive(false);
        }
    }
}
