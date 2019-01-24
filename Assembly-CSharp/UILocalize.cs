using System;
using UnityEngine;

// Token: 0x02000085 RID: 133
[AddComponentMenu("NGUI/UI/Localize")]
[RequireComponent(typeof(UIWidget))]
public class UILocalize : MonoBehaviour
{
	// Token: 0x0600038B RID: 907 RVA: 0x00004B0F File Offset: 0x00002D0F
	private void OnLocalize(Localization loc)
	{
		if (this.mLanguage != loc.currentLanguage)
		{
			this.Localize();
		}
	}

	// Token: 0x0600038C RID: 908 RVA: 0x00004B2D File Offset: 0x00002D2D
	private void OnEnable()
	{
		if (this.mStarted && Localization.instance != null)
		{
			this.Localize();
		}
	}

	// Token: 0x0600038D RID: 909 RVA: 0x00004B50 File Offset: 0x00002D50
	private void Start()
	{
		this.mStarted = true;
		if (Localization.instance != null)
		{
			this.Localize();
		}
	}

	// Token: 0x0600038E RID: 910 RVA: 0x00028300 File Offset: 0x00026500
	public void Localize()
	{
		Localization instance = Localization.instance;
		UIWidget component = base.GetComponent<UIWidget>();
		UILabel uilabel = component as UILabel;
		UISprite uisprite = component as UISprite;
		if (string.IsNullOrEmpty(this.mLanguage) && string.IsNullOrEmpty(this.key) && uilabel != null)
		{
			this.key = uilabel.text;
		}
		string text = (!string.IsNullOrEmpty(this.key)) ? instance.Get(this.key) : string.Empty;
		if (uilabel != null)
		{
			UIInput uiinput = NGUITools.FindInParents<UIInput>(uilabel.gameObject);
			if (uiinput != null && uiinput.label == uilabel)
			{
				uiinput.defaultText = text;
			}
			else
			{
				uilabel.text = text;
			}
		}
		else if (uisprite != null)
		{
			uisprite.spriteName = text;
			uisprite.MakePixelPerfect();
		}
		this.mLanguage = instance.currentLanguage;
	}

	// Token: 0x0400032F RID: 815
	public string key;

	// Token: 0x04000330 RID: 816
	private string mLanguage;

	// Token: 0x04000331 RID: 817
	private bool mStarted;
}
