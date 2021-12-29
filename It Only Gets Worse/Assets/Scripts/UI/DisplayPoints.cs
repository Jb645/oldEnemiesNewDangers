using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayPoints : MonoBehaviour
{
    private TextMeshProUGUI pointText;
    private PointTracker point;

    // Start is called before the first frame update
    private void Awake()
    {
        pointText = GetComponentInChildren<TextMeshProUGUI>();
        point = ScriptableTags.pointTracker;
    }

    private void FixedUpdate()
    {
        pointText.text = $"Points: {point.currentPoints}";
    }
}