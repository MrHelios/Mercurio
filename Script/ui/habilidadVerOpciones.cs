using UnityEngine;
using UnityEngine.SceneManagement;

public class habilidadVerOpciones : MonoBehaviour
{
    private GameObject config;
    private GameObject hero;
    private bool estado;
    private cooldown cd;    
	
	void Start ()
    {
        hero = GameObject.Find("hero");
        config = GameObject.Find("Canvas/Opciones").transform.GetChild(0).gameObject;
        estado = false;

        cd = new cooldown();
        cd.setUltimaVez(-99f);
        cd.setCooldown(0.25f);

        guardarPartida();
	}

    private void guardarPartida()
    {
        GameObject config = GameObject.Find("Config");
        if (config != null)
        {
            string nombre = config.GetComponent<conservarGameObject>().getFile();
            int escena_actual = SceneManager.GetActiveScene().buildIndex;
            
            archivoPartidas ap = new archivoPartidas();
            ap.guardar(nombre, escena_actual);
        }
        else
            Debug.Log("No hay gameobject Config");
    }

    public bool getEstado()
    {
        return estado;
    }

    public void cambiarEstado()
    {
        if(hero != null)
        {
            Vector2 v = hero.GetComponent<Rigidbody2D>().velocity;
            hero.GetComponent<Rigidbody2D>().velocity = new Vector2(0, v.y);
            hero.GetComponent<movimiento>().desactivar();

            habilidad[] h = hero.GetComponents<habilidad>();
            for (int i = 0; i < h.Length; i++)
                h[i].enabled = estado;
        }

        estado = !estado;
        config.SetActive(estado);
        cd.setUltimaVez(Time.time);

    }
	
	void FixedUpdate ()
    {
        if (cd.tiempoCompletado() && Input.GetAxis("Cancel") > 0)
            cambiarEstado();
	}
}
