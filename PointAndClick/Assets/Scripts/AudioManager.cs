using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour 
{
    private AudioSource Source;
    public bool IsSound;

    private void Awake()
    {
            Source = gameObject.GetComponent<AudioSource>();
        if (IsSound == true)
        {
            //Source.volume = SFX SETTING
        }
        else
        {
            //Source.volume = MUSIC SETTING
        }
    }
}
