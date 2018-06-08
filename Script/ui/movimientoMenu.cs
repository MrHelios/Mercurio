using UnityEngine;
using UnityEngine.UI;

public class movimientoMenu : MonoBehaviour
{
    private int posicion, max;
    private float cooldown, ultimaVezUsado;
    private cooldown cd;

	void Start ()
    {
        posicion = 0;
        max = transform.childCount;

        amarillo();

        if(GameObject.Find("Canvas").GetComponent<cooldownGlobal>() != null)
            cd = GameObject.Find("Canvas").GetComponent<cooldownGlobal>().cd;
        else
        {
            cd = new cooldown();
            cd.setCooldown(0.2f);
            cd.setUltimaVez(-99f);
        }
    }

    private void blanco()
    {
        transform.GetChild(posicion).transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(255, 255, 255);
    }

    private void amarillo()
    {
        transform.GetChild(posicion).transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(255, 255, 0);
    }
	

	void FixedUpdate ()
    {
        float v = Input.GetAxis("Vertical");
        if (Mathf.Abs(v) > 0 && cd.tiempoCompletado())
        {
            if (v < 0f)
            {
                blanco();

                posicion++;
                if (posicion == max)
                    posicion = 0;

                amarillo();
            }
            else
            {
                blanco();

                posicion--;
                if (posicion == -1)
                    posicion = max - 1;

                amarillo();
            }
            cd.setUltimaVez(Time.time);
        }

        if (Input.GetAxis("Fire1") > 0)
            transform.GetChild(posicion).GetComponent<Button>().onClick.Invoke();
		
	}
}
