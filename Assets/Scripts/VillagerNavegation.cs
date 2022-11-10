using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerNavegation : MonoBehaviour
{
    [SerializeField]
    private MicroTask _microTask;

    private void Start()
    {
        _microTask.StartTask(UpdateCoins);
    }

    private void UpdateCoins(int coins)
    {
        Debug.Log(coins +" MOEDAS");
    }
}
