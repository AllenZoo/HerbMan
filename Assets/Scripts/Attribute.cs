using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Attribute
{
    [System.NonSerialized]
    public Player_Stats parent;
    public Attributes type;
    public ModifiableInt value;
    public void SetParent(Player_Stats player_Stats)
    {
        parent = player_Stats;
        value = new ModifiableInt(AttributeModified);
    }

    public void AttributeModified()
    {
        parent.AttributeModified(this);
    }
}
