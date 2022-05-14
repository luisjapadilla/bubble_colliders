using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject buble;

    public GameObject startbubble;
    public float minX;
    public float maxX;
    public float miny;
    public float maxy;

    Vector2 SpawnPoint;

    public float rate = 2f;

    float nextSpawn = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time+ rate;

            float randomx = Random.Range(minX, maxX);
            float randomy = Random.Range(miny, maxy);
            SpawnPoint = new Vector2(randomx, randomy);
            Instantiate(startbubble, SpawnPoint, Quaternion.identity);
        }
    }
    IEnumerator BuildDestroy()
    {
        Instantiate(startbubble, SpawnPoint, Quaternion.identity);
        yield return new WaitForSeconds(2);
        Instantiate(buble, SpawnPoint, Quaternion.identity);
    }
}
