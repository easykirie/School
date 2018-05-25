using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour {

	static T instance;

	public static T Instance
	{
		get
		{
			if (instance == null)
				instance = FindObjectOfType<T>();

			if (instance == null)
				instance = new GameObject(typeof(T).ToString()).AddComponent<T>();

			return instance;
		}
	}

	protected virtual void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

}
