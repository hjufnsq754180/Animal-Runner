using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeShopPanels : MonoBehaviour
{
    [SerializeField] private List<GameObject> _shopPanels;
    [SerializeField] private List<Button> _shopPanelsButton;

    private void Start()
    {
        OffAllShopPanels();
        _shopPanels[0].SetActive(true);
        _shopPanelsButton[0].interactable = false;
    }

    private void OffAllShopPanels()
    {
        foreach (var item in _shopPanels)
        {
            item.SetActive(false);
        }

        foreach (var item in _shopPanelsButton)
        {
            item.interactable = true;
        }
    }

    #region ShopButtons

    public void ActiveDonatPanel()
    {
        OffAllShopPanels();
        _shopPanels[0].SetActive(true);
        _shopPanelsButton[0].interactable = false;
    }

    public void ActiveSkinPanel()
    {
        OffAllShopPanels();
        _shopPanels[1].SetActive(true);
        _shopPanelsButton[1].interactable = false;
    }

    public void ActiveDecorationPanel()
    {
        OffAllShopPanels();
        _shopPanels[2].SetActive(true);
        _shopPanelsButton[2].interactable = false;
    }

    public void ActiveEffectPanel()
    {
        OffAllShopPanels();
        _shopPanels[3].SetActive(true);
        _shopPanelsButton[3].interactable = false;
    }

    #endregion
}
