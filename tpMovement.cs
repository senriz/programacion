using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpMovement : MonoBehaviour
{

    [SerializeField] private float velocidad;

    [SerializeField] private Transform suelo;

    [SerializeField] private float distancia;

    [SerializeField] private bool derecha;

    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate(){
        RaycastHit2D infoSuelo = Physics2D.Raycast(suelo.position, Vector2.down, distancia);

        rb.velocity = new Vector2 (velocidad, rb.velocity.y);

        if (infoSuelo == false){
            Girar();
        }
    }

    private void Girar(){
        derecha = !derecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawLine(suelo.transform.position, suelo.transform.position + Vector3.down * distancia);
    }
}
