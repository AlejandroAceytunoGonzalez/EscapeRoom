using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSetter : MonoBehaviour
{
    [SerializeField] private int index;
    private void Awake()
    {
        GameManager.Instance.SetTrack(index);
    }
}
