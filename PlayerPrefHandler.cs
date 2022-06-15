using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefHandler : MonoBehaviour
{
    List<ParticleSystem> particles = new List<ParticleSystem>();
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("ParticlesOn") == 0)
        {
            var sceneParticles = FindObjectsOfType<ParticleSystem>(true); // Fetch existing particles (Including disabled)
            foreach (ParticleSystem item in sceneParticles)
            {
                if (particles.Contains(item))
                {

                }
                else
                {
                    particles.Add(item);
                }
            }
            foreach (ParticleSystem _particles in particles)
            {
                _particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                _particles.gameObject.SetActive(false);
            }
        }
        if (PlayerPrefs.HasKey("Speed"))
        {
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
    }

}
