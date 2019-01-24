using System;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x02000247 RID: 583
public class FunctionalItem : IUnityItem
{
	// Token: 0x06001014 RID: 4116 RVA: 0x0000B452 File Offset: 0x00009652
	public FunctionalItem(BaseUberStrikeItemView view)
	{
		this.View = view;
		this._icon = UnityItemConfiguration.Instance.GetFunctionalItemIcon(view.ID);
	}

	// Token: 0x170003D2 RID: 978
	// (get) Token: 0x06001015 RID: 4117 RVA: 0x00003C84 File Offset: 0x00001E84
	public bool Equippable
	{
		get
		{
			return false;
		}
	}

	// Token: 0x170003D3 RID: 979
	// (get) Token: 0x06001016 RID: 4118 RVA: 0x0000B477 File Offset: 0x00009677
	// (set) Token: 0x06001017 RID: 4119 RVA: 0x0000B484 File Offset: 0x00009684
	public string Name
	{
		get
		{
			return this.View.Name;
		}
		set
		{
			this.View.Name = value;
		}
	}

	// Token: 0x170003D4 RID: 980
	// (get) Token: 0x06001018 RID: 4120 RVA: 0x0000B492 File Offset: 0x00009692
	public UberstrikeItemClass ItemClass
	{
		get
		{
			return this.View.ItemClass;
		}
	}

	// Token: 0x170003D5 RID: 981
	// (get) Token: 0x06001019 RID: 4121 RVA: 0x0000A4D5 File Offset: 0x000086D5
	public string PrefabName
	{
		get
		{
			return string.Empty;
		}
	}

	// Token: 0x170003D6 RID: 982
	// (get) Token: 0x0600101A RID: 4122 RVA: 0x00004D4D File Offset: 0x00002F4D
	public bool IsLoaded
	{
		get
		{
			return true;
		}
	}

	// Token: 0x170003D7 RID: 983
	// (get) Token: 0x0600101B RID: 4123 RVA: 0x0000A4BA File Offset: 0x000086BA
	public GameObject Prefab
	{
		get
		{
			return null;
		}
	}

	// Token: 0x170003D8 RID: 984
	// (get) Token: 0x0600101C RID: 4124 RVA: 0x0000B49F File Offset: 0x0000969F
	// (set) Token: 0x0600101D RID: 4125 RVA: 0x0000B4A7 File Offset: 0x000096A7
	public BaseUberStrikeItemView View { get; private set; }

	// Token: 0x0600101E RID: 4126 RVA: 0x00003C87 File Offset: 0x00001E87
	public void Unload()
	{
	}

	// Token: 0x0600101F RID: 4127 RVA: 0x0000A4BA File Offset: 0x000086BA
	public GameObject Create(Vector3 position, Quaternion rotation)
	{
		return null;
	}

	// Token: 0x06001020 RID: 4128 RVA: 0x00065C60 File Offset: 0x00063E60
	public void DrawIcon(Rect position)
	{
		if (this._icon != null)
		{
			GUI.DrawTexture(position, this._icon);
		}
		else
		{
			Debug.LogError(string.Concat(new object[]
			{
				"Can't find icon for item:",
				this.View.ID,
				", ",
				this.View.Name
			}));
		}
	}

	// Token: 0x04000DEB RID: 3563
	private Texture2D _icon;
}
