using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class AdditiveSlot : MonoBehaviour
{
    public UserInterface ui;

    private void Start()
    {
        AddEvent(gameObject, EventTriggerType.PointerEnter, delegate { OnEnter(gameObject); });
        AddEvent(gameObject, EventTriggerType.PointerExit, delegate { OnExit(gameObject); });
    }

    public void OnEnter(GameObject obj)
    {
        MouseData.additiveSlotHoveredOver = obj;
    }

    public void OnExit(GameObject obj)
    {
        MouseData.additiveSlotHoveredOver = null;
    }

    protected void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }


}
