using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float distance;
    bool moveW; bool moveE; bool moveN; bool moveS;
    bool canMove = true;
    // For the sake of the last line being simple, pretend true and false have reverse meanings

    void Update()
    {
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<TileController>().burnt == false) // If tile stepped on isn't burnt (gone)
        {
            if (!moveW) moveW = true;
            if (!moveE) moveE = true;
            if (!moveN) moveN = true;
            if (!moveS) moveS = true;
            // Movement is successful
            canMove = true; // Reenable movement
        }
        else 
        {
            if (!moveW) { transform.position += new Vector3(distance, 0); moveW = true; Debug.Log("West"); }
            if (!moveE) { transform.position -= new Vector3(distance, 0); moveE = true; Debug.Log("East"); }
            if (!moveN) { transform.position -= new Vector3(0, distance); moveN = true; Debug.Log("North"); }
            if (!moveS) { transform.position += new Vector3(0, distance); moveS = true; Debug.Log("South"); }
            // Reverses direction if player moves to a tile that's been burnt (change to "if the player moves to nothing"?)
            // DOESN'T reenable movement, so if the player lands on nothing they lose
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canMove = false; // Disables movement upon leaving a tile
    }
}
