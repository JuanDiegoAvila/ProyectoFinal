﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour
{
    public AudioClip[] songs;
    AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!music.isPlaying)
        {
            int song = Random.Range(0, songs.Length + 1);
            music.PlayOneShot(songs[song]);
        }
    }
}