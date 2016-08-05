using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelScore : MonoBehaviour
{
    public int score;
    GameObject gameManager;
    GameManager gm;
    // Use this for initialization
    void Start ()
    {
        gameManager = GameObject.Find("GameManager");
        gm = gameManager.GetComponent<GameManager>();
        gm.GetComponent<GameManager>().scoreObject = this.gameObject;

    }
	
	// Update is called once per frame
	void Update ()
    {
        score = gm.totalBlood;
	}

}
