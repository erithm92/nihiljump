using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float jumpForce, fireRate, bulletForce;
    public GameObject levelManager, blood;
    public bool alive;
    Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        

	    if (alive)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpForce);
            }
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 normalized = mousePos - new Vector2(transform.position.x,transform.position.y);
                normalized.Normalize();
                transform.rotation = Quaternion.Euler(Vector3.zero);
                rb.velocity = Vector3.zero;
                rb.angularVelocity = 0;
                levelManager.GetComponent<LevelManager>().ShootingPause();
                GameObject bullet = Instantiate(blood, gameObject.transform.position 
                                    + new Vector3(.5f, 0, 0), transform.rotation) as GameObject;

                bullet.GetComponent<Rigidbody2D>().velocity = normalized * bulletForce;
                
            }
        }
	}
}
