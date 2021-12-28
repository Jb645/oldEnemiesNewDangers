using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCost : MonoBehaviour
{
    private Text costText;

    // Start is called before the first frame update
    private void Awake()
    {
        costText = transform.GetChild(1).GetComponent<Text>();
    }

    // Update is called once per frame
    public void setCostText(int cost)
    {
        costText.text = $"{cost}";
    }
}