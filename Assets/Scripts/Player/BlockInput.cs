using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInput : MonoBehaviour
{
    public void SetPlayerInput(bool state)
    {
        FindObjectOfType<PlayerController>().SetCanMove(state);
    }
}
