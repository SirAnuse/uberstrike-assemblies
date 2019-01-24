using System;
using UnityEngine;

// Token: 0x02000065 RID: 101
[AddComponentMenu("NGUI/Tween/Orthographic Size")]
[RequireComponent(typeof(Camera))]
public class TweenOrthoSize : UITweener
{
	// Token: 0x1700005A RID: 90
	// (get) Token: 0x06000296 RID: 662 RVA: 0x00003E9B File Offset: 0x0000209B
	public Camera cachedCamera
	{
		get
		{
			if (this.mCam == null)
			{
				this.mCam = base.camera;
			}
			return this.mCam;
		}
	}

	// Token: 0x1700005B RID: 91
	// (get) Token: 0x06000297 RID: 663 RVA: 0x00003EC0 File Offset: 0x000020C0
	// (set) Token: 0x06000298 RID: 664 RVA: 0x00003ECD File Offset: 0x000020CD
	public float orthoSize
	{
		get
		{
			return this.cachedCamera.orthographicSize;
		}
		set
		{
			this.cachedCamera.orthographicSize = value;
		}
	}

	// Token: 0x06000299 RID: 665 RVA: 0x00003EDB File Offset: 0x000020DB
	protected override void OnUpdate(float factor, bool isFinished)
	{
		this.cachedCamera.orthographicSize = this.from * (1f - factor) + this.to * factor;
	}

	// Token: 0x0600029A RID: 666 RVA: 0x000214A8 File Offset: 0x0001F6A8
	public static TweenOrthoSize Begin(GameObject go, float duration, float to)
	{
		TweenOrthoSize tweenOrthoSize = UITweener.Begin<TweenOrthoSize>(go, duration);
		tweenOrthoSize.from = tweenOrthoSize.orthoSize;
		tweenOrthoSize.to = to;
		if (duration <= 0f)
		{
			tweenOrthoSize.Sample(1f, true);
			tweenOrthoSize.enabled = false;
		}
		return tweenOrthoSize;
	}

	// Token: 0x04000232 RID: 562
	public float from;

	// Token: 0x04000233 RID: 563
	public float to;

	// Token: 0x04000234 RID: 564
	private Camera mCam;
}
