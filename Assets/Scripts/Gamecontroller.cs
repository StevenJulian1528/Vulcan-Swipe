using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Gamecontroller : MonoBehaviour
{
    public Text scoreText;
    public float scoreAmount;
    public float pointIncreasePerSecond;
    bool isOver = false;
    public GameObject GameOverUI;
    // Start is called before the first frame update
    //private void Awake()
    //{
    //    DontDestroyOnLoad(this);
    //}
    void Start()
    {
        scoreAmount = 0f;
        pointIncreasePerSecond = 1f;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOver)
        {
            scoreText.text = (int)scoreAmount + "";
            scoreAmount += pointIncreasePerSecond * Time.deltaTime;
        }
    }

    public void isGameOver(bool over)
    {
        isOver = over;
        if(isOver)
        {
            GameOverUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
