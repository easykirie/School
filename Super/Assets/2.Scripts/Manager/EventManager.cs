using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager> {

	Dictionary<string, List<IEventReceiver>> listofReceiver = new Dictionary<string, List<IEventReceiver>>();
	//Dictionary<string, Action<EventAgs>> listofReceveCallback = new Dictionary<string, Action<EventAgs>>();

	public void RegisterEvent(EventAgs ags, IEventReceiver receiver)
	{
		if (!listofReceiver.ContainsKey(ags.Key))
		{
			listofReceiver.Add(ags.Key, new List<IEventReceiver>());
		}

		listofReceiver[ags.Key].Add(receiver);
	}

	//public void RegisterEvent(EventAgs ags, Action<EventAgs> callback)
	//{

	//}

	public void CallEvent(EventAgs ags)
	{
		if (!listofReceiver.ContainsKey(ags.Key))
			return;

		List<IEventReceiver> receivers = listofReceiver[ags.Key];

		foreach(IEventReceiver receiver in receivers)
		{
			receiver.ReceiveEvent(ags);
		}
	}

}
