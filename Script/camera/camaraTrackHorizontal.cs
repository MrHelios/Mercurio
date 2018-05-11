using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraTrackHorizontal : MonoBehaviour
{
    private GameObject hero;
    public int valorY;
	
	void Start ()
    {
        hero = GameObject.Find("hero");
	}
	
	
	void Update ()
    {
        float x = hero.transform.position.x;        
        transform.position = new Vector3(x , valorY, -10);
	}
}
