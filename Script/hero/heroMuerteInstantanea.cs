using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroMuerteInstantanea : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<hero>().muerte();
        }
    }

}
