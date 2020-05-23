using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject start;
    public GameObject logo;
    public GameObject h2p;
    public GameObject space;

    public void PressStart()
    {
        logo.SetActive(false);
        h2p.SetActive(true);
        space.SetActive(true);
        start.SetActive(false);
    }
}
