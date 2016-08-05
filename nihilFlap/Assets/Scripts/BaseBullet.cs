using UnityEngine;
using System.Collections;

public class BaseBullet : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        Vector3 mousepos = Input.mousePosition;
        mousepos.z = 10f; //The distance between the camera and object
        Vector3 objectpos = Camera.main.WorldToScreenPoint(transform.position);
        mousepos.x = mousepos.x - objectpos.x;
        mousepos.y = mousepos.y - objectpos.y;
        float angle = Mathf.Atan2(mousepos.y, mousepos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
   
    void OnCollisionEnter2D(Collision2D other)
    {
        anim.SetBool("hit", true);
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }


}
