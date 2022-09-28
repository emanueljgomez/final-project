using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    // Variables
    [SerializeField] private float horizontalInput;
    [SerializeField] private float speed = 40.0f;
    [SerializeField] private GameObject projectilePrefab; // Component Variable for Player (assign prefab projectile)
    [SerializeField] private bool cooldown;

    void Start()
    {
        InvokeRepeating("RestartCooldown", 0.7f, 0.7f);
    }

    // Update is called once per frame
    void Update()
    {
       PlayerHorizontalMovement();
       PlayerAttack();
       KeepPlayerInBounds();
    }

    // ========================================
    // ========================================

    void PlayerHorizontalMovement() {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }

    void PlayerAttack() {
        if (Input.GetKeyDown(KeyCode.Space) && cooldown == false)
        {
        // Launch a proyectile from the Player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        // Instantiate method: creates a copy of a prefab. Formula: Instantiate(Original object, spawn position, rotation)
            cooldown = true;
        }
    }

    void KeepPlayerInBounds() {
        if (transform.position.x < -35)
        {
            transform.position = new Vector3(-35, transform.position.y, transform.position.z);
        }

        if (transform.position.x > 35)
        {
            transform.position = new Vector3(35, transform.position.y, transform.position.z);
        }
    }

    void RestartCooldown() {
        cooldown = false;
    }

}
