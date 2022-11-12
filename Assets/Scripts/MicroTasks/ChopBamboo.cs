using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopBamboo : MicroTask
{
    [SerializeField]
    private int _goal = 10;

    private int _times;

    private bool _waitLeft;

    public override void StartTask(Finished callback)
    {
        base.StartTask(callback);
        _times = 0;
        _waitLeft = true;
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
            Debug.Log(_times);
        }
        
        if (_times >= _goal)
        {
            Debug.Log("Terminou");
            Finish(true);
        }
        
    }
}
