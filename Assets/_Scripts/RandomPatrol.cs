using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomPatrol : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float miny;
    public float maxy;

    public float minSpeed;
    public float maxSpeed;
    
    float speed;

    public float secondstomax;

    private enum Color { Blue, Red, Green   , }

    Vector2 targetposition;
    // Start is called before the first frame update
    void Start()
    {
        targetposition = getRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector2)transform.position != targetposition)
        {
            speed = Mathf.Lerp(minSpeed, maxSpeed, GetDifficulty());
            transform.position = Vector2.MoveTowards(transform.position, targetposition, speed * Time.deltaTime );
        }
        else
        {
            targetposition = getRandomPosition();
        }
    }
    Vector2 getRandomPosition()
    {
        float randomx = Random.Range(minX, maxX);
        float randomy = Random.Range(miny, maxy);

        return new Vector2(randomx, randomy);
    }

    float GetDifficulty()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondstomax);
    }
}
