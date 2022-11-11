using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Work : MicroTask
{
    [SerializeField]
    private Sprite _sprite;

    [SerializeField]
    private Image _image;

    [SerializeField]
    private int _awnser; 
    public override void StartTask(Finished callback)
    {
        base.StartTask(callback);
        _awnser = 0;

        //while (_awnser = Random.Range(-1, 2));
    }

    public void Update()
    {
        
    }
}
