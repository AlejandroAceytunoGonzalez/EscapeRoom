using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCharacterSO : ScriptableObject
{
    public List<DialogueCharacterDef> DialogueCharacters;
}
[Serializable]
public class DialogueCharacterDef
{
    public string characterTag;
    public Sprite sprite;
}