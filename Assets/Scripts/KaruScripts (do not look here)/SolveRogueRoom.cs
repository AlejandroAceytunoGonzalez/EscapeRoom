using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolveRogueRoom : MonoBehaviour
{
    // Start is called before the first frame update
    public void PullTheLeverRogue()
    {
        GameManager.Instance.Solve(Character.Rogue);
    }
}
