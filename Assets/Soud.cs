using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip up;
    public AudioClip bump;
    AudioSource aud;

    void Start()
    {
        this.aud = GetComponent<AudioSource>();
    }

    public void PlaySound1()
    {
        this.aud.PlayOneShot(this.up );
    }
    public void PlaySound2()
    {
        this.aud.PlayOneShot(this.bump );
    }
}