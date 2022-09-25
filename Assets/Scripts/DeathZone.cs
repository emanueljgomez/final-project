using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
