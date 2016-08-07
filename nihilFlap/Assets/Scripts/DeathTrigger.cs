using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour {
    public GameObject gameManager;
	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerController>())
        {
            gameManager.GetComponent<GameManager>().PlayerDeath();
        }
    }
}
