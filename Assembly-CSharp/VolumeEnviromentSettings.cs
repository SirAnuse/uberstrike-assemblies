using System;
using UnityEngine;

// Token: 0x02000290 RID: 656
[RequireComponent(typeof(Collider))]
public class VolumeEnviromentSettings : MonoBehaviour
{
	// Token: 0x06001217 RID: 4631 RVA: 0x00005101 File Offset: 0x00003301
	private void Awake()
	{
		base.collider.isTrigger = true;
	}

	// Token: 0x06001218 RID: 4632 RVA: 0x0006ABC0 File Offset: 0x00068DC0
	private void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Player")
		{
			GameState.Current.Player.MoveController.SetEnviroment(this.Settings, base.collider.bounds);
			if (this.Settings.Type == EnviromentSettings.TYPE.WATER)
			{
				float y = GameState.Current.Player.MoveController.Velocity.y;
				if (y < -20f)
				{
					AutoMonoBehaviour<SfxManager>.Instance.Play3dAudioClip(GameAudio.BigSplash, collider.transform.position, 1f);
				}
				else if (y < -10f)
				{
					AutoMonoBehaviour<SfxManager>.Instance.Play3dAudioClip(GameAudio.MediumSplash, collider.transform.position, 1f);
				}
			}
		}
	}

	// Token: 0x06001219 RID: 4633 RVA: 0x0000C832 File Offset: 0x0000AA32
	private void OnTriggerExit(Collider c)
	{
		if (c.tag == "Player")
		{
			GameState.Current.Player.MoveController.ResetEnviroment();
		}
	}

	// Token: 0x04000EFB RID: 3835
	public EnviromentSettings Settings;
}
