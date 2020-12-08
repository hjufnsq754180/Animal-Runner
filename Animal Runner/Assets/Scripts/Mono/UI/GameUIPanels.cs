using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIPanels : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _levelComplitePanel;
    [SerializeField] private GameObject _levelListPanel;
    [SerializeField] private GameObject _achivmentPanel;
    //TODO: панели дневной награды, отключения рекламы

    [SerializeField] private List<GameObject> _allPanels;

    private SfxController sfxController;

    private void Start()
    {
        sfxController = FindObjectOfType<SfxController>();
        GameEventManager.PickLevel += OffAllPanels;

        //GET MAIN MENU PANEl
        OffAllPanels();
        GameEventManager.TriggerAddCoinEvent();
        _mainMenuPanel.SetActive(true);
    }

    private void OffAllPanels()
    {
        foreach (var item in _allPanels)
        {
            item.SetActive(false);
        }
    }

    public void GetMainMenuPanel()
    {
        OffAllPanels();
        GameEventManager.TriggerAddCoinEvent();
        _mainMenuPanel.SetActive(true);
        sfxController.PlayClickBackClip();
    }

    public void GetSettingsPanel()
    {
        OffAllPanels();
        _settingsPanel.SetActive(true);
        sfxController.PlayClickClip();
    }
    
    public void GetShopPanel()
    {
        OffAllPanels();
        _shopPanel.SetActive(true);
        sfxController.PlayClickClip();
    }
    
    public void GetLevelListPanel()
    {
        OffAllPanels();
        _levelListPanel.SetActive(true);
        sfxController.PlayClickClip();
    }
    
    public void GetAchivmentPanel()
    {
        OffAllPanels();
        _achivmentPanel.SetActive(true);
        sfxController.PlayClickClip();
    }

}
