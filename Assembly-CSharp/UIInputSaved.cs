using System;
using UnityEngine;

// Token: 0x02000082 RID: 130
[AddComponentMenu("NGUI/UI/Input (Saved)")]
public class UIInputSaved : UIInput
{
	// Token: 0x17000090 RID: 144
	// (get) Token: 0x0600035E RID: 862 RVA: 0x00004877 File Offset: 0x00002A77
	// (set) Token: 0x0600035F RID: 863 RVA: 0x0000487F File Offset: 0x00002A7F
	public override string text
	{
		get
		{
			return base.text;
		}
		set
		{
			base.text = value;
			this.SaveToPlayerPrefs(value);
		}
	}

	// Token: 0x06000360 RID: 864 RVA: 0x00027498 File Offset: 0x00025698
	private void Awake()
	{
		this.onSubmit = new UIInput.OnSubmit(this.SaveToPlayerPrefs);
		if (!string.IsNullOrEmpty(this.playerPrefsField) && PlayerPrefs.HasKey(this.playerPrefsField))
		{
			this.text = PlayerPrefs.GetString(this.playerPrefsField);
		}
	}

	// Token: 0x06000361 RID: 865 RVA: 0x0000488F File Offset: 0x00002A8F
	private void SaveToPlayerPrefs(string val)
	{
		if (!string.IsNullOrEmpty(this.playerPrefsField))
		{
			PlayerPrefs.SetString(this.playerPrefsField, val);
		}
	}

	// Token: 0x06000362 RID: 866 RVA: 0x000048AD File Offset: 0x00002AAD
	private void OnApplicationQuit()
	{
		this.SaveToPlayerPrefs(this.text);
	}

	// Token: 0x04000310 RID: 784
	public string playerPrefsField;
}
