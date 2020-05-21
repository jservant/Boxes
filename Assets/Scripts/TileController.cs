using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    SpriteRenderer sr;
    Collider2D col;

    public Sprite[] sprites;
    public bool Turn = false; // Tells tiles that there was input and disables when it updates it's sprite
    public bool collided = false; // Turns on when player touches tile
    public int currentSprite;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        currentSprite = 7;
    }

    private void LateUpdate() // LateUpdate because you want these to process after the player moves
    {
        // Prevent ticking when player can't move
        bool pMove;
        bool lost = GameObject.FindWithTag("GameController").GetComponent<GameController>().lose;
        bool won = GameObject.FindWithTag("GameController").GetComponent<GameController>().win;
        if (!lost && !won) { pMove = GameObject.FindWithTag("Player").GetComponent<PlayerController>().canMove; } else { pMove = false; } // This is mostly to prevent errors
        
        // Have tile activate when player moves, if they can
        if (pMove && !won && Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)
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
        }
        if (currentSprite <= 0) // If tile # is 0
        {
            collided = false;
            Turn = false;
            /*GameObject.FindWithTag("GameController").GetComponent<GameController>().numOfTiles--;*/
            gameObject.SetActive(false); // Remove tile from game
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (col.enabled && !collided)
        {
            collided = true; // Tells game tile has been touched to start burn sequence
            Turn = false;
            GameObject.FindWithTag("GameController").GetComponent<GameController>().numOfTilesTouched++;
            currentSprite = Random.Range(5, 7); // SHOULD BE pick a random die count between 4 and 6
            sr.sprite = sprites[currentSprite]; // Set sprite to that value
        }
    }
}
