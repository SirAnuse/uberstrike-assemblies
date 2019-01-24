using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000202 RID: 514
public static class AssetBundleLoader
{
	// Token: 0x06000E44 RID: 3652 RVA: 0x00061A6C File Offset: 0x0005FC6C
	public static IEnumerator LoadAssetBundleNoCache(string path, Action<float> progress = null, Action<AssetBundle> onLoaded = null, Action<string> onError = null)
	{
		Debug.Log("LOADING ASSETBUNDLE: " + path);
		WWW loader = new WWW(path);
		while (!loader.isDone)
		{
			yield return new WaitForEndOfFrame();
			if (progress != null)
			{
				progress(loader.progress);
			}
		}
		if (!string.IsNullOrEmpty(loader.error))
		{
			Debug.LogError("Failed to locate Asset " + path + ". Error" + loader.error);
			if (onError != null)
			{
				onError("Failed to locate Asset " + path + ". Error" + loader.error);
			}
		}
		else if (onLoaded != null)
		{
			onLoaded(loader.assetBundle);
		}
		if (progress != null)
		{
			progress(1f);
		}
		loader.Dispose();
		yield break;
	}
}
