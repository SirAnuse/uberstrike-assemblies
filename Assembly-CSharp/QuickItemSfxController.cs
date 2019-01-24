using System;
using System.Collections.Generic;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x0200025B RID: 603
public class QuickItemSfxController : Singleton<QuickItemSfxController>
{
	// Token: 0x060010AF RID: 4271 RVA: 0x0000B9F0 File Offset: 0x00009BF0
	private QuickItemSfxController()
	{
		this._effects = new Dictionary<QuickItemLogic, QuickItemSfx>();
		this._curShownEffects = new Dictionary<int, QuickItemSfx>();
	}

	// Token: 0x1700040B RID: 1035
	// (get) Token: 0x060010B0 RID: 4272 RVA: 0x00066E28 File Offset: 0x00065028
	private int NextSfxId
	{
		get
		{
			return ++this._sfxId;
		}
	}

	// Token: 0x060010B1 RID: 4273 RVA: 0x0000BA0E File Offset: 0x00009C0E
	public void RegisterQuickItemEffect(QuickItemLogic behaviour, QuickItemSfx effect)
	{
		if (effect)
		{
			this._effects[behaviour] = effect;
		}
		else
		{
			Debug.LogError("QuickItemSfx is null: " + behaviour);
		}
	}

	// Token: 0x060010B2 RID: 4274 RVA: 0x00066E48 File Offset: 0x00065048
	public void ShowThirdPersonEffect(CharacterConfig player, QuickItemLogic effectType, int robotLifeTime, int scrapsLifeTime, bool isInstant = false)
	{
		robotLifeTime = ((robotLifeTime <= 0) ? 5000 : robotLifeTime);
		scrapsLifeTime = ((scrapsLifeTime <= 0) ? 3000 : scrapsLifeTime);
		QuickItemSfx original;
		if (this._effects.TryGetValue(effectType, out original))
		{
			QuickItemSfx quickItemSfx = UnityEngine.Object.Instantiate(original) as QuickItemSfx;
			quickItemSfx.ID = this.NextSfxId;
			if (quickItemSfx)
			{
				this._curShownEffects.Add(quickItemSfx.ID, quickItemSfx);
				quickItemSfx.transform.parent = player.transform;
				quickItemSfx.transform.localRotation = Quaternion.AngleAxis(-45f, Vector3.up);
				quickItemSfx.transform.localPosition = new Vector3(0f, 0.2f, 0f);
				quickItemSfx.Play(robotLifeTime, scrapsLifeTime, isInstant);
				LayerUtil.SetLayerRecursively(quickItemSfx.transform, UberstrikeLayer.IgnoreRaycast);
			}
		}
		else
		{
			Debug.LogError("Failed to get effect: " + effectType);
		}
	}

	// Token: 0x060010B3 RID: 4275 RVA: 0x00066F44 File Offset: 0x00065144
	public void RemoveEffect(int id)
	{
		QuickItemSfx quickItemSfx;
		if (this._curShownEffects.TryGetValue(id, out quickItemSfx))
		{
			this._curShownEffects.Remove(id);
		}
	}

	// Token: 0x060010B4 RID: 4276 RVA: 0x00066F74 File Offset: 0x00065174
	public void DestroytSfxFromPlayer(byte playerNumber)
	{
		foreach (KeyValuePair<int, QuickItemSfx> keyValuePair in this._curShownEffects)
		{
			if ((keyValuePair.Key & 255) == (int)playerNumber)
			{
				keyValuePair.Value.Destroy();
				this._curShownEffects.Remove(keyValuePair.Key);
				break;
			}
		}
	}

	// Token: 0x060010B5 RID: 4277 RVA: 0x0000B667 File Offset: 0x00009867
	private static int CreateGlobalSfxID(byte playerNumber, int sfxId)
	{
		return (sfxId << 8) + (int)playerNumber;
	}

	// Token: 0x04000E23 RID: 3619
	private Dictionary<QuickItemLogic, QuickItemSfx> _effects;

	// Token: 0x04000E24 RID: 3620
	private Dictionary<int, QuickItemSfx> _curShownEffects;

	// Token: 0x04000E25 RID: 3621
	private int _sfxId;
}
