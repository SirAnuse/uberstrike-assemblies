using System;
using UnityEngine;

// Token: 0x020002DC RID: 732
public class PrefabManager : MonoBehaviour
{
	// Token: 0x17000506 RID: 1286
	// (get) Token: 0x060014F7 RID: 5367 RVA: 0x0000E12F File Offset: 0x0000C32F
	// (set) Token: 0x060014F8 RID: 5368 RVA: 0x0000E136 File Offset: 0x0000C336
	public static PrefabManager Instance { get; private set; }

	// Token: 0x17000507 RID: 1287
	// (get) Token: 0x060014F9 RID: 5369 RVA: 0x0000E13E File Offset: 0x0000C33E
	public static bool Exists
	{
		get
		{
			return PrefabManager.Instance != null;
		}
	}

	// Token: 0x17000508 RID: 1288
	// (get) Token: 0x060014FA RID: 5370 RVA: 0x0000E14B File Offset: 0x0000C34B
	public AvatarDecorator DefaultAvatar
	{
		get
		{
			return this._defaultAvatar;
		}
	}

	// Token: 0x17000509 RID: 1289
	// (get) Token: 0x060014FB RID: 5371 RVA: 0x0000E153 File Offset: 0x0000C353
	public AvatarDecoratorConfig DefaultRagdoll
	{
		get
		{
			return this._defaultRagdoll;
		}
	}

	// Token: 0x060014FC RID: 5372 RVA: 0x0000E15B File Offset: 0x0000C35B
	public CharacterConfig InstantiateLocalCharacter()
	{
		return UnityEngine.Object.Instantiate(this._localCharacter) as CharacterConfig;
	}

	// Token: 0x060014FD RID: 5373 RVA: 0x0000E16D File Offset: 0x0000C36D
	public CharacterConfig InstantiateRemoteCharacter()
	{
		return UnityEngine.Object.Instantiate(this._remoteCharacter) as CharacterConfig;
	}

	// Token: 0x060014FE RID: 5374 RVA: 0x00076C84 File Offset: 0x00074E84
	public LocalPlayer InstantiateLocalPlayer()
	{
		LocalPlayer localPlayer = UnityEngine.Object.Instantiate(this._player) as LocalPlayer;
		UnityEngine.Object.DontDestroyOnLoad(localPlayer);
		localPlayer.SetEnabled(false);
		return localPlayer;
	}

	// Token: 0x060014FF RID: 5375 RVA: 0x0000E17F File Offset: 0x0000C37F
	private void Awake()
	{
		PrefabManager.Instance = this;
	}

	// Token: 0x040013D3 RID: 5075
	[SerializeField]
	private LocalPlayer _player;

	// Token: 0x040013D4 RID: 5076
	[SerializeField]
	private AvatarDecorator _defaultAvatar;

	// Token: 0x040013D5 RID: 5077
	[SerializeField]
	private AvatarDecoratorConfig _defaultRagdoll;

	// Token: 0x040013D6 RID: 5078
	[SerializeField]
	private CharacterConfig _remoteCharacter;

	// Token: 0x040013D7 RID: 5079
	[SerializeField]
	private CharacterConfig _localCharacter;
}
