using UnityEngine;

public class irLocacion : MonoBehaviour
{
    private GameObject[] puntos;
    private enemMovimiento ia_mov;
    private float cercania;

    void Awake()
    {
        puntos = new GameObject[2];
        puntos[0] = GameObject.Find(transform.parent.name + "/puntos/a");
        if (puntos[0] == null)
            Debug.Log("No se encontro punto a para " + transform.parent.name);

        puntos[1] = GameObject.Find(transform.parent.name + "/puntos/b");
        if (puntos[1] == null)
            Debug.Log("No se encontro punto b para " + transform.parent.name);
    }

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
