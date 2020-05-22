using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController
{
    public GameObject[] tiles;
    private bool win = false;
    private bool lose = false;
    [Space()]
    public int numOfTilesTouched = 0;

    public bool Lose
    {
        get
        {
            return lose;
        }
        set
        {
            lose = value;
            if (lose)
            {
                GameObject.FindWithTag("Player").SetActive(false);
            }
        }
    }
    public bool Win
    {
        get { return win; }
        set 
        {
            win = value;
        }
    }
}
