using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicOptions : MonoBehaviour
{
    [SerializeField]
    Slider soundSlider;

    public void Start()
    {
        if(PlayerPrefs.HasKey("MusicVolume"))
        {
            soundSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }
        else
        {
            soundSlider.value = 1;
        }
    }
    public void SelectVolume(Slider value)
    {
        AudioListener.volume = value.value;
        PlayerPrefs.SetFloat("MusicVolume", value.value);
    }

    public void ApplyChanges()
    {

    }
}
