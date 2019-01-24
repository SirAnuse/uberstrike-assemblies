using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002DD RID: 733
public class RagdollBuilder : Singleton<RagdollBuilder>
{
	// Token: 0x06001500 RID: 5376 RVA: 0x0000E187 File Offset: 0x0000C387
	private RagdollBuilder()
	{
	}

	// Token: 0x06001501 RID: 5377 RVA: 0x00076CB0 File Offset: 0x00074EB0
	public AvatarDecoratorConfig CreateRagdoll(Loadout gearLoadout)
	{
		IUnityItem holo;
		if (gearLoadout.TryGetItem(LoadoutSlotType.GearHolo, out holo))
		{
			return this.CreateHolo(holo);
		}
		return this.CreateLutzRavinoff(gearLoadout);
	}

	// Token: 0x06001502 RID: 5378 RVA: 0x00076CDC File Offset: 0x00074EDC
	private AvatarDecoratorConfig CreateLutzRavinoff(Loadout gearLoadout)
	{
		AvatarDecoratorConfig defaultRagdoll = PrefabManager.Instance.DefaultRagdoll;
		AvatarDecoratorConfig avatarDecoratorConfig = UnityEngine.Object.Instantiate(defaultRagdoll) as AvatarDecoratorConfig;
		List<GameObject> list = new List<GameObject>();
		SkinnedMeshCombiner.Combine(avatarDecoratorConfig.gameObject, list);
		foreach (GameObject obj in list)
		{
			UnityEngine.Object.Destroy(obj);
		}
		return avatarDecoratorConfig;
	}

	// Token: 0x06001503 RID: 5379 RVA: 0x00076D5C File Offset: 0x00074F5C
	private AvatarDecoratorConfig CreateHolo(IUnityItem holo)
	{
		AvatarDecoratorConfig avatarDecoratorConfig = null;
		GameObject gameObject = holo.Create(Vector3.zero, Quaternion.identity);
		HoloGearItem component = gameObject.GetComponent<HoloGearItem>();
		if (component && component.Configuration.Ragdoll)
		{
			avatarDecoratorConfig = (UnityEngine.Object.Instantiate(component.Configuration.Ragdoll) as AvatarDecoratorConfig);
			LayerUtil.SetLayerRecursively(avatarDecoratorConfig.transform, UberstrikeLayer.Ragdoll);
			SkinnedMeshCombiner.Combine(avatarDecoratorConfig.gameObject, new List<GameObject>());
		}
		UnityEngine.Object.Destroy(gameObject);
		return avatarDecoratorConfig;
	}
}
