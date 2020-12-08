using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWorld : MonoBehaviour
{
    [SerializeField] private List<GameObject> _worldList;
    [SerializeField] private int _currentWorld;

    private SfxController sfxController;

    private void Start()
    {
        sfxController = FindObjectOfType<SfxController>();
        _currentWorld = PlayerPrefs.GetInt("currentWorld", 0);
        OffAllWorld();
        GetCurrentWorld();
    }

    public void NextWorld()
    {
        OffAllWorld();
        if (_currentWorld + 1 == _worldList.Count)
        {
            _currentWorld = 0;
        }
        else
        {
            _currentWorld++;
        }
        GetCurrentWorld();
        sfxController.PlayClickClip();
    }

    public void PreviousWorld()
    {
        OffAllWorld();
        if (_currentWorld == 0)
        {
            _currentWorld = _worldList.Count - 1;
        }
        else
        {
            _currentWorld--;
        }
        GetCurrentWorld();
        sfxController.PlayClickClip();
    }

    private void GetCurrentWorld()
    {
        _worldList[_currentWorld].SetActive(true);
        PlayerPrefs.SetInt("currentWorld", _currentWorld);
    }

    private void OffAllWorld()
    {
        foreach (var item in _worldList)
        {
            item.SetActive(false);
        }
    }
}
