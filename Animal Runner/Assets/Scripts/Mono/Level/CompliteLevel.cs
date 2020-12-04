using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompliteLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            GameEventManager.TriggerLevelComplite();
        }
    }
}
