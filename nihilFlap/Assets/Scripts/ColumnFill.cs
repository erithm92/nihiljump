using UnityEngine;
using System.Collections;

public class ColumnFill : MonoBehaviour
{
    public GameObject spire, enemy;
    public GameObject spire1, spire2, spire3, spire4;
    
    public bool top, bottom;
  
    public float verticalOffset, enemyOffset;
    public float high, low;
    public Vector3 topPos, bottomPos;
    bool wide;
	void Start ()
    {
        float spireSelection = Random.Range(0, 4);
        if (spireSelection < 1)
            spire = spire1;
        else if (spireSelection >= 1 && spireSelection < 2)
            spire = spire2;
        else if (spireSelection >= 2 && spireSelection < 3)
            spire = spire3;
        else
            spire = spire4;

        top = randomBool();
        bottom = randomBool();
        if (top==bottom)
        {
            if(top == false)
            {
                top = randomBool();
                bottom = randomBool();
            }
        }
        wide = randomBool();
        verticalOffset = Random.Range(low, high);
        enemyOffset = Random.Range(1.5f, 3);
        
        if (top)
        {
            if (!bottom)
                verticalOffset -= 1;
            FillTop();
        }
        if (bottom)
        {
            if (!top)
                verticalOffset += 1;
            FillBot();
        }
        transform.position += new Vector3(0, verticalOffset, 0);

    }
	void Update()
    {
        if (transform.position.x < -4)
            Destroy(gameObject);
    }
    bool randomBool()
    {
        return (Random.value > 0.5f);
    }
    void FillTop()
    {
        GameObject toSpawn = RandomSelectObstacle();
        GameObject top = Instantiate(toSpawn,transform.position + topPos, transform.rotation) as GameObject;
        if (toSpawn == enemy)
        {
            top.transform.position += new Vector3(0, -enemyOffset, 0);
            bool random = randomBool();
            if (random)
            {
                GameObject top2 = Instantiate(toSpawn, top.transform.position + Vector3.down / 2, transform.rotation) as GameObject;
                top2.transform.parent = gameObject.transform;
                if (wide)
                    top2.transform.position += new Vector3(0, .05f, 0);
            }
        }
        else
            top.GetComponent<SpriteRenderer>().flipY = true;
       
        if (wide)
            top.transform.position += new Vector3(0, .05f, 0);
            top.transform.parent = gameObject.transform;
    }
    void FillBot()
    {
        GameObject toSpawn = RandomSelectObstacle();
        GameObject bot = Instantiate(toSpawn, transform.position + bottomPos, transform.rotation) as GameObject;
        if (toSpawn == enemy)
        {
            bot.transform.position += new Vector3(0, enemyOffset, 0);
            bool random = randomBool();
            if(random)
            {
                GameObject bot2 = Instantiate(toSpawn, bot.transform.position + Vector3.up/2, transform.rotation) as GameObject;
                bot2.transform.parent = gameObject.transform;
                if (wide)
                    bot2.transform.position += new Vector3(0, -.05f, 0);
            }
        }
        bot.transform.parent = gameObject.transform;
        if (wide)
            bot.transform.position += new Vector3(0, -.05f, 0);
    }
    GameObject RandomSelectObstacle()
    {
        if (randomBool())
            return enemy;
        else
            return spire;
    }
}
