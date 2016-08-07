using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject player, obstacleSpawner;
    GameObject gameManager;
    GameManager gm;
    bool timeSlowed;
	// Use this for initialization
	void Start ()
    {
        gameManager = GameObject.Find("GameManager");
        gm = gameManager.GetComponent<GameManager>();
        gm.levelManager = this.gameObject;
        if (player != null)
            player.GetComponent<PlayerController>().levelManager = gameObject;
        else
        {
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerController>().levelManager = gameObject;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {

    }
    public void PlayerDeath()
    {
        player.GetComponent<PlayerController>().alive = false;
        if (obstacleSpawner != null)
            obstacleSpawner.GetComponent<ObstacleSpawner>().canSpawn = false;
        else
        {
            obstacleSpawner = GameObject.Find("Obstacle_Spawner");
            obstacleSpawner.GetComponent<ObstacleSpawner>().canSpawn = false;
        }
    }
    public void ShootingPause()
    {
        StopCoroutine("ReturnTime");
        if (Time.timeScale <= .5f)
        {
            StopCoroutine("LevelSlow");
        }
        StartCoroutine("LevelSlow");  
    }
    IEnumerator LevelSlow()
    {
        while (Time.timeScale >= .5f)
        {
            Time.timeScale -= .2f;
            yield return new WaitForSeconds(.01f);
        }
        yield return new WaitForSeconds(.1f);
        StartCoroutine("ReturnTime");
    }
    IEnumerator ReturnTime()
    {
        while (Time.timeScale < 1f)
        {
            Time.timeScale += .2f;
            yield return new WaitForSeconds(.01f);
            if (Time.timeScale > 1)
                Time.timeScale = 1;
        }
    }
}
