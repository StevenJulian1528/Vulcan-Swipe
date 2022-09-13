using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public float volumeListener;
    public int scoreFinal = 0;
    private Text scoreText;
    private static SettingsController settingscontrollerInstance;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("scoremenu").GetComponent<Text>();
        volumeListener = AudioListener.volume;
        scoreText.text = scoreFinal + "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (settingscontrollerInstance == null)
        {
            settingscontrollerInstance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }
}
