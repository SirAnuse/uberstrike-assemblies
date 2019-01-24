using System;
using System.Collections.Generic;
using UberStrike.Core.Models;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x02000309 RID: 777
public class HUDDesktopEventStream : MonoBehaviour
{
	// Token: 0x060015DD RID: 5597 RVA: 0x0007A4D0 File Offset: 0x000786D0
	private void Start()
	{
		GameData.Instance.OnHUDStreamMessage.AddEvent(new Action<GameActorInfo, string, GameActorInfo>(this.AddMessage), this);
		GameData.Instance.OnHUDStreamClear.AddEvent(new Action(this.ClearLog), this);
		GameData.Instance.OnPlayerKilled.AddEvent(new Action<GameActorInfo, GameActorInfo, UberstrikeItemClass, BodyPart>(HUDDesktopEventStream.HandleKilledMessage), this);
		foreach (object obj in this.template.transform.parent)
		{
			Transform transform = (Transform)obj;
			if (transform != this.template.transform)
			{
				UnityEngine.Object.Destroy(transform.gameObject);
			}
		}
		for (int i = 0; i < this.maxItems; i++)
		{
			GameObject gameObject = GameObjectHelper.Instantiate(this.template.gameObject, this.template.transform.parent, new Vector3(0f, (float)i * this.ySpace, 0f));
			gameObject.name = "Item " + i;
			this.itemsGfx.Add(new HUDDesktopEventStream.ItemGfx
			{
				Label1 = gameObject.transform.Find("1_label").GetComponent<UILabel>(),
				Label2 = gameObject.transform.Find("2_label").GetComponent<UILabel>(),
				Label3 = gameObject.transform.Find("3_label").GetComponent<UILabel>(),
				Aligner = gameObject.GetComponent<UIHorizontalAligner>()
			});
		}
		this.template.gameObject.SetActive(false);
		this.ApplyChanges();
	}

	// Token: 0x060015DE RID: 5598 RVA: 0x0007A6A0 File Offset: 0x000788A0
	private void ApplyChanges()
	{
		int i = 0;
		foreach (HUDDesktopEventStream.Item item in this.items)
		{
			HUDDesktopEventStream.ItemGfx itemGfx = this.itemsGfx[i];
			itemGfx.Aligner.gameObject.SetActive(true);
			itemGfx.Label1.text = item.Label1;
			itemGfx.Label1.effectColor = item.Label1EffectColor;
			itemGfx.Label2.text = item.Label2;
			itemGfx.Label3.text = item.Label3;
			itemGfx.Label3.effectColor = item.Label3EffectColor;
			itemGfx.Label1.gameObject.SetActive(itemGfx.Label1.text != string.Empty);
			itemGfx.Label2.gameObject.SetActive(itemGfx.Label2.text != string.Empty);
			itemGfx.Label3.gameObject.SetActive(itemGfx.Label3.text != string.Empty);
			itemGfx.Aligner.Reposition();
			i++;
		}
		while (i < this.maxItems)
		{
			this.itemsGfx[i].Aligner.gameObject.SetActive(false);
			i++;
		}
	}

	// Token: 0x060015DF RID: 5599 RVA: 0x0007A824 File Offset: 0x00078A24
	public void AddMessage(GameActorInfo player1, string actionString, GameActorInfo player2)
	{
		this.items.Enqueue(new HUDDesktopEventStream.Item
		{
			Label1 = ((!string.IsNullOrEmpty(player1.ClanTag)) ? ("[" + player1.ClanTag + "] " + player1.PlayerName) : player1.PlayerName),
			Label1EffectColor = HUDDesktopEventStream.GetPlayerColor(player1),
			Label2 = actionString,
			Label3 = ((player2 != null) ? ((!string.IsNullOrEmpty(player2.ClanTag)) ? ("[" + player2.ClanTag + "] " + player2.PlayerName) : player2.PlayerName) : string.Empty),
			Label3EffectColor = HUDDesktopEventStream.GetPlayerColor(player2),
			TimeEnd = Time.time + this.displayTime
		});
		if (this.items.Count > this.maxItems)
		{
			this.items.Dequeue();
		}
		this.ApplyChanges();
	}

	// Token: 0x060015E0 RID: 5600 RVA: 0x0000EB51 File Offset: 0x0000CD51
	public void ClearLog()
	{
		this.items.Clear();
		this.ApplyChanges();
	}

	// Token: 0x060015E1 RID: 5601 RVA: 0x0007A924 File Offset: 0x00078B24
	public void DoAnimateDown(bool down)
	{
		SpringPosition.Begin(this.container.gameObject, new Vector3(0f, (!down) ? 0f : -60f, 0f), 10f).onFinished = delegate(SpringPosition el)
		{
			el.enabled = false;
		};
	}

	// Token: 0x060015E2 RID: 5602 RVA: 0x0007A98C File Offset: 0x00078B8C
	private void Update()
	{
		while (this.items.Count > 0 && Time.time >= this.items.Peek().TimeEnd)
		{
			this.items.Dequeue();
			this.ApplyChanges();
		}
	}

	// Token: 0x060015E3 RID: 5603 RVA: 0x0007A9DC File Offset: 0x00078BDC
	public static Color GetPlayerColor(GameActorInfo player)
	{
		if (player == null)
		{
			return Color.white;
		}
		if (player.Cmid == PlayerDataManager.Cmid)
		{
			return Color.green.SetAlpha(0.549019635f);
		}
		if (GameState.Current.GameMode == GameModeType.DeathMatch)
		{
			return new Color(0.5019608f, 0.5019608f, 0.5019608f, 0.549019635f);
		}
		if (player.TeamID == TeamID.BLUE)
		{
			return GUIUtils.ColorBlue.SetAlpha(0.549019635f);
		}
		if (player.TeamID == TeamID.RED)
		{
			return GUIUtils.ColorRed.SetAlpha(0.549019635f);
		}
		return Color.black;
	}

	// Token: 0x060015E4 RID: 5604 RVA: 0x0007AA7C File Offset: 0x00078C7C
	public static void HandleKilledMessage(GameActorInfo shooter, GameActorInfo target, UberstrikeItemClass weapon, BodyPart bodyPart)
	{
		bool flag = GameState.Current.GameMode == GameModeType.None;
		if (flag)
		{
			return;
		}
		if (target == null)
		{
			return;
		}
		if (shooter == null || shooter == target)
		{
			GameData.Instance.OnHUDStreamMessage.Fire(target, LocalizedStrings.NKilledThemself, null);
		}
		else
		{
			string v = string.Empty;
			if (weapon == UberstrikeItemClass.WeaponMelee)
			{
				v = "smacked";
			}
			else if (bodyPart == BodyPart.Head)
			{
				v = "headshot";
			}
			else if (bodyPart == BodyPart.Nuts)
			{
				v = "nutshot";
			}
			else
			{
				v = "killed";
			}
			GameData.Instance.OnHUDStreamMessage.Fire(shooter, v, target);
		}
	}

	// Token: 0x040014A2 RID: 5282
	[SerializeField]
	private UIHorizontalAligner template;

	// Token: 0x040014A3 RID: 5283
	[SerializeField]
	private GameObject container;

	// Token: 0x040014A4 RID: 5284
	[SerializeField]
	private float ySpace = -17f;

	// Token: 0x040014A5 RID: 5285
	[SerializeField]
	private int maxItems = 8;

	// Token: 0x040014A6 RID: 5286
	[SerializeField]
	private float displayTime = 5f;

	// Token: 0x040014A7 RID: 5287
	private List<HUDDesktopEventStream.ItemGfx> itemsGfx = new List<HUDDesktopEventStream.ItemGfx>();

	// Token: 0x040014A8 RID: 5288
	private Queue<HUDDesktopEventStream.Item> items = new Queue<HUDDesktopEventStream.Item>();

	// Token: 0x0200030A RID: 778
	[Serializable]
	public class ItemGfx
	{
		// Token: 0x040014AA RID: 5290
		public UILabel Label1;

		// Token: 0x040014AB RID: 5291
		public UILabel Label2;

		// Token: 0x040014AC RID: 5292
		public UILabel Label3;

		// Token: 0x040014AD RID: 5293
		public UIHorizontalAligner Aligner;
	}

	// Token: 0x0200030B RID: 779
	[Serializable]
	public class Item
	{
		// Token: 0x040014AE RID: 5294
		public string Label1 = string.Empty;

		// Token: 0x040014AF RID: 5295
		public Color Label1EffectColor;

		// Token: 0x040014B0 RID: 5296
		public string Label2 = string.Empty;

		// Token: 0x040014B1 RID: 5297
		public string Label3 = string.Empty;

		// Token: 0x040014B2 RID: 5298
		public Color Label3EffectColor;

		// Token: 0x040014B3 RID: 5299
		public float TimeEnd;
	}
}
