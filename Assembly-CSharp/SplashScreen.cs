using System;
using UnityEngine;

// Token: 0x020003A6 RID: 934
public class SplashScreen : MonoBehaviour
{
	// Token: 0x06001B8D RID: 7053 RVA: 0x0008D8E8 File Offset: 0x0008BAE8
	private void Start()
	{
		this.loadingBarBackground = new Texture2D(1, 1, TextureFormat.RGB24, false);
		this.loadingBarBackground.SetPixels(new Color[]
		{
			Color.white
		});
		this.loadingBarBackground.Apply(false);
		this.mainScreen = this.initializingScreen;
		this.blurScreen = this.initializingScreenBlurred;
	}

	// Token: 0x06001B8E RID: 7054 RVA: 0x0008D94C File Offset: 0x0008BB4C
	private void OnGUI()
	{
		GUI.skin = PopupSkin.Skin;
		GUIStyle label_loading = PopupSkin.label_loading;
		float alpha = (Mathf.Sin(Time.time * 2f) + 1.3f) * 0.5f;
		if (!GlobalSceneLoader.IsError)
		{
			label_loading.normal.textColor = label_loading.normal.textColor.SetAlpha(alpha);
			if (GlobalSceneLoader.IsGlobalSceneLoaded && GlobalSceneLoader.IsItemAssetBundleLoaded)
			{
				this._blurBackgroundAlpha = Mathf.Lerp(this._blurBackgroundAlpha, 0f, Time.deltaTime);
			}
			float num = (float)Screen.width / (float)this.mainScreen.width;
			float num2 = (float)Screen.height / (float)this.mainScreen.height;
			float num3 = (num <= num2) ? num2 : num;
			Rect position = new Rect((float)(Screen.width / 2) - (float)this.mainScreen.width * num3 / 2f, (float)(Screen.height / 2) - (float)this.mainScreen.height * num3 / 2f, (float)this.mainScreen.width * num3, (float)this.mainScreen.height * num3);
			GUI.depth = 100;
			GUI.color = new Color(1f, 1f, 1f, 1f);
			GUI.DrawTexture(position, this.mainScreen);
			GUI.color = new Color(1f, 1f, 1f, 1f - this._blurBackgroundAlpha);
			GUI.DrawTexture(position, this.blurScreen);
			GUI.color = Color.white;
			if (Application.internetReachability == NetworkReachability.NotReachable)
			{
				label_loading.normal.textColor = label_loading.normal.textColor.SetAlpha(1f);
				GUI.Label(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), "No internet connection available", label_loading);
			}
			else if (!GlobalSceneLoader.IsGlobalSceneLoaded)
			{
				Vector2 v = label_loading.CalcSize(new GUIContent("Loading game. Please wait..."));
				GUITools.LabelShadow(new Rect(0f, (float)(Screen.height - 150), (float)Screen.width, v.Height()), "Loading game. Please wait...", label_loading, label_loading.normal.textColor);
				GUI.color = new Color(1f, 1f, 1f, 0.5f);
				GUI.DrawTexture(new Rect((float)Screen.width * 0.5f - this.barSize.x * 0.5f, (float)(Screen.height - 150) + this.barSize.Height() + 8f, this.barSize.x, 8f), this.loadingBarBackground);
				GUI.color = Color.white;
				GUI.DrawTexture(new Rect((float)Screen.width * 0.5f - this.barSize.x * 0.5f, (float)(Screen.height - 150) + this.barSize.Height() + 8f, (float)Mathf.RoundToInt(this.TotalProgress * this.barSize.x), 8f), this.loadingBarBackground);
			}
			else if (!GlobalSceneLoader.IsInitialised)
			{
				Vector2 v2 = label_loading.CalcSize(new GUIContent("Connecting..."));
				GUITools.LabelShadow(new Rect(0f, (float)(Screen.height - 150), (float)Screen.width, v2.Height()), "Connecting...", label_loading, label_loading.normal.textColor);
			}
		}
		else if (!PopupSystem.IsAnyPopupOpen)
		{
			label_loading.normal.textColor = label_loading.normal.textColor.SetAlpha(1f);
			if (GUI.Button(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), "There was a problem loading UberStrike. Try reloading or visit support.uberstrike.com if the problem persists.", label_loading))
			{
				Application.Quit();
			}
		}
	}

	// Token: 0x17000621 RID: 1569
	// (get) Token: 0x06001B8F RID: 7055 RVA: 0x000123D6 File Offset: 0x000105D6
	private float TotalProgress
	{
		get
		{
			return GlobalSceneLoader.GlobalSceneProgress;
		}
	}

	// Token: 0x0400188E RID: 6286
	[SerializeField]
	private Texture2D initializingScreen;

	// Token: 0x0400188F RID: 6287
	[SerializeField]
	private Texture2D initializingScreenBlurred;

	// Token: 0x04001890 RID: 6288
	private Texture mainScreen;

	// Token: 0x04001891 RID: 6289
	private Texture blurScreen;

	// Token: 0x04001892 RID: 6290
	private Texture2D loadingBarBackground;

	// Token: 0x04001893 RID: 6291
	private float _blurBackgroundAlpha = 1f;

	// Token: 0x04001894 RID: 6292
	private Vector2 barSize = new Vector2(300f, 20f);
}
