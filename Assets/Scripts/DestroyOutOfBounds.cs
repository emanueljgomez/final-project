using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Start() was removed
    // Update is called once per frame
    void Update()
    {
        DestroyOutOfBoundsObject();
    }

    // ========================================
    // ========================================

    void DestroyOutOfBoundsObject() {
        if (transform.position.z > 120)
        {
            Destroy(gameObject);
        } 
    }
}
