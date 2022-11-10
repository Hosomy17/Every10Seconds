using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Village.Audio;

namespace Village.Audio
{
    public class MenuController : MonoBehaviour
    {
        private void Start()
        {
            AudioManager.instance.PlayMusic("MenuMusic");
        }

        public void StartGameplay()
        {
            AudioManager.instance.PlaySFX("MenuMusic");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
        
        public void GetSFXNewVolume(float volume)
                {
                    AudioManager.instance.SetSFXVolume(volume);
                }
        
                public void GetMusicNewVolume(float volume)
                {
        
                    AudioManager.instance.SetMusicVolume(volume);
                }


    }
}
