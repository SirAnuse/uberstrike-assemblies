using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000090 RID: 144
[RequireComponent(typeof(UISprite))]
[AddComponentMenu("NGUI/UI/Sprite Animation")]
[ExecuteInEditMode]
public class UISpriteAnimation : MonoBehaviour
{
	// Token: 0x170000BD RID: 189
	// (get) Token: 0x060003F0 RID: 1008 RVA: 0x00004EA7 File Offset: 0x000030A7
	public int frames
	{
		get
		{
			return this.mSpriteNames.Count;
		}
	}

	// Token: 0x170000BE RID: 190
	// (get) Token: 0x060003F1 RID: 1009 RVA: 0x00004EB4 File Offset: 0x000030B4
	// (set) Token: 0x060003F2 RID: 1010 RVA: 0x00004EBC File Offset: 0x000030BC
	public int framesPerSecond
	{
		get
		{
			return this.mFPS;
		}
		set
		{
			this.mFPS = value;
		}
	}

	// Token: 0x170000BF RID: 191
	// (get) Token: 0x060003F3 RID: 1011 RVA: 0x00004EC5 File Offset: 0x000030C5
	// (set) Token: 0x060003F4 RID: 1012 RVA: 0x00004ECD File Offset: 0x000030CD
	public string namePrefix
	{
		get
		{
			return this.mPrefix;
		}
		set
		{
			if (this.mPrefix != value)
			{
				this.mPrefix = value;
				this.RebuildSpriteList();
			}
		}
	}

	// Token: 0x170000C0 RID: 192
	// (get) Token: 0x060003F5 RID: 1013 RVA: 0x00004EED File Offset: 0x000030ED
	// (set) Token: 0x060003F6 RID: 1014 RVA: 0x00004EF5 File Offset: 0x000030F5
	public bool loop
	{
		get
		{
			return this.mLoop;
		}
		set
		{
			this.mLoop = value;
		}
	}

	// Token: 0x170000C1 RID: 193
	// (get) Token: 0x060003F7 RID: 1015 RVA: 0x00004EFE File Offset: 0x000030FE
	public bool isPlaying
	{
		get
		{
			return this.mActive;
		}
	}

	// Token: 0x060003F8 RID: 1016 RVA: 0x00004F06 File Offset: 0x00003106
	private void Start()
	{
		this.RebuildSpriteList();
	}

	// Token: 0x060003F9 RID: 1017 RVA: 0x0002BE38 File Offset: 0x0002A038
	private void Update()
	{
		if (this.mActive && this.mSpriteNames.Count > 1 && Application.isPlaying && (float)this.mFPS > 0f)
		{
			this.mDelta += Time.deltaTime;
			float num = 1f / (float)this.mFPS;
			if (num < this.mDelta)
			{
				this.mDelta = ((num <= 0f) ? 0f : (this.mDelta - num));
				if (++this.mIndex >= this.mSpriteNames.Count)
				{
					this.mIndex = 0;
					this.mActive = this.loop;
				}
				if (this.mActive)
				{
					this.mSprite.spriteName = this.mSpriteNames[this.mIndex];
					this.mSprite.MakePixelPerfect();
				}
			}
		}
	}

	// Token: 0x060003FA RID: 1018 RVA: 0x0002BF34 File Offset: 0x0002A134
	private void RebuildSpriteList()
	{
		if (this.mSprite == null)
		{
			this.mSprite = base.GetComponent<UISprite>();
		}
		this.mSpriteNames.Clear();
		if (this.mSprite != null && this.mSprite.atlas != null)
		{
			List<UIAtlas.Sprite> spriteList = this.mSprite.atlas.spriteList;
			int i = 0;
			int count = spriteList.Count;
			while (i < count)
			{
				UIAtlas.Sprite sprite = spriteList[i];
				if (string.IsNullOrEmpty(this.mPrefix) || sprite.name.StartsWith(this.mPrefix))
				{
					this.mSpriteNames.Add(sprite.name);
				}
				i++;
			}
			this.mSpriteNames.Sort();
		}
	}

	// Token: 0x060003FB RID: 1019 RVA: 0x0002C004 File Offset: 0x0002A204
	public void Reset()
	{
		this.mActive = true;
		this.mIndex = 0;
		if (this.mSprite != null && this.mSpriteNames.Count > 0)
		{
			this.mSprite.spriteName = this.mSpriteNames[this.mIndex];
			this.mSprite.MakePixelPerfect();
		}
	}

	// Token: 0x0400037C RID: 892
	[SerializeField]
	[HideInInspector]
	private int mFPS = 30;

	// Token: 0x0400037D RID: 893
	[SerializeField]
	[HideInInspector]
	private string mPrefix = string.Empty;

	// Token: 0x0400037E RID: 894
	[SerializeField]
	[HideInInspector]
	private bool mLoop = true;

	// Token: 0x0400037F RID: 895
	private UISprite mSprite;

	// Token: 0x04000380 RID: 896
	private float mDelta;

	// Token: 0x04000381 RID: 897
	private int mIndex;

	// Token: 0x04000382 RID: 898
	private bool mActive = true;

	// Token: 0x04000383 RID: 899
	private List<string> mSpriteNames = new List<string>();
}
