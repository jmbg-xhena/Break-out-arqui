using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewIntGameEvent", menuName = "Events/New Int Game Event", order = 1)]
public class IntGameEvent : ScriptableObject
{
	private List<IntGameEventListener> listeners =
		new List<IntGameEventListener>();

	public void Raise(int param)
	{
		for (int i = listeners.Count - 1; i >= 0; i--)
			listeners[i].OnEventRaised(param);
	}

	public void RegisterListener(IntGameEventListener listener)
	{ listeners.Add(listener); }

	public void UnregisterListener(IntGameEventListener listener)
	{ listeners.Remove(listener); }
}