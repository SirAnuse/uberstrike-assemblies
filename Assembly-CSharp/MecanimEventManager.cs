using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002F7 RID: 759
public static class MecanimEventManager
{
	// Token: 0x0600159A RID: 5530 RVA: 0x0000E759 File Offset: 0x0000C959
	public static void SetEventDataSource(MecanimEventData dataSource)
	{
		if (dataSource != null)
		{
			MecanimEventManager.eventDataSources = new MecanimEventData[1];
			MecanimEventManager.eventDataSources[0] = dataSource;
			MecanimEventManager.LoadDataInGame();
		}
	}

	// Token: 0x0600159B RID: 5531 RVA: 0x0000E77F File Offset: 0x0000C97F
	public static void SetEventDataSource(MecanimEventData[] dataSources)
	{
		if (dataSources != null)
		{
			MecanimEventManager.eventDataSources = dataSources;
			MecanimEventManager.LoadDataInGame();
		}
	}

	// Token: 0x0600159C RID: 5532 RVA: 0x0000E792 File Offset: 0x0000C992
	public static void OnLevelLoaded()
	{
		MecanimEventManager.lastStates.Clear();
	}

	// Token: 0x0600159D RID: 5533 RVA: 0x00078EA8 File Offset: 0x000770A8
	public static ICollection<MecanimEvent> GetEvents(int animatorControllerId, Animator animator)
	{
		List<MecanimEvent> list = new List<MecanimEvent>();
		int hashCode = animator.GetHashCode();
		if (!MecanimEventManager.lastStates.ContainsKey(hashCode))
		{
			MecanimEventManager.lastStates[hashCode] = new Dictionary<int, AnimatorStateInfo>();
		}
		int layerCount = animator.layerCount;
		Dictionary<int, AnimatorStateInfo> dictionary = MecanimEventManager.lastStates[hashCode];
		for (int i = 0; i < layerCount; i++)
		{
			if (!dictionary.ContainsKey(i))
			{
				dictionary[i] = default(AnimatorStateInfo);
			}
			AnimatorStateInfo animatorStateInfo = dictionary[i];
			AnimatorStateInfo currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(i);
			int num = (int)animatorStateInfo.normalizedTime;
			int num2 = (int)currentAnimatorStateInfo.normalizedTime;
			float normalizedTimeStart = animatorStateInfo.normalizedTime - (float)num;
			float normalizedTimeEnd = currentAnimatorStateInfo.normalizedTime - (float)num2;
			if (animatorStateInfo.nameHash == currentAnimatorStateInfo.nameHash)
			{
				if (currentAnimatorStateInfo.loop)
				{
					if (num == num2)
					{
						list.AddRange(MecanimEventManager.CollectEvents(animator, animatorControllerId, i, currentAnimatorStateInfo.nameHash, currentAnimatorStateInfo.tagHash, normalizedTimeStart, normalizedTimeEnd, false));
					}
					else
					{
						list.AddRange(MecanimEventManager.CollectEvents(animator, animatorControllerId, i, currentAnimatorStateInfo.nameHash, currentAnimatorStateInfo.tagHash, normalizedTimeStart, 1.00001f, false));
						list.AddRange(MecanimEventManager.CollectEvents(animator, animatorControllerId, i, currentAnimatorStateInfo.nameHash, currentAnimatorStateInfo.tagHash, 0f, normalizedTimeEnd, false));
					}
				}
				else
				{
					float num3 = Mathf.Clamp01(animatorStateInfo.normalizedTime);
					float num4 = Mathf.Clamp01(currentAnimatorStateInfo.normalizedTime);
					if (num == 0 && num2 == 0)
					{
						if (num3 != num4)
						{
							list.AddRange(MecanimEventManager.CollectEvents(animator, animatorControllerId, i, currentAnimatorStateInfo.nameHash, currentAnimatorStateInfo.tagHash, num3, num4, false));
						}
					}
					else if (num == 0 && num2 > 0)
					{
						list.AddRange(MecanimEventManager.CollectEvents(animator, animatorControllerId, i, animatorStateInfo.nameHash, animatorStateInfo.tagHash, num3, 1.00001f, false));
					}
				}
			}
			else
			{
				list.AddRange(MecanimEventManager.CollectEvents(animator, animatorControllerId, i, currentAnimatorStateInfo.nameHash, currentAnimatorStateInfo.tagHash, 0f, normalizedTimeEnd, false));
				if (!animatorStateInfo.loop)
				{
					list.AddRange(MecanimEventManager.CollectEvents(animator, animatorControllerId, i, animatorStateInfo.nameHash, animatorStateInfo.tagHash, normalizedTimeStart, 1.00001f, true));
				}
			}
			dictionary[i] = currentAnimatorStateInfo;
		}
		return list;
	}

	// Token: 0x0600159E RID: 5534 RVA: 0x00079104 File Offset: 0x00077304
	private static ICollection<MecanimEvent> CollectEvents(Animator animator, int animatorControllerId, int layer, int nameHash, int tagHash, float normalizedTimeStart, float normalizedTimeEnd, bool onlyCritical = false)
	{
		if (MecanimEventManager.loadedData.ContainsKey(animatorControllerId) && MecanimEventManager.loadedData[animatorControllerId].ContainsKey(layer) && MecanimEventManager.loadedData[animatorControllerId][layer].ContainsKey(nameHash))
		{
			List<MecanimEvent> list = MecanimEventManager.loadedData[animatorControllerId][layer][nameHash];
			List<MecanimEvent> list2 = new List<MecanimEvent>();
			foreach (MecanimEvent mecanimEvent in list)
			{
				if (mecanimEvent.normalizedTime >= normalizedTimeStart && mecanimEvent.normalizedTime < normalizedTimeEnd && mecanimEvent.condition.Test(animator))
				{
					if (!onlyCritical || mecanimEvent.critical)
					{
						MecanimEvent mecanimEvent2 = new MecanimEvent(mecanimEvent);
						mecanimEvent2.SetContext(new EventContext
						{
							controllerId = animatorControllerId,
							layer = layer,
							stateHash = nameHash,
							tagHash = tagHash
						});
						list2.Add(mecanimEvent2);
					}
				}
			}
			return list2;
		}
		return new MecanimEvent[0];
	}

	// Token: 0x0600159F RID: 5535 RVA: 0x00079244 File Offset: 0x00077444
	private static void LoadDataInGame()
	{
		if (MecanimEventManager.eventDataSources == null)
		{
			return;
		}
		MecanimEventManager.loadedData = new Dictionary<int, Dictionary<int, Dictionary<int, List<MecanimEvent>>>>();
		foreach (MecanimEventData mecanimEventData in MecanimEventManager.eventDataSources)
		{
			if (!(mecanimEventData == null))
			{
				MecanimEventDataEntry[] data = mecanimEventData.data;
				foreach (MecanimEventDataEntry mecanimEventDataEntry in data)
				{
					int instanceID = mecanimEventDataEntry.animatorController.GetInstanceID();
					if (!MecanimEventManager.loadedData.ContainsKey(instanceID))
					{
						MecanimEventManager.loadedData[instanceID] = new Dictionary<int, Dictionary<int, List<MecanimEvent>>>();
					}
					if (!MecanimEventManager.loadedData[instanceID].ContainsKey(mecanimEventDataEntry.layer))
					{
						MecanimEventManager.loadedData[instanceID][mecanimEventDataEntry.layer] = new Dictionary<int, List<MecanimEvent>>();
					}
					MecanimEventManager.loadedData[instanceID][mecanimEventDataEntry.layer][mecanimEventDataEntry.stateNameHash] = new List<MecanimEvent>(mecanimEventDataEntry.events);
				}
			}
		}
	}

	// Token: 0x04001453 RID: 5203
	private static MecanimEventData[] eventDataSources;

	// Token: 0x04001454 RID: 5204
	private static Dictionary<int, Dictionary<int, Dictionary<int, List<MecanimEvent>>>> loadedData;

	// Token: 0x04001455 RID: 5205
	private static Dictionary<int, Dictionary<int, AnimatorStateInfo>> lastStates = new Dictionary<int, Dictionary<int, AnimatorStateInfo>>();
}
