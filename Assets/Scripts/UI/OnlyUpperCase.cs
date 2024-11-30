using TMPro;
using UnityEngine;

public class OnlyUpperCase : MonoBehaviour
{
    private TMP_InputField inputField;

    private void Awake()
    {
        inputField = GetComponent<TMP_InputField>();
    }

    public void ToUpper()
    {
        inputField.text = inputField.text.ToUpper();
    }
}
