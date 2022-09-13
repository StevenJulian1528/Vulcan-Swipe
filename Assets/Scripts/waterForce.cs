using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterForce : MonoBehaviour
{
    public GameObject parentsObject;

    Vector2 startPos, endPos, direction;
    float touchTimeStart, touchTimeFinish, timeInterval;

    [Range(2f, 5f)]
    public float throwForse = 5f;

    private AudioSource waterSplashAudio;
    // Start is called before the first frame update
    void Start()
    {
        waterSplashAudio = GetComponent<AudioSource>();
        makeChildObject();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag.Equals("water"))
        //    {
        //        touchTimeStart = Time.time;
        //        startPos = Input.GetTouch(0).position;
        //        print("touch");
        //    }

        //}

        //if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag.Equals("water"))
        //    {
        //        touchTimeFinish = Time.time;
        //        timeInterval = touchTimeFinish - touchTimeStart;
        //        endPos = Input.GetTouch(0).position;
        //        direction = startPos - endPos;
        //        GetComponent<Rigidbody2D>().AddForce(-direction / timeInterval * throwForse);
        //    }
        //}
    }
    private void OnMouseDown()
    {
        touchTimeStart = Time.time;
        startPos = Input.mousePosition;
        print("touch");
    }
    private void OnMouseUp()
    {

        touchTimeFinish = Time.time;
        timeInterval = touchTimeFinish - touchTimeStart;
        endPos = Input.mousePosition;
        direction = startPos - endPos;
        GetComponent<Rigidbody2D>().AddForce(-direction * throwForse);
        waterSplashAudio.Play();
    }

    void makeChildObject()
    {
        //gameObject.transform.position = parentsObject.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("removerwater"))
        {
            Destroy(gameObject);
        }
    }
}
