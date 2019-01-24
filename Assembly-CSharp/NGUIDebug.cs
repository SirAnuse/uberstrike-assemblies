using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200004B RID: 75
[AddComponentMenu("NGUI/Internal/Debug")]
public class NGUIDebug : MonoBehaviour
{
	// Token: 0x060001A2 RID: 418 RVA: 0x0001D668 File Offset: 0x0001B868
	public static void Log(string text)
	{
		if (Application.isPlaying)
		{
			if (NGUIDebug.mLines.Count > 20)
			{
				NGUIDebug.mLines.RemoveAt(0);
			}
			NGUIDebug.mLines.Add(text);
			if (NGUIDebug.mInstance == null)
			{
				GameObject gameObject = new GameObject("_NGUI Debug");
				NGUIDebug.mInstance = gameObject.AddComponent<NGUIDebug>();
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
			}
		}
		else
		{
			Debug.Log(text);
		}
	}

	// Token: 0x060001A3 RID: 419 RVA: 0x0001D6E0 File Offset: 0x0001B8E0
	public static void DrawBounds(Bounds b)
	{
		Vector3 center = b.center;
		Vector3 vector = b.center - b.extents;
		Vector3 vector2 = b.center + b.extents;
		Debug.DrawLine(new Vector3(vector.x, vector.y, center.z), new Vector3(vector2.x, vector.y, center.z), Color.red);
		Debug.DrawLine(new Vector3(vector.x, vector.y, center.z), new Vector3(vector.x, vector2.y, center.z), Color.red);
		Debug.DrawLine(new Vector3(vector2.x, vector.y, center.z), new Vector3(vector2.x, vector2.y, center.z), Color.red);
		Debug.DrawLine(new Vector3(vector.x, vector2.y, center.z), new Vector3(vector2.x, vector2.y, center.z), Color.red);
	}

	// Token: 0x060001A4 RID: 420 RVA: 0x0001D818 File Offset: 0x0001BA18
	private void OnGUI()
	{
		int i = 0;
		int count = NGUIDebug.mLines.Count;
		while (i < count)
		{
			GUILayout.Label(NGUIDebug.mLines[i], new GUILayoutOption[0]);
			i++;
		}
	}

	// Token: 0x040001C0 RID: 448
	private static List<string> mLines = new List<string>();

	// Token: 0x040001C1 RID: 449
	private static NGUIDebug mInstance = null;
}
