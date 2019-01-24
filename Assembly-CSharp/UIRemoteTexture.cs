using System;
using UnityEngine;

// Token: 0x02000358 RID: 856
[AddComponentMenu("NGUI/CMune Extensions/Texture Remote")]
[ExecuteInEditMode]
public class UIRemoteTexture : MonoBehaviour
{
	// Token: 0x1700056D RID: 1389
	// (get) Token: 0x060017C3 RID: 6083 RVA: 0x00010020 File Offset: 0x0000E220
	// (set) Token: 0x060017C4 RID: 6084 RVA: 0x00010028 File Offset: 0x0000E228
	public string Url
	{
		get
		{
			return this.url;
		}
		set
		{
			if (this.url == value)
			{
				return;
			}
			this.url = value;
			if (!string.IsNullOrEmpty(this.url))
			{
				this.State = UIRemoteTexture.DownloadState.Downloading;
			}
		}
	}

	// Token: 0x060017C5 RID: 6085 RVA: 0x0001005A File Offset: 0x0000E25A
	public void ShowDefault()
	{
		this.State = UIRemoteTexture.DownloadState.Error;
	}

	// Token: 0x060017C6 RID: 6086 RVA: 0x00080CA4 File Offset: 0x0007EEA4
	private void Start()
	{
		if (this.uiTexture == null)
		{
			this.uiTexture = new GameObject("LoadedTexture")
			{
				layer = base.gameObject.layer,
				transform = 
				{
					parent = base.transform,
					localPosition = Vector3.zero,
					localScale = Vector3.zero,
					localRotation = Quaternion.identity
				}
			}.AddComponent<UITexture>();
			this.uiTexture.depth = 0;
			this.uiTexture.enabled = false;
		}
		if (this.loadingSpinning == null)
		{
			this.loadingSpinning = new GameObject("LoadingSpinning")
			{
				layer = base.gameObject.layer,
				transform = 
				{
					parent = base.transform,
					localPosition = Vector3.zero,
					localScale = Vector3.zero,
					localRotation = Quaternion.identity
				}
			}.AddComponent<UISprite>();
			this.loadingSpinning.depth = 2;
		}
		if (this.defaultImage == null)
		{
			this.defaultImage = new GameObject("DefaultImage")
			{
				layer = base.gameObject.layer,
				transform = 
				{
					parent = base.transform,
					localPosition = Vector3.zero,
					localScale = Vector3.zero,
					localRotation = Quaternion.identity
				}
			}.AddComponent<UISprite>();
			this.defaultImage.depth = 1;
		}
		if (!string.IsNullOrEmpty(this.url) && this.uiTexture.mainTexture == null)
		{
			this.State = ((!Application.isPlaying) ? UIRemoteTexture.DownloadState.None : UIRemoteTexture.DownloadState.Downloading);
		}
	}

	// Token: 0x1700056E RID: 1390
	// (get) Token: 0x060017C7 RID: 6087 RVA: 0x00010063 File Offset: 0x0000E263
	// (set) Token: 0x060017C8 RID: 6088 RVA: 0x00080E8C File Offset: 0x0007F08C
	private UIRemoteTexture.DownloadState State
	{
		get
		{
			return this._state;
		}
		set
		{
			this._state = value;
			this.TryEnableAndSetScale(this.uiTexture, value == UIRemoteTexture.DownloadState.Downloaded);
			this.TryEnableAndSetScale(this.loadingSpinning, value == UIRemoteTexture.DownloadState.None || value == UIRemoteTexture.DownloadState.Downloading);
			this.TryEnableAndSetScale(this.defaultImage, value == UIRemoteTexture.DownloadState.None || value == UIRemoteTexture.DownloadState.Downloading || value == UIRemoteTexture.DownloadState.Error);
		}
	}

	// Token: 0x060017C9 RID: 6089 RVA: 0x00080EEC File Offset: 0x0007F0EC
	private void TryEnableAndSetScale(UITexture texture, bool enabled)
	{
		if (texture == null)
		{
			return;
		}
		texture.enabled = enabled;
		if (enabled && texture.transform.localScale == Vector3.zero && texture.mainTexture != null)
		{
			texture.transform.localScale = new Vector3((float)texture.mainTexture.width, (float)texture.mainTexture.height, 1f);
		}
	}

	// Token: 0x060017CA RID: 6090 RVA: 0x00080F6C File Offset: 0x0007F16C
	private void TryEnableAndSetScale(UISprite sprite, bool enabled)
	{
		if (sprite == null)
		{
			return;
		}
		sprite.enabled = enabled;
		if (enabled)
		{
			UIAtlas.Sprite atlasSprite = sprite.GetAtlasSprite();
			if (sprite.transform.localScale == Vector3.zero && atlasSprite != null)
			{
				sprite.transform.localScale = new Vector3(atlasSprite.outer.width, atlasSprite.outer.height, 1f);
			}
		}
	}

	// Token: 0x060017CB RID: 6091 RVA: 0x00080FE8 File Offset: 0x0007F1E8
	private void Update()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		if (this.State == UIRemoteTexture.DownloadState.Downloading)
		{
			if (this.loadingSpinning != null && this.loadingSpinning.enabled)
			{
				this.loadingSpinning.transform.localRotation = Quaternion.Euler(0f, 0f, -Time.time * this.rotationSpeed + Time.time * this.rotationSpeed % 30f);
			}
			TextureLoader.Holder holder = AutoMonoBehaviour<TextureLoader>.Instance.Load(this.url, null);
			if (holder.State != TextureLoader.State.Downloading)
			{
				if (holder.State == TextureLoader.State.Ok)
				{
					this.uiTexture.mainTexture = holder.Texture;
					this.State = UIRemoteTexture.DownloadState.Downloaded;
				}
				else
				{
					this.State = UIRemoteTexture.DownloadState.Error;
				}
			}
		}
	}

	// Token: 0x040016A4 RID: 5796
	[SerializeField]
	private string url;

	// Token: 0x040016A5 RID: 5797
	[SerializeField]
	private UITexture uiTexture;

	// Token: 0x040016A6 RID: 5798
	[SerializeField]
	private UISprite loadingSpinning;

	// Token: 0x040016A7 RID: 5799
	[SerializeField]
	private UISprite defaultImage;

	// Token: 0x040016A8 RID: 5800
	private float rotationSpeed = 300f;

	// Token: 0x040016A9 RID: 5801
	private UIRemoteTexture.DownloadState _state;

	// Token: 0x02000359 RID: 857
	private enum DownloadState
	{
		// Token: 0x040016AB RID: 5803
		None,
		// Token: 0x040016AC RID: 5804
		Downloading,
		// Token: 0x040016AD RID: 5805
		Downloaded,
		// Token: 0x040016AE RID: 5806
		Error
	}
}
