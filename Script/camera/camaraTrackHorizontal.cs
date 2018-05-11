using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraTrackHorizontal : MonoBehaviour
{
    private GameObject hero;

	
	void Start ()
    {
        hero = GameObject.Find("hero");
	}
	
	
	void Update ()
    {
        float x = hero.transform.position.x;        
        transform.position = new Vector3(x ,-1, -10);
	}
}
