using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public void DropDown(int idx)
    {
        if (idx == 1) Back2Menu();
        if (idx == 2) QuitGame();
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Back2Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
