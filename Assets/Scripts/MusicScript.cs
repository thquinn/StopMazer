﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public AudioSource[] bgms;
    public AudioSource currentBGM;

    bool stopped;

    void Start() {
        if (GameObject.FindGameObjectsWithTag("Music").Length > 1) {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (stopped) {
            return;
        }
        if (currentBGM == null || !currentBGM.isPlaying) {
            AudioSource oldBGM = currentBGM;
            while (oldBGM == currentBGM) {
                currentBGM = bgms[Random.Range(0, bgms.Length)];
            }
            currentBGM.Play();
        }
    }

    public void Stop() {
        currentBGM.Stop();
        stopped = true;
    }
}
