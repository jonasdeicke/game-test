using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource playerShot;
    public AudioSource hitSound;
    public AudioSource gameMusic;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayPlayerShot()
    {
        playerShot.Play();
    }

    public void PlayHitSound()
    {
        hitSound.Play();
    }

    public void PlayGameMusic()
    {
        gameMusic.loop = true;//not working
        gameMusic.Play();
    }
}
