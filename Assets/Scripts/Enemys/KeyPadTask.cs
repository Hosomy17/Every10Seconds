using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyPadTask : MicroTask
{
    public TMP_Text _cardCode;

    public TMP_Text _inputCode;

    public int _codeLength = 5;

    public float _codeResetTimeInSeconds  = 0.2f;

    private bool _isReseting = false;

    private void OnEnable()
    {
        string code = string.Empty; 

        for(int i = 0; i < _codeLength; i++)
        {
            code += Random.Range(1, 9);

            _inputCode.text = string.Empty;
        }
    }

    public void ButtonClick(int number)
    {
        if (_isReseting)
        {
            return;
        }
        _inputCode.text += number;

        if(_inputCode.text == _cardCode.text)
        {
            _inputCode.text = "Correct";
            StartCoroutine(ResetCode());
            Finish(true);
        }
        else if(_inputCode.text.Length >= _codeLength)
        {
            _inputCode.text = "Failed";
            StartCoroutine(ResetCode());
        }
    }

    private IEnumerator ResetCode()
    {
        _isReseting = true;

        yield return new WaitForSeconds(_codeResetTimeInSeconds);

        _inputCode.text = string.Empty;
        _isReseting = false;
    }
}
