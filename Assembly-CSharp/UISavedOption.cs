using System;
using UnityEngine;

// Token: 0x02000030 RID: 48
[AddComponentMenu("NGUI/Interaction/Saved Option")]
public class UISavedOption : MonoBehaviour
{
	// Token: 0x17000013 RID: 19
	// (get) Token: 0x060000FB RID: 251 RVA: 0x00002E01 File Offset: 0x00001001
	private string key
	{
		get
		{
			return (!string.IsNullOrEmpty(this.keyName)) ? this.keyName : ("NGUI State: " + base.name);
		}
	}

	// Token: 0x060000FC RID: 252 RVA: 0x0001AB2C File Offset: 0x00018D2C
	private void Awake()
	{
		this.mList = base.GetComponent<UIPopupList>();
		this.mCheck = base.GetComponent<UICheckbox>();
		if (this.mList != null)
		{
			UIPopupList uipopupList = this.mList;
			uipopupList.onSelectionChange = (UIPopupList.OnSelectionChange)Delegate.Combine(uipopupList.onSelectionChange, new UIPopupList.OnSelectionChange(this.SaveSelection));
		}
		if (this.mCheck != null)
		{
			UICheckbox uicheckbox = this.mCheck;
			uicheckbox.onStateChange = (UICheckbox.OnStateChange)Delegate.Combine(uicheckbox.onStateChange, new UICheckbox.OnStateChange(this.SaveState));
		}
	}

	// Token: 0x060000FD RID: 253 RVA: 0x0001ABC4 File Offset: 0x00018DC4
	private void OnDestroy()
	{
		if (this.mCheck != null)
		{
			UICheckbox uicheckbox = this.mCheck;
			uicheckbox.onStateChange = (UICheckbox.OnStateChange)Delegate.Remove(uicheckbox.onStateChange, new UICheckbox.OnStateChange(this.SaveState));
		}
		if (this.mList != null)
		{
			UIPopupList uipopupList = this.mList;
			uipopupList.onSelectionChange = (UIPopupList.OnSelectionChange)Delegate.Remove(uipopupList.onSelectionChange, new UIPopupList.OnSelectionChange(this.SaveSelection));
		}
	}

	// Token: 0x060000FE RID: 254 RVA: 0x0001AC44 File Offset: 0x00018E44
	private void OnEnable()
	{
		if (this.mList != null)
		{
			string @string = PlayerPrefs.GetString(this.key);
			if (!string.IsNullOrEmpty(@string))
			{
				this.mList.selection = @string;
			}
			return;
		}
		if (this.mCheck != null)
		{
			this.mCheck.isChecked = (PlayerPrefs.GetInt(this.key, 1) != 0);
		}
		else
		{
			string string2 = PlayerPrefs.GetString(this.key);
			UICheckbox[] componentsInChildren = base.GetComponentsInChildren<UICheckbox>(true);
			int i = 0;
			int num = componentsInChildren.Length;
			while (i < num)
			{
				UICheckbox uicheckbox = componentsInChildren[i];
				uicheckbox.isChecked = (uicheckbox.name == string2);
				i++;
			}
		}
	}

	// Token: 0x060000FF RID: 255 RVA: 0x0001AD00 File Offset: 0x00018F00
	private void OnDisable()
	{
		if (this.mCheck == null && this.mList == null)
		{
			UICheckbox[] componentsInChildren = base.GetComponentsInChildren<UICheckbox>(true);
			int i = 0;
			int num = componentsInChildren.Length;
			while (i < num)
			{
				UICheckbox uicheckbox = componentsInChildren[i];
				if (uicheckbox.isChecked)
				{
					this.SaveSelection(uicheckbox.name);
					break;
				}
				i++;
			}
		}
	}

	// Token: 0x06000100 RID: 256 RVA: 0x00002E2E File Offset: 0x0000102E
	private void SaveSelection(string selection)
	{
		PlayerPrefs.SetString(this.key, selection);
	}

	// Token: 0x06000101 RID: 257 RVA: 0x00002E3C File Offset: 0x0000103C
	private void SaveState(bool state)
	{
		PlayerPrefs.SetInt(this.key, (!state) ? 0 : 1);
	}

	// Token: 0x04000138 RID: 312
	public string keyName;

	// Token: 0x04000139 RID: 313
	private UIPopupList mList;

	// Token: 0x0400013A RID: 314
	private UICheckbox mCheck;
}
