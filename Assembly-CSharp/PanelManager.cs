using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002D4 RID: 724
public class PanelManager : MonoBehaviour
{
	// Token: 0x170004D8 RID: 1240
	// (get) Token: 0x0600147A RID: 5242 RVA: 0x0000DB95 File Offset: 0x0000BD95
	// (set) Token: 0x0600147B RID: 5243 RVA: 0x0000DB9C File Offset: 0x0000BD9C
	public static PanelManager Instance { get; private set; }

	// Token: 0x170004D9 RID: 1241
	// (get) Token: 0x0600147C RID: 5244 RVA: 0x0000DBA4 File Offset: 0x0000BDA4
	public static bool Exists
	{
		get
		{
			return PanelManager.Instance != null;
		}
	}

	// Token: 0x170004DA RID: 1242
	// (get) Token: 0x0600147D RID: 5245 RVA: 0x0000DBB1 File Offset: 0x0000BDB1
	public LoginPanelGUI LoginPanel
	{
		get
		{
			return this._allPanels[PanelType.Login] as LoginPanelGUI;
		}
	}

	// Token: 0x0600147E RID: 5246 RVA: 0x00075770 File Offset: 0x00073970
	private void Awake()
	{
		PanelManager.Instance = this;
		this._allPanels = new Dictionary<PanelType, IPanelGui>
		{
			{
				PanelType.Login,
				base.GetComponent<LoginPanelGUI>()
			},
			{
				PanelType.Signup,
				base.GetComponent<SignupPanelGUI>()
			},
			{
				PanelType.CompleteAccount,
				base.GetComponent<CompleteAccountPanelGUI>()
			},
			{
				PanelType.Options,
				base.GetComponent<OptionsPanelGUI>()
			},
			{
				PanelType.Help,
				base.GetComponent<HelpPanelGUI>()
			},
			{
				PanelType.CreateGame,
				base.GetComponent<CreateGamePanelGUI>()
			},
			{
				PanelType.ReportPlayer,
				base.GetComponent<ReportPlayerPanelGUI>()
			},
			{
				PanelType.Moderation,
				base.GetComponent<ModerationPanelGUI>()
			},
			{
				PanelType.SendMessage,
				base.GetComponent<SendMessagePanelGUI>()
			},
			{
				PanelType.FriendRequest,
				base.GetComponent<FriendRequestPanelGUI>()
			},
			{
				PanelType.ClanRequest,
				base.GetComponent<InviteToClanPanelGUI>()
			},
			{
				PanelType.BuyItem,
				base.GetComponent<BuyPanelGUI>()
			},
			{
				PanelType.NameChange,
				base.GetComponent<NameChangePanelGUI>()
			}
		};
		foreach (IPanelGui panelGui in this._allPanels.Values)
		{
			MonoBehaviour monoBehaviour = (MonoBehaviour)panelGui;
			if (monoBehaviour)
			{
				monoBehaviour.enabled = false;
			}
		}
	}

	// Token: 0x0600147F RID: 5247 RVA: 0x000758A0 File Offset: 0x00073AA0
	private void OnGUI()
	{
		PanelManager.IsAnyPanelOpen = false;
		foreach (IPanelGui panelGui in this._allPanels.Values)
		{
			if (panelGui.IsEnabled)
			{
				PanelManager.IsAnyPanelOpen = true;
				break;
			}
		}
		if (Event.current.type == EventType.Layout)
		{
			if (PanelManager.IsAnyPanelOpen)
			{
				GuiLockController.EnableLock(GuiDepth.Panel);
			}
			else
			{
				GuiLockController.ReleaseLock(GuiDepth.Panel);
				base.enabled = false;
			}
			if (PanelManager._wasAnyPanelOpen != PanelManager.IsAnyPanelOpen)
			{
				if (PanelManager._wasAnyPanelOpen)
				{
					AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.ClosePanel, 0UL, 1f, 1f);
				}
				else
				{
					AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.OpenPanel, 0UL, 1f, 1f);
				}
				PanelManager._wasAnyPanelOpen = !PanelManager._wasAnyPanelOpen;
			}
		}
	}

	// Token: 0x170004DB RID: 1243
	// (get) Token: 0x06001480 RID: 5248 RVA: 0x0000DBC4 File Offset: 0x0000BDC4
	// (set) Token: 0x06001481 RID: 5249 RVA: 0x0000DBCB File Offset: 0x0000BDCB
	public static bool IsAnyPanelOpen { get; private set; }

	// Token: 0x06001482 RID: 5250 RVA: 0x0000DBD3 File Offset: 0x0000BDD3
	public bool IsPanelOpen(PanelType panel)
	{
		return this._allPanels[panel].IsEnabled;
	}

	// Token: 0x06001483 RID: 5251 RVA: 0x000759A4 File Offset: 0x00073BA4
	public void CloseAllPanels(PanelType except = PanelType.None)
	{
		foreach (IPanelGui panelGui in this._allPanels.Values)
		{
			if (panelGui.IsEnabled)
			{
				panelGui.Hide();
			}
		}
	}

	// Token: 0x06001484 RID: 5252 RVA: 0x00075A0C File Offset: 0x00073C0C
	public IPanelGui OpenPanel(PanelType panel)
	{
		foreach (KeyValuePair<PanelType, IPanelGui> keyValuePair in this._allPanels)
		{
			if (panel == keyValuePair.Key)
			{
				if (!keyValuePair.Value.IsEnabled)
				{
					keyValuePair.Value.Show();
				}
			}
			else if (keyValuePair.Value.IsEnabled)
			{
				keyValuePair.Value.Hide();
			}
		}
		base.enabled = true;
		return this._allPanels[panel];
	}

	// Token: 0x06001485 RID: 5253 RVA: 0x0000DBE6 File Offset: 0x0000BDE6
	public void ClosePanel(PanelType panel)
	{
		if (this._allPanels.ContainsKey(panel) && this._allPanels[panel].IsEnabled)
		{
			this._allPanels[panel].Hide();
		}
	}

	// Token: 0x040013A9 RID: 5033
	private IDictionary<PanelType, IPanelGui> _allPanels;

	// Token: 0x040013AA RID: 5034
	private static bool _wasAnyPanelOpen;
}
