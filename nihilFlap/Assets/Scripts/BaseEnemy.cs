using UnityEngine;
using System.Collections;

public class BaseEnemy : MonoBehaviour {
    public float speed;
    public GameObject blood;
    public int bloodAmmount;
    public bool bleed;
    // Use this for initialization
    void Start () {
        bleed = true;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.left * speed * Time.deltaTime;
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        Vector3 hitPoint = other.contacts[0].point;
        if (bleed)
        {
            StartCoroutine(Bleed(hitPoint));
            bleed = false;

        }
    }
    IEnumerator Bleed(Vector3 hitPoint)
    {
        for (int i = 0; i < bloodAmmount; i++)
        {
            GameObject bloodDrop = Instantiate(blood, hitPoint + (Vector3.left * .01f), gameObject.transform.rotation) as GameObject;
            bloodDrop.GetComponent<Renderer>().material.color = Color.green;
            yield return new WaitForSeconds(.03f);
        }
        Destroy(gameObject);
    }
}
