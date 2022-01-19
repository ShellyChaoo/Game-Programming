using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSetting : MonoBehaviour
{
    public GameObject ObjectMusic;
    private AudioSource audioPlayer;
    private void Start()
    {
        ObjectMusic = GameObject.FindGameObjectsWithTag("GameMusic")[0];
        audioPlayer = ObjectMusic.GetComponent<AudioSource>();
    }
    public void SetVolume(float volume)
    {
        audioPlayer.volume = volume;
    }
}
