using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    SpriteRenderer sr;
    public Sprite[] sprites;
    public bool Turn = false; // Tells tiles that there was input and disables when it updates it's sprite
    public bool collided = false; // Turns on when player touches tile
    public bool burnt;
    public int currentSprite;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        currentSprite = 7;
    }

    private void Update()
    {        
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)
            || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)
            || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)
            || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) { Turn = true; } // If player does anything activate this

        if (Turn && collided) // If player did anything AND the tile has been touched
        {
            if (currentSprite <= 6)
            {
                currentSprite--;
                sr.sprite = sprites[currentSprite];
                Turn = false;
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
        if (currentSprite <= 0)
        {
            sr.sprite = null;
            burnt = true;
            collided = false;
            Turn = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!burnt && !collided)
        {
            collided = true; // Tells game tile has been touched to start burn sequence
            Turn = false;
            currentSprite = Random.Range(5, 7); // SHOULD BE pick a random die count between 4 and 6
            sr.sprite = sprites[currentSprite]; // Set sprite to that value
        }
    }
}
