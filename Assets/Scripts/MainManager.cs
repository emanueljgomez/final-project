using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{   
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject playBtn;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject restartBtn;
    [SerializeField] private string username;
    [SerializeField] private string champion;
    [SerializeField] private Text maxScoreText;

    private static int maxScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        endScreen.SetActive(false);
        restartBtn.gameObject.SetActive(false);
        PlayerPrefs.SetInt("Score", 0);
        playBtn = GameObject.FindGameObjectWithTag("PlayBtn");
        startScreen = GameObject.FindGameObjectWithTag("StartScreen");
        maxScore = PlayerPrefs.GetInt("MaxScore");
        champion = PlayerPrefs.GetString("Champion");
        Debug.Log("(MainManager.cs) Current Max score: " + maxScore);
        Debug.Log("(MainManager.cs) Last Player: " + username);
        Debug.Log("(MainManager.cs) Current Champion: " + champion);
        maxScoreText.text = $"{champion} - {maxScore}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ----------

    public void StartGame()
    {
        Time.timeScale = 1;
        startScreen.gameObject.SetActive(false);
    }

    public void RestartGame()
    {   
        Debug.Log("(MainManager.cs) Juego reiniciado!");
        endScreen.gameObject.SetActive(false);
        restartBtn.gameObject.SetActive(false);
        startScreen.gameObject.SetActive(true);
        player.gameObject.SetActive(true);
    }
}
