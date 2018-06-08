using UnityEngine;

public class ancladoConEstructura : MonoBehaviour
{
    private GameObject hero;

    void Start()
    {
        hero = GameObject.Find("hero");    
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {            
            Vector2 v = hero.GetComponent<Rigidbody2D>().velocity;
            hero.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<movRepetitivo>().getVelocidad().x, GetComponent<movRepetitivo>().getVelocidad().y);
        }
    }
}
