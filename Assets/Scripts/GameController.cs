using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController
{
    public GameObject[] tiles;
    private bool win = false;
    private bool lose = false;
    public bool Move { get; set; } = true;
    public int numOfTilesTouched;

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
                Debug.Log("dude you lost lol");
            }
        }
    }

    public bool Win
    {
        get { return win; }
        set 
        {
            win = value;
            Move = false;
        }
    }
}
