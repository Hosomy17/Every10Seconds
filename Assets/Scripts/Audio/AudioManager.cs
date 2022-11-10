using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections.Generic;

namespace Village.Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;

        public Sound[] sounds;

        private Dictionary<string, Sound> sfxs = new Dictionary<string, Sound>();
        private Dictionary<string, Sound> musics = new Dictionary<string, Sound>();

        private string m_CurrentMusic = "-empty-";

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);

            foreach (Sound s in sounds)
            {
                if (s.isMusic)
                {
                    AddToDictionary(s, musics, true);
                    continue;
                }

                AddToDictionary(s, sfxs);
            }
        }

        public void PlaySFX(string name, bool continuous = false)
        {
            if (!sfxs.ContainsKey(name))
            {
                Debug.LogWarning("Efeito sonoro de nome '" + name + "' n�o encontrado");
                return;
            }

            if (!continuous)
            {
                sfxs[name].source.Stop();
            }

            sfxs[name].source.Play();
        }

        public void PlayMusic(string name)
        {
            if (m_CurrentMusic.Equals(name))
            {
                Debug.LogWarning("Musica '" + name + "' j� est� tocando");
                return;
            }

            if (!musics.ContainsKey(name))
            {
                Debug.LogWarning("Musica de nome '" + name + "' n�o encontrado");
                return;
            }

            if (m_CurrentMusic.Equals("-empty-"))
            {
                m_CurrentMusic = name;
            }

            musics[m_CurrentMusic].source.Stop();
            musics[name].source.Play();

            m_CurrentMusic = name;
        }

        private void AddToDictionary(Sound newSound, Dictionary<string, Sound> audioDictionary, bool loop = false)
        {
            newSound.source = gameObject.AddComponent<AudioSource>();
            newSound.source.clip = newSound.clip;

            newSound.source.volume = newSound.volume * (loop ? PlayerPrefs.GetFloat("music_volume") : PlayerPrefs.GetFloat("sfx_volume"));
            newSound.source.pitch = newSound.pitch;

            newSound.source.loop = loop;

            audioDictionary[newSound.name] = newSound;
        }

        public void SetSFXVolume(float newVolume)
        {
            PlayerPrefs.SetFloat("sfx_volume", newVolume);

            foreach (var sfx in sfxs)
            {
                sfx.Value.source.volume = sfx.Value.volume * newVolume;
            }
        }

        public void SetMusicVolume(float newVolume)
        {
            PlayerPrefs.SetFloat("music_volume", newVolume);

            foreach (var music in musics)
            {
                music.Value.source.volume = music.Value.volume * newVolume;
            }
        }
    }
}

