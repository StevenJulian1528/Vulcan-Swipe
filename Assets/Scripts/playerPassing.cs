using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPassing : MonoBehaviour
{
    bool isTrue = false;
    public spawnerWater spawnerWater;
    public Gamecontroller Gamecontroller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("pembatas") && !isTrue)
        {
            isTrue = true;
            spawnerWater.spawnWater(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("pembatas") && isTrue)
        {
            isTrue = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("water"))
        {
            print("kena water");
            Gamecontroller.isGameOver(true);
        }
    }
}
