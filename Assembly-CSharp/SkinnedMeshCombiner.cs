using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020003FD RID: 1021
public class SkinnedMeshCombiner
{
	// Token: 0x06001D5D RID: 7517 RVA: 0x00092010 File Offset: 0x00090210
	public static void Combine(GameObject target, List<GameObject> objects)
	{
		if (target && objects != null)
		{
			SkinnedMeshCombiner.CopyComponents(target, objects);
			List<SkinnedMeshRenderer> list = new List<SkinnedMeshRenderer>();
			foreach (GameObject gameObject in objects)
			{
				if (gameObject != null)
				{
					list.AddRange(gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(true));
				}
			}
			SkinnedMeshCombiner.SuperCombineCreate(target, list);
		}
	}

	// Token: 0x06001D5E RID: 7518 RVA: 0x000920A0 File Offset: 0x000902A0
	public static void Update(GameObject target, List<GameObject> objects)
	{
		if (target && objects != null)
		{
			SkinnedMeshCombiner.CopyComponents(target, objects);
			List<SkinnedMeshRenderer> list = new List<SkinnedMeshRenderer>();
			foreach (GameObject gameObject in objects)
			{
				if (gameObject)
				{
					list.AddRange(gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(true));
				}
			}
			SkinnedMeshCombiner.SuperCombineUpdate(target, list);
		}
	}

	// Token: 0x06001D5F RID: 7519 RVA: 0x0009212C File Offset: 0x0009032C
	private static void CopyComponents(GameObject target, List<GameObject> objects)
	{
		HashSet<string> hashSet = new HashSet<string>(Enum.GetNames(typeof(BoneIndex)));
		foreach (GameObject gameObject in objects)
		{
			List<Component> list = new List<Component>(gameObject.GetComponentsInChildren<ParticleSystem>(true));
			list.AddRange(gameObject.GetComponentsInChildren<AudioSource>(true));
			foreach (Component component in list)
			{
				if (!(component.transform.parent == null))
				{
					string name = component.transform.parent.name;
					if (hashSet.Contains(name))
					{
						Transform transform = target.transform.FindChildWithName(name);
						if (transform != null)
						{
							component.transform.Reparent(transform);
						}
					}
				}
			}
		}
	}

	// Token: 0x06001D60 RID: 7520 RVA: 0x00092250 File Offset: 0x00090450
	private static GameObject SuperCombineCreate(GameObject sourceGameObject, List<SkinnedMeshRenderer> otherGear)
	{
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in otherGear)
		{
			if (skinnedMeshRenderer.sharedMesh == null)
			{
				Debug.LogError(skinnedMeshRenderer.name + "'s sharedMesh is null!");
			}
		}
		List<CombineInstance> list = new List<CombineInstance>();
		List<Material> list2 = new List<Material>();
		List<Transform> list3 = new List<Transform>();
		Dictionary<string, Transform> dictionary = new Dictionary<string, Transform>();
		foreach (Transform transform in sourceGameObject.GetComponentsInChildren<Transform>(true))
		{
			dictionary[transform.name] = transform.transform;
		}
		foreach (SkinnedMeshRenderer skinnedMeshRenderer2 in sourceGameObject.GetComponentsInChildren<SkinnedMeshRenderer>(true))
		{
			list2.AddRange(skinnedMeshRenderer2.sharedMaterials);
			for (int k = 0; k < skinnedMeshRenderer2.sharedMesh.subMeshCount; k++)
			{
				list.Add(new CombineInstance
				{
					mesh = skinnedMeshRenderer2.sharedMesh,
					subMeshIndex = k
				});
				list3.AddRange(skinnedMeshRenderer2.bones);
			}
			UnityEngine.Object.Destroy(skinnedMeshRenderer2);
		}
		if (otherGear != null && otherGear.Count > 0)
		{
			foreach (SkinnedMeshRenderer skinnedMeshRenderer3 in otherGear)
			{
				list2.AddRange(skinnedMeshRenderer3.sharedMaterials);
				if (!(skinnedMeshRenderer3.sharedMesh == null))
				{
					for (int l = 0; l < skinnedMeshRenderer3.sharedMesh.subMeshCount; l++)
					{
						list.Add(new CombineInstance
						{
							mesh = skinnedMeshRenderer3.sharedMesh,
							subMeshIndex = l
						});
						foreach (Transform transform2 in skinnedMeshRenderer3.bones)
						{
							if (dictionary.ContainsKey(transform2.name))
							{
								list3.Add(dictionary[transform2.name]);
							}
							else
							{
								Debug.LogError("Couldn't find a matching bone transform in the gameobject you're trying to add this skinned mesh to! " + transform2.name);
							}
						}
					}
				}
			}
		}
		SkinnedMeshRenderer skinnedMeshRenderer4 = sourceGameObject.AddComponent<SkinnedMeshRenderer>();
		if (skinnedMeshRenderer4.sharedMesh == null)
		{
			skinnedMeshRenderer4.sharedMesh = new Mesh();
		}
		skinnedMeshRenderer4.sharedMesh.Clear();
		skinnedMeshRenderer4.sharedMesh.name = "CombinedMesh";
		skinnedMeshRenderer4.sharedMesh.CombineMeshes(list.ToArray(), false, false);
		skinnedMeshRenderer4.bones = list3.ToArray();
		foreach (Material obj in skinnedMeshRenderer4.materials)
		{
			UnityEngine.Object.Destroy(obj);
		}
		skinnedMeshRenderer4.materials = list2.ToArray();
		Animation component = sourceGameObject.GetComponent<Animation>();
		if (component)
		{
			component.cullingType = AnimationCullingType.BasedOnClipBounds;
		}
		return sourceGameObject;
	}

	// Token: 0x06001D61 RID: 7521 RVA: 0x00092598 File Offset: 0x00090798
	private static GameObject SuperCombineUpdate(GameObject sourceGameObject, List<SkinnedMeshRenderer> otherGear)
	{
		List<CombineInstance> list = new List<CombineInstance>();
		List<Material> list2 = new List<Material>();
		List<Transform> list3 = new List<Transform>();
		Dictionary<string, Transform> dictionary = new Dictionary<string, Transform>();
		foreach (Transform transform in sourceGameObject.GetComponentsInChildren<Transform>(true))
		{
			dictionary[transform.name] = transform.transform;
		}
		if (otherGear != null && otherGear.Count > 0)
		{
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in otherGear)
			{
				list2.AddRange(skinnedMeshRenderer.sharedMaterials);
				if (skinnedMeshRenderer.sharedMesh == null)
				{
					Debug.Log("No shared mesh in " + skinnedMeshRenderer.name);
				}
				else
				{
					for (int j = 0; j < skinnedMeshRenderer.sharedMesh.subMeshCount; j++)
					{
						list.Add(new CombineInstance
						{
							mesh = skinnedMeshRenderer.sharedMesh,
							subMeshIndex = j
						});
						foreach (Transform transform2 in skinnedMeshRenderer.bones)
						{
							if (dictionary.ContainsKey(transform2.name))
							{
								Transform transform3 = dictionary[transform2.name];
								transform3.localPosition = transform2.localPosition;
								list3.Add(transform3);
							}
							else
							{
								Debug.LogError("I couldn't find a matching bone transform in the gameobject you're trying to add this skinned mesh to! " + transform2.name);
							}
						}
					}
				}
			}
		}
		else
		{
			Debug.LogError("Gear array contains no Skinned Meshes! Trying to go naked?");
		}
		SkinnedMeshRenderer component = sourceGameObject.GetComponent<SkinnedMeshRenderer>();
		if (component)
		{
			if (component.sharedMesh == null)
			{
				component.sharedMesh = new Mesh();
			}
			component.sharedMesh.Clear();
			component.sharedMesh.name = "CombinedMesh";
			component.sharedMesh.CombineMeshes(list.ToArray(), false, false);
			component.bones = list3.ToArray();
			foreach (Material obj in component.materials)
			{
				UnityEngine.Object.Destroy(obj);
			}
			component.materials = list2.ToArray();
		}
		else
		{
			Debug.LogError("There is no SkinnedMeshRenderer on " + sourceGameObject.name);
		}
		Animation component2 = sourceGameObject.GetComponent<Animation>();
		if (component2)
		{
			component2.cullingType = AnimationCullingType.AlwaysAnimate;
		}
		return sourceGameObject;
	}
}
