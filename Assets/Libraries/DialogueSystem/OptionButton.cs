using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OptionButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI optionText;
    [SerializeField] private TextMeshProUGUI optionIndexText;

    public void setText(string text, string optionIndex = null)
    {
        optionText.text = text;
        if (optionIndex != null && optionIndexText != null) optionIndexText.text = optionIndex;
    }
}
