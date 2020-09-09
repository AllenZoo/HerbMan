using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputSlot : MonoBehaviour
{
    public static OutputSlot Instance { get; private set; }

    private Transform outputSlotImage;
    private Item output;

    private void Awake()
    {
        outputSlotImage = transform.Find("outputItemSlot");
    }

    public Item GetOutput()
    {
        return output;
    }
    public void SetOutputItem(Item output)
    {
        this.output = output;
    }
}
