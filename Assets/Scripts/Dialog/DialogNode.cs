using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum CharacterType
    {
        Npc,
        Player
    }
[Serializable]
public class DialogNode 
{
    public CharacterType type;
    public string characterName;
    [TextArea]
    public string dialog;
}
