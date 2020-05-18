using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float distance;
    bool moveW; bool moveE; bool moveN; bool moveS;

    void Update()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("THING");
        if (collision.gameObject.GetComponent<TileController>().burnt == false) 
        {
            if (!moveW) moveW = true;
            if (!moveE) moveE = true;
            if (!moveN) moveN = true;
            if (!moveS) moveS = true;
        }
        else
        {
            if (!moveW) { transform.position += new Vector3(distance, 0); moveW = true; Debug.Log("West"); }
            if (!moveE) { transform.position -= new Vector3(distance, 0); moveE = true; Debug.Log("East"); }
            if (!moveN) { transform.position -= new Vector3(0, distance); moveN = true; Debug.Log("North"); }
            if (!moveS) { transform.position += new Vector3(0, distance); moveS = true; Debug.Log("South"); }
        }
    }
}
