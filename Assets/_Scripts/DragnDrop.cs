using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DragnDrop : MonoBehaviour
{
    bool moveallowed;
    Collider2D col;

    public SpriteRenderer spriteRenderer;
    private GameMaster gm;
    public Sprite[] values;
    public int Spritecounter;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        col = GetComponent<Collider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Spritecounter = UnityEngine.Random.Range(0, 3);
        spriteRenderer.sprite = values[Spritecounter];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchposition = Camera.main.ScreenToWorldPoint(touch.position);
            if (touch.phase == TouchPhase.Began)
            {
                Collider2D touachcolider = Physics2D.OverlapPoint(touchposition);
                if (col == touachcolider)
                {
                    moveallowed = true;
                    if (Spritecounter < 2)
                    {
                        Spritecounter++;
                        spriteRenderer.sprite = values[Spritecounter];
                    }
                    else
                    {
                        Spritecounter = 0;
                        spriteRenderer.sprite = values[Spritecounter];
                    }
                }
            }
            if(touch.phase == TouchPhase.Moved)
            {
                if (moveallowed)
                {
                    transform.position = new Vector2(touchposition.x, touchposition.y);
                }
            }
            if(touch.phase == TouchPhase.Ended)
            {
                moveallowed = false;
              
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Planets")
        {
            int i = other.gameObject.GetComponent<DragnDrop>().Spritecounter;
            if(i == Spritecounter)
            {
                Destroy(other.gameObject);
                Destroy(this);
            }
            else
            {
               gm.GameOver();
            }
            
            
        }
    }
}