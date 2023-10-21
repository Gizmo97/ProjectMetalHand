using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool quickSelectOn = false;

    public GameObject pauseMenuUI;
    public GameObject quickSelectUI;
    public GameObject creditUI;
    public GameObject weaponUI;
    public BaseWeapon weapon;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && quickSelectOn == false)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (Input.GetKey(KeyCode.Q) && GameIsPaused == false)
        {
            Cursor.lockState = CursorLockMode.None;
            quickSelectUI.SetActive(true);
            Time.timeScale = 0f;
            quickSelectOn = true;
        }
        else if (GameIsPaused == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            quickSelectUI.SetActive(false);
            Time.timeScale = 1f;
            quickSelectOn = false;
        }
    }

    public void Resume ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}