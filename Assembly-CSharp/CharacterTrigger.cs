using System;
using UnityEngine;

// Token: 0x02000368 RID: 872
[RequireComponent(typeof(Collider))]
public class CharacterTrigger : MonoBehaviour
{
	// Token: 0x170005A1 RID: 1441
	// (get) Token: 0x06001873 RID: 6259 RVA: 0x00083520 File Offset: 0x00081720
	public AvatarHudInformation HudInfo
	{
		get
		{
			if (this._hud == null && this._config != null && this._config.Avatar != null)
			{
				return this._config.Avatar.Decorator.HudInformation;
			}
			return this._hud;
		}
	}

	// Token: 0x170005A2 RID: 1442
	// (get) Token: 0x06001874 RID: 6260 RVA: 0x000105C5 File Offset: 0x0000E7C5
	public CharacterConfig Character
	{
		get
		{
			return this._config;
		}
	}

	// Token: 0x04001707 RID: 5895
	[SerializeField]
	private AvatarHudInformation _hud;

	// Token: 0x04001708 RID: 5896
	[SerializeField]
	private CharacterConfig _config;
}
