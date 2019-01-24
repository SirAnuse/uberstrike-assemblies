using System;
using UnityEngine;

// Token: 0x0200029E RID: 670
public static class AvatarBuilder
{
	// Token: 0x0600127C RID: 4732 RVA: 0x0006E2F8 File Offset: 0x0006C4F8
	public static void Destroy(GameObject obj)
	{
		Renderer[] componentsInChildren = obj.GetComponentsInChildren<Renderer>();
		foreach (Renderer renderer in componentsInChildren)
		{
			foreach (Material obj2 in renderer.materials)
			{
				UnityEngine.Object.Destroy(obj2);
			}
		}
		SkinnedMeshRenderer componentInChildren = obj.GetComponentInChildren<SkinnedMeshRenderer>();
		if (componentInChildren)
		{
			UnityEngine.Object.Destroy(componentInChildren.sharedMesh);
		}
		UnityEngine.Object.Destroy(obj);
	}

	// Token: 0x0600127D RID: 4733 RVA: 0x0006E37C File Offset: 0x0006C57C
	public static AvatarDecorator CreateLocalAvatar()
	{
		AvatarDecorator avatarDecorator = global::AvatarBuilder.CreateAvatarMesh(Singleton<LoadoutManager>.Instance.Loadout.GetAvatarGear());
		UnityEngine.Object.DontDestroyOnLoad(avatarDecorator.gameObject);
		global::AvatarBuilder.SetupLocalAvatar(avatarDecorator);
		return avatarDecorator;
	}

	// Token: 0x0600127E RID: 4734 RVA: 0x0006E3B0 File Offset: 0x0006C5B0
	public static void UpdateLocalAvatar(AvatarGearParts gear)
	{
		if (GameState.Current.Avatar.Decorator.name != gear.Base.name)
		{
			AvatarDecorator decorator = GameState.Current.Avatar.Decorator;
			AvatarDecorator avatarDecorator = global::AvatarBuilder.CreateAvatarMesh(gear);
			UnityEngine.Object.DontDestroyOnLoad(avatarDecorator.gameObject);
			avatarDecorator.transform.ShareParent(decorator.transform);
			avatarDecorator.gameObject.SetActive(decorator.gameObject.activeSelf);
			global::AvatarBuilder.ReparentChildren(decorator.WeaponAttachPoint, avatarDecorator.WeaponAttachPoint);
			UnityEngine.Object.Destroy(decorator.gameObject);
			GameState.Current.Avatar.SetDecorator(avatarDecorator);
			global::AvatarBuilder.SetupLocalAvatar(GameState.Current.Avatar.Decorator);
		}
		else if (GameState.Current.Avatar.Decorator)
		{
			global::AvatarBuilder.UpdateAvatarMesh(GameState.Current.Avatar.Decorator, gear);
			global::AvatarBuilder.SetupLocalAvatar(GameState.Current.Avatar.Decorator);
		}
		else
		{
			Debug.LogError("No local Player created yet! Call 'CreateLocalPlayerAvatar' first!");
		}
	}

	// Token: 0x0600127F RID: 4735 RVA: 0x0006E4C8 File Offset: 0x0006C6C8
	private static void ReparentChildren(Transform oldParent, Transform newParent)
	{
		while (oldParent.childCount > 0)
		{
			Transform child = oldParent.GetChild(0);
			child.Reparent(newParent);
		}
	}

	// Token: 0x06001280 RID: 4736 RVA: 0x0006E4F8 File Offset: 0x0006C6F8
	public static AvatarDecorator CreateRemoteAvatar(AvatarGearParts gear, Color skinColor)
	{
		AvatarDecorator avatarDecorator = global::AvatarBuilder.CreateAvatarMesh(gear);
		global::AvatarBuilder.SetupRemoteAvatar(avatarDecorator, skinColor);
		return avatarDecorator;
	}

	// Token: 0x06001281 RID: 4737 RVA: 0x0006E514 File Offset: 0x0006C714
	public static AvatarDecorator UpdateRemoteAvatar(AvatarDecorator avatar, AvatarGearParts gear, Color skinColor)
	{
		if (avatar.name != gear.Base.name)
		{
			AvatarDecorator avatarDecorator = avatar;
			avatar = global::AvatarBuilder.CreateAvatarMesh(gear);
			avatar.transform.ShareParent(avatarDecorator.transform);
			avatar.gameObject.SetActive(avatarDecorator.gameObject.activeSelf);
			global::AvatarBuilder.ReparentChildren(avatarDecorator.WeaponAttachPoint, avatar.WeaponAttachPoint);
			UnityEngine.Object.Destroy(avatarDecorator.gameObject);
			global::AvatarBuilder.SetupRemoteAvatar(avatar, skinColor);
		}
		else
		{
			global::AvatarBuilder.UpdateAvatarMesh(avatar, gear);
			global::AvatarBuilder.SetupRemoteAvatar(avatar, skinColor);
		}
		return avatar;
	}

	// Token: 0x06001282 RID: 4738 RVA: 0x0006E5A4 File Offset: 0x0006C7A4
	public static AvatarDecoratorConfig InstantiateRagdoll(AvatarGearParts gear, Color skinColor)
	{
		SkinnedMeshCombiner.Combine(gear.Base, gear.Parts);
		LayerUtil.SetLayerRecursively(gear.Base.transform, UberstrikeLayer.Ragdoll);
		gear.Base.GetComponent<SkinnedMeshRenderer>().updateWhenOffscreen = true;
		AvatarDecoratorConfig component = gear.Base.GetComponent<AvatarDecoratorConfig>();
		component.SetSkinColor(skinColor);
		return component;
	}

	// Token: 0x06001283 RID: 4739 RVA: 0x0006E5FC File Offset: 0x0006C7FC
	private static void UpdateAvatarMesh(AvatarDecorator avatar, AvatarGearParts gear)
	{
		if (!avatar)
		{
			Debug.LogError("AvatarDecorator is null!");
			return;
		}
		gear.Parts.Add(gear.Base);
		foreach (ParticleSystem particleSystem in avatar.GetComponentsInChildren<ParticleSystem>(true))
		{
			UnityEngine.Object.Destroy(particleSystem.gameObject);
		}
		SkinnedMeshCombiner.Update(avatar.gameObject, gear.Parts);
		avatar.renderer.receiveShadows = false;
		gear.Parts.ForEach(delegate(GameObject obj)
		{
			UnityEngine.Object.Destroy(obj);
		});
	}

	// Token: 0x06001284 RID: 4740 RVA: 0x0006E6A0 File Offset: 0x0006C8A0
	private static AvatarDecorator CreateAvatarMesh(AvatarGearParts gear)
	{
		SkinnedMeshCombiner.Combine(gear.Base, gear.Parts);
		gear.Parts.ForEach(delegate(GameObject obj)
		{
			UnityEngine.Object.Destroy(obj);
		});
		return gear.Base.GetComponent<AvatarDecorator>();
	}

	// Token: 0x06001285 RID: 4741 RVA: 0x0006E6F4 File Offset: 0x0006C8F4
	private static void SetupLocalAvatar(AvatarDecorator avatar)
	{
		if (avatar)
		{
			avatar.SetLayers(UberstrikeLayer.RemotePlayer);
			avatar.Configuration.SetSkinColor(PlayerDataManager.SkinColor);
			avatar.HudInformation.SetAvatarLabel(PlayerDataManager.NameAndTag);
		}
		else
		{
			Debug.LogError("No AvatarDecorator to setup!");
		}
	}

	// Token: 0x06001286 RID: 4742 RVA: 0x0000CBC0 File Offset: 0x0000ADC0
	private static void SetupRemoteAvatar(AvatarDecorator avatar, Color skinColor)
	{
		if (avatar)
		{
			avatar.SetLayers(UberstrikeLayer.RemotePlayer);
			avatar.Configuration.SetSkinColor(skinColor);
		}
		else
		{
			Debug.LogError("No AvatarDecorator to setup!");
		}
	}
}
