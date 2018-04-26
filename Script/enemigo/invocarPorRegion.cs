using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invocarPorRegion : MonoBehaviour
{
    public GameObject enem;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name.Equals("hero"))
        {
            enem.SetActive(true);
            Destroy(gameObject.GetComponent<invocarPorRegion>());
        }
    }

}
