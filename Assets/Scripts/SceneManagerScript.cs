using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public static bool IsGamePaused = false;
    public GameObject pauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused)
                Resume();
            else
                Pause();
        }
    }
    
    public void LoadMoonbucks()
    {
        SceneManager.LoadScene("Moonbucks");
    }
    public void LoadSupermarket()
    {
        SceneManager.LoadScene("Supermarket");
    }
    public void LoadKadernictvi()
    {
        SceneManager.LoadScene("Kadernictvi");
    }
    public void LoadMuzeum()
    {
        SceneManager.LoadScene("Muzeum");
    }
    public void LoadPark()
    {
        SceneManager.LoadScene("Park");
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        IsGamePaused = false;
        Time.timeScale = 1;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        IsGamePaused = true;
        Time.timeScale = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
