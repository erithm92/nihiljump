using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Player : MonoBehaviour {

    public float jumpForce;
    public GameObject blood;
    public int bloodAmmount;
    public bool bleed, alive;
    public Animator anim;
    public GameObject score;
    Text scoreText;
    int scoreCount = 0;
	// Use this for initialization
	void Start ()
    {
        scoreText = score.GetComponent<Text>();
        scoreText.text = "" + scoreCount;
        alive = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(jumpForce * Vector3.up);
            if (alive)
            {
                scoreCount += 1;
                scoreText.text = "" + scoreCount;
            }
            //anim.SetBool("jump", true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //anim.SetBool("jump", false);
        }
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
            Instantiate(blood, hitPoint + (Vector3.left * .01f) , gameObject.transform.rotation);
            yield return new WaitForSeconds(.03f);
        }
        bleed = true;
    }
}
