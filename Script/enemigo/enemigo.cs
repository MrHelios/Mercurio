using UnityEngine;

public class enemigo : MonoBehaviour
{
    protected vida vidaEnemigo;
    private GameObject posicion_inicial;

    void Awake()
    {
        gameObject.tag = "Enemy";

        vidaEnemigo = new vida(1);

        if(gameObject.transform.parent.GetComponent<crearEnemigo>() != null)
            gameObject.SetActive(false);

        posicion_inicial = GameObject.Find(transform.parent.name +"/puntos/inicio");
        if (posicion_inicial != null)
            transform.position = posicion_inicial.transform.position;
        else
            Debug.Log(transform.parent.name + " no tiene posicion inicial.");
    }

    void Start ()
    {
        
    }

    private void aumentarCargaArcana(Vector3 v)
    {
        if (GameObject.Find("hero").GetComponent<municionArcana>() != null)
            GameObject.Find("hero").GetComponent<municionArcana>().crearEfecto(v);
        else
            Debug.Log("No sé coloco la municionArcana en el hero.");
    }

    private void desactivarHabilidades()
    {        
        aumentarCargaArcana(gameObject.transform.position);

        transform.parent.GetComponent<destruir>().enabled = true;

        habilidad[] h = GetComponents<habilidad>();
        for (int i = 0; i < h.Length; i++)
            h[i].enabled = false;

        if (GetComponent<enemMovimiento>() != null)
        {
            GetComponent<enemMovimiento>().enabled = false;
            GetComponent<irLocacion>().enabled = false;
        }

        if (GetComponent<Rigidbody2D>() != null)
            Destroy(GetComponent<Rigidbody2D>());

        if (GetComponent<Collider2D>() != null)
            GetComponent<Collider2D>().enabled = false;
    }

    public bool estaVivo()
    {
        return vidaEnemigo.getVidaAct() > 0;
    }
	
    public vida getVida()
    {
        return vidaEnemigo;
    }

    public void pierdeVida()
    {
        vidaEnemigo.pierdeVida();
        if(vidaEnemigo.estaMuerto())
        {
            muerte();
            GetComponent<Animator>().SetTrigger("muerte");

            desactivarHabilidades();
        }
    }

    public void revivir()
    {
        vidaEnemigo.restaurar_maxima_vida();
    }

    public void muerte()
    {
        vidaEnemigo.muerte();
    }

}
