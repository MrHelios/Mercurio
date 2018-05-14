using UnityEngine;

public class heroColision : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.gameObject.GetComponent<hero>().pierdeVida();
            
        }        
    }

}
