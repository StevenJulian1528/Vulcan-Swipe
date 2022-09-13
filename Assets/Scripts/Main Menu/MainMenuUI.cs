using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    bool isSoundOn;
    private SettingsController settingscontroller;
    public Sprite[] soundSprites;
    // Start is called before the first frame update
    void Start()
    {
        settingscontroller = GameObject.FindGameObjectWithTag("settingscontroller").GetComponent<SettingsController>();
        if(settingscontroller.volumeListener <= 0)
        {
            isSoundOn = false;
        }
        else if(settingscontroller.volumeListener >= 0)
        {
            isSoundOn = true;
        }

        //settingscontroller = GetComponent<SettingsController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void MainPlay()
    {
        SceneManager.LoadScene("MainPlay");
    }

    public void SettingsSound()
    {
        if(isSoundOn)
        {
            settingscontroller.volumeListener = 0;
            isSoundOn = false;
            gameObject.GetComponent<Image>().sprite = soundSprites[1];
            print("sound on");
        }
        else if(!isSoundOn)
        {
            settingscontroller.volumeListener = 0.3f;
            isSoundOn = true;
            gameObject.GetComponent<Image>().sprite = soundSprites[0];
            print("sound false");
        }
    }
}
