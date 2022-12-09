using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathZoneAsteroidSpecial : DeathZoneAsteroid
{   
    [SerializeField] private GameObject miniAsteroid;

    void Start()
    {
        playerHealth = PlayerPrefs.GetInt("PHealth");
    }

    // Polymorphism: handleDestroy() from DeathZoneAsteroid.cs base functionality is extended
    public override void handleDestroy() {
        
        if (gameObject.tag == "Asteroid5" && playerHealth < 100) {
            // Using PlayerPrefs to track Player's Health
            playerHealth = PlayerPrefs.GetInt("PHealth");
            playerHealth = playerHealth +10; // Restores player health upon being destroyed
            if (playerHealth > 100) {
                playerHealth = 100;
            }
            PlayerPrefs.SetInt("PHealth", playerHealth);
            Debug.Log("Green Asteroid destroyed! [ +10 Health ] -- Hull integrity: " + playerHealth);
        } else if (gameObject.tag == "Asteroid4") {
            Debug.Log("Red Asteroid impact detected!");
            Instantiate(miniAsteroid, transform.position, miniAsteroid.transform.rotation);
        } else if (gameObject.tag == "Asteroid4B") {
            Debug.Log("Mini Asteroid destroyed!");
        }

        base.handleDestroy();
    }

}
