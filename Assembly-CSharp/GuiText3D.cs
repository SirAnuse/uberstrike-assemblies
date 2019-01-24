using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000154 RID: 340
public class GuiText3D : MonoBehaviour
{
	// Token: 0x0600090C RID: 2316 RVA: 0x00007AA4 File Offset: 0x00005CA4
	private void Awake()
	{
		this._transform = base.transform;
	}

	// Token: 0x0600090D RID: 2317 RVA: 0x00039934 File Offset: 0x00037B34
	private void Start()
	{
		this._guiText = (base.gameObject.AddComponent(typeof(GUIText)) as GUIText);
		this._guiText.alignment = TextAlignment.Center;
		this._guiText.anchor = TextAnchor.MiddleCenter;
		if (this.mCamera == null || this.mTarget == null || this.mFont == null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		this._guiText.font = this.mFont;
		this._guiText.text = this.mText;
		this._guiText.material = this.mFont.material;
		this._material = this._guiText.material;
		this.startColor = this._material.color;
		this.finalColor = this._material.color;
		if (this.mFadeOut)
		{
			this.finalColor.a = 0f;
		}
	}

	// Token: 0x0600090E RID: 2318 RVA: 0x00039A40 File Offset: 0x00037C40
	private void LateUpdate()
	{
		if (this.mCamera != null && this.mTarget != null && (this.mLifeTime < 0f || this.mLifeTime > this.time))
		{
			this.time += Time.deltaTime;
			this._viewportPosition = this.mCamera.WorldToViewportPoint(this.mTarget.localPosition);
			if (this.mFadeOut && this.mLifeTime > 0f)
			{
				this._material.color = Color.Lerp(this.startColor, this.finalColor, this.time / this.mLifeTime);
			}
			else
			{
				float t = Mathf.Clamp01(this._viewportPosition.z / this.mMaxDistance);
				this._material.color = Color.Lerp(this.startColor, this.finalColor, t);
			}
			this.fadeDir += Time.deltaTime * this.mFadeDirection;
			this._transform.localPosition = this._viewportPosition + this.fadeDir;
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0600090F RID: 2319 RVA: 0x00039B8C File Offset: 0x00037D8C
	private IEnumerator startShowGuiText(float mLifeTime)
	{
		float time = 0f;
		Vector3 fadeDir = Vector3.zero;
		Color startColor = this._material.color;
		Color finalColor = this._material.color;
		if (this.mFadeOut)
		{
			finalColor.a = 0f;
		}
		while (this.mCamera != null && this.mTarget != null && (mLifeTime < 0f || mLifeTime > time))
		{
			time += Time.deltaTime;
			this._viewportPosition = this.mCamera.WorldToViewportPoint(this.mTarget.localPosition);
			if (this.mFadeOut && mLifeTime > 0f)
			{
				this._material.color = Color.Lerp(startColor, finalColor, time / mLifeTime);
			}
			else
			{
				float dist = Mathf.Clamp01(this._viewportPosition.z / this.mMaxDistance);
				this._material.color = Color.Lerp(startColor, finalColor, dist);
			}
			fadeDir += Time.deltaTime * this.mFadeDirection;
			this._transform.localPosition = this._viewportPosition + fadeDir;
			yield return new WaitForEndOfFrame();
		}
		UnityEngine.Object.Destroy(base.gameObject);
		yield break;
	}

	// Token: 0x04000942 RID: 2370
	public Font mFont;

	// Token: 0x04000943 RID: 2371
	public string mText;

	// Token: 0x04000944 RID: 2372
	public Camera mCamera;

	// Token: 0x04000945 RID: 2373
	public Transform mTarget;

	// Token: 0x04000946 RID: 2374
	public float mMaxDistance = 20f;

	// Token: 0x04000947 RID: 2375
	public float mLifeTime = 5f;

	// Token: 0x04000948 RID: 2376
	public Color mColor = Color.black;

	// Token: 0x04000949 RID: 2377
	public bool mFadeOut = true;

	// Token: 0x0400094A RID: 2378
	public Vector3 mFadeDirection = Vector2.up;

	// Token: 0x0400094B RID: 2379
	private GUIText _guiText;

	// Token: 0x0400094C RID: 2380
	private Transform _transform;

	// Token: 0x0400094D RID: 2381
	private Material _material;

	// Token: 0x0400094E RID: 2382
	private Vector3 _viewportPosition;

	// Token: 0x0400094F RID: 2383
	private float time;

	// Token: 0x04000950 RID: 2384
	private Vector3 fadeDir = Vector3.zero;

	// Token: 0x04000951 RID: 2385
	private Color startColor;

	// Token: 0x04000952 RID: 2386
	private Color finalColor;
}
