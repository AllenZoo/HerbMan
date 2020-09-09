using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputSlot : MonoBehaviour
{
    private Transform outputSlotImage;

    private void Awake()
    {
        outputSlotImage = transform.Find("outputItemSlot");
    }
}
