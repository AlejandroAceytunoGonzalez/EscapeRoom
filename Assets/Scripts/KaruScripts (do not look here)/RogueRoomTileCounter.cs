using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueRoomTileCounter : MonoBehaviour
{
    // Example of a global variable
    public static int tileCount = 0;

    private void Update()
    {
        if (tileCount >= 4)
        {
            tileCount = 0;
        }
    }

    // Use Awake() to ensure it initializes early, if needed
    private void Awake()
    {
        tileCount = 0;
    }
}
