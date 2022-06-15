using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject mainMenu;
    public GameObject graphicsMenu;
    public GameObject soundMenu;
    public GameObject gameplayMenu;
    public GameObject creditsMenu;
    Dropdown dropDownMenu;
    FullScreenMode preferredMode;
    // float preferredVolume = 1; // I assume this is for when sound is implemented
    int width;
    int height;
    /// <summary>
    /// Main Menu Commands
    /// </summary>
    public void StartPlease()
    {
        StaticHandler.ResetStatics();
        LevelManager.levelManager.LoadScene("Level");
    }
    public void GoToOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToDictionary()
    {
        LevelManager.levelManager.LoadScene("Dictionary");
    }

    private void Awake()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow, Screen.currentResolution.refreshRate);
    }

    /// <summary>
    /// Options Menu Commands
    /// </summary>
    public void GoToGraphics()
    {
        optionsMenu.SetActive(false);
        graphicsMenu.SetActive(true);
    }
    public void GoToSound()
    {
        optionsMenu.SetActive(false);
        soundMenu.SetActive(true);
    }
    public void BackToMainMenu()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    /// <summary>
    /// Graphics Menu Commands
    /// </summary>
    public void Resolution()
    {
        dropDownMenu = GameObject.Find("Resolution").GetComponent<Dropdown>();
        if (dropDownMenu.value == 0)
        {
            width = 1280;
            height = 720;
        }
        if (dropDownMenu.value == 1)
        {
            width = 1920;
            height = 1080;
        }
        if (dropDownMenu.value == 2)
        {
            width = 2560;
            height = 1440;
        }
    }
    public void DisplayMode()
    {
        preferredMode = FullScreenMode.FullScreenWindow;
        dropDownMenu = GameObject.Find("DisplayMode").GetComponent<Dropdown>();
        if (dropDownMenu.value == 0)
        { 
            preferredMode = FullScreenMode.FullScreenWindow;
        }
        if (dropDownMenu.value == 1)
        {
            preferredMode = FullScreenMode.MaximizedWindow;
        }
        if (dropDownMenu.value == 2)
        {
            preferredMode = FullScreenMode.Windowed;
        }
    }

    public void SwapBack()
    {
        graphicsMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void BackToOptions()
    {
        graphicsMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    /// <summary>
    /// Sound Menu Commands
    /// </summary>
    public void MasterVolumeSlider(System.Single value)
    {
        AudioListener.volume = value;
    }
    public void BackToOptionsSound()
    {
        soundMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void GoToGameplay()
    {
        optionsMenu.SetActive(false);
        gameplayMenu.SetActive(true);
    }
    public void BackToOptionsGameplay()
    {
        gameplayMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void GoToCredits()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void BackToMainMenuCredits()
    {
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

}
