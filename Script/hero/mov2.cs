using UnityEngine;

public class mov2 : MonoBehaviour
{
    private Animator anim;
    private cooldown cd_movimiento;

    void Start()
    {
        anim = GetComponent<Animator>();
        if (GetComponent<movimiento>() != null)
            cd_movimiento = GetComponent<movimiento>().getCooldown();
        else
            cd_movimiento = null;
    }

    private bool estaAtaqueBasicoCDCompleto()
    {
        if (GetComponent<atqbasico>() == null)
            return false;
        else
            return GetComponent<atqbasico>().getCooldown().tiempoCompletado();
    }

    private bool dejoDeMoverse()
    {
        if (cd_movimiento == null)
            return true;
        else
            return cd_movimiento.tiempoCompletado();
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
        
    }

    void FixedUpdate()
    {
        Vector2 v = GetComponent<Rigidbody2D>().velocity;

        if (Input.GetAxis("Fire1") > 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, v.y);

            if (Input.GetAxis("Fire1") > 0 && dejoDeMoverse()  && estaAtaqueBasicoCDCompleto())
            {
                GetComponent<atqbasico>().activar();
                GetComponent<atqbasico>().getCooldown().setUltimaVez(Time.time);

                if(cd_movimiento != null)
                {
                    cd_movimiento.setCooldown(0.35f);
                    cd_movimiento.setUltimaVez(Time.time);
                }
            }

        }

    }
}
