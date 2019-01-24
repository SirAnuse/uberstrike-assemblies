using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000424 RID: 1060
public sealed class MeleeWeaponDecorator : BaseWeaponDecorator
{
	// Token: 0x06001E3D RID: 7741 RVA: 0x00014143 File Offset: 0x00012343
	protected override void Awake()
	{
		base.Awake();
		base.IsMelee = true;
	}

	// Token: 0x06001E3E RID: 7742 RVA: 0x00094CE4 File Offset: 0x00092EE4
	public override void ShowShootEffect(RaycastHit[] hits)
	{
		base.ShowShootEffect(hits);
		if (base.EnableShootAnimation && this._animation && this._shootAnimClips.Length > 0)
		{
			int num = UnityEngine.Random.Range(0, this._shootAnimClips.Length);
			this._animation.clip = this._shootAnimClips[num];
			this._animation.Rewind();
			this._animation.Play();
		}
	}

	// Token: 0x06001E3F RID: 7743 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void PlayHitSound()
	{
	}

	// Token: 0x06001E40 RID: 7744 RVA: 0x00094D5C File Offset: 0x00092F5C
	public override void PlayEquipSound()
	{
		if (this._mainAudioSource && this._equipSound)
		{
			this._mainAudioSource.volume = ((!ApplicationDataManager.ApplicationOptions.AudioEnabled) ? 0f : ApplicationDataManager.ApplicationOptions.AudioEffectsVolume);
			this._mainAudioSource.PlayOneShot(this._equipSound);
		}
	}

	// Token: 0x06001E41 RID: 7745 RVA: 0x00094DC8 File Offset: 0x00092FC8
	protected override void EmitImpactSound(string impactType, Vector3 position)
	{
		if (this._impactSounds != null && this._impactSounds.Length > 0)
		{
			int num = UnityEngine.Random.Range(0, this._impactSounds.Length);
			AudioClip audioClip = this._impactSounds[num];
			if (audioClip)
			{
				AutoMonoBehaviour<SfxManager>.Instance.Play3dAudioClip(audioClip, position, 1f);
			}
			else
			{
				Debug.LogError("Missing impact sound for melee weapon!");
			}
		}
		else
		{
			Debug.LogError("Melee impact sound is not signed!");
		}
	}

	// Token: 0x06001E42 RID: 7746 RVA: 0x00014152 File Offset: 0x00012352
	protected override void ShowImpactEffects(RaycastHit hit, Vector3 direction, Vector3 muzzlePosition, float distance, bool playSound)
	{
		base.StartCoroutine(this.StartShowImpactEffects(hit, direction, muzzlePosition, distance, playSound));
	}

	// Token: 0x06001E43 RID: 7747 RVA: 0x00094E40 File Offset: 0x00093040
	private IEnumerator StartShowImpactEffects(RaycastHit hit, Vector3 direction, Vector3 muzzlePosition, float distance, bool playSound)
	{
		yield return new WaitForSeconds(0.2f);
		base.EmitImpactParticles(hit, direction, muzzlePosition, distance, playSound);
		yield break;
	}

	// Token: 0x04001A2E RID: 6702
	[SerializeField]
	private Animation _animation;

	// Token: 0x04001A2F RID: 6703
	[SerializeField]
	private AnimationClip[] _shootAnimClips;

	// Token: 0x04001A30 RID: 6704
	[SerializeField]
	private AudioClip[] _impactSounds;

	// Token: 0x04001A31 RID: 6705
	[SerializeField]
	private AudioClip _equipSound;
}
