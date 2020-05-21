using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] tiles;
    private bool win = false;

    public bool lose = false;
    public bool Win
    {
        //tiles = GameObject.FindGameObjectsWithTag("Tile"); // Makes an array of all tiles in scene
        set { }
    }

    public GameObject losePanel;
    public GameObject winPanel;
    public GameObject pressR;
    public GameObject pressSpace;
    [Space()]
    public int numOfTilesTouched = 0;

    private void Start()
    {
    }

    void Update()
    {
        if (numOfTilesTouched == tiles.Length) { win = true; }

        if (!win && lose)
        {
            losePanel.SetActive(true);
            pressR.SetActive(true);
        }
        if (win)
        {
            winPanel.SetActive(true);
            pressSpace.SetActive(true);
        }
    }
}
