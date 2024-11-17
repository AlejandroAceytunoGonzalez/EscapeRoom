using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharactersSO : ScriptableObject
{
    public List<PlayerCharacterDef> playerCharacters;
}
[Serializable]
public class PlayerCharacterDef
{
    public Character character;
    public float height;
    public float width;
}
public enum Character
{
    Rogue,
    Mage,
    Cleric,
    Bard,
}