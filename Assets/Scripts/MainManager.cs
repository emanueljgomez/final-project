using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{   
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject playBtn;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private string username;
    [SerializeField] private string champion;
    [SerializeField] private Text maxScoreText;

    private static int maxScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        endScreen.SetActive(false);
        playBtn = GameObject.FindGameObjectWithTag("PlayBtn");
        startScreen = GameObject.FindGameObjectWithTag("StartScreen");
        maxScore = PlayerPrefs.GetInt("MaxScore");
        champion = PlayerPrefs.GetString("Champion");
        Debug.Log("(MainManager.cs) Current Max score: " + maxScore);
        Debug.Log("(MainManager.cs) Last Player: " + username);
        Debug.Log("(MainManager.cs) Current Champion: " + champion);
        maxScoreText.text = $"[ Highest Score ]\n{champion} - {maxScore}";
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
}
