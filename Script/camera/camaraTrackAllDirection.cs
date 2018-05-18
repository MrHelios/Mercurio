using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraTrackAllDirection : MonoBehaviour
{
    private GameObject hero;
    public int maxY, minY;
    public int maxX, minX;

    void Start()
    {
        hero = GameObject.Find("hero");
    }

    void Update()
    {
        float x = hero.transform.position.x;
        float y = hero.transform.position.y;
        Vector3 pos = transform.position;

        if (maxX > x && x > minX)
        {
            if(maxY > y && y > minY)
                transform.position = new Vector3(x, y, -10);
            else
                transform.position = new Vector3(x, pos.y, -10);
        }
        else if(maxY > y && y > minY)
        {
            transform.position = new Vector3(pos.x, y, -10);
        }
    }

}
