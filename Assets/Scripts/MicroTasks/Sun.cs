using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    private RectTransform _rect;

    private float _maxTime = 10f;
    private float _time = 0f;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (_rect.anchorMin.x < 1)
        {
            _time += Time.deltaTime;
            var pos = _time / _maxTime;
            var vet = Vector2.one;
            vet.x = pos; 
            
            _rect.anchorMin = vet;
            _rect.anchorMax = vet;
            _rect.pivot = vet;
        }
    }
}
