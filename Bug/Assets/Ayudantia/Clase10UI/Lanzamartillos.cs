using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzamartillos : MonoBehaviour
{
    public GameObject prefabMartillo;
    
    public Transform spawnMartillo;

    public float velocidadLanzamiento;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.F)) {
            GameObject nuevoMartillo = Instantiate(prefabMartillo, spawnMartillo.position, Quaternion.identity);
            float velocidadDireccional = velocidadLanzamiento;
            if (GetComponent<SpriteRenderer>().flipX) {
                velocidadDireccional *= -1;
            }
            nuevoMartillo.GetComponent<Rigidbody2D>().velocity =
                new Vector2(velocidadDireccional, velocidadDireccional);
            Destroy(nuevoMartillo,3f);

        }
    }
}
