using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // \/ prefabs for menus
    public Button button;
    public GameObject menu;
    public GameObject areYouSureMenu;
    public GameObject optionsMenu;
    public GameObject graphicsMenu;
    public GameObject soundMenu;
    public GameObject gameplayMenu;
    Dropdown screenTypeMenu;
    Dropdown resolutionMenu;
    FullScreenMode preferredMode; 
    CanvasScaler UICanvasSize;
    int width;
    int height;
    // Start is called before the first frame update
    void Start() // Attach this to a hidden game object.
    {
        Button btn = gameObject.AddComponent<Button>();
    }

    /// <summary>
    /// Main Menu Commands (Including Pause button ingame)
    /// </summary>
    public void Pausing() // method to show pause menu and pause game
    {
        Time.timeScale = 0f;
        Instantiate(menu);
    }

    public void ReturnToGame() // unpause and hide menu
    {
        if(PlayerPrefs.HasKey("Speed"))
        {
            Debug.Log("Speed key exists");
            if (PlayerPrefs.GetInt("Speed") == 0)
            {
                Time.timeScale = 0.5f;
            }
            else if (PlayerPrefs.GetInt("Speed") == 1)
            {
                Time.timeScale = 0.75f;
            }
            else if (PlayerPrefs.GetInt("Speed") == 2)
            {
                Time.timeScale = 1f;
            }
            else if (PlayerPrefs.GetInt("Speed") == 3)
            {
                Time.timeScale = 1.25f;
            }
            else if (PlayerPrefs.GetInt("Speed") == 4)
            {
                Time.timeScale = 1.5f;
            }
        }
        else
        {
            Time.timeScale = 1f;
        }
        Destroy(GameObject.Find("PauseCanvas(Clone)"));
        Debug.Log(Time.timeScale);
    }

    public void OptionsMenu() // show options menu
    {
        Destroy(GameObject.Find("PauseCanvas(Clone)"));
        Instantiate(optionsMenu);
    }

    public void ReturntoMenu() // unpause and change to main menu scene
    {
        Time.timeScale = 1f;
        LevelManager.levelManager.LoadScene("Title Screen");
    }

    /// <summary>
    /// Section on Restart Game Menu
    /// </summary>
    public void RestartGame() // show yes / no menu
    {
        Destroy(GameObject.Find("PauseCanvas(Clone)"));
        Instantiate(areYouSureMenu);
    }
    public void YesMan() // unpause and reload game scene
    {
        Time.timeScale = 1f;
        StaticHandler.ResetStatics();
        LevelManager.levelManager.LoadScene("Level");
    }
    public void NoMan() // close yes / no menu
    {
        Destroy(GameObject.Find("RestartGameScreen(Clone)"));
        Instantiate(menu);
    }

    // Section on Options Menu

    public void BackToMainMenu() // return from options menu
    {
        Destroy(GameObject.Find("OptionsMenu(Clone)"));
        Instantiate(menu);
    }

    public void GoToGraphics() // open graphics menu
    {
        Destroy(GameObject.Find("OptionsMenu(Clone)"));
        Instantiate(graphicsMenu);
    }
    public void GoToSound() // open audio menu
    {
        Destroy(GameObject.Find("OptionsMenu(Clone)"));
        Instantiate(soundMenu);
    }

    /// <summary>
    /// Graphics Menu Shenanigans
    /// </summary>
    public void SelectingScreenMode() // screen-mode dropdown
    {
        preferredMode = FullScreenMode.FullScreenWindow;
        screenTypeMenu = GameObject.Find("ScreenModeDrop").GetComponent<Dropdown>();
        if(screenTypeMenu.value == 0)
        {
            preferredMode = FullScreenMode.FullScreenWindow;
        }
        if(screenTypeMenu.value == 1)
        {
            preferredMode = FullScreenMode.MaximizedWindow;
        }
        if (screenTypeMenu.value == 2)
        {
            preferredMode = FullScreenMode.Windowed;
        }
    }
    public void UIScaler(System.Single value) // UI-scale scaler
    {
        UICanvasSize = GameObject.Find("UI_Canvas").GetComponent<CanvasScaler>();
        UICanvasSize.scaleFactor = value;
    }

    public void Resolution() // resolution dropdown
    {
        resolutionMenu = GameObject.Find("ResolutionDrop").GetComponent<Dropdown>();
        if (resolutionMenu.value == 0)
        {
            width = 1280;
            height = 720;
        }
        if (resolutionMenu.value == 1)
        {
            width = 1920;
            height = 1080;
        }
        if (resolutionMenu.value == 2)
        {
            width = 2560;
            height = 1440;
        }
    }

    public void ApplyChangesGraphics() // apply changes and return to options menu
    {
        if (width == 0 || height == 0) // If no width or height has been changed, keep it as it is
        {
            Destroy(GameObject.Find("GraphicsMenu(Clone)"));
            Instantiate(optionsMenu);
        }
        else
        {
            Screen.SetResolution(width, height, preferredMode, Screen.currentResolution.refreshRate);
            Destroy(GameObject.Find("GraphicsMenu(Clone)"));
            Instantiate(optionsMenu);
        }
    }
    public void BackToOptionsGraphics() // Return to Options
    {
        Destroy(GameObject.Find("GraphicsMenu(Clone)"));
        Instantiate(optionsMenu);
    }

    
    // Sound Menu stuff
    public void VolumeSlider(System.Single value) // Changes the Volume
    {
        AudioListener.volume = value;
    }
    public void BackToMenuSound() // Return to Options Menu from Sound Menu
    {
        Destroy(GameObject.Find("SoundMenu(Clone)"));
        Instantiate(optionsMenu);
    }
    public void GoToGameplay() // return from options menu
    {
        Destroy(GameObject.Find("OptionsMenu(Clone)"));
        Instantiate(gameplayMenu);
    }
    public void BackToMenuGameplay() // Return to Options Menu from Sound Menu
    {
        Destroy(GameObject.Find("GameplayMenu(Clone)"));
        Instantiate(optionsMenu);
    }
    public void ExitGame() // close the application
    {
        Application.Quit();
    }
}
