using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathZoneAsteroid : MonoBehaviour
{
    [SerializeField] private int playerHealth;
    [SerializeField] private int score;
    [SerializeField] private int maxScore;
    [SerializeField] private Text scoreText;    
    [SerializeField] private Text maxScoreText;
    [SerializeField] private string username;
    

    // TAREA: Anidar los IF de colision de misiles dentro de los IF de colision de jugador -- 22/10/2022 Desestimar, parece estar funcionando correctamente

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

        scoreText = GameObject.FindGameObjectWithTag("ShowScore").GetComponent<Text>();
        score = PlayerPrefs.GetInt("Score");
        maxScore = PlayerPrefs.GetInt("MaxScore");
        username = PlayerPrefs.GetString("PName");
        maxScoreText = GameObject.FindGameObjectWithTag("ShowMaxScore").GetComponent<Text>();

        if (other.gameObject.tag == "Asteroid1" | other.gameObject.tag == "Asteroid2" | other.gameObject.tag == "Asteroid3")
        {
            Debug.Log("Two asteroids have collisioned!");
        } else if (other.gameObject.tag == "Player" && gameObject.tag == "Asteroid1" )
        {   
            // Using PlayerPrefs to track Player's Health
            playerHealth = PlayerPrefs.GetInt("PHealth");
            playerHealth = playerHealth -20; // Value changes depending on asteroid type
            PlayerPrefs.SetInt("PHealth", playerHealth);
            // ----------
            Debug.Log("Type 1 Asteroid impact detected! -- Hull integrity: " + playerHealth);
            Destroy(gameObject);
        } else if (other.gameObject.tag == "Player" && gameObject.tag == "Asteroid2" )
        {
            // Using PlayerPrefs to track Player's Health
            playerHealth = PlayerPrefs.GetInt("PHealth");
            playerHealth = playerHealth -30; // Value changes depending on asteroid type
            PlayerPrefs.SetInt("PHealth", playerHealth);
            // ----------
            Debug.Log("Type 2 Asteroid impact detected! -- Hull integrity: " + playerHealth);
            Destroy(gameObject);
        } else if (other.gameObject.tag == "Player" && gameObject.tag == "Asteroid3" )
        {
            // Using PlayerPrefs to track Player's Health
            playerHealth = PlayerPrefs.GetInt("PHealth");
            playerHealth = playerHealth -10; // Value changes depending on asteroid type
            PlayerPrefs.SetInt("PHealth", playerHealth);
            // ----------
            Debug.Log("Type 3 Asteroid impact detected! -- Hull integrity: " + playerHealth);
            Destroy(gameObject);
        } else if (other.gameObject.tag == "PlayerProjectile" && gameObject.tag == "Asteroid3" )
        {          
                
                score = score + 10; // Value changes depending on asteroid type
                PlayerPrefs.SetInt("Score", score);
                // ----------
                scoreText.text = $"Score: {score}";
                Debug.Log("(DeathZoneAsteroid.cs) Type 3 Asteroid destroyed - Score updated: " + score);
                checkMaxScore();
                Destroy(other.gameObject);
                Destroy(gameObject);

            }  else if (other.gameObject.tag == "PlayerProjectile" && gameObject.tag == "Asteroid2" )
            {

                //Destroy(gameObject);

                score = score + 30; // Value changes depending on asteroid type
                PlayerPrefs.SetInt("Score", score);
                // ----------
                scoreText.text = $"Score: {score}";
                Debug.Log("(DeathZoneAsteroid.cs) Type 2 Asteroid destroyed - Score updated: " + score);
                checkMaxScore();
                Destroy(other.gameObject);
                Destroy(gameObject);

            } else if (other.gameObject.tag == "PlayerProjectile" && gameObject.tag == "Asteroid1" )
            {

                //Destroy(gameObject);

                score = score + 20; // Value changes depending on asteroid type
                PlayerPrefs.SetInt("Score", score);
                // ----------
                scoreText.text = $"Score: {score}";
                Debug.Log("(DeathZoneAsteroid.cs) Type 1 Asteroid destroyed - Score updated: " + score);
                checkMaxScore();
                Destroy(other.gameObject);
                Destroy(gameObject);

            }            
        }
        
        /*
        if (other.gameObject.tag == "PlayerProjectile" && gameObject.tag == "Asteroid1")
        {
            // Using PlayerPrefs to track Player's Score
            score = PlayerPrefs.GetInt("Score");
            score = score + 20; // Value changes depending on asteroid type
            PlayerPrefs.SetInt("Score", score);
            // ----------
            scoreText.text = $"Score: {score}";
            Debug.Log("(DeathZoneAsteroid.cs) Score updated: " + score);
            Destroy(gameObject);
            Destroy(other.gameObject);

        }  else if (other.gameObject.tag == "PlayerProjectile" && gameObject.tag == "Asteroid2")
        {   
            // Using PlayerPrefs to track Player's Score
            score = PlayerPrefs.GetInt("Score");
            score = score + 30; // Value changes depending on asteroid type
            PlayerPrefs.SetInt("Score", score);
            // ----------
            scoreText.text = $"Score: {score}";
            Debug.Log("(DeathZone.cs) Score updated: " + score);
            Destroy(gameObject);
            Destroy(other.gameObject);

        } else if (other.gameObject.tag == "PlayerProjectile" && gameObject.tag == "Asteroid3")
        {
            // Using PlayerPrefs to track Player's Score
            score = PlayerPrefs.GetInt("Score");
            score = score + 10; // Value changes depending on asteroid type
            PlayerPrefs.SetInt("Score", score);
            // ----------
            scoreText.text = $"Score: {score}";
            Debug.Log("(DeathZone.cs) Score updated: " + score);
            Destroy(gameObject);
            Destroy(other.gameObject);

        }
        */
    

    private void checkMaxScore() {
        if (score > maxScore) {
            maxScore = score;
            PlayerPrefs.SetInt("MaxScore", maxScore);
            PlayerPrefs.SetString("Champion", username);
            maxScoreText.text = $"{username} - {maxScore}";            
        }
    }

}
