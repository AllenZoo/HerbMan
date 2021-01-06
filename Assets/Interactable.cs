using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class Interactable : MonoBehaviour
{
    public delegate void Interacation(Player player);

    private Interacation curFunc;
    private KeyCode interactInput;

    public KeyCode GetInputKey()
    {
        return interactInput;
    }

    public void SetInteractionInput(KeyCode keyCode)
    {
        interactInput = keyCode;
    }

    public void SetInteractionFunc(Interacation func)
    {
        curFunc = func;
    }

    public void Interact(Player player)
    {
        curFunc(player);
    }

}
