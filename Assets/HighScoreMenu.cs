using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreMenu : MonoBehaviour
{
    public Text texthighscore;
    private SettingsController settingscontroller;
    // Start is called before the first frame update
    void Start()
    {
        settingscontroller = GameObject.FindGameObjectWithTag("settingscontroller").GetComponent<SettingsController>();
    }

    // Update is called once per frame
    void Update()
    {
        texthighscore.text = settingscontroller.scoreFinal+"";
    }
}
