using System;
using UnityEngine;

// Token: 0x020001A3 RID: 419
public abstract class PageScene : MonoBehaviour
{
	// Token: 0x17000308 RID: 776
	// (get) Token: 0x06000B84 RID: 2948 RVA: 0x000090E6 File Offset: 0x000072E6
	public bool HaveMouseOrbitCamera
	{
		get
		{
			return this._haveMouseOrbitCamera;
		}
	}

	// Token: 0x17000309 RID: 777
	// (get) Token: 0x06000B85 RID: 2949 RVA: 0x000090EE File Offset: 0x000072EE
	public int GuiWidth
	{
		get
		{
			return this._guiWidth;
		}
	}

	// Token: 0x1700030A RID: 778
	// (get) Token: 0x06000B86 RID: 2950 RVA: 0x000090F6 File Offset: 0x000072F6
	public Transform AvatarAnchor
	{
		get
		{
			return this._avatarAnchor;
		}
	}

	// Token: 0x1700030B RID: 779
	// (get) Token: 0x06000B87 RID: 2951 RVA: 0x000090FE File Offset: 0x000072FE
	public Vector3 MouseOrbitConfig
	{
		get
		{
			return this._mouseOrbitConfig;
		}
	}

	// Token: 0x1700030C RID: 780
	// (get) Token: 0x06000B88 RID: 2952 RVA: 0x00009106 File Offset: 0x00007306
	public Vector3 MouseOrbitPivot
	{
		get
		{
			return this._mouseOrbitPivot;
		}
	}

	// Token: 0x1700030D RID: 781
	// (get) Token: 0x06000B89 RID: 2953
	public abstract PageType PageType { get; }

	// Token: 0x1700030E RID: 782
	// (get) Token: 0x06000B8A RID: 2954 RVA: 0x0000910E File Offset: 0x0000730E
	public bool IsEnabled
	{
		get
		{
			return base.gameObject.activeSelf;
		}
	}

	// Token: 0x06000B8B RID: 2955 RVA: 0x00049D68 File Offset: 0x00047F68
	private void Awake()
	{
		this._mouseOrbitConfig.x = (this._mouseOrbitConfig.x + 360f) % 360f;
		this._mouseOrbitConfig.y = (this._mouseOrbitConfig.y + 360f) % 360f;
	}

	// Token: 0x06000B8C RID: 2956 RVA: 0x0000911B File Offset: 0x0000731B
	public void Load()
	{
		base.gameObject.SetActive(true);
		this.OnLoad();
	}

	// Token: 0x06000B8D RID: 2957 RVA: 0x0000912F File Offset: 0x0000732F
	public void Unload()
	{
		base.gameObject.SetActive(false);
		this.OnUnload();
	}

	// Token: 0x06000B8E RID: 2958 RVA: 0x00003C87 File Offset: 0x00001E87
	protected virtual void OnLoad()
	{
	}

	// Token: 0x06000B8F RID: 2959 RVA: 0x00003C87 File Offset: 0x00001E87
	protected virtual void OnUnload()
	{
	}

	// Token: 0x04000AD5 RID: 2773
	[SerializeField]
	protected Vector3 _mouseOrbitConfig;

	// Token: 0x04000AD6 RID: 2774
	[SerializeField]
	private Vector3 _mouseOrbitPivot;

	// Token: 0x04000AD7 RID: 2775
	[SerializeField]
	protected Transform _avatarAnchor;

	// Token: 0x04000AD8 RID: 2776
	[SerializeField]
	protected int _guiWidth = -1;

	// Token: 0x04000AD9 RID: 2777
	[SerializeField]
	private bool _haveMouseOrbitCamera;
}
