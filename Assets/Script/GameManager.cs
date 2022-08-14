using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int score;
    public Text scoreText;
    public GameObject blocks;
    public GameObject uIVictory;

    void Awake(){
        if (instance == null)
        {
            instance = this;
           // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        uIVictory.SetActive(false);
        Time.timeScale = 1;
        score = 0;
        scoreText.text = score.ToString();
    }

    void Update()
    {
        scoreText.text = score.ToString();
        if (blocks.transform.childCount == 0)
        {
            
            uIVictory.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void RestartGame()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.buildIndex);
    }

    public void LoadNextScene()
    {
        Scene activeScene = SceneManager.GetActiveScene(); 
        if (activeScene.buildIndex+1 != -1)
            SceneManager.LoadScene(activeScene.buildIndex + 1);
        else
        {
            Debug.Log("this is the last level");
        }
    }
}
