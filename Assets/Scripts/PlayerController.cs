using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float distance;
    public bool moveW; public bool moveE; public bool moveN; public bool moveS;
    // For the sake of the last line being simple, pretend true and false have reverse meanings
    public float time;
    public bool canMove = true;
    public bool won = false;
    SpriteRenderer sr;

    private void Start()
    {
        GameController gc = new GameController();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //won = GameObject.FindWithTag("GameController").GetComponent<GameController>().win;
        
        if (won) canMove = false;
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position -= new Vector3(distance, 0); moveW = false;
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position += new Vector3(distance, 0); moveE = false;
            }
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0, distance); moveN = false;
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.position -= new Vector3(0, distance); moveS = false;
            }
        }
        else if (!won)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                if (!moveW) { transform.position += new Vector3(distance, 0); moveW = true; Debug.Log("West"); }
                if (!moveE) { transform.position -= new Vector3(distance, 0); moveE = true; Debug.Log("East"); }
                if (!moveN) { transform.position -= new Vector3(0, distance); moveN = true; Debug.Log("North"); }
                if (!moveS) { transform.position += new Vector3(0, distance); moveS = true; Debug.Log("South"); }
                // Reverses direction if player moves to a tile that's been burnt (change to "if the player moves to nothing"?)
                // DOESN'T reenable movement, so if the player lands on nothing they lose
            }
            if (time <= -.75f) //Trigger all the game over stuff
            {
                sr.enabled = false;
            }
            if (time <= -1.5f)
            {
                time = -1.5f;
                GameObject.FindWithTag("GameController").GetComponent<GameController>().lose = true;
                gameObject.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!moveW) moveW = true;
        if (!moveE) moveE = true;
        if (!moveN) moveN = true;
        if (!moveS) moveS = true;
        // Movement is successful
        canMove = true; // Reenable movement

        time = 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canMove = false; // Disables movement upon leaving a tile
    }
}
