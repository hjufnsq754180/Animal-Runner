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

    private void Start()
    {
        GameEventManager.PickLevel += OffAllPanels;
        GetMainMenuPanel();
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
    }

    public void GetSettingsPanel()
    {
        OffAllPanels();
        _settingsPanel.SetActive(true);
    }
    
    public void GetShopPanel()
    {
        OffAllPanels();
        _shopPanel.SetActive(true);
    }
    
    public void GetLevelListPanel()
    {
        OffAllPanels();
        _levelListPanel.SetActive(true);
    }
    
    public void GetAchivmentPanel()
    {
        OffAllPanels();
        _achivmentPanel.SetActive(true);
    }

}
