using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerHelper : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioSource jumpSFX;



    public void Play()
    {
        audioSource.Play();
    }

    public void JumpPlay()
    {
        jumpSFX.Play();
    }
}
