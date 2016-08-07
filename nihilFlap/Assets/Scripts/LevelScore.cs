using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelScore : MonoBehaviour
{
    public int score, startScore, levelScore;
    GameObject gameManager;
    GameManager gm;
    Text scoreText;

    // Use this for initialization
    void Start ()
    {
        gameManager = GameObject.Find("GameManager");
        gm = gameManager.GetComponent<GameManager>();
        gm.GetComponent<GameManager>().scoreObject = this.gameObject;
        scoreText = GetComponent<Text>();
        score = gm.totalBlood;
        startScore = gm.totalBlood;
        InvokeRepeating("BloodGain", 0, .1f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        scoreText.text = "" + score;
	}
    void BloodGain()
    {
        score += 1;
    }
    void LateUpdate()
    {
        PlayerPrefs.SetInt("TOTALBLOOD", score);
        PlayerPrefs.Save();
    }
    public void CalculateLevelScore()
    {
        levelScore = score - startScore;
        if(PlayerPrefs.HasKey("HIGHSCORE"))
        {
            if (levelScore > PlayerPrefs.GetInt("HIGHSCORE"))
            {
                //highscore!!!
            }

        }
        else
        {
            //HIGHSCORE
            PlayerPrefs.SetInt("HIGHSCORE", levelScore);
        }
        PlayerPrefs.Save();
    }

}
