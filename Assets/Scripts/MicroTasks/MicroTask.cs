using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MicroTask : MonoBehaviour
{
    [SerializeField]
    private int _coins = 3;
    
    protected bool _activated;


    //Passar metodo de pontos antes de começar
    public delegate void Finished(int coins);
    private Finished _finished; 
    
    //Iniciar minigame, passe o metodo de retorno para quando terminar a task
    public virtual void StartTask(Finished callback)
    {
        _finished = callback;
        _activated = true;
        
        gameObject.SetActive(true);
    }

    //Termine o minigame, em caso de fim do tempo do dia, passe falha para forçar saida
    public void Finish(bool result)
    {
        _activated = false;
        gameObject.SetActive(false);
        
        if (result == true)
        {
            _finished(_coins);
        }
        else
        {
            _finished(0);
        }
        
        _finished = null;
    }
}
