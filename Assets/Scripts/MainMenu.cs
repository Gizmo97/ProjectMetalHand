using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public void Sandbox()
    {
        SceneManager.LoadScene("Sandbox");
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Debug.Log("Quiting...");
        Application.Quit();
    }
}
