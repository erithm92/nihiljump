using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameObject instance;
    public GameObject scoreObject;
    public GameObject levelManager;
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
       
    }
    void Start()
    {
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
        Debug.Log(PlayerPrefs.GetInt("TOTALBLOOD"));
        PlayerPrefs.Save();
    }
    void Update()
    {
        if (scoreObject != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                scoreObject.GetComponent<LevelScore>().score -= 5;
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
    public void PlayerDeath()
    {
        levelManager.GetComponent<LevelManager>().PlayerDeath();
        SceneManager.LoadScene(0);
        instance = null;
        Destroy(gameObject);
    }
}
