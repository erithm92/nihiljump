using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour
{
    public GameObject deathScreen, blood, gameManager;
    public enum triggerPosition { BOTTOM, LEFT};
    public triggerPosition colliderSide;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            other.gameObject.GetComponent<Player>().alive = false;
            StartCoroutine(Bleed(other.transform.position));
        }
       
    }
    IEnumerator Bleed(Vector3 hitPoint)
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject bloodDrop = Instantiate(blood, hitPoint + (Vector3.left * .01f), gameObject.transform.rotation) as GameObject;
            if (colliderSide == triggerPosition.LEFT)
                bloodDrop.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 20);
            else if (colliderSide == triggerPosition.BOTTOM)
                bloodDrop.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 20);
            yield return new WaitForSeconds(.02f);
        }
        yield return new WaitForSeconds(.5f);
        gameManager.GetComponent<GameManager>().PickQuote();
        deathScreen.SetActive(true);

    }
}
