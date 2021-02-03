using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    GameObject gameController;

    GameController gController;
    void Start()
    {
        gController = gameController.GetComponent<GameController>();
    }

    public void EnterColor(string value)
    {
        switch (value)
        {
            case "yellow":
                break;
            case "red":
                break;
            case "black":
                break;
            case "white":
                break;
            default:
                break;
        }
    }
}
