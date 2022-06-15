using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayOptions : MonoBehaviour
{
    [SerializeField]
    Dropdown speedDrop;

    public void Start()
    {
        if(PlayerPrefs.HasKey("Speed"))
        {
            if(PlayerPrefs.GetInt("Speed") == 0)
            {
                speedDrop.value = 0;
            }
            else if (PlayerPrefs.GetInt("Speed") == 1)
            {
                speedDrop.value = 1;
            }
            else if (PlayerPrefs.GetInt("Speed") == 2)
            {
                speedDrop.value = 2;
            }
            else if (PlayerPrefs.GetInt("Speed") == 3)
            {
                speedDrop.value = 3;
            }
            else if (PlayerPrefs.GetInt("Speed") == 4)
            {
                speedDrop.value = 4;
            }
        }
        else
        {
            speedDrop.value = 2;
        }    
    }

    public void ChangeSpeed(Dropdown change)
    {
        if (change.value == PlayerPrefs.GetInt("AntiAliasing")) // Checks if the value selected is the same as the current saved preference
        {
            // If yes, do nothing.
        }
        else if (change.value == 0)
        {
            PlayerPrefs.SetInt("Speed", 0);
        }
        else if (change.value == 1)
        {
            PlayerPrefs.SetInt("Speed", 1);
        }
        else if (change.value == 2)
        {
            PlayerPrefs.SetInt("Speed", 2);
        }
        else if (change.value == 3)
        {
            PlayerPrefs.SetInt("Speed", 3);
        }
        else if (change.value == 4)
        {
            PlayerPrefs.SetInt("Speed", 4);
        }
    }
}
