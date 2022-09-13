using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVolume : MonoBehaviour
{
    float volumeAudio;
    private SettingsController settingscontroller;
    // Start is called before the first frame update
    void Start()
    {
        settingscontroller = GameObject.FindGameObjectWithTag("settingscontroller").GetComponent<SettingsController>();
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = settingscontroller.volumeListener;
    }
}
