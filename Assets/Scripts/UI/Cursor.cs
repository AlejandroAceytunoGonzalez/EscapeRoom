using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{
    [SerializeField] private Image cursor;
    [SerializeField] private Sprite normalCursor;
    [SerializeField] private Sprite interactableCursor;

    public void SetCursorInteractable(bool interactable)
    {
        if (interactable)
        {
            cursor.sprite = interactableCursor;
        }
        else
        {
            cursor.sprite = normalCursor;
        }
    }
}
