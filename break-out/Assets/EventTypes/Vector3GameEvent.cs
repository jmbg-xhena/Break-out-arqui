using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewVector3GameEvent", menuName = "Events/New Vector3 Game Event", order = 1)]
public class Vector3GameEvent : ScriptableObject
{
	private List<Vector3GameEventListener> listeners =
		new List<Vector3GameEventListener>();

	public void Raise(Vector3 param)
	{
		for (int i = listeners.Count - 1; i >= 0; i--)
			listeners[i].OnEventRaised(param);
	}

	public void RegisterListener(Vector3GameEventListener listener)
	{ listeners.Add(listener); }

	public void UnregisterListener(Vector3GameEventListener listener)
	{ listeners.Remove(listener); }
}