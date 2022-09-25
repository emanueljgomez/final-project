using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Variables
    [SerializeField] private GameObject bgPrefab;

    void Start()
    {
        InvokeRepeating("SpawnNewBg", 0.0f, 32.7f);
    }
    
    // ========================================
    // ========================================

    void SpawnNewBg()
    {
        Instantiate(bgPrefab, bgPrefab.transform.position, bgPrefab.transform.rotation);
    }
}
