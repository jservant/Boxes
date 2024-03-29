﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameController gameC = new GameController();
    SpriteRenderer sr;
    float distance = 1.25f;
    bool moveW; bool moveE; bool moveN; bool moveS; // For the sake of this line being simple, pretend true and false have reverse meanings
    [SerializeField] float time;

    public GameObject losePanel;
    public GameObject winPanel;
    public GameObject pressR;
    public GameObject pressSpace;

    private void Start()
    {
        gameC.tiles = GameObject.FindGameObjectsWithTag("Tile"); // Makes an array of all tiles in scene
        gameC.Lose = false;
        gameC.Win = false;
        Debug.Log("Total tiles: " + gameC.tiles.Length);
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (gameC.numOfTilesTouched == gameC.tiles.Length)
        { 
            gameC.Win = true;
            winPanel.SetActive(true);
            pressR.SetActive(true);
        }
        if (gameC.Move)
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
        else if (!gameC.Win)
        {
            if (!moveW) { transform.position += new Vector3(distance, 0); moveW = true; Debug.Log("West"); }
            if (!moveE) { transform.position -= new Vector3(distance, 0); moveE = true; Debug.Log("East"); }
            if (!moveN) { transform.position -= new Vector3(0, distance); moveN = true; Debug.Log("North"); }
            if (!moveS) { transform.position += new Vector3(0, distance); moveS = true; Debug.Log("South"); }
            // Reverses direction if player moves to a tile that's been burnt (change to "if the player moves to nothing"?)
            // DOESN'T reenable movement, so if the player lands on nothing they lose

            time -= Time.deltaTime;
            if (time <= -.75f) //Trigger all the game over stuff
            {
                sr.enabled = false;
            }
            if (time <= -1.5f)
            {
                time = -1.5f;
                gameC.Lose = true;
                losePanel.SetActive(true);
                pressR.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!moveW) moveW = true;
        if (!moveE) moveE = true;
        if (!moveN) moveN = true;
        if (!moveS) moveS = true;
        // Movement is successful
        if (!collision.GetComponent<TileController>().collided)
        {
            gameC.numOfTilesTouched++;
        }
        Debug.Log("Tiles touched: " + gameC.numOfTilesTouched);
        gameC.Move = true; // Reenable movement
        time = 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gameC.Move = false; // Disables movement upon leaving a tile
    }
}
