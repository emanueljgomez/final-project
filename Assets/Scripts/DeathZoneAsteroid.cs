using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneAsteroid : MonoBehaviour
{
    [SerializeField] private int playerHealth;

    /*
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Asteroid1" | other.gameObject.tag == "Asteroid2" | other.gameObject.tag == "Asteroid3")
        {
            Debug.Log("Two asteroids have collisioned!");
        } else if (other.gameObject.tag == "Player" )
        {
            Debug.Log("Starship damaged!");
            Destroy(gameObject);
        } else
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

    }
    */

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Asteroid1" | other.gameObject.tag == "Asteroid2" | other.gameObject.tag == "Asteroid3")
        {
            Debug.Log("Two asteroids have collisioned!");
        } else if (other.gameObject.tag == "Player" && gameObject.tag == "Asteroid1" )
        {
            playerHealth = playerHealth -20;
            Debug.Log("Type 1 Asteroid impact detected! -- Hull integrity: " + playerHealth);
            Destroy(gameObject);
        } else if (other.gameObject.tag == "Player" && gameObject.tag == "Asteroid2" )
        {
            playerHealth = playerHealth -30;
            Debug.Log("Type 2 Asteroid impact detected! -- Hull integrity: " + playerHealth);
            Destroy(gameObject);
        } else if (other.gameObject.tag == "Player" && gameObject.tag == "Asteroid3" )
        {
            playerHealth = playerHealth -10;
            Debug.Log("Type 3 Asteroid impact detected! -- Hull integrity: " + playerHealth);
            Destroy(gameObject);
        } else
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

}
