using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayEvent : MonoBehaviour
{
    public static DisplayEvent current;

    private void Awake()
    {
        current = this;
    }
}