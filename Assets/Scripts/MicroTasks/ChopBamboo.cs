using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChopBamboo : MicroTask
{
    [SerializeField]
    private Sprite _animatio1;
    
    [SerializeField]
    private Sprite _animatio2;

    [SerializeField]
    private Image _image;
    
    [SerializeField]
    private int _goal = 10;

    private int _times;

    private bool _waitLeft;

    public override void StartTask(Finished callback)
    {
        base.StartTask(callback);
        
        _times = 0;
        _waitLeft = true;
        _image.sprite = _animatio1;
    }

    public void Update()
    {
        if (_activated == false)
        {
            return;
        }
        
        var pressLeft = Input.GetKeyDown(KeyCode.LeftArrow);
        var pressRight = Input.GetKeyDown(KeyCode.RightArrow);

        if (pressLeft && pressRight)
        {
            return;
        }
        
        if ((_waitLeft && pressLeft) || (!_waitLeft && pressRight))
        {
            _times++;
            _waitLeft = !_waitLeft;

            //se times dividido por 2 sobra 0 é par usa animation1, se não impar usa animation2
            _image.sprite = (_times % 2 == 0) ? _animatio1 : _animatio2; 
            
            Debug.Log(_times);
        }
        
        if (_times >= _goal)
        {
            Debug.Log("Terminou");
            Finish(true);
        }
        
    }
}
