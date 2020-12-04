using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryButton : MonoBehaviour
{
    public void Retry()
    {
        GameEventManager.TriggerAddCoinEvent();
        GameEventManager.TriggerRetry();
        GameEventManager.TriggerPickLevel();
    }
}
