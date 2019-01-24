using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using UberStrike.DataCenter.Common.Entities;
using UnityEngine;

// Token: 0x0200015F RID: 351
public class GlobalUIRibbon : MonoBehaviour
{
	// Token: 0x1700029C RID: 668
	// (get) Token: 0x0600094E RID: 2382 RVA: 0x00007D3E File Offset: 0x00005F3E
	// (set) Token: 0x0600094F RID: 2383 RVA: 0x00007D45 File Offset: 0x00005F45
	public static GlobalUIRibbon Instance { get; private set; }

	// Token: 0x1700029D RID: 669
	// (get) Token: 0x06000950 RID: 2384 RVA: 0x00007D4D File Offset: 0x00005F4D
	public bool IsVisible
	{
		get
		{
			return base.enabled;
		}
	}

	// Token: 0x1700029E RID: 670
	// (get) Token: 0x06000951 RID: 2385 RVA: 0x00007D55 File Offset: 0x00005F55
	public int StatusBarHeight
	{
		get
		{
			return (!ApplicationDataManager.IsMobile) ? 0 : 44;
		}
	}

	// Token: 0x06000952 RID: 2386 RVA: 0x00007D69 File Offset: 0x00005F69
	public int Height()
	{
		return (int)this._yOffset + this._height - 1;
	}

	// Token: 0x1700029F RID: 671
	// (get) Token: 0x06000953 RID: 2387 RVA: 0x0003ACC0 File Offset: 0x00038EC0
	private float CreditsAlpha
	{
		get
		{
			GlobalUIRibbon.RibbonEvent ribbonEvent;
			if (this._ribbonEvents.TryGetValue(GlobalUIRibbon.EventType.CreditEvent, out ribbonEvent))
			{
				return ribbonEvent.Alpha;
			}
			return 1f;
		}
	}

	// Token: 0x170002A0 RID: 672
	// (get) Token: 0x06000954 RID: 2388 RVA: 0x0003ACEC File Offset: 0x00038EEC
	private int CreditsValue
	{
		get
		{
			GlobalUIRibbon.RibbonEvent ribbonEvent;
			if (this._ribbonEvents.TryGetValue(GlobalUIRibbon.EventType.CreditEvent, out ribbonEvent))
			{
				return ribbonEvent.Value;
			}
			return PlayerDataManager.Credits;
		}
	}

	// Token: 0x170002A1 RID: 673
	// (get) Token: 0x06000955 RID: 2389 RVA: 0x0003AD18 File Offset: 0x00038F18
	private float PointsAlpha
	{
		get
		{
			GlobalUIRibbon.RibbonEvent ribbonEvent;
			if (this._ribbonEvents.TryGetValue(GlobalUIRibbon.EventType.PointEvent, out ribbonEvent))
			{
				return ribbonEvent.Alpha;
			}
			return 1f;
		}
	}

	// Token: 0x170002A2 RID: 674
	// (get) Token: 0x06000956 RID: 2390 RVA: 0x0003AD44 File Offset: 0x00038F44
	private int PointsValue
	{
		get
		{
			GlobalUIRibbon.RibbonEvent ribbonEvent;
			if (this._ribbonEvents.TryGetValue(GlobalUIRibbon.EventType.PointEvent, out ribbonEvent))
			{
				return ribbonEvent.Value;
			}
			return PlayerDataManager.Points;
		}
	}

	// Token: 0x170002A3 RID: 675
	// (get) Token: 0x06000957 RID: 2391 RVA: 0x0003AD70 File Offset: 0x00038F70
	private float XpAlpha
	{
		get
		{
			GlobalUIRibbon.RibbonEvent ribbonEvent;
			if (this._ribbonEvents.TryGetValue(GlobalUIRibbon.EventType.XpEvent, out ribbonEvent))
			{
				return ribbonEvent.Alpha;
			}
			return 1f;
		}
	}

	// Token: 0x170002A4 RID: 676
	// (get) Token: 0x06000958 RID: 2392 RVA: 0x0003AD9C File Offset: 0x00038F9C
	private int XpValue
	{
		get
		{
			GlobalUIRibbon.RibbonEvent ribbonEvent;
			if (this._ribbonEvents.TryGetValue(GlobalUIRibbon.EventType.XpEvent, out ribbonEvent))
			{
				return ribbonEvent.Value;
			}
			return PlayerDataManager.PlayerExperience;
		}
	}

	// Token: 0x06000959 RID: 2393 RVA: 0x0003ADC8 File Offset: 0x00038FC8
	private void Awake()
	{
		GlobalUIRibbon.Instance = this;
		this._ribbonEvents = new Dictionary<GlobalUIRibbon.EventType, GlobalUIRibbon.RibbonEvent>();
		global::EventHandler.Global.AddListener<GameEvents.PlayerPause>(new Action<GameEvents.PlayerPause>(this.OnPlayerPaused));
		global::EventHandler.Global.AddListener<GameEvents.MatchEnd>(new Action<GameEvents.MatchEnd>(this.OnMatchEndEvent));
		global::EventHandler.Global.AddListener<GameEvents.PlayerIngame>(new Action<GameEvents.PlayerIngame>(this.OnPlayerInGameEvent));
		global::EventHandler.Global.AddListener<GameEvents.PlayerDied>(new Action<GameEvents.PlayerDied>(this.OnPlayerKilled));
	}

	// Token: 0x0600095A RID: 2394 RVA: 0x00007D7B File Offset: 0x00005F7B
	private void OnPlayerKilled(GameEvents.PlayerDied ev)
	{
		this.Show();
	}

	// Token: 0x0600095B RID: 2395 RVA: 0x00007D7B File Offset: 0x00005F7B
	private void OnMatchEndEvent(GameEvents.MatchEnd ev)
	{
		this.Show();
	}

	// Token: 0x0600095C RID: 2396 RVA: 0x00007D7B File Offset: 0x00005F7B
	private void OnPlayerPaused(GameEvents.PlayerPause ev)
	{
		this.Show();
	}

	// Token: 0x0600095D RID: 2397 RVA: 0x00007D83 File Offset: 0x00005F83
	private void OnPlayerInGameEvent(GameEvents.PlayerIngame ev)
	{
		this.Hide();
	}

	// Token: 0x0600095E RID: 2398 RVA: 0x00007D8B File Offset: 0x00005F8B
	private void Start()
	{
		this._yOffset = (float)(-(float)this._height);
		this.InitOptionsDropdown();
		base.enabled = false;
		this._isReady = true;
	}

	// Token: 0x0600095F RID: 2399 RVA: 0x0003AE40 File Offset: 0x00039040
	private void InitOptionsDropdown()
	{
		this._optionsDropdown = new GuiDropDown();
		this._optionsDropdown.Caption = new GUIContent(GlobalUiIcons.QuadpanelButtonOptions);
		this._optionsDropdown.Add(new GUIContent(" " + LocalizedStrings.Help, GlobalUiIcons.QuadpanelButtonHelp), delegate()
		{
			PanelManager.Instance.OpenPanel(PanelType.Help);
		});
		this._optionsDropdown.Add(new GUIContent(" " + LocalizedStrings.Options, GlobalUiIcons.QuadpanelButtonOptions), delegate()
		{
			PanelManager.Instance.OpenPanel(PanelType.Options);
		});
		this._optionsDropdown.Add(new GUIContent(" " + LocalizedStrings.Audio, GlobalUiIcons.QuadpanelButtonSoundoff), new GUIContent(" " + LocalizedStrings.Audio, GlobalUiIcons.QuadpanelButtonSoundon), () => ApplicationDataManager.ApplicationOptions.AudioEnabled, delegate()
		{
			ApplicationDataManager.ApplicationOptions.AudioEnabled = !ApplicationDataManager.ApplicationOptions.AudioEnabled;
			AutoMonoBehaviour<SfxManager>.Instance.EnableAudio(ApplicationDataManager.ApplicationOptions.AudioEnabled);
			ApplicationDataManager.ApplicationOptions.SaveApplicationOptions();
			AutoMonoBehaviour<SfxManager>.Instance.UpdateEffectsVolume();
		});
		if (Application.isWebPlayer)
		{
			this._optionsDropdown.Add(new GUIContent(" " + LocalizedStrings.Windowed, GlobalUiIcons.QuadpanelButtonNormalize), new GUIContent(" " + LocalizedStrings.Fullscreen, GlobalUiIcons.QuadpanelButtonFullscreen), () => Screen.fullScreen, delegate()
			{
				ScreenResolutionManager.IsFullScreen = !Screen.fullScreen;
			});
		}
		else
		{
			if (PlayerDataManager.AccessLevel == MemberAccessLevel.Admin)
			{
				this._optionsDropdown.Add(new GUIContent(" CONSOLE"), delegate()
				{
					DebugConsoleManager.Instance.IsDebugConsoleEnabled = true;
				});
			}
			this._optionsDropdown.Add(new GUIContent(" " + LocalizedStrings.Logout, GlobalUiIcons.QuadpanelButtonLogout), delegate()
			{
				PopupSystem.ShowMessage("Logout", "This will log out your Steam account and allow you to link another account.", PopupSystem.AlertType.OKCancel, delegate()
				{
					PlayerPrefs.DeleteKey("CurrentSteamUser");
					Application.Quit();
				});
			});
		}
		global::EventHandler.Global.AddListener<GlobalEvents.Login>(delegate(GlobalEvents.Login ev)
		{
			if (ev.AccessLevel >= MemberAccessLevel.Moderator)
			{
				this._optionsDropdown.Add(new GUIContent(" " + LocalizedStrings.Moderate, GlobalUiIcons.QuadpanelButtonModerate), delegate()
				{
					if (PlayerDataManager.AccessLevel >= MemberAccessLevel.Moderator)
					{
						PanelManager.Instance.OpenPanel(PanelType.Moderation);
					}
				});
			}
		});
	}

	// Token: 0x06000960 RID: 2400 RVA: 0x0003B084 File Offset: 0x00039284
	private void Update()
	{
		if (!this._isReady)
		{
			return;
		}
		if (this._ribbonEvents.Count > 0)
		{
			foreach (object obj in Enum.GetValues(typeof(GlobalUIRibbon.EventType)))
			{
				GlobalUIRibbon.EventType key = (GlobalUIRibbon.EventType)((int)obj);
				GlobalUIRibbon.RibbonEvent ribbonEvent;
				if (this._ribbonEvents.TryGetValue(key, out ribbonEvent))
				{
					if (ribbonEvent.IsDone())
					{
						this._ribbonEvents.Remove(key);
					}
					else
					{
						ribbonEvent.Animate();
					}
				}
			}
		}
		if (this._yOffset < 0f)
		{
			this._yOffset = Mathf.Lerp(this._yOffset, 0.1f, Time.deltaTime * 8f);
		}
		else
		{
			this._yOffset = 0f;
		}
	}

	// Token: 0x06000961 RID: 2401 RVA: 0x0003B180 File Offset: 0x00039380
	private void OnGUI()
	{
		if (!this._isReady || !Singleton<AuthenticationManager>.Instance.IsAuthComplete)
		{
			return;
		}
		GUI.depth = 7;
		GUI.Label(new Rect(0f, this._yOffset, (float)Screen.width, 44f), GUIContent.none, BlueStonez.window_standard_grey38);
		this.DoMenuBar(new Rect(0f, this._yOffset, (float)Screen.width, 44f));
		if (this._ribbonEvents.Count > 0)
		{
			GlobalUIRibbon.EventType[] array = (GlobalUIRibbon.EventType[])Enum.GetValues(typeof(GlobalUIRibbon.EventType));
			for (int i = 0; i < array.Length; i++)
			{
				GlobalUIRibbon.RibbonEvent ribbonEvent;
				if (this._ribbonEvents.TryGetValue(array[i], out ribbonEvent))
				{
					ribbonEvent.Draw();
				}
			}
		}
		GuiManager.DrawTooltip();
	}

	// Token: 0x06000962 RID: 2402 RVA: 0x0003B254 File Offset: 0x00039454
	private void DoMenuBar(Rect rect)
	{
		GUI.enabled = !Singleton<SceneLoader>.Instance.IsLoading;
		if (MenuPageManager.Instance == null)
		{
			if (GUI.Button(new Rect(rect.x + 9f, rect.y + 6f, 100f, 32f), "Back", BlueStonez.button_white))
			{
				Singleton<GameStateController>.Instance.LeaveGame(true);
			}
		}
		else if (!MenuPageManager.Instance.IsCurrentPage(PageType.Home) && GUITools.Button(new Rect(rect.x + 9f, rect.y + 6f, 100f, 32f), new GUIContent("Back"), BlueStonez.button_white))
		{
			if (MenuPageManager.Instance.IsCurrentPage(PageType.Play) && Singleton<GameServerController>.Instance.SelectedServer != null)
			{
				PlayPageGUI.Instance.ShowServerSelection();
			}
			else if (MenuPageManager.Instance.IsCurrentPage(PageType.Training))
			{
				MenuPageManager.Instance.LoadPage(PageType.Play, false);
			}
			else
			{
				Singleton<GameStateController>.Instance.Client.Disconnect();
				MenuPageManager.Instance.LoadPage(PageType.Home, false);
			}
		}
		int num = 0;
		if (ApplicationDataManager.IsMobile)
		{
			num = 44;
		}
		if (!GameState.Current.HasJoinedGame || GamePageManager.HasPage)
		{
			Rect position = new Rect(rect.width - 420f + (float)num, 12f, 100f, 20f);
			GUIContent content = new GUIContent(this.PointsValue.ToString("N0"), ShopIcons.IconPoints20x20);
			GUI.color = new Color(1f, 1f, 1f, this.PointsAlpha);
			GUI.Label(position, content, BlueStonez.label_interparkbold_13pt);
			Rect position2 = new Rect(rect.width - 310f + (float)num, 12f, 100f, 20f);
			GUIContent content2 = new GUIContent(this.CreditsValue.ToString("N0"), ShopIcons.IconCredits20x20);
			GUI.color = new Color(1f, 1f, 1f, this.CreditsAlpha);
			GUI.Label(position2, content2, BlueStonez.label_interparkbold_13pt);
			GUI.color = Color.white;
			if (GUITools.Button(new Rect(rect.width - 200f + (float)num, rect.y + 9f, 100f, 26f), new GUIContent("Get Credits", LocalizedStrings.ClickHereBuyCreditsMsg), BlueStonez.buttongold_medium))
			{
				ApplicationDataManager.OpenBuyCredits();
			}
		}
		if (!ApplicationDataManager.IsMobile)
		{
			GUIContent content3 = (!Screen.fullScreen) ? new GUIContent(string.Empty, GlobalUiIcons.QuadpanelButtonFullscreen, "Enter Fullscreen mode.") : new GUIContent(string.Empty, GlobalUiIcons.QuadpanelButtonNormalize, "Return to windowed mode.");
			if (GUI.Button(new Rect((float)(Screen.width - 88), this._yOffset, 44f, 44f), content3, BlueStonez.buttondark_medium))
			{
				ScreenResolutionManager.IsFullScreen = !Screen.fullScreen;
			}
		}
		this._optionsDropdown.SetRect(new Rect((float)(Screen.width - 44), this._yOffset, 44f, 44f));
		this._optionsDropdown.Draw();
	}

	// Token: 0x06000963 RID: 2403 RVA: 0x0003B5A4 File Offset: 0x000397A4
	private void DoFpsAndVersion()
	{
		string text = string.Format("{0} v{1}", ApplicationDataManager.FrameRate, "4.7.1");
		GUI.color = Color.white.SetAlpha(0.3f);
		GUI.Label(new Rect(5f, (float)(Screen.height - 25), 190f, 20f), text, BlueStonez.label_interparkmed_11pt_right);
		GUI.color = Color.white;
	}

	// Token: 0x06000964 RID: 2404 RVA: 0x00007DAF File Offset: 0x00005FAF
	public void Show()
	{
		base.enabled = true;
		global::EventHandler.Global.Fire(new GlobalEvents.GlobalUIRibbonChanged());
	}

	// Token: 0x06000965 RID: 2405 RVA: 0x00007DC7 File Offset: 0x00005FC7
	public void Hide()
	{
		base.enabled = false;
		this._yOffset = (float)(-(float)this._height);
		global::EventHandler.Global.Fire(new GlobalEvents.GlobalUIRibbonChanged());
	}

	// Token: 0x06000966 RID: 2406 RVA: 0x0003B60C File Offset: 0x0003980C
	public void AddXPEvent(int deltaXP)
	{
		if (deltaXP > 0)
		{
			this._ribbonEvents[GlobalUIRibbon.EventType.XpEvent] = new GlobalUIRibbon.GainEvent(370, Color.white, deltaXP, PlayerDataManager.PlayerExperience);
		}
		else if (deltaXP < 0)
		{
			this._ribbonEvents[GlobalUIRibbon.EventType.XpEvent] = new GlobalUIRibbon.LoseEvent(370, Color.white, deltaXP, PlayerDataManager.PlayerExperience);
		}
	}

	// Token: 0x06000967 RID: 2407 RVA: 0x0003B670 File Offset: 0x00039870
	public void AddCreditsEvent(int deltaCredits)
	{
		int x = Screen.width - 310 + this.StatusBarHeight;
		if (deltaCredits > 0)
		{
			this._ribbonEvents[GlobalUIRibbon.EventType.CreditEvent] = new GlobalUIRibbon.GainEvent(x, Color.white, deltaCredits, PlayerDataManager.Credits);
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.GetPoints, 0UL, 1f, 1f);
		}
		else if (deltaCredits < 0)
		{
			this._ribbonEvents[GlobalUIRibbon.EventType.CreditEvent] = new GlobalUIRibbon.LoseEvent(x, Color.white, deltaCredits, PlayerDataManager.Credits);
		}
	}

	// Token: 0x06000968 RID: 2408 RVA: 0x0003B6F8 File Offset: 0x000398F8
	public void AddPointsEvent(int deltaPoints)
	{
		int x = Screen.width - 420 + this.StatusBarHeight;
		if (deltaPoints > 0)
		{
			this._ribbonEvents[GlobalUIRibbon.EventType.PointEvent] = new GlobalUIRibbon.GainEvent(x, Color.white, deltaPoints, PlayerDataManager.Points);
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.GetPoints, 0UL, 1f, 1f);
		}
		else if (deltaPoints < 0)
		{
			this._ribbonEvents[GlobalUIRibbon.EventType.PointEvent] = new GlobalUIRibbon.LoseEvent(x, Color.white, deltaPoints, PlayerDataManager.Points);
		}
	}

	// Token: 0x04000984 RID: 2436
	private const int NEWSFEED_HEIGHT = 0;

	// Token: 0x04000985 RID: 2437
	private const int PAGETABS_HEIGHT = 0;

	// Token: 0x04000986 RID: 2438
	private const int STATUSBAR_HEIGHT = 44;

	// Token: 0x04000987 RID: 2439
	private const int ButtonY = 0;

	// Token: 0x04000988 RID: 2440
	private int _height = 44;

	// Token: 0x04000989 RID: 2441
	private GuiDropDown _optionsDropdown;

	// Token: 0x0400098A RID: 2442
	private bool _isReady;

	// Token: 0x0400098B RID: 2443
	private float _yOffset;

	// Token: 0x0400098C RID: 2444
	private Dictionary<GlobalUIRibbon.EventType, GlobalUIRibbon.RibbonEvent> _ribbonEvents;

	// Token: 0x02000160 RID: 352
	private abstract class RibbonEvent
	{
		// Token: 0x06000974 RID: 2420 RVA: 0x0003B828 File Offset: 0x00039A28
		public RibbonEvent(int horizontalPosition, Color color, int deltaValue, int currentValue)
		{
			this._value = (float)(currentValue - deltaValue);
			this._delta = (float)deltaValue;
			this._timer = 0f;
			this._alpha = 1f;
			this._scale = 1f;
			this._color = color;
			this._speed = Mathf.Sign((float)deltaValue) * 20f;
			this._style = BlueStonez.label_interparkbold_32pt;
			if (this._speed > 0f)
			{
				this._content = string.Format("+{0}", deltaValue.ToString("N0"));
			}
			else
			{
				this._content = string.Format("-{0}", Mathf.Abs(deltaValue).ToString("N0"));
			}
			Vector2 vector = this._style.CalcSize(new GUIContent(this._content));
			this._rect = new Rect((float)horizontalPosition, this._height, vector.x, vector.y);
		}

		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x06000975 RID: 2421
		public abstract int Value { get; }

		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x06000976 RID: 2422
		public abstract float Alpha { get; }

		// Token: 0x06000977 RID: 2423 RVA: 0x0003B938 File Offset: 0x00039B38
		public void Draw()
		{
			GUIUtility.ScaleAroundPivot(new Vector2(this._scale, this._scale), new Vector2(this._rect.x + this._rect.width / 2f, this._rect.y + this._rect.height / 2f));
			GUI.contentColor = new Color(0f, 0f, 0f, this._alpha);
			GUI.Label(new Rect(this._rect.x + 1f, this._rect.y + 1f, this._rect.width, this._rect.height), this._content, this._style);
			GUI.contentColor = new Color(this._color.r, this._color.g, this._color.b, this._alpha);
			GUI.Label(this._rect, this._content, this._style);
			GUI.contentColor = Color.white;
			GUI.matrix = Matrix4x4.identity;
		}

		// Token: 0x06000978 RID: 2424
		public abstract void Animate();

		// Token: 0x06000979 RID: 2425
		public abstract bool IsDone();

		// Token: 0x04000998 RID: 2456
		protected const float _timeStage1 = 1f;

		// Token: 0x04000999 RID: 2457
		protected const float _timeStage2 = 6f;

		// Token: 0x0400099A RID: 2458
		protected float _alpha;

		// Token: 0x0400099B RID: 2459
		protected float _scale;

		// Token: 0x0400099C RID: 2460
		protected float _timer;

		// Token: 0x0400099D RID: 2461
		protected float _speed;

		// Token: 0x0400099E RID: 2462
		protected float _duration = 8f;

		// Token: 0x0400099F RID: 2463
		protected float _height = 10f;

		// Token: 0x040009A0 RID: 2464
		protected float _value;

		// Token: 0x040009A1 RID: 2465
		protected float _delta;

		// Token: 0x040009A2 RID: 2466
		protected Rect _rect;

		// Token: 0x040009A3 RID: 2467
		protected Color _color;

		// Token: 0x040009A4 RID: 2468
		protected GUIStyle _style;

		// Token: 0x040009A5 RID: 2469
		protected string _content;
	}

	// Token: 0x02000161 RID: 353
	private class GainEvent : GlobalUIRibbon.RibbonEvent
	{
		// Token: 0x0600097A RID: 2426 RVA: 0x0003BA64 File Offset: 0x00039C64
		public GainEvent(int x, Color color, int deltaValue, int currentValue) : base(x, color, deltaValue, currentValue)
		{
			this._alpha = 0f;
			this._scale = 1f;
			this._rect.y = 0f;
		}

		// Token: 0x0600097B RID: 2427 RVA: 0x0003BAC4 File Offset: 0x00039CC4
		public override void Animate()
		{
			if (this._timer < this._moveTime)
			{
				this._rect.y = Mathfx.Berp(0f, this._height, this._timer / this._moveTime);
				this._alpha = Mathf.Lerp(this._alpha, 1f, 8f * Time.deltaTime);
			}
			else if (this._timer > this._moveTime + this._scaleTime && this._timer < this._moveTime + this._stayTime + this._scaleTime)
			{
				this._scale = Mathf.Lerp(this._scale, 0.5f, 15f * Time.deltaTime);
				this._alpha = Mathf.Lerp(this._alpha, 0.2f, 10f * Time.deltaTime);
			}
			this._timer += Time.deltaTime;
		}

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x0600097C RID: 2428 RVA: 0x00007E91 File Offset: 0x00006091
		public override int Value
		{
			get
			{
				return Mathf.RoundToInt(this._value + this._delta * this._timer / (this._moveTime + this._stayTime + this._scaleTime));
			}
		}

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x0600097D RID: 2429 RVA: 0x00007EC1 File Offset: 0x000060C1
		public override float Alpha
		{
			get
			{
				return 1f - this._alpha;
			}
		}

		// Token: 0x0600097E RID: 2430 RVA: 0x00007ECF File Offset: 0x000060CF
		public override bool IsDone()
		{
			return this._timer >= this._moveTime + this._scaleTime + this._stayTime;
		}

		// Token: 0x040009A6 RID: 2470
		private float _moveTime = 0.3f;

		// Token: 0x040009A7 RID: 2471
		private float _stayTime = 0.5f;

		// Token: 0x040009A8 RID: 2472
		private float _scaleTime = 0.3f;
	}

	// Token: 0x02000162 RID: 354
	private class LoseEvent : GlobalUIRibbon.RibbonEvent
	{
		// Token: 0x0600097F RID: 2431 RVA: 0x00007EF0 File Offset: 0x000060F0
		public LoseEvent(int x, Color color, int deltaValue, int currentValue) : base(x, color, deltaValue, currentValue)
		{
			this._scale = 0.3f;
		}

		// Token: 0x06000980 RID: 2432 RVA: 0x0003BBBC File Offset: 0x00039DBC
		public override void Animate()
		{
			if (this._timer < this._scaleTime)
			{
				this._scale = Mathfx.Berp(0.3f, 1f, this._timer / this._scaleTime * 2f);
			}
			else if (this._timer < this._scaleTime + this._moveTime)
			{
				this._rect.y = Mathf.Lerp(this._rect.y, 0f, 10f * Time.deltaTime);
				this._alpha = Mathf.Lerp(this._alpha, 0f, 10f * Time.deltaTime);
			}
			this._timer += Time.deltaTime;
		}

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x06000981 RID: 2433 RVA: 0x00007F1E File Offset: 0x0000611E
		public override int Value
		{
			get
			{
				return Mathf.RoundToInt(this._value + this._delta * this._timer / (this._moveTime + this._scaleTime));
			}
		}

		// Token: 0x170002AA RID: 682
		// (get) Token: 0x06000982 RID: 2434 RVA: 0x00007EC1 File Offset: 0x000060C1
		public override float Alpha
		{
			get
			{
				return 1f - this._alpha;
			}
		}

		// Token: 0x06000983 RID: 2435 RVA: 0x00007F47 File Offset: 0x00006147
		public override bool IsDone()
		{
			return this._timer >= this._moveTime + this._scaleTime;
		}

		// Token: 0x040009A9 RID: 2473
		private float _scaleTime = 0.5f;

		// Token: 0x040009AA RID: 2474
		private float _moveTime = 0.5f;
	}

	// Token: 0x02000163 RID: 355
	private enum EventType
	{
		// Token: 0x040009AC RID: 2476
		XpEvent,
		// Token: 0x040009AD RID: 2477
		PointEvent,
		// Token: 0x040009AE RID: 2478
		CreditEvent
	}

	// Token: 0x02000164 RID: 356
	private class LiveFeed
	{
		// Token: 0x06000984 RID: 2436 RVA: 0x00007F61 File Offset: 0x00006161
		public LiveFeed()
		{
			this._content = new List<GlobalUIRibbon.LiveFeed.FeedItem>(10);
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x0003BC80 File Offset: 0x00039E80
		public void SetContent(List<LiveFeedView> feeds)
		{
			this._content.Clear();
			foreach (LiveFeedView liveFeedView in feeds)
			{
				GlobalUIRibbon.LiveFeed.FeedItem feedItem = new GlobalUIRibbon.LiveFeed.FeedItem();
				feedItem.Timer = 0f;
				feedItem.View = liveFeedView;
				feedItem.Date = liveFeedView.Date.ToShortDateString();
				feedItem.Length = BlueStonez.label_interparkbold_11pt_left.CalcSize(new GUIContent(liveFeedView.Description)).x;
				if (liveFeedView.Priority == 0)
				{
					this._content.Insert(0, feedItem);
				}
				else
				{
					this._content.Add(feedItem);
				}
			}
		}

		// Token: 0x06000986 RID: 2438 RVA: 0x0003BD54 File Offset: 0x00039F54
		public void Update()
		{
			if (this._content.Count == 0 || this._content[0].View.Priority == 0)
			{
				return;
			}
			if (this._isRotating)
			{
				this._rotateY = Mathf.Clamp(this._rotateY + Time.deltaTime * 10f, 0f, 16f);
				if (this._rotateY == 16f)
				{
					this._isRotating = false;
					this._index = (this._index + 1) % this._content.Count;
				}
			}
			else
			{
				GlobalUIRibbon.LiveFeed.FeedItem feedItem = this._content[this._index];
				if (feedItem.Timer > 5f)
				{
					feedItem.Timer = 0f;
					this._rotateY = 0f;
					this._isRotating = true;
				}
				else
				{
					feedItem.Timer += Time.deltaTime;
				}
			}
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x0003BE4C File Offset: 0x0003A04C
		public void Draw(Rect rect)
		{
			if (this._content.Count == 0)
			{
				return;
			}
			GlobalUIRibbon.LiveFeed.FeedItem feedItem = this._content[this._index];
			GUI.BeginGroup(rect);
			if (this._isRotating)
			{
				GlobalUIRibbon.LiveFeed.FeedItem feedItem2 = this._content[(this._index + 1) % this._content.Count];
				feedItem.Draw(new Rect(0f, -this._rotateY, rect.width, rect.height));
				feedItem2.Draw(new Rect(0f, 16f - this._rotateY, rect.width, rect.height));
			}
			else
			{
				feedItem.Draw(new Rect(0f, 0f, rect.width, rect.height));
			}
			GUI.EndGroup();
		}

		// Token: 0x040009AF RID: 2479
		private List<GlobalUIRibbon.LiveFeed.FeedItem> _content;

		// Token: 0x040009B0 RID: 2480
		private int _index;

		// Token: 0x040009B1 RID: 2481
		private bool _isRotating;

		// Token: 0x040009B2 RID: 2482
		private float _rotateY;

		// Token: 0x02000165 RID: 357
		private class FeedItem
		{
			// Token: 0x06000989 RID: 2441 RVA: 0x0003BF2C File Offset: 0x0003A12C
			public void Draw(Rect rect)
			{
				GUI.Label(new Rect(8f, rect.y + 1f, 160f, 14f), this.Date, BlueStonez.label_interparkmed_11pt_left);
				if (this.View.Priority == 0)
				{
					GUI.color = Color.red;
				}
				GUI.Label(new Rect(80f, rect.y, this.Length, 14f), this.View.Description, BlueStonez.label_interparkbold_11pt_left);
				GUI.color = Color.white;
				GUI.contentColor = ((this.View.Priority != 0) ? ColorScheme.UberStrikeYellow : Color.red);
				if (!string.IsNullOrEmpty(this.View.Url) && GUITools.Button(new Rect(90f + this.Length, rect.y, 78f, 16f), new GUIContent(LocalizedStrings.MoreInfo, LocalizedStrings.OpenThisLinkInANewBrowserWindow), BlueStonez.buttondark_medium))
				{
					ScreenResolutionManager.IsFullScreen = false;
					ApplicationDataManager.OpenUrl(this.View.Description, this.View.Url);
				}
				GUI.contentColor = Color.white;
			}

			// Token: 0x040009B3 RID: 2483
			public float Timer;

			// Token: 0x040009B4 RID: 2484
			public string Date;

			// Token: 0x040009B5 RID: 2485
			public float Length;

			// Token: 0x040009B6 RID: 2486
			public LiveFeedView View;
		}
	}
}
