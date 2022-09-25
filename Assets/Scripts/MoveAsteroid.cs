using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAsteroid : MonoBehaviour
{
    // Variables
    [SerializeField] private float speed = 40.0f;

    // Start() was removed
    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
        DestrAsteroid();
    }

    // ========================================
    // ========================================

    void AsteroidMovement() {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
        // Vector3 movement is relative to the object's facing angle
    }

    void DestrAsteroid()
    {
        if (transform.position.z < -600)
        {
            Destroy(gameObject);
        }
    }

}
