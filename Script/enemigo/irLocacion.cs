using UnityEngine;

public class irLocacion : MonoBehaviour
{
    public GameObject[] puntos;
    private enemMovimiento ia_mov;
    private float cercania;
	
	void Start ()
    {
        cercania = 0.25f;
        ia_mov = GetComponent<enemMovimiento>();
	}
	
	void FixedUpdate ()
    {
        if (ia_mov.getMirada().Equals("derecha") && ia_mov.getVelocidad().SqrMagnitude() != 0)
        {
            float valor = Mathf.Abs(transform.position.x - puntos[0].transform.position.x);
            if (cercania > valor)
            {
                ia_mov.setMirada("izquierda");
            }
        }
        else if(ia_mov.getVelocidad().SqrMagnitude() != 0)
        {
            float valor = Mathf.Abs(transform.position.x - puntos[1].transform.position.x);
            if (cercania > valor)
                ia_mov.setMirada("derecha");
        }
        else
        {
            ia_mov.setMovimiento();
        }
    }
}
