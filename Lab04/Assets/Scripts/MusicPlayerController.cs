using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayerController : MonoBehaviour
{
    private AudioSource audioSource;
    public List<AudioClip> clipList;
    public int musicIndex = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ModifyVolume(float vol)
    {
        audioSource.volume = vol;
    }
    public void ToggleMuteOption(bool toggle)
    {
        audioSource.mute = toggle;
    }

    public void PlayMusicClip()
    {
        audioSource.Stop(); //先取消正在撥放的音樂再撥放新的
        audioSource.clip = clipList[musicIndex];
        audioSource.Play();
    } 
    public void ChangeMusicIndex(int idx)
    {
        musicIndex = idx;
        PlayMusicClip();
    }
}
