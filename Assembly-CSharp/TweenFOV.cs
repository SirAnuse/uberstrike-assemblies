using System;
using UnityEngine;

// Token: 0x02000064 RID: 100
[RequireComponent(typeof(Camera))]
[AddComponentMenu("NGUI/Tween/Field of View")]
public class TweenFOV : UITweener
{
	// Token: 0x17000058 RID: 88
	// (get) Token: 0x06000290 RID: 656 RVA: 0x00003E37 File Offset: 0x00002037
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

	// Token: 0x17000059 RID: 89
	// (get) Token: 0x06000291 RID: 657 RVA: 0x00003E5C File Offset: 0x0000205C
	// (set) Token: 0x06000292 RID: 658 RVA: 0x00003E69 File Offset: 0x00002069
	public float fov
	{
		get
		{
			return this.cachedCamera.fieldOfView;
		}
		set
		{
			this.cachedCamera.fieldOfView = value;
		}
	}

	// Token: 0x06000293 RID: 659 RVA: 0x00003E77 File Offset: 0x00002077
	protected override void OnUpdate(float factor, bool isFinished)
	{
		this.cachedCamera.fieldOfView = this.from * (1f - factor) + this.to * factor;
	}

	// Token: 0x06000294 RID: 660 RVA: 0x00021460 File Offset: 0x0001F660
	public static TweenFOV Begin(GameObject go, float duration, float to)
	{
		TweenFOV tweenFOV = UITweener.Begin<TweenFOV>(go, duration);
		tweenFOV.from = tweenFOV.fov;
		tweenFOV.to = to;
		if (duration <= 0f)
		{
			tweenFOV.Sample(1f, true);
			tweenFOV.enabled = false;
		}
		return tweenFOV;
	}

	// Token: 0x0400022F RID: 559
	public float from;

	// Token: 0x04000230 RID: 560
	public float to;

	// Token: 0x04000231 RID: 561
	private Camera mCam;
}
