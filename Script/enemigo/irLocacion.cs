using System.Collections;
using System.Collections.Generic;
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
        if (ia_mov.getMirada().Equals("derecha"))
        {
            float valor = Vector3.SqrMagnitude(transform.position - puntos[0].transform.position);
            if (cercania > valor)
            {
                ia_mov.setMirada("izquierda");
            }
        }
        else
        {
            float valor = Vector3.SqrMagnitude(transform.position - puntos[1].transform.position);
            if (cercania > valor)
                ia_mov.setMirada("derecha");
        }
    }
}
