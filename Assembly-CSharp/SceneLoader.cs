using System;
using System.Collections;
using UnityEngine;

// Token: 0x020003A3 RID: 931
public class SceneLoader : Singleton<SceneLoader>
{
	// Token: 0x06001B76 RID: 7030 RVA: 0x00012300 File Offset: 0x00010500
	private SceneLoader()
	{
		this._blackTexture = new Texture2D(1, 1, TextureFormat.RGB24, false);
	}

	// Token: 0x1700061D RID: 1565
	// (get) Token: 0x06001B77 RID: 7031 RVA: 0x00012317 File Offset: 0x00010517
	// (set) Token: 0x06001B78 RID: 7032 RVA: 0x0001231F File Offset: 0x0001051F
	public string CurrentScene { get; private set; }

	// Token: 0x1700061E RID: 1566
	// (get) Token: 0x06001B79 RID: 7033 RVA: 0x00012328 File Offset: 0x00010528
	// (set) Token: 0x06001B7A RID: 7034 RVA: 0x00012330 File Offset: 0x00010530
	public bool IsLoading { get; private set; }

	// Token: 0x06001B7B RID: 7035 RVA: 0x0008D360 File Offset: 0x0008B560
	public void LoadLevel(string level, Action onSuccess = null)
	{
		if (!this.IsLoading)
		{
			if (GameState.Current.Avatar.Decorator != null)
			{
				GameState.Current.Avatar.Decorator.transform.parent = null;
			}
			UnityRuntime.StartRoutine(this.LoadLevelAsync(level, onSuccess));
		}
		else
		{
			Debug.LogError("Trying to load level twice!");
		}
	}

	// Token: 0x06001B7C RID: 7036 RVA: 0x0008D3CC File Offset: 0x0008B5CC
	private IEnumerator LoadLevelAsync(string level, Action onSuccess)
	{
		this.IsLoading = true;
		this.CurrentScene = level;
		AutoMonoBehaviour<BackgroundMusicPlayer>.Instance.Stop();
		AutoMonoBehaviour<UnityRuntime>.Instance.OnGui += this.OnGUI;
		for (float f = this._color.a * 1f; f < 1f; f += Time.deltaTime)
		{
			yield return new WaitForEndOfFrame();
			this._color.a = f / 1f;
		}
		this._color.a = 1f;
		Application.LoadLevel(level);
		yield return new WaitForEndOfFrame();
		if (level == "Menu")
		{
			AutoMonoBehaviour<BackgroundMusicPlayer>.Instance.Play(GameAudio.HomeSceneBackground);
			MenuPageManager.Instance.LoadPage(PageType.Home, false);
		}
		else
		{
			Application.LoadLevelAdditive("DesktopHUD");
		}
		for (float f2 = 0f; f2 < 1f; f2 += Time.deltaTime)
		{
			yield return new WaitForEndOfFrame();
			this._color.a = 1f - f2 / 1f;
		}
		AutoMonoBehaviour<UnityRuntime>.Instance.OnGui -= this.OnGUI;
		this.IsLoading = false;
		if (onSuccess != null)
		{
			onSuccess();
		}
		yield break;
	}

	// Token: 0x06001B7D RID: 7037 RVA: 0x0008D404 File Offset: 0x0008B604
	private void OnGUI()
	{
		GUI.depth = 8;
		GUI.color = this._color;
		GUI.DrawTexture(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), this._blackTexture);
		GUI.color = Color.white;
	}

	// Token: 0x0400187C RID: 6268
	private const float FadeTime = 1f;

	// Token: 0x0400187D RID: 6269
	private Texture2D _blackTexture;

	// Token: 0x0400187E RID: 6270
	private Color _color;
}
