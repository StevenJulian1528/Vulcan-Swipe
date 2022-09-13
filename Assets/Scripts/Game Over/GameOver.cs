using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverUI, scoreUI;
    public Text scoreText;
    public Gamecontroller gamecontroller;
    private SettingsController settingscontroller;
    public int scoreTemp;
    public AudioSource gameplaySound;
    // Start is called before the first frame update
    void Start()
    {
        gameplaySound.Stop();
        settingscontroller = GameObject.FindGameObjectWithTag("settingscontroller").GetComponent<SettingsController>();
        GameOverUI.SetActive(true);
        scoreUI.SetActive(false);
        scoreText.text = (int)gamecontroller.scoreAmount + "";
        scoreTemp = (int)gamecontroller.scoreAmount;
        if (scoreTemp > settingscontroller.scoreFinal)
        {
            settingscontroller.scoreFinal = scoreTemp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
