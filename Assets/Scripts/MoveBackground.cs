using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{   
    // Variables
    [SerializeField] private float speed = 50;    
    // Start() was removed
    // Update is called once per frame
    void Update()
    {
        MoveBg();
        DestrBg();
    }
    
    // ========================================
    // ========================================

    void MoveBg()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

    void DestrBg()
    {
        if (transform.position.z < -1200)
        {
            Destroy(gameObject);
        }
    }
}
