using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameObject instance;
    public GameObject scoreObject;
    public int totalBlood, levelToLoad, score;
    
    void Awake()
    {
        if (instance == null)
            instance = gameObject;
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        if (PlayerPrefs.HasKey("TOTALBLOOD"))
            totalBlood = PlayerPrefs.GetInt("TOTALBLOOD");
        else
            totalBlood = 0;
        if (PlayerPrefs.HasKey("LEVELSELECTION"))
            levelToLoad = PlayerPrefs.GetInt("LEVELSELECTION");
        else
        {
            levelToLoad = 1;
            PlayerPrefs.SetInt("LEVELSELECTION", levelToLoad);
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public int CalcLevelScore()
    {
        return totalBlood - score;
    }
}
