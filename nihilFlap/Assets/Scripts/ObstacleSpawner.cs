using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
    public float spawnTime, minTime, maxTime;
    public GameObject column;
    public bool canSpawn;
	void Start ()
    {
       StartCoroutine("SpawnColumn");
	}
	
	// Update is called once per frame
	IEnumerator SpawnColumn()
    {
        while (canSpawn)
        {
            spawnTime = Random.Range(minTime, maxTime);
            Instantiate(column, transform.position, transform.rotation);
            yield return new WaitForSeconds(spawnTime);
        }

    }
}
