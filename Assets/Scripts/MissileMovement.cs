using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{   
    // Variables
    [SerializeField] private float speed = 40.0f;

    // Start() was removed
    // Update is called once per frame
    void Update()
    {
        MoveMissile();
    }

    // ========================================
    // ========================================

    void MoveMissile() {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        // Vector3 movement is relative to the object's facing angle
    }
}
