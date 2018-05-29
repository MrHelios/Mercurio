using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraTrackHorizontal : MonoBehaviour
{
    private GameObject hero;
    public int valorY, valorZ;    
    public int maxX, minX;
	
	void Start ()
    {
        hero = GameObject.Find("hero");
	}
	
	
	void Update ()
    {
        float x = hero.transform.position.x;        
        if(maxX > x && x > minX)
            transform.position = new Vector3(x , valorY, valorZ);
	}
}
