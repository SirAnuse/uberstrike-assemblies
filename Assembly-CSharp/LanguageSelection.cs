using System;
using UnityEngine;

// Token: 0x02000008 RID: 8
[AddComponentMenu("NGUI/Interaction/Language Selection")]
[RequireComponent(typeof(UIPopupList))]
public class LanguageSelection : MonoBehaviour
{
	// Token: 0x06000025 RID: 37 RVA: 0x0000221A File Offset: 0x0000041A
	private void Start()
	{
		this.mList = base.GetComponent<UIPopupList>();
		this.UpdateList();
		this.mList.eventReceiver = base.gameObject;
		this.mList.functionName = "OnLanguageSelection";
	}

	// Token: 0x06000026 RID: 38 RVA: 0x00015FEC File Offset: 0x000141EC
	private void UpdateList()
	{
		if (Localization.instance != null && Localization.instance.languages != null)
		{
			this.mList.items.Clear();
			int i = 0;
			int num = Localization.instance.languages.Length;
			while (i < num)
			{
				TextAsset textAsset = Localization.instance.languages[i];
				if (textAsset != null)
				{
					this.mList.items.Add(textAsset.name);
				}
				i++;
			}
			this.mList.selection = Localization.instance.currentLanguage;
		}
	}

	// Token: 0x06000027 RID: 39 RVA: 0x0000224F File Offset: 0x0000044F
	private void OnLanguageSelection(string language)
	{
		if (Localization.instance != null)
		{
			Localization.instance.currentLanguage = language;
		}
	}

	// Token: 0x04000037 RID: 55
	private UIPopupList mList;
}
