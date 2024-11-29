using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRolls : MonoBehaviour
{
    [SerializeField] private List<Animator> goldenRolls;
    private MusicPuzzle musicPuzzle;
    private void Awake()
    {
        musicPuzzle = FindObjectOfType<MusicPuzzle>();
        musicPuzzle.OnFinish += Finish;
    }
    public void Finish()
    {
        foreach (Animator rotatingAnim in goldenRolls) {
            rotatingAnim.SetBool("Finished", true);
        }

    }
}
