using UnityEngine;

public class heroMuerteInstantanea : MonoBehaviour
{
    private GameObject hero;

    private void Start()
    {
        hero = GameObject.Find("hero");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            hero.GetComponent<hero>().muerte();
        }
    }

}
