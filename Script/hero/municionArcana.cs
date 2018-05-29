using UnityEngine;

public class municionArcana : habilidad
{
    private bool estado;
    private int cant_max_energia, cant_actual_energia;
    private Vector3 pos;

    public GameObject ui, efecto_municion;

    void Start()
    {
        cant_max_energia = 25;
        cant_actual_energia = 0;

        ui = GameObject.Find("Canvas");

        activar();
    }

    public override void activar()
    {
        estado = true;
    }

    public override void desactivar()
    {
        estado = false;
    }

    protected override void efecto()
    {
        GameObject nuevo = Instantiate(efecto_municion);

        nuevo.transform.position = pos;
        nuevo.GetComponent<SpriteRenderer>().enabled = true;
        nuevo.GetComponent<destruir>().enabled = true;
        nuevo.GetComponent<Collider2D>().enabled = true;

        nuevo.AddComponent<Rigidbody2D>();
        nuevo.GetComponent<Rigidbody2D>().gravityScale = 0f;
        nuevo.GetComponent<Rigidbody2D>().velocity = 4 * auxCalculo(pos, transform.position);

        nuevo.AddComponent<desactivarImpactoConHero>();
    }

    public void crearEfecto(Vector3 v)
    {
        pos = v;
        efecto();
    }

    private Vector3 auxCalculo(Vector3 v1, Vector3 v2)
    {
        Vector3 r = v2 - v1;
        return r.normalized;
    }    

    public void aumentarCarga()
    {
        if(estado)
        {
            if (cant_max_energia > cant_actual_energia)
            {
                cant_actual_energia++;
                ui.GetComponent<controladorMunicionUI>().cambiarTexto(cant_actual_energia);                
            }
        }
    }

    public bool hayCarga()
    {
        return cant_actual_energia > 0 && estado;
    }

    public void disminuirCarga()
    {
        if(estado)
        {
            if (hayCarga())
            {
                cant_actual_energia--;
                ui.GetComponent<controladorMunicionUI>().cambiarTexto(cant_actual_energia);
            }
        }
    }

}
