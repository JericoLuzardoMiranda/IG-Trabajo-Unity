using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLogicScript : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;

    private Animator anim;
    private Rigidbody rb;
    public float x, y;
    
    public float alturaRayo = 1.0f;
    public LayerMask capaSuelo;     // Para asegurarnos de que detectamos solo el terreno

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        // Rotación del personaje
        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);
    }

    void FixedUpdate() {
        // Movimiento del personaje
        Vector3 movimiento = transform.forward * y * velocidadMovimiento * Time.deltaTime;

        // Lanzamos un raycast para detectar el suelo
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up * alturaRayo, Vector3.down, out hit, 1.5f, capaSuelo))
        {
            // Ajustamos la posición para que siga el terreno
            Vector3 nuevaPosicion = rb.position + movimiento;
            nuevaPosicion.y = hit.point.y;
            rb.MovePosition(nuevaPosicion);
            Quaternion inclinacionTerreno = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, inclinacionTerreno, Time.deltaTime * 10.0f));
        } else {
            // Si no hay suelo, usamos el movimiento normal
            rb.MovePosition(rb.position + movimiento);
        }
    }
}
