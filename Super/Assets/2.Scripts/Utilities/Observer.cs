using System;
using System.Collections.Generic;

public class Observer<T>
{
	T previous;
	T current;

	Dictionary<string, Action<T, T>> changeCallback = new Dictionary<string, Action<T, T>>();

	public T Previous
	{
		get
		{
			return previous;
		}
	}

	public T Value
	{
		get
		{
			return current;
		}

		set
		{
			previous = current;
			current = value;

			InvokeCallback(previous, current);
		}
	}

	public void AddCallback(string key, Action<T, T> callback)
	{
		if (callback == null || changeCallback.ContainsKey(key))
			return;

		changeCallback.Add(key, callback);
	}

	public void RemoveCallback(string key)
	{
		if (!changeCallback.ContainsKey(key))
			return;

		changeCallback.Remove(key);
	}

	void InvokeCallback(T pre, T curr)
	{
		foreach(Action<T, T> callback in changeCallback.Values)
		{
			callback(pre, curr);
		}
	}
}
