using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Work : MicroTask
{
    [SerializeField]
    private string _correct;
    
    [SerializeField]
    private string _wrong;
    
    private int _awnser;

    [SerializeField]
    private Sprite _sprite;

    [SerializeField]
    private Image _image;

    [SerializeField]
    private TMPro.TMP_Text _leftOption;
    
    [SerializeField]
    private TMPro.TMP_Text _rightOption;

    public override void StartTask(Finished callback)
    {
        base.StartTask(callback);
        _awnser = 0;
        
        while(_awnser == 0)
            _awnser = Random.Range(-1, 2);

        if (_awnser == -1)
        {
            _leftOption.text = _correct;
            _rightOption.text = _wrong;
        }
        else
        {
            _leftOption.text = _wrong;
            _rightOption.text = _correct;
        }

        _image.sprite = _sprite;
    }

    public void Update()
    {
        if (_activated == false)
        {
            return;
        }

        int guess = 0;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            guess--;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            guess++;

        if(guess == 0)
            return;
        
        Finish(guess == _awnser);
    }
}
