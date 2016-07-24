using UnityEngine;
using System.Collections;

public class LevelMove : MonoBehaviour
{
    [SerializeField]
    private float levelSpeed;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += Vector3.left * levelSpeed * Time.deltaTime;
	}
}
