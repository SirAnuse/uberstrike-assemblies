using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200008A RID: 138
[AddComponentMenu("NGUI/UI/Root")]
[ExecuteInEditMode]
public class UIRoot : MonoBehaviour
{
	// Token: 0x170000AB RID: 171
	// (get) Token: 0x060003BF RID: 959 RVA: 0x00004CF9 File Offset: 0x00002EF9
	public static List<UIRoot> list
	{
		get
		{
			return UIRoot.mRoots;
		}
	}

	// Token: 0x170000AC RID: 172
	// (get) Token: 0x060003C0 RID: 960 RVA: 0x000296F0 File Offset: 0x000278F0
	public int activeHeight
	{
		get
		{
			int num = Mathf.Max(2, Screen.height);
			if (this.scalingStyle == UIRoot.Scaling.FixedSize)
			{
				return this.manualHeight;
			}
			if (num < this.minimumHeight)
			{
				return this.minimumHeight;
			}
			if (num > this.maximumHeight)
			{
				return this.maximumHeight;
			}
			return num;
		}
	}

	// Token: 0x170000AD RID: 173
	// (get) Token: 0x060003C1 RID: 961 RVA: 0x00004D00 File Offset: 0x00002F00
	public float pixelSizeAdjustment
	{
		get
		{
			return this.GetPixelSizeAdjustment(Screen.height);
		}
	}

	// Token: 0x060003C2 RID: 962 RVA: 0x00029744 File Offset: 0x00027944
	public static float GetPixelSizeAdjustment(GameObject go)
	{
		UIRoot uiroot = NGUITools.FindInParents<UIRoot>(go);
		return (!(uiroot != null)) ? 1f : uiroot.pixelSizeAdjustment;
	}

	// Token: 0x060003C3 RID: 963 RVA: 0x00029774 File Offset: 0x00027974
	public float GetPixelSizeAdjustment(int height)
	{
		height = Mathf.Max(2, height);
		if (this.scalingStyle == UIRoot.Scaling.FixedSize)
		{
			return (float)this.manualHeight / (float)height;
		}
		if (height < this.minimumHeight)
		{
			return (float)this.minimumHeight / (float)height;
		}
		if (height > this.maximumHeight)
		{
			return (float)this.maximumHeight / (float)height;
		}
		return 1f;
	}

	// Token: 0x060003C4 RID: 964 RVA: 0x00004D0D File Offset: 0x00002F0D
	private void Awake()
	{
		this.mTrans = base.transform;
		UIRoot.mRoots.Add(this);
		if (this.automatic)
		{
			this.scalingStyle = UIRoot.Scaling.PixelPerfect;
			this.automatic = false;
		}
	}

	// Token: 0x060003C5 RID: 965 RVA: 0x00004D3F File Offset: 0x00002F3F
	private void OnDestroy()
	{
		UIRoot.mRoots.Remove(this);
	}

	// Token: 0x060003C6 RID: 966 RVA: 0x000297D4 File Offset: 0x000279D4
	private void Start()
	{
		UIOrthoCamera componentInChildren = base.GetComponentInChildren<UIOrthoCamera>();
		if (componentInChildren != null)
		{
			Debug.LogWarning("UIRoot should not be active at the same time as UIOrthoCamera. Disabling UIOrthoCamera.", componentInChildren);
			Camera component = componentInChildren.gameObject.GetComponent<Camera>();
			componentInChildren.enabled = false;
			if (component != null)
			{
				component.orthographicSize = 1f;
			}
		}
	}

	// Token: 0x060003C7 RID: 967 RVA: 0x0002982C File Offset: 0x00027A2C
	private void Update()
	{
		if (this.mTrans != null)
		{
			float num = (float)this.activeHeight;
			if (num > 0f)
			{
				float num2 = 2f / num;
				Vector3 localScale = this.mTrans.localScale;
				if (Mathf.Abs(localScale.x - num2) > 1.401298E-45f || Mathf.Abs(localScale.y - num2) > 1.401298E-45f || Mathf.Abs(localScale.z - num2) > 1.401298E-45f)
				{
					this.mTrans.localScale = new Vector3(num2, num2, num2);
				}
			}
		}
	}

	// Token: 0x060003C8 RID: 968 RVA: 0x000298CC File Offset: 0x00027ACC
	public static void Broadcast(string funcName)
	{
		int i = 0;
		int count = UIRoot.mRoots.Count;
		while (i < count)
		{
			UIRoot uiroot = UIRoot.mRoots[i];
			if (uiroot != null)
			{
				uiroot.BroadcastMessage(funcName, SendMessageOptions.DontRequireReceiver);
			}
			i++;
		}
	}

	// Token: 0x060003C9 RID: 969 RVA: 0x00029918 File Offset: 0x00027B18
	public static void Broadcast(string funcName, object param)
	{
		if (param == null)
		{
			Debug.LogError("SendMessage is bugged when you try to pass 'null' in the parameter field. It behaves as if no parameter was specified.");
		}
		else
		{
			int i = 0;
			int count = UIRoot.mRoots.Count;
			while (i < count)
			{
				UIRoot uiroot = UIRoot.mRoots[i];
				if (uiroot != null)
				{
					uiroot.BroadcastMessage(funcName, param, SendMessageOptions.DontRequireReceiver);
				}
				i++;
			}
		}
	}

	// Token: 0x04000358 RID: 856
	private static List<UIRoot> mRoots = new List<UIRoot>();

	// Token: 0x04000359 RID: 857
	public UIRoot.Scaling scalingStyle = UIRoot.Scaling.FixedSize;

	// Token: 0x0400035A RID: 858
	[HideInInspector]
	public bool automatic;

	// Token: 0x0400035B RID: 859
	public int manualHeight = 720;

	// Token: 0x0400035C RID: 860
	public int minimumHeight = 320;

	// Token: 0x0400035D RID: 861
	public int maximumHeight = 1536;

	// Token: 0x0400035E RID: 862
	private Transform mTrans;

	// Token: 0x0200008B RID: 139
	public enum Scaling
	{
		// Token: 0x04000360 RID: 864
		PixelPerfect,
		// Token: 0x04000361 RID: 865
		FixedSize,
		// Token: 0x04000362 RID: 866
		FixedSizeOnMobiles
	}
}
