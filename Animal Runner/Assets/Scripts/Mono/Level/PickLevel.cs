﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickLevel : MonoBehaviour
{
    [SerializeField] private List<GameObject> _levelsList;
    [SerializeField] private Button[] levelButtons;


    private SfxController sfxController;

    private void Start()
    {
        sfxController = FindObjectOfType<SfxController>();
        GameEventManager.UpdateLevelUI += UpdateUiLevels;
        UpdateUiLevels();
    }

    public void ActiveLevel(int curentLevel)
    {
        foreach (var item in _levelsList)
        {
            item.SetActive(false);
        }
        _levelsList[curentLevel - 1].SetActive(true);
        GameEventManager.TriggerGameStart();
        GameEventManager.TriggerPickLevel();

        GameManager gm = FindObjectOfType<GameManager>();
        gm._currentLevel = curentLevel;
        sfxController.PlayClickClip();
    }

    private void UpdateUiLevels()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
        
        for(int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 <= levelReached)
            {
                levelButtons[i].interactable = true;
            }
        }
        Debug.LogWarning("Открыт уровень: " + levelReached);
    }
}
