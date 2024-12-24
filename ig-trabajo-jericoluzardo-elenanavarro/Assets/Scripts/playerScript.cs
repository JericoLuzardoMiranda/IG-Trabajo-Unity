using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{

    public Transform player;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() {
        Vector3 pos = player.position;

        // Se utiliza los eventos de teclas para mover el jugador
        if (Input.GetKey(KeyCode.W)) {
            pos.z += speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S)) {
            pos.z -= speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A)) {
            pos.x -= speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D)) {
            pos.x += speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space)) {
            pos.y += speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftShift)) {
            pos.y -= speed * Time.deltaTime;
        }

        player.position = pos;
    }
}
