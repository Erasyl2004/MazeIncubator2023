using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void PlayPressed()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ExitPressed()
    {
        Application.Quit();
    }
    public void QuitPressed()
    {
        SceneManager.LoadScene("Menu");
    }
}
