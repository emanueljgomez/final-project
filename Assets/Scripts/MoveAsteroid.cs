using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveAsteroid : MonoBehaviour
{
    // Variables
    public Text statusText;
    [SerializeField] private float speed = 40.0f;
    [SerializeField] private int score;
    [SerializeField] private int points;
    [SerializeField] private Text scoreText;    

    void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        statusText = GameObject.FindGameObjectWithTag("statusText").GetComponent<Text>();
        scoreText = GameObject.FindGameObjectWithTag("ShowScore").GetComponent<Text>();
    }

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
        if (transform.position.z < -50 && gameObject.tag == "Asteroid1")
        {
            Destroy(gameObject);
            points = 20;
            updateScore();

        } else if (transform.position.z < -50 && gameObject.tag == "Asteroid2")
        {
            Destroy(gameObject);
            points = 30;
            updateScore();

        } else if (transform.position.z < -50 && gameObject.tag == "Asteroid3")
        {
            Destroy(gameObject);
            points = 10;
            updateScore();

        } else if (transform.position.z < -50 && gameObject.tag == "Asteroid4")
        {
            Destroy(gameObject);
            points = 10;
            updateScore();

        } else if (transform.position.z < -50 && gameObject.tag == "Asteroid4B")
        {
            Destroy(gameObject);
            points = 5;
            updateScore();

        } else if (transform.position.z < -50 && gameObject.tag == "Asteroid5")
        {
            Destroy(gameObject);
            points = 20;
            updateScore();
        }
    }

    void updateScore() {
        score = score - points; // Value changes depending on asteroid type
        PlayerPrefs.SetInt("Score", score);
        // ----------
        scoreText.text = $"Score: {score}";
        Debug.Log("Failed to destroy: [ " + gameObject.tag + " ] - Score updated: " + score);
    }

}
