using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsEffect : MonoBehaviour
{
    public AudioSource audioPlayer;
	public AudioClip meowSE;
    public AudioClip winSE;
    public AudioClip gameoverSE;
    public AudioClip clickSE;

    public void PlayMeowSE()
    {
        audioPlayer.PlayOneShot(meowSE);
    }
    public void PlayWinSE()
    {
        audioPlayer.PlayOneShot(winSE);
    }
    public void PlayGameOverSE()
    {
        audioPlayer.PlayOneShot(gameoverSE);
    }
    public void PlayClickSE()
    {
        audioPlayer.PlayOneShot(clickSE);
    }
}
