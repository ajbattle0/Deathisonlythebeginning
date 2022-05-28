using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance { get; private set; }
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource ambientNoiseSource;
    public AudioClip sad, happy, ambiont;

    public void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    public void PlayMusic(AudioClip music = null)
    {
        if(music != null && musicSource.clip != music)
        {
            musicSource.clip = music;           
        }
        musicSource.Play();
    }
    public void StopMusic()
    {     
        musicSource.Stop();
    }
    public void PlayAmbient(AudioClip music = null)
    {
        if (music != null && ambientNoiseSource.clip != music)
        {
            ambientNoiseSource.clip = music;
        }
        ambientNoiseSource.Play();
    }
    public void StopAmbient()
    {
        ambientNoiseSource.Stop();
    }
}