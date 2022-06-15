using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Rendering;

public class GraphicsOptions : MonoBehaviour
{
    [SerializeField]
    Toggle toggle;
    [SerializeField]
    Dropdown resolution;
    [SerializeField]
    Dropdown fullscreenMode;
    [SerializeField]
    Dropdown pipelineDrop;
    [SerializeField]
    Dropdown antiAliasingDrop;
    [SerializeField]
    Dropdown shadowsDrop;
    List<ParticleSystem> particles = new List<ParticleSystem>();
    public GameObject[] particlePrefabs;
    ParticleSystem[] particleEmitters;
    public int width;
    public int height;
    public FullScreenMode screenMode;
    public RenderPipelineAsset highQuality;
    public RenderPipelineAsset mediumQuality;
    public RenderPipelineAsset lowQuality;
    public RenderPipelineAsset customQuality;
    // Start is called before the first frame update
    void Awake()
    {
        width = Screen.currentResolution.width;
        height = Screen.currentResolution.height;
        screenMode = FullScreenMode.ExclusiveFullScreen;
    }
    void Start()
    {
        if(!PlayerPrefs.HasKey("AntiAliasing"))
        {
            if(QualitySettings.antiAliasing == 0)
            {
                antiAliasingDrop.value = 0;
            }
            if (QualitySettings.antiAliasing == 2)
            {
                antiAliasingDrop.value = 1;
            }
            if (QualitySettings.antiAliasing == 4)
            {
                antiAliasingDrop.value = 2;
            }
            if (QualitySettings.antiAliasing == 8)
            {
                antiAliasingDrop.value = 3;
            }
        }
        else
        {
            antiAliasingDrop.value = PlayerPrefs.GetInt("AntiAliasing");
        }
        if (!PlayerPrefs.HasKey("Shadows"))
        {
            if (QualitySettings.shadows == ShadowQuality.All)
            {
                shadowsDrop.value = 0;
            }
            if (QualitySettings.shadows == ShadowQuality.HardOnly)
            {
                shadowsDrop.value = 1;
            }
            if (QualitySettings.shadows == ShadowQuality.Disable)
            {
                shadowsDrop.value = 2;
            }
        }
        else
        {
            antiAliasingDrop.value = PlayerPrefs.GetInt("Shadows");
        }
        resolution.value = PlayerPrefs.GetInt("ResolutionMode"); // Visually sets the value of the dropdown according to preference mode
        fullscreenMode.value = PlayerPrefs.GetInt("ScreenMode");
        pipelineDrop.value = PlayerPrefs.GetInt("QualityChoice");
        toggle.isOn = PlayerPrefs.GetInt("ParticlesOn") == 1 ? true : false; // Sets the value of the toggle based on the preference
}

    public void DisableOrEnableParticles()
    {
        var sceneParticles = FindObjectsOfType<ParticleSystem>(true); // Fetch existing particles (Including disabled)
        foreach (ParticleSystem item in sceneParticles) // For each particle found on the scene...
        {
            if (particles.Contains(item)) // If it already has found it before, don't add it again.
            {

            }
            else // Otherwise...
            {
                particles.Add(item); // Add the item to the list of particles
            }
        }
        foreach (var prefab in particlePrefabs) // For each item within the prefab array...
        {

            particleEmitters = prefab.GetComponentsInChildren<ParticleSystem>(true); // Fetch ParticleSystem children from prefabs (Including disabled)
            foreach (ParticleSystem item in particleEmitters) // For each particle system in the array...
            {
                if(particles.Contains(item)) // If its already present, do not add again
                {

                }
                else // Otherwise...
                {
                    particles.Add(item); // Add to the list.
                }
            }
        }
        if (!toggle.isOn) // If the toggle is ticked when clicked...
        {
            PlayerPrefs.SetInt("ParticlesOn", 0); // set preference to 0 (I don't want particles)
        }
        else // If it was off, do the opposite except turn everything on.
        {
            PlayerPrefs.SetInt("ParticlesOn", 1); // set preference to 1 (I want particles)
        }
    }

    public void ChangeResolution(Dropdown change)
    {
        if(change.value == PlayerPrefs.GetInt("ResolutionMode")) // Checks if the value selected is the same as the current saved preference
        {
            // If yes, do nothing.
        }
        else if(change.value == 0) // Otherwise, go through each option.
        {
            width = 1280; // Set width.
            height = 720; // Set height.
            PlayerPrefs.SetInt("ResolutionMode", 0); // Set the preference as that value.
        }
        else if (change.value == 1)
        {
            width = 1280;
            height = 800;
            PlayerPrefs.SetInt("ResolutionMode", 1);
        }
        else if (change.value == 2)
        {
            width = 1600;
            height = 900;
            PlayerPrefs.SetInt("ResolutionMode", 2);
        }
        else if (change.value == 3)
        {
            width = 1680;
            height = 1050;
            PlayerPrefs.SetInt("ResolutionMode", 3);
        }
        else if (change.value == 4)
        {
            width = 1920;
            height = 1080;
            PlayerPrefs.SetInt("ResolutionMode", 4);
        }
        else if (change.value == 5)
        {
            width = 2560;
            height = 1440;
            PlayerPrefs.SetInt("ResolutionMode", 5);
        }
        else if (change.value == 6)
        {
            width = 2560;
            height = 1600;
            PlayerPrefs.SetInt("ResolutionMode", 6);
        }
    }

    public void ChangeScreenMode(Dropdown change)
    {
        if (change.value == PlayerPrefs.GetInt("ScreenMode")) // Checks if the value selected is the same as the current saved preference
        {
            // If yes, do nothing.
        }
        else if (change.value == 0)
        {
            screenMode = FullScreenMode.ExclusiveFullScreen;
            PlayerPrefs.SetInt("ScreenMode", 0);
        }
        else if (change.value == 1)
        {
            screenMode = FullScreenMode.FullScreenWindow;
            PlayerPrefs.SetInt("ScreenMode", 1);
        }
        else if (change.value == 2)
        {
            screenMode = FullScreenMode.Windowed;
            PlayerPrefs.SetInt("ScreenMode", 2);
        }
    }

    public void SwapPipelines(Dropdown change)
    {
        if (change.value == PlayerPrefs.GetInt("QualityChoice")) // Checks if the value selected is the same as the current saved preference
        {
            // If yes, do nothing.
        }
        else if (change.value == 0)
        {
            PlayerPrefs.SetInt("QualityChoice", 0);
        }
        else if (change.value == 1)
        {
            PlayerPrefs.SetInt("QualityChoice", 1);
        }
        else if (change.value == 2)
        {
            PlayerPrefs.SetInt("QualityChoice", 2);
        }
    }

    public void ChangeAntiAliasing(Dropdown change)
    {
        if (change.value == PlayerPrefs.GetInt("AntiAliasing")) // Checks if the value selected is the same as the current saved preference
        {
            // If yes, do nothing.
        }
        else if (change.value == 0)
        {
            PlayerPrefs.SetInt("AntiAliasing", 0);
        }
        else if (change.value == 1)
        {
            PlayerPrefs.SetInt("AntiAliasing", 1);
        }
        else if (change.value == 2)
        {
            PlayerPrefs.SetInt("AntiAliasing", 2);
        }
        else if (change.value == 3)
        {
            PlayerPrefs.SetInt("AntiAliasing", 3);
        }
    }

    public void ChangeShadows(Dropdown change)
    {
        if (change.value == PlayerPrefs.GetInt("Shadows")) // Checks if the value selected is the same as the current saved preference
        {
            // If yes, do nothing.
        }
        else if (change.value == 0)
        {
            PlayerPrefs.SetInt("Shadows", 0);
        }
        else if (change.value == 1)
        {
            PlayerPrefs.SetInt("Shadows", 1);
        }
        else if (change.value == 2)
        {
            PlayerPrefs.SetInt("Shadows", 2);
        }
    }

    public void ChangeVSyncToggle()
    {
        if (!toggle.isOn) // If the toggle is ticked when clicked...
        {
            PlayerPrefs.SetInt("VSyncOn", 0); // set preference to 0 (I don't want Vsync)
        }
        else // If it was off, do the opposite except turn everything on.
        {
            PlayerPrefs.SetInt("VSyncOn", 1); // set preference to 1 (I want Vsync)
        }
    }

    public void ApplyChanges()
    {
        Screen.SetResolution(width, height, screenMode);
        if (PlayerPrefs.GetInt("ParticlesOn") == 0)
        {
            foreach (ParticleSystem _particles in particles) // For each item within the list...
            {
                _particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear); // Stop the emitter from further work...
                _particles.gameObject.SetActive(false); // And disable it.
            }
        }
        else
        {
            foreach (ParticleSystem _particles in particles) // For each item within the list...
            {
                _particles.Play(true); // Start playing particles again.
                _particles.gameObject.SetActive(true); // And enable it.
            }
        }
        if (PlayerPrefs.GetInt("QualityChoice") == 0)
        {
            GraphicsSettings.defaultRenderPipeline = highQuality;
            QualitySettings.renderPipeline = highQuality;
        }
        else if (PlayerPrefs.GetInt("QualityChoice") == 1)
        {
            GraphicsSettings.defaultRenderPipeline = mediumQuality;
            QualitySettings.renderPipeline = mediumQuality;
        }
        else if (PlayerPrefs.GetInt("QualityChoice") == 2)
        {
            GraphicsSettings.defaultRenderPipeline = lowQuality;
            QualitySettings.renderPipeline = lowQuality;
        }

        if (PlayerPrefs.GetInt("AntiAliasing") == 0)
        {
            QualitySettings.antiAliasing = 0;
        }
        else if (PlayerPrefs.GetInt("AntiAliasing") == 1)
        {
            QualitySettings.antiAliasing = 2;
        }
        else if (PlayerPrefs.GetInt("AntiAliasing") == 2)
        {
            QualitySettings.antiAliasing = 4;
        }
        else if (PlayerPrefs.GetInt("AntiAliasing") == 3)
        {
            QualitySettings.antiAliasing = 8;
        }

        if (PlayerPrefs.GetInt("Shadows") == 0)
        {
            QualitySettings.shadows = ShadowQuality.All;
        }
        else if (PlayerPrefs.GetInt("Shadows") == 1)
        {
            QualitySettings.shadows = ShadowQuality.HardOnly;
        }
        else if (PlayerPrefs.GetInt("Shadows") == 2)
        {
            QualitySettings.shadows = ShadowQuality.Disable;
        }

        if (PlayerPrefs.GetInt("VSyncOn") == 0)
        {
            QualitySettings.vSyncCount = 0;
        }
        else
        {
            QualitySettings.vSyncCount = 1;
        }
    }

}
