using UnityEngine;

public class movimiento : habilidad
{
    private float vel;
    private string mirada;
    private cooldown sin_apretar_tecla_mov;    

    void Awake()
    {
        cd = new cooldown();
        cd.setUltimaVez(-99f);
        cd.setCooldown(0.2f);
    }

    void Start ()
    {
        anim = GetComponent<Animator>();
        mirada = "derecha";
        estado_anim = "movimiento";
        vel = 4f;

        sin_apretar_tecla_mov = new cooldown();
        sin_apretar_tecla_mov.setUltimaVez(0);
        sin_apretar_tecla_mov.setCooldown(0.1f);
    }

    private bool chequearSiEstaAgachado()
    {
        if (GetComponent<mov2>() == null)
            return false;
        return !GetComponent<mov2>().getEstaAgachado();
    }

    public override void activar()
    {
        anim.SetBool(estado_anim, true);
    }

    public override void desactivar()
    {
        anim.SetBool(estado_anim, false);
    }

    public string getMirada()
    {
        return mirada;
    }

    protected override void efecto()
    {
        float velX = Input.GetAxis("Horizontal");
        Vector2 v = GetComponent<Rigidbody2D>().velocity;

        if (Mathf.Abs(velX) > 0.1f && chequearSiEstaAgachado() && cd.tiempoCompletado())
        {
            cd.setCooldown(0.2f);
            sin_apretar_tecla_mov.setUltimaVez(Time.time);
            GetComponent<Rigidbody2D>().velocity = new Vector2(velX * vel, v.y);

            if (velX > 0)
            {
                mirada = "derecha";                
                GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
            }
            else
            {
                mirada = "izquierda";                
                GetComponent<Transform>().localScale = new Vector3(-1, 1, 1);
            }
            activar();
        }        
        else if (sin_apretar_tecla_mov.tiempoCompletado())
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, v.y);
            desactivar();
        }
        
    }

    void FixedUpdate ()
    {
        efecto();
    }
}
