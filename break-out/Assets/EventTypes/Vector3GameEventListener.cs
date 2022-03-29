using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Vector3GameEventListener : MonoBehaviour
{
    public Vector3GameEvent Event;
    public Vector3Event Response;

    private void OnEnable()
    { Event.RegisterListener(this); }

    private void OnDisable()
    { Event.UnregisterListener(this); }

    public void OnEventRaised(Vector3 param)
    { Response.Invoke(param); }
}

[System.Serializable]
public class Vector3Event : UnityEvent<Vector3> {}