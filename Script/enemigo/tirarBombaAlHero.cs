using UnityEngine;

public class tirarBombaAlHero : habilidad
{
    public GameObject bomba;
    private GameObject hero;
    private bool activo;

    void Awake()
    {
        activo = true;
    }

    void Start()
    {
        cd = new cooldown();
        cd.setCooldown(2f);
        cd.setUltimaVez(-99f);

        hero = GameObject.Find("hero");
    }

    protected override void efecto()
    {
        GameObject nuevo = Instantiate(bomba);

        nuevo.transform.position = transform.position;
        nuevo.SetActive(true);
        
        nuevo.GetComponent<Rigidbody2D>().gravityScale = 0;
        nuevo.GetComponent<Rigidbody2D>().velocity = 5 * auxCalcular(hero.transform.position, transform.position);
        nuevo.GetComponent<destruir>().enabled = true;

        cd.setUltimaVez(Time.time);
    }

    private Vector3 auxCalcular(Vector3 v1, Vector3 v2)
    {
        Vector3 r = v1 - v2;
        return r.normalized;
    }

    public override void activar()
    {
        activo = true;
    }

    public override void desactivar()
    {
        activo = false;
    }

    void FixedUpdate()
    {
        if (cd.tiempoCompletado() && activo)
            efecto();
    }

}
