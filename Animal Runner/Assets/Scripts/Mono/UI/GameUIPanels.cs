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
    [SerializeField] private GameObject _getAdCoinPanel;
    [SerializeField] private GameObject _getAdCoinPanelInShop;
    //TODO: панели дневной награды, отключения рекламы, кнопки выхода
    [SerializeField] private GameObject _coinPanel;

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
        _coinPanel.SetActive(true);
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
        _getAdCoinPanelInShop.SetActive(false);
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

    public void GetAdRewardCoin()
    {
        //TODO: IF Логика показа рекламы за коин 
        GameEventManager.TriggerAddAdCoinEvent();
        OffAllPanels();
        Debug.LogWarning("Реклама просмотрена!");
        //_levelListPanel.SetActive(true);
        _getAdCoinPanel.SetActive(true);
        sfxController.PlayClickClip();
    }

    public void GetAdCoinPanel()
    {
        OffAllPanels();
        _levelListPanel.SetActive(true);
        _coinPanel.SetActive(true);
        sfxController.PlayClickClip();
    }

    public void GetRewardCoin()
    {
        GameEventManager.TriggerAddCoinEvent();
        OffAllPanels();
        _levelListPanel.SetActive(true);
        _coinPanel.SetActive(true);
        sfxController.PlayClickClip();
    }

    public void GetAdRewardCoinShop()
    {
        //TODO: IF Логика показа рекламы за коин 
        GameEventManager.TriggerAddAdRewardCoinsEvent();
        _getAdCoinPanelInShop.SetActive(true);
        sfxController.PlayClickClip();
    }

    public void GetAdCoinPanelShop()
    {
        _getAdCoinPanelInShop.SetActive(false);
        sfxController.PlayClickClip();
    }
}
