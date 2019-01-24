using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

// Token: 0x0200004D RID: 77
public static class NGUITools
{
	// Token: 0x17000038 RID: 56
	// (get) Token: 0x060001C9 RID: 457 RVA: 0x0000356C File Offset: 0x0000176C
	// (set) Token: 0x060001CA RID: 458 RVA: 0x00003597 File Offset: 0x00001797
	public static float soundVolume
	{
		get
		{
			if (!NGUITools.mLoaded)
			{
				NGUITools.mLoaded = true;
				NGUITools.mGlobalVolume = PlayerPrefs.GetFloat("Sound", 1f);
			}
			return NGUITools.mGlobalVolume;
		}
		set
		{
			if (NGUITools.mGlobalVolume != value)
			{
				NGUITools.mLoaded = true;
				NGUITools.mGlobalVolume = value;
				PlayerPrefs.SetFloat("Sound", value);
			}
		}
	}

	// Token: 0x17000039 RID: 57
	// (get) Token: 0x060001CB RID: 459 RVA: 0x000035BB File Offset: 0x000017BB
	public static bool fileAccess
	{
		get
		{
			return Application.platform != RuntimePlatform.WindowsWebPlayer && Application.platform != RuntimePlatform.OSXWebPlayer;
		}
	}

	// Token: 0x060001CC RID: 460 RVA: 0x000035D6 File Offset: 0x000017D6
	public static AudioSource PlaySound(AudioClip clip)
	{
		return NGUITools.PlaySound(clip, 1f, 1f);
	}

	// Token: 0x060001CD RID: 461 RVA: 0x000035E8 File Offset: 0x000017E8
	public static AudioSource PlaySound(AudioClip clip, float volume)
	{
		return NGUITools.PlaySound(clip, volume, 1f);
	}

	// Token: 0x060001CE RID: 462 RVA: 0x0001E9FC File Offset: 0x0001CBFC
	public static AudioSource PlaySound(AudioClip clip, float volume, float pitch)
	{
		volume *= NGUITools.soundVolume;
		if (clip != null && volume > 0.01f)
		{
			if (NGUITools.mListener == null)
			{
				NGUITools.mListener = (UnityEngine.Object.FindObjectOfType(typeof(AudioListener)) as AudioListener);
				if (NGUITools.mListener == null)
				{
					Camera camera = Camera.main;
					if (camera == null)
					{
						camera = (UnityEngine.Object.FindObjectOfType(typeof(Camera)) as Camera);
					}
					if (camera != null)
					{
						NGUITools.mListener = camera.gameObject.AddComponent<AudioListener>();
					}
				}
			}
			if (NGUITools.mListener != null && NGUITools.mListener.enabled && NGUITools.GetActive(NGUITools.mListener.gameObject))
			{
				AudioSource audioSource = NGUITools.mListener.audio;
				if (audioSource == null)
				{
					audioSource = NGUITools.mListener.gameObject.AddComponent<AudioSource>();
				}
				audioSource.pitch = pitch;
				audioSource.PlayOneShot(clip, volume);
				return audioSource;
			}
		}
		return null;
	}

	// Token: 0x060001CF RID: 463 RVA: 0x0001EB14 File Offset: 0x0001CD14
	public static WWW OpenURL(string url)
	{
		WWW result = null;
		try
		{
			result = new WWW(url);
		}
		catch (Exception ex)
		{
			Debug.LogError(ex.Message);
		}
		return result;
	}

	// Token: 0x060001D0 RID: 464 RVA: 0x0001EB54 File Offset: 0x0001CD54
	public static WWW OpenURL(string url, WWWForm form)
	{
		if (form == null)
		{
			return NGUITools.OpenURL(url);
		}
		WWW result = null;
		try
		{
			result = new WWW(url, form);
		}
		catch (Exception ex)
		{
			Debug.LogError((ex == null) ? "<null>" : ex.Message);
		}
		return result;
	}

	// Token: 0x060001D1 RID: 465 RVA: 0x000035F6 File Offset: 0x000017F6
	public static int RandomRange(int min, int max)
	{
		if (min == max)
		{
			return min;
		}
		return UnityEngine.Random.Range(min, max + 1);
	}

	// Token: 0x060001D2 RID: 466 RVA: 0x0001EBB0 File Offset: 0x0001CDB0
	public static string GetHierarchy(GameObject obj)
	{
		string text = obj.name;
		while (obj.transform.parent != null)
		{
			obj = obj.transform.parent.gameObject;
			text = obj.name + "/" + text;
		}
		return "\"" + text + "\"";
	}

	// Token: 0x060001D3 RID: 467 RVA: 0x0001EC14 File Offset: 0x0001CE14
	public static Color ParseColor(string text, int offset)
	{
		int num = NGUIMath.HexToDecimal(text[offset]) << 4 | NGUIMath.HexToDecimal(text[offset + 1]);
		int num2 = NGUIMath.HexToDecimal(text[offset + 2]) << 4 | NGUIMath.HexToDecimal(text[offset + 3]);
		int num3 = NGUIMath.HexToDecimal(text[offset + 4]) << 4 | NGUIMath.HexToDecimal(text[offset + 5]);
		float num4 = 0.003921569f;
		return new Color(num4 * (float)num, num4 * (float)num2, num4 * (float)num3);
	}

	// Token: 0x060001D4 RID: 468 RVA: 0x0001EC98 File Offset: 0x0001CE98
	public static string EncodeColor(Color c)
	{
		int num = 16777215 & NGUIMath.ColorToInt(c) >> 8;
		return NGUIMath.DecimalToHex(num);
	}

	// Token: 0x060001D5 RID: 469 RVA: 0x0001ECBC File Offset: 0x0001CEBC
	public static int ParseSymbol(string text, int index, List<Color> colors, bool premultiply)
	{
		int length = text.Length;
		if (index + 2 < length)
		{
			if (text[index + 1] == '-')
			{
				if (text[index + 2] == ']')
				{
					if (colors != null && colors.Count > 1)
					{
						colors.RemoveAt(colors.Count - 1);
					}
					return 3;
				}
			}
			else if (index + 7 < length && text[index + 7] == ']')
			{
				if (colors != null)
				{
					Color color = NGUITools.ParseColor(text, index + 1);
					if (NGUITools.EncodeColor(color) != text.Substring(index + 1, 6).ToUpper())
					{
						return 0;
					}
					color.a = colors[colors.Count - 1].a;
					if (premultiply && color.a != 1f)
					{
						color = Color.Lerp(NGUITools.mInvisible, color, color.a);
					}
					colors.Add(color);
				}
				return 8;
			}
		}
		return 0;
	}

	// Token: 0x060001D6 RID: 470 RVA: 0x0001EDBC File Offset: 0x0001CFBC
	public static string StripSymbols(string text)
	{
		if (text != null)
		{
			int i = 0;
			int length = text.Length;
			while (i < length)
			{
				char c = text[i];
				if (c == '[')
				{
					int num = NGUITools.ParseSymbol(text, i, null, false);
					if (num > 0)
					{
						text = text.Remove(i, num);
						length = text.Length;
						continue;
					}
				}
				i++;
			}
		}
		return text;
	}

	// Token: 0x060001D7 RID: 471 RVA: 0x0000360A File Offset: 0x0000180A
	public static T[] FindActive<T>() where T : Component
	{
		return UnityEngine.Object.FindObjectsOfType(typeof(T)) as T[];
	}

	// Token: 0x060001D8 RID: 472 RVA: 0x0001EE20 File Offset: 0x0001D020
	public static Camera FindCameraForLayer(int layer)
	{
		int num = 1 << layer;
		Camera[] array = NGUITools.FindActive<Camera>();
		int i = 0;
		int num2 = array.Length;
		while (i < num2)
		{
			Camera camera = array[i];
			if ((camera.cullingMask & num) != 0)
			{
				return camera;
			}
			i++;
		}
		return null;
	}

	// Token: 0x060001D9 RID: 473 RVA: 0x0001EE68 File Offset: 0x0001D068
	public static BoxCollider AddWidgetCollider(GameObject go)
	{
		if (go != null)
		{
			Collider component = go.GetComponent<Collider>();
			BoxCollider boxCollider = component as BoxCollider;
			if (boxCollider == null)
			{
				if (component != null)
				{
					if (Application.isPlaying)
					{
						UnityEngine.Object.Destroy(component);
					}
					else
					{
						UnityEngine.Object.DestroyImmediate(component);
					}
				}
				boxCollider = go.AddComponent<BoxCollider>();
			}
			int num = NGUITools.CalculateNextDepth(go);
			Bounds bounds = NGUIMath.CalculateRelativeWidgetBounds(go.transform);
			boxCollider.isTrigger = true;
			boxCollider.center = bounds.center + Vector3.back * ((float)num * 0.25f);
			boxCollider.size = new Vector3(bounds.size.x, bounds.size.y, 0f);
			return boxCollider;
		}
		return null;
	}

	// Token: 0x060001DA RID: 474 RVA: 0x0001EF3C File Offset: 0x0001D13C
	public static string GetName<T>() where T : Component
	{
		string text = typeof(T).ToString();
		if (text.StartsWith("UI"))
		{
			text = text.Substring(2);
		}
		else if (text.StartsWith("UnityEngine."))
		{
			text = text.Substring(12);
		}
		return text;
	}

	// Token: 0x060001DB RID: 475 RVA: 0x0001EF90 File Offset: 0x0001D190
	public static GameObject AddChild(GameObject parent)
	{
		GameObject gameObject = new GameObject();
		if (parent != null)
		{
			Transform transform = gameObject.transform;
			transform.parent = parent.transform;
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
			transform.localScale = Vector3.one;
			gameObject.layer = parent.layer;
		}
		return gameObject;
	}

	// Token: 0x060001DC RID: 476 RVA: 0x0001EFF0 File Offset: 0x0001D1F0
	public static GameObject AddChild(GameObject parent, GameObject prefab)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(prefab) as GameObject;
		if (gameObject != null && parent != null)
		{
			Transform transform = gameObject.transform;
			transform.parent = parent.transform;
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
			transform.localScale = Vector3.one;
			gameObject.layer = parent.layer;
		}
		return gameObject;
	}

	// Token: 0x060001DD RID: 477 RVA: 0x0001F064 File Offset: 0x0001D264
	public static int CalculateNextDepth(GameObject go)
	{
		int num = -1;
		UIWidget[] componentsInChildren = go.GetComponentsInChildren<UIWidget>();
		int i = 0;
		int num2 = componentsInChildren.Length;
		while (i < num2)
		{
			num = Mathf.Max(num, componentsInChildren[i].depth);
			i++;
		}
		return num + 1;
	}

	// Token: 0x060001DE RID: 478 RVA: 0x0001F0A4 File Offset: 0x0001D2A4
	public static T AddChild<T>(GameObject parent) where T : Component
	{
		GameObject gameObject = NGUITools.AddChild(parent);
		gameObject.name = NGUITools.GetName<T>();
		return gameObject.AddComponent<T>();
	}

	// Token: 0x060001DF RID: 479 RVA: 0x0001F0CC File Offset: 0x0001D2CC
	public static T AddWidget<T>(GameObject go) where T : UIWidget
	{
		int depth = NGUITools.CalculateNextDepth(go);
		T result = NGUITools.AddChild<T>(go);
		result.depth = depth;
		Transform transform = result.transform;
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
		transform.localScale = new Vector3(100f, 100f, 1f);
		result.gameObject.layer = go.layer;
		return result;
	}

	// Token: 0x060001E0 RID: 480 RVA: 0x0001F14C File Offset: 0x0001D34C
	public static UISprite AddSprite(GameObject go, UIAtlas atlas, string spriteName)
	{
		UIAtlas.Sprite sprite = (!(atlas != null)) ? null : atlas.GetSprite(spriteName);
		UISprite uisprite = NGUITools.AddWidget<UISprite>(go);
		uisprite.type = ((sprite != null && !(sprite.inner == sprite.outer)) ? UISprite.Type.Sliced : UISprite.Type.Simple);
		uisprite.atlas = atlas;
		uisprite.spriteName = spriteName;
		return uisprite;
	}

	// Token: 0x060001E1 RID: 481 RVA: 0x0001F1B4 File Offset: 0x0001D3B4
	public static GameObject GetRoot(GameObject go)
	{
		Transform transform = go.transform;
		for (;;)
		{
			Transform parent = transform.parent;
			if (parent == null)
			{
				break;
			}
			transform = parent;
		}
		return transform.gameObject;
	}

	// Token: 0x060001E2 RID: 482 RVA: 0x0001F1F4 File Offset: 0x0001D3F4
	public static T FindInParents<T>(GameObject go) where T : Component
	{
		if (go == null)
		{
			return (T)((object)null);
		}
		object obj = go.GetComponent<T>();
		if (obj == null)
		{
			Transform parent = go.transform.parent;
			while (parent != null && obj == null)
			{
				obj = parent.gameObject.GetComponent<T>();
				parent = parent.parent;
			}
		}
		return (T)((object)obj);
	}

	// Token: 0x060001E3 RID: 483 RVA: 0x0001F268 File Offset: 0x0001D468
	public static void Destroy(UnityEngine.Object obj)
	{
		if (obj != null)
		{
			if (Application.isPlaying)
			{
				if (obj is GameObject)
				{
					GameObject gameObject = obj as GameObject;
					gameObject.transform.parent = null;
				}
				UnityEngine.Object.Destroy(obj);
			}
			else
			{
				UnityEngine.Object.DestroyImmediate(obj);
			}
		}
	}

	// Token: 0x060001E4 RID: 484 RVA: 0x00003620 File Offset: 0x00001820
	public static void DestroyImmediate(UnityEngine.Object obj)
	{
		if (obj != null)
		{
			if (Application.isEditor)
			{
				UnityEngine.Object.DestroyImmediate(obj);
			}
			else
			{
				UnityEngine.Object.Destroy(obj);
			}
		}
	}

	// Token: 0x060001E5 RID: 485 RVA: 0x0001F2BC File Offset: 0x0001D4BC
	public static void Broadcast(string funcName)
	{
		GameObject[] array = UnityEngine.Object.FindObjectsOfType(typeof(GameObject)) as GameObject[];
		int i = 0;
		int num = array.Length;
		while (i < num)
		{
			array[i].SendMessage(funcName, SendMessageOptions.DontRequireReceiver);
			i++;
		}
	}

	// Token: 0x060001E6 RID: 486 RVA: 0x0001F300 File Offset: 0x0001D500
	public static void Broadcast(string funcName, object param)
	{
		GameObject[] array = UnityEngine.Object.FindObjectsOfType(typeof(GameObject)) as GameObject[];
		int i = 0;
		int num = array.Length;
		while (i < num)
		{
			array[i].SendMessage(funcName, param, SendMessageOptions.DontRequireReceiver);
			i++;
		}
	}

	// Token: 0x060001E7 RID: 487 RVA: 0x0001F344 File Offset: 0x0001D544
	public static bool IsChild(Transform parent, Transform child)
	{
		if (parent == null || child == null)
		{
			return false;
		}
		while (child != null)
		{
			if (child == parent)
			{
				return true;
			}
			child = child.parent;
		}
		return false;
	}

	// Token: 0x060001E8 RID: 488 RVA: 0x0001F394 File Offset: 0x0001D594
	private static void Activate(Transform t)
	{
		NGUITools.SetActiveSelf(t.gameObject, true);
		int i = 0;
		int childCount = t.childCount;
		while (i < childCount)
		{
			Transform child = t.GetChild(i);
			if (child.gameObject.activeSelf)
			{
				return;
			}
			i++;
		}
		int j = 0;
		int childCount2 = t.childCount;
		while (j < childCount2)
		{
			Transform child2 = t.GetChild(j);
			NGUITools.Activate(child2);
			j++;
		}
	}

	// Token: 0x060001E9 RID: 489 RVA: 0x00003649 File Offset: 0x00001849
	private static void Deactivate(Transform t)
	{
		NGUITools.SetActiveSelf(t.gameObject, false);
	}

	// Token: 0x060001EA RID: 490 RVA: 0x00003657 File Offset: 0x00001857
	public static void SetActive(GameObject go, bool state)
	{
		if (state)
		{
			NGUITools.Activate(go.transform);
		}
		else
		{
			NGUITools.Deactivate(go.transform);
		}
	}

	// Token: 0x060001EB RID: 491 RVA: 0x0001F40C File Offset: 0x0001D60C
	public static void SetActiveChildren(GameObject go, bool state)
	{
		Transform transform = go.transform;
		if (state)
		{
			int i = 0;
			int childCount = transform.childCount;
			while (i < childCount)
			{
				Transform child = transform.GetChild(i);
				NGUITools.Activate(child);
				i++;
			}
		}
		else
		{
			int j = 0;
			int childCount2 = transform.childCount;
			while (j < childCount2)
			{
				Transform child2 = transform.GetChild(j);
				NGUITools.Deactivate(child2);
				j++;
			}
		}
	}

	// Token: 0x060001EC RID: 492 RVA: 0x0000367A File Offset: 0x0000187A
	public static bool GetActive(GameObject go)
	{
		return go && go.activeInHierarchy;
	}

	// Token: 0x060001ED RID: 493 RVA: 0x00003690 File Offset: 0x00001890
	public static void SetActiveSelf(GameObject go, bool state)
	{
		go.SetActive(state);
	}

	// Token: 0x060001EE RID: 494 RVA: 0x0001F484 File Offset: 0x0001D684
	public static void SetLayer(GameObject go, int layer)
	{
		go.layer = layer;
		Transform transform = go.transform;
		int i = 0;
		int childCount = transform.childCount;
		while (i < childCount)
		{
			Transform child = transform.GetChild(i);
			NGUITools.SetLayer(child.gameObject, layer);
			i++;
		}
	}

	// Token: 0x060001EF RID: 495 RVA: 0x00003699 File Offset: 0x00001899
	public static Vector3 Round(Vector3 v)
	{
		v.x = Mathf.Round(v.x);
		v.y = Mathf.Round(v.y);
		v.z = Mathf.Round(v.z);
		return v;
	}

	// Token: 0x060001F0 RID: 496 RVA: 0x0001F4CC File Offset: 0x0001D6CC
	public static void MakePixelPerfect(Transform t)
	{
		UIWidget component = t.GetComponent<UIWidget>();
		if (component != null)
		{
			component.MakePixelPerfect();
		}
		else
		{
			t.localPosition = NGUITools.Round(t.localPosition);
			t.localScale = NGUITools.Round(t.localScale);
			int i = 0;
			int childCount = t.childCount;
			while (i < childCount)
			{
				NGUITools.MakePixelPerfect(t.GetChild(i));
				i++;
			}
		}
	}

	// Token: 0x060001F1 RID: 497 RVA: 0x0001F540 File Offset: 0x0001D740
	public static bool Save(string fileName, byte[] bytes)
	{
		if (!NGUITools.fileAccess)
		{
			return false;
		}
		string path = Application.persistentDataPath + "/" + fileName;
		if (bytes == null)
		{
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			return true;
		}
		FileStream fileStream = null;
		try
		{
			fileStream = File.Create(path);
		}
		catch (Exception ex)
		{
			NGUIDebug.Log(ex.Message);
			return false;
		}
		fileStream.Write(bytes, 0, bytes.Length);
		fileStream.Close();
		return true;
	}

	// Token: 0x060001F2 RID: 498 RVA: 0x0001F5D0 File Offset: 0x0001D7D0
	public static byte[] Load(string fileName)
	{
		if (!NGUITools.fileAccess)
		{
			return null;
		}
		string path = Application.persistentDataPath + "/" + fileName;
		if (File.Exists(path))
		{
			return File.ReadAllBytes(path);
		}
		return null;
	}

	// Token: 0x060001F3 RID: 499 RVA: 0x0001F610 File Offset: 0x0001D810
	public static Color ApplyPMA(Color c)
	{
		if (c.a != 1f)
		{
			c.r *= c.a;
			c.g *= c.a;
			c.b *= c.a;
		}
		return c;
	}

	// Token: 0x060001F4 RID: 500 RVA: 0x0001F670 File Offset: 0x0001D870
	public static void MarkParentAsChanged(GameObject go)
	{
		UIWidget[] componentsInChildren = go.GetComponentsInChildren<UIWidget>();
		int i = 0;
		int num = componentsInChildren.Length;
		while (i < num)
		{
			componentsInChildren[i].ParentHasChanged();
			i++;
		}
	}

	// Token: 0x060001F5 RID: 501 RVA: 0x0001F6A4 File Offset: 0x0001D8A4
	private static PropertyInfo GetSystemCopyBufferProperty()
	{
		if (NGUITools.mSystemCopyBuffer == null)
		{
			Type typeFromHandle = typeof(GUIUtility);
			NGUITools.mSystemCopyBuffer = typeFromHandle.GetProperty("systemCopyBuffer", BindingFlags.Static | BindingFlags.NonPublic);
		}
		return NGUITools.mSystemCopyBuffer;
	}

	// Token: 0x1700003A RID: 58
	// (get) Token: 0x060001F6 RID: 502 RVA: 0x0001F6E0 File Offset: 0x0001D8E0
	// (set) Token: 0x060001F7 RID: 503 RVA: 0x0001F70C File Offset: 0x0001D90C
	public static string clipboard
	{
		get
		{
			PropertyInfo systemCopyBufferProperty = NGUITools.GetSystemCopyBufferProperty();
			return (systemCopyBufferProperty == null) ? null : ((string)systemCopyBufferProperty.GetValue(null, null));
		}
		set
		{
			PropertyInfo systemCopyBufferProperty = NGUITools.GetSystemCopyBufferProperty();
			if (systemCopyBufferProperty != null)
			{
				systemCopyBufferProperty.SetValue(null, value, null);
			}
		}
	}

	// Token: 0x040001C2 RID: 450
	private static AudioListener mListener;

	// Token: 0x040001C3 RID: 451
	private static bool mLoaded = false;

	// Token: 0x040001C4 RID: 452
	private static float mGlobalVolume = 1f;

	// Token: 0x040001C5 RID: 453
	private static Color mInvisible = new Color(0f, 0f, 0f, 0f);

	// Token: 0x040001C6 RID: 454
	private static PropertyInfo mSystemCopyBuffer = null;
}
