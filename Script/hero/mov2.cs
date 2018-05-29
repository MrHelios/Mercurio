using UnityEngine;

public class mov2 : MonoBehaviour
{
    private Animator anim;    

    void Start()
    {
        anim = GetComponent<Animator>();        
    }

    private bool estaAtaqueBasicoCDCompleto()
    {
        if (GetComponent<atqbasico>() == null)
            return false;
        else
            return GetComponent<atqbasico>().getCooldown().tiempoCompletado();
    }

    private bool estaAtaqueEnAltoCDCompleto()
    {
        if (GetComponent<atqenalto>() == null)
            return false;
        else
            return GetComponent<atqenalto>().getCooldown().tiempoCompletado();
    }

    public string getMirada()
    {
        if (GetComponent<movimiento>() == null)
            return "derecha";
        return GetComponent<movimiento>().getMirada();
    }

    public bool getEstaSaltando()
    {
        if (GetComponent<salto>() == null)
            return false;
        return GetComponent<salto>().getEstaSaltando();
    }

    public bool getEstaAgachado()
    {
        if (GetComponent<agacharse>() == null)
            return false;
        return GetComponent<agacharse>().getEstaAgachado();
    }

    public void animacionMuerte()
    {
        anim.SetTrigger("muerto");
    }

    void FixedUpdate()
    {
        Vector2 v = GetComponent<Rigidbody2D>().velocity;

        if (Input.GetAxis("Fire1") > 0)
        {
            if (Input.GetAxis("Fire1") > 0  && estaAtaqueBasicoCDCompleto())
            {
                GetComponent<atqbasico>().activar();
                GetComponent<atqbasico>().getCooldown().setUltimaVez(Time.time);
            }
        }
        else if(Input.GetAxis("Fire5") > 0 && estaAtaqueEnAltoCDCompleto())
        {
            GetComponent<atqenalto>().activar();
            GetComponent<atqenalto>().getCooldown().setUltimaVez(Time.time);
        }

    }
}
