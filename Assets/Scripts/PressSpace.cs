using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PressSpace : MonoBehaviour
{
    public KeyCode _Key;
    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(_Key))
        {
            button.onClick.Invoke();
        }
    }

    public void SpacePush()
    {
        SceneManager.LoadScene("Level");
    }
}
