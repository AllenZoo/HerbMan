using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarText : MonoBehaviour
{
    private StatBar statBar;
    private Text text;

    private void Awake()
    {
        statBar = this.GetComponentInParent<StatBar>();
        text = GetComponent<Text>();
    }
    private void Start()
    {
        
    }
    public void RefreshText()
    {
        text.text = "" + Mathf.Round(statBar.GetCurValue()) + " / " + statBar.GetMaxValue();
    }
}
