using System;
using System.Text;
using Steamworks;
using UnityEngine;

// Token: 0x020003A9 RID: 937
internal class SteamManager : MonoBehaviour
{
	// Token: 0x17000623 RID: 1571
	// (get) Token: 0x06001B94 RID: 7060 RVA: 0x0001240A File Offset: 0x0001060A
	public static bool Initialized
	{
		get
		{
			return SteamManager.m_instance.m_bInitialized;
		}
	}

	// Token: 0x06001B95 RID: 7061 RVA: 0x00012416 File Offset: 0x00010616
	private static void SteamAPIDebugTextHook(int nSeverity, StringBuilder pchDebugText)
	{
		Debug.LogWarning(pchDebugText);
	}

	// Token: 0x06001B96 RID: 7062 RVA: 0x00003C87 File Offset: 0x00001E87
	private void Awake()
	{
	}

	// Token: 0x06001B97 RID: 7063 RVA: 0x0008DE48 File Offset: 0x0008C048
	private void Start()
	{
		Debug.Log("INITIALIZING STEAMWORKS SDK");
		if (SteamManager.m_instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		SteamManager.m_instance = this;
		try
		{
			if (SteamAPI.RestartAppIfNecessary((AppId_t)291210u))
			{
				Application.Quit();
				return;
			}
		}
		catch (DllNotFoundException arg)
		{
			Debug.LogError("[Steamworks.NET] Could not load [lib]steam_api.dll/so/dylib. It's likely not in the correct location. Refer to the README for more details.\n" + arg, this);
			Application.Quit();
			return;
		}
		if (!SteamAPI.Init())
		{
			Debug.LogError("[Steamworks.NET] SteamAPI_Init() failed. Refer to Valve's documentation or the comment above this line for more information.", this);
			Application.Quit();
			return;
		}
		this.m_bInitialized = true;
		Debug.Log("SteamAPI was successfully initialized!");
		if (!SteamUser.BLoggedOn())
		{
			Debug.LogError("[Steamworks.NET] Steam user must be logged in to play this game (SteamUser()->BLoggedOn() returned false).", this);
			Application.Quit();
			return;
		}
	}

	// Token: 0x06001B98 RID: 7064 RVA: 0x0001241E File Offset: 0x0001061E
	private void OnEnable()
	{
		if (!this.m_bInitialized)
		{
			return;
		}
		if (this.m_SteamAPIWarningMessageHook == null)
		{
			this.m_SteamAPIWarningMessageHook = new SteamAPIWarningMessageHook_t(SteamManager.SteamAPIDebugTextHook);
			SteamClient.SetWarningMessageHook(this.m_SteamAPIWarningMessageHook);
		}
	}

	// Token: 0x06001B99 RID: 7065 RVA: 0x00012454 File Offset: 0x00010654
	private void OnApplicationQuit()
	{
		if (!this.m_bInitialized)
		{
			return;
		}
		SteamAPI.Shutdown();
	}

	// Token: 0x06001B9A RID: 7066 RVA: 0x00012467 File Offset: 0x00010667
	private void Update()
	{
		if (!this.m_bInitialized)
		{
			return;
		}
		SteamAPI.RunCallbacks();
	}

	// Token: 0x040018B0 RID: 6320
	private static SteamManager m_instance;

	// Token: 0x040018B1 RID: 6321
	private bool m_bInitialized;

	// Token: 0x040018B2 RID: 6322
	private SteamAPIWarningMessageHook_t m_SteamAPIWarningMessageHook;
}
