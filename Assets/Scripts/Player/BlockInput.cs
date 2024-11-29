using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInput : MonoBehaviour
{
    public void SetPlayerInput(bool state)
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        if (player != null ) player.SetCanMove(state);
    }
}
