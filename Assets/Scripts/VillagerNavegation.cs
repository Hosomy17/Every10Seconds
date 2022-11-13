using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class VillagerNavegation : MonoBehaviour
{
    [SerializeField]
    private GameObject _startPoint;
    
    [SerializeField]
    private EventSystem _eventSystem;

    [SerializeField]
    private List<MicroTask> _microTasks;

    [SerializeField]
    private TMP_Text _coinsText;
    
    private int _coins;

    public void GetTask(int index)
    {
        StartCoroutine(DisableEventSystem());
        
        _microTasks[index].StartTask(UpdateCoins);
    }

    private void UpdateCoins(int coins)
    {
        _coins += coins;
        _coinsText.text = "x" + _coins;

        StartCoroutine(EnableEventSystem());
    }

    private IEnumerator DisableEventSystem()
    {
        yield return new WaitForNextFrameUnit();
        EventSystem.current.SetSelectedGameObject(_startPoint);

        _eventSystem.enabled = false;
    }

    private IEnumerator EnableEventSystem()
    {
        yield return new WaitForNextFrameUnit();
        _eventSystem.enabled = true;
    }
}
