using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    SpriteRenderer sr;
    public Sprite[] sprites;
    public bool Turn = false;
    public bool collided = false;
    public int currentSprite;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {        
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)
            || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)
            || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)
            || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) { Turn = true; }

        if (Turn && collided)
        {
            if (currentSprite == 0)
            {
                Turn = false;
            }
            if (currentSprite <= 6)
            {
                currentSprite--;
                sr.sprite = sprites[currentSprite];
                Turn = false;
            }
            else if (currentSprite == 7)
            {
                // make wall code
            }
            
            //switch (currentSprite)
            //{
            //    case 1:
            //        sr.sprite = sprites[2]; Turn = false;
            //        break;
            //    case 2:
            //        sr.sprite = sprites[3]; Turn = false;
            //        break;
            //    case 3:
            //        sr.sprite = sprites[4]; Turn = false;
            //        break;
            //    case 4:
            //        sr.sprite = sprites[5]; Turn = false;
            //        break;
            //    case 5:
            //        sr.sprite = sprites[6]; Turn = false;
            //        break;
            //    case 6:
            //        // turn into wall
            //        break;
            //}
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collided = true;
        currentSprite = Random.Range(4, 6);
        sr.sprite = sprites[currentSprite];
    }
}
