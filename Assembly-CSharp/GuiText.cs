using System;
using UnityEngine;

// Token: 0x02000153 RID: 339
public class GuiText : MonoBehaviour
{
	// Token: 0x06000904 RID: 2308 RVA: 0x00007A5A File Offset: 0x00005C5A
	private void Awake()
	{
		this._transform = base.transform;
	}

	// Token: 0x06000905 RID: 2309 RVA: 0x00039748 File Offset: 0x00037948
	private void Start()
	{
		this._guiText = (base.gameObject.AddComponent(typeof(GUIText)) as GUIText);
		this._guiText.alignment = TextAlignment.Center;
		this._guiText.anchor = TextAnchor.MiddleCenter;
		this._guiText.font = this._font;
		this._guiText.text = this._text;
		this._guiText.material = this._font.material;
		this._material = this._guiText.material;
	}

	// Token: 0x06000906 RID: 2310 RVA: 0x000397D8 File Offset: 0x000379D8
	private void LateUpdate()
	{
		if (Camera.main != null && this._isVisible)
		{
			Vector3 position = Camera.main.WorldToViewportPoint(this._target.localPosition + this._offset);
			this._transform.position = position;
			if (this._hasTimeLimit)
			{
				this._visibleTime -= Time.deltaTime;
				if (this._visibleTime > 0f)
				{
					this._color.a = this._visibleTime;
					this._material.color = this._color;
				}
				else
				{
					this._guiText.enabled = false;
				}
			}
			else
			{
				if (this._distanceCap > 0f)
				{
					float a = 1f - Mathf.Clamp01(position.z / this._distanceCap);
					this._color.a = a;
				}
				this._material.color = this._color;
			}
		}
	}

	// Token: 0x06000907 RID: 2311 RVA: 0x00007A68 File Offset: 0x00005C68
	public void ShowText(int seconds)
	{
		this._visibleTime = (float)seconds;
	}

	// Token: 0x06000908 RID: 2312 RVA: 0x00007A72 File Offset: 0x00005C72
	public void ShowText()
	{
		this.ShowText(5);
	}

	// Token: 0x1700028B RID: 651
	// (get) Token: 0x06000909 RID: 2313 RVA: 0x00007A7B File Offset: 0x00005C7B
	// (set) Token: 0x0600090A RID: 2314 RVA: 0x00007A83 File Offset: 0x00005C83
	public bool IsTextVisible
	{
		get
		{
			return this._isVisible;
		}
		set
		{
			if (this._isVisible != value)
			{
				this._isVisible = value;
				this._guiText.enabled = value;
			}
		}
	}

	// Token: 0x04000936 RID: 2358
	[SerializeField]
	private Font _font;

	// Token: 0x04000937 RID: 2359
	[SerializeField]
	private string _text;

	// Token: 0x04000938 RID: 2360
	[SerializeField]
	private Color _color;

	// Token: 0x04000939 RID: 2361
	[SerializeField]
	private Vector3 _offset;

	// Token: 0x0400093A RID: 2362
	[SerializeField]
	private Transform _target;

	// Token: 0x0400093B RID: 2363
	[SerializeField]
	private bool _hasTimeLimit;

	// Token: 0x0400093C RID: 2364
	[SerializeField]
	private float _distanceCap = -1f;

	// Token: 0x0400093D RID: 2365
	private GUIText _guiText;

	// Token: 0x0400093E RID: 2366
	private Transform _transform;

	// Token: 0x0400093F RID: 2367
	private Material _material;

	// Token: 0x04000940 RID: 2368
	private float _visibleTime;

	// Token: 0x04000941 RID: 2369
	private bool _isVisible = true;
}
