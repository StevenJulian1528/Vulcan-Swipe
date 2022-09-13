using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public GameObject bg;
    public GameObject[] levels;
    public Sprite[] spriteLevels;
    private Camera mainCamera;
    private Vector2 screenBounds;
    public float choke;
    public float speed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = gameObject.GetComponent<Camera>();
        //rb.velocity = new Vector2(0, -speed);
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        foreach(GameObject obj in levels)
        {
            loadChildObjects(obj);
        }
    }
    
    void loadChildObjects(GameObject obj)
    {
        int rand = Random.Range(0, spriteLevels.Length - 1);
        print(rand);
        bg.GetComponent<SpriteRenderer>().sprite = spriteLevels[rand];
        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.y - choke;
        int childsNeeded = (int)Mathf.Ceil(screenBounds.y * 2 / objectWidth);
        GameObject clone = Instantiate(obj) as GameObject;
        for(int i = 0; i <= childsNeeded; i++)
        {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(obj.transform.position.x, objectWidth * i, obj.transform.position.z);
            c.name = obj.name + 1;
        }
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
        Debug.Log(obj.name);
    }

    void repositionChildObjects(GameObject obj)
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if(children.Length > 1)
        {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.y;
            if (transform.position.y + screenBounds.y > lastChild.transform.position.y + halfObjectWidth)
            {
                int rand = Random.Range(0, spriteLevels.Length);
                print(rand);
                firstChild.GetComponent<SpriteRenderer>().sprite = spriteLevels[rand];
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x, lastChild.transform.position.y + halfObjectWidth * 2, lastChild.transform.position.z);

            }
            else if(transform.position.y - screenBounds.y < firstChild.transform.position.y - halfObjectWidth)
            {
                int rand = Random.Range(0, spriteLevels.Length);
                print(rand);
                lastChild.GetComponent<SpriteRenderer>().sprite = spriteLevels[rand];
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x, firstChild.transform.position.y - halfObjectWidth * 2, firstChild.transform.position.z);
            }
        }
    }

    private void LateUpdate()
    {
        foreach(GameObject obj in levels)
        {

            repositionChildObjects(obj);
        }
    }
    // Update is called once per frame
}
