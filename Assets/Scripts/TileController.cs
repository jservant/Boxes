using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    SpriteRenderer sr;
    public GameController gameC = new GameController();

    public Sprite[] sprites;
    public bool Turn = false; // Tells tiles that there was input and disables when it updates it's sprite
    public bool collided = false; // Turns on when player touches tile
    int currentSprite;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        currentSprite = 7;
    }

    private void LateUpdate() // LateUpdate because you want these to process after the player moves
    {
        // Have tile activate when player moves, if they can
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)
            || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)
            || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)
            || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) { Turn = true; } // If player does anything activate this

        if (collided && Turn) // If player did anything AND the tile has been touched
        {
            if (currentSprite <= 6)
            {
                currentSprite--;
                sr.sprite = sprites[currentSprite];
                Turn = false;
            }
            if (currentSprite <= 0) // If tile # is 0
            {
                collided = false;
                Turn = false;
                gameObject.SetActive(false); // Remove tile from game
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collided)
        {
            currentSprite = Random.Range(5, 7); // SHOULD BE pick a random die count between 4 and 6
            sr.sprite = sprites[currentSprite]; // Set sprite to that value
            Turn = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collided = true;
    }
}
