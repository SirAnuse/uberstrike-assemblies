using System;
using System.Collections;
using System.Collections.Generic;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x02000361 RID: 865
public class AvatarDecoratorConfig : MonoBehaviour
{
	// Token: 0x06001823 RID: 6179 RVA: 0x00081DD4 File Offset: 0x0007FFD4
	private void Awake()
	{
		this._skinColor = Color.magenta;
		foreach (AvatarBone avatarBone in this._avatarBones)
		{
			avatarBone.Collider = avatarBone.Transform.GetComponent<Collider>();
			avatarBone.Rigidbody = avatarBone.Transform.GetComponent<Rigidbody>();
			avatarBone.OriginalPosition = avatarBone.Transform.localPosition;
			avatarBone.OriginalRotation = avatarBone.Transform.localRotation;
		}
	}

	// Token: 0x06001824 RID: 6180 RVA: 0x00081E50 File Offset: 0x00080050
	private void SetGravity(bool enabled)
	{
		foreach (AvatarBone avatarBone in this._avatarBones)
		{
			if (avatarBone != null && avatarBone.Rigidbody)
			{
				avatarBone.Rigidbody.useGravity = enabled;
			}
		}
	}

	// Token: 0x06001825 RID: 6181 RVA: 0x00081EA0 File Offset: 0x000800A0
	public void ApplyDamageToRagdoll(DamageInfo damageInfo)
	{
		GameObject gameObject = null;
		switch (damageInfo.BodyPart)
		{
		case BodyPart.Body:
			gameObject = this.GetBone(BoneIndex.Spine).gameObject;
			break;
		case BodyPart.Head:
			gameObject = this.GetBone(BoneIndex.Head).gameObject;
			break;
		case BodyPart.Nuts:
			gameObject = this.GetBone(BoneIndex.Hips).gameObject;
			break;
		}
		if (gameObject != null)
		{
			RagdollBodyPart component = gameObject.GetComponent<RagdollBodyPart>();
			if (component != null)
			{
				base.StartCoroutine(this.Die(component, damageInfo));
			}
			else
			{
				Debug.LogError(gameObject.name + " doesn't contain a RagdollBodyPart component.");
			}
		}
		else
		{
			Debug.LogError("Bone GameObject " + damageInfo.BodyPart + " was not found.");
		}
	}

	// Token: 0x06001826 RID: 6182 RVA: 0x00081F78 File Offset: 0x00080178
	private IEnumerator Die(RagdollBodyPart ragdollBodyPart, DamageInfo damageInfo)
	{
		this.SetGravity(false);
		if (damageInfo.IsExplosion)
		{
			damageInfo.Force *= (float)damageInfo.Damage;
			damageInfo.UpwardsForceMultiplier = 10f;
		}
		ragdollBodyPart.ApplyDamage(damageInfo);
		float bTime = 0f;
		while (bTime < this._hangTime)
		{
			bTime += Time.deltaTime;
			ragdollBodyPart.rigidbody.AddForce(Vector3.down * this._hangTimeDownwardForce);
			yield return new WaitForEndOfFrame();
		}
		this.SetGravity(true);
		yield break;
	}

	// Token: 0x06001827 RID: 6183 RVA: 0x0001037C File Offset: 0x0000E57C
	public Color GetSkinColor()
	{
		return this._skinColor;
	}

	// Token: 0x06001828 RID: 6184 RVA: 0x00081FB0 File Offset: 0x000801B0
	public void SetSkinColor(Color skinColor)
	{
		SkinnedMeshRenderer componentInChildren = base.GetComponentInChildren<SkinnedMeshRenderer>();
		if (componentInChildren != null)
		{
			this._skinColor = skinColor;
			foreach (Material material in componentInChildren.materials)
			{
				if (material.name.Contains("Skin"))
				{
					material.color = skinColor;
				}
			}
		}
	}

	// Token: 0x06001829 RID: 6185 RVA: 0x00082014 File Offset: 0x00080214
	public Transform GetBone(BoneIndex bone)
	{
		foreach (AvatarBone avatarBone in this._avatarBones)
		{
			if (avatarBone.Bone == bone)
			{
				return avatarBone.Transform;
			}
		}
		return base.transform;
	}

	// Token: 0x0600182A RID: 6186 RVA: 0x00010384 File Offset: 0x0000E584
	public void SetBones(List<AvatarBone> bones)
	{
		this._avatarBones = bones.ToArray();
	}

	// Token: 0x0600182B RID: 6187 RVA: 0x0008205C File Offset: 0x0008025C
	public static void CopyBones(AvatarDecoratorConfig srcAvatar, AvatarDecoratorConfig dstAvatar)
	{
		foreach (AvatarBone avatarBone in srcAvatar._avatarBones)
		{
			Transform bone = dstAvatar.GetBone(avatarBone.Bone);
			if (bone)
			{
				bone.position = avatarBone.Transform.position;
				bone.rotation = avatarBone.Transform.rotation;
			}
		}
	}

	// Token: 0x040016D8 RID: 5848
	[SerializeField]
	private AvatarBone[] _avatarBones;

	// Token: 0x040016D9 RID: 5849
	private Color _skinColor;

	// Token: 0x040016DA RID: 5850
	private float _hangTime = 0.5f;

	// Token: 0x040016DB RID: 5851
	private float _hangTimeDownwardForce = 4f;
}
