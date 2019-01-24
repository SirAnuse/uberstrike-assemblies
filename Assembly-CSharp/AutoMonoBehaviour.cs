using System;
using UnityEngine;

// Token: 0x020003BB RID: 955
public class AutoMonoBehaviour<T> : MonoBehaviour where T : class
{
	// Token: 0x17000636 RID: 1590
	// (get) Token: 0x06001BFE RID: 7166 RVA: 0x000129B8 File Offset: 0x00010BB8
	protected static bool IsRunning
	{
		get
		{
			return AutoMonoBehaviour<T>._isRunning;
		}
	}

	// Token: 0x06001BFF RID: 7167 RVA: 0x0008EB54 File Offset: 0x0008CD54
	private static T GetInstance()
	{
		GameObject gameObject = GameObject.Find("AutoMonoBehaviours");
		if (gameObject == null)
		{
			gameObject = new GameObject("AutoMonoBehaviours");
			UnityEngine.Object.DontDestroyOnLoad(gameObject);
		}
		string name = typeof(T).Name;
		AutoMonoBehaviour<T>._gameObject = GameObject.Find("AutoMonoBehaviours/" + name);
		if (AutoMonoBehaviour<T>._gameObject == null)
		{
			AutoMonoBehaviour<T>._gameObject = new GameObject(name);
			AutoMonoBehaviour<T>._gameObject.transform.parent = gameObject.transform;
		}
		return AutoMonoBehaviour<T>._gameObject.AddComponent(typeof(T)) as T;
	}

	// Token: 0x06001C00 RID: 7168 RVA: 0x000129BF File Offset: 0x00010BBF
	private void OnApplicationQuit()
	{
		AutoMonoBehaviour<T>._isRunning = false;
	}

	// Token: 0x06001C01 RID: 7169 RVA: 0x000129C7 File Offset: 0x00010BC7
	protected virtual void Start()
	{
		if (AutoMonoBehaviour<T>._instance == null)
		{
			throw new Exception("The script " + typeof(T).Name + " is self instantiating and shouldn't be attached manually to a GameObject.");
		}
	}

	// Token: 0x17000637 RID: 1591
	// (get) Token: 0x06001C02 RID: 7170 RVA: 0x0008EC04 File Offset: 0x0008CE04
	public static T Instance
	{
		get
		{
			if (AutoMonoBehaviour<T>._instance == null && AutoMonoBehaviour<T>._isRunning)
			{
				if (AutoMonoBehaviour<T>._isInstantiating)
				{
					throw new Exception(string.Concat(new object[]
					{
						"Recursive calls to Constuctor of AutoMonoBehaviour! Check your ",
						typeof(T),
						":Awake() function for calls to ",
						typeof(T),
						".Instance"
					}));
				}
				AutoMonoBehaviour<T>._isInstantiating = true;
				AutoMonoBehaviour<T>._instance = AutoMonoBehaviour<T>.GetInstance();
			}
			return AutoMonoBehaviour<T>._instance;
		}
	}

	// Token: 0x040018FB RID: 6395
	private const string rootGameObjectName = "AutoMonoBehaviours";

	// Token: 0x040018FC RID: 6396
	private static T _instance;

	// Token: 0x040018FD RID: 6397
	private static GameObject _gameObject;

	// Token: 0x040018FE RID: 6398
	private static bool _isRunning = true;

	// Token: 0x040018FF RID: 6399
	private static bool _isInstantiating;
}
