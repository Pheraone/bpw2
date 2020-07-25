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

    // Start is called before the first frame update
    AudioSource music;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayTheMusic()
    {
        music.Play();
    }

    public void  StopTheMusic()
    {
        music.Stop();
    }

}
