using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    private static AudioHandler audioHandle;
    public static AudioHandler AudioHandle
    {
        get
        {
            if (audioHandle == null)
                audioHandle = FindObjectOfType<AudioHandler>();

            return audioHandle;
        }
    }

  
    AudioSource music;

    

    //public void PlayTheMusic()
    //{
    //    music.Play();
    //}

    public void  StopTheMusic()
    {
        music.Stop();
    }

}
