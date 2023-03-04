using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDontDestroy : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
