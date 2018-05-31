using UnityEngine;

public struct EventAgs
{
	string key;
	GameObject sender;

	public EventAgs(string key, GameObject sender)
	{
		this.key = key;
		this.sender = sender;
	}

	public string Key
	{
		get
		{
			return key;
		}
	}

	public GameObject Sender
	{
		get
		{
			return sender;
		}
	}
}
