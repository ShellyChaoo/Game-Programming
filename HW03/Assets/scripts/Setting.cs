using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    public SoundsEffect soundsEffect;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.name.Contains("Lose"))
        {
            soundsEffect.PlayGameOverSE();
        }
        else if(gameObject.name.Contains("Win"))
        {
            soundsEffect.PlayWinSE();
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        soundsEffect.PlayClickSE();
    }
    public void Back2Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        soundsEffect.PlayClickSE();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        soundsEffect.PlayClickSE();
    }

    public void Level2Back2Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-2);
        soundsEffect.PlayClickSE();
    }
}
