using System;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x02000265 RID: 613
public class ArmorBuffQuickItem : QuickItem
{
	// Token: 0x17000426 RID: 1062
	// (get) Token: 0x060010FF RID: 4351 RVA: 0x0000BC57 File Offset: 0x00009E57
	// (set) Token: 0x06001100 RID: 4352 RVA: 0x0000BC5F File Offset: 0x00009E5F
	public override QuickItemConfiguration Configuration
	{
		get
		{
			return this._config;
		}
		set
		{
			this._config = (ArmorBuffConfiguration)value;
		}
	}

	// Token: 0x06001101 RID: 4353 RVA: 0x00067FF8 File Offset: 0x000661F8
	protected override void OnActivated()
	{
		if (!this.machine.ContainsState(1))
		{
			this.machine.RegisterState(1, new ArmorBuffQuickItem.ActivatedState(this));
		}
		Singleton<QuickItemSfxController>.Instance.ShowThirdPersonEffect(GameState.Current.Player.Character, QuickItemLogic.ArmorPack, this._config.RobotLifeTimeMilliSeconds, this._config.ScrapsLifeTimeMilliSeconds, this._config.IsInstant);
		GameState.Current.Actions.ActivateQuickItem(QuickItemLogic.ArmorPack, this._config.RobotLifeTimeMilliSeconds, this._config.ScrapsLifeTimeMilliSeconds, this._config.IsInstant);
		this.machine.SetState(1);
	}

	// Token: 0x06001102 RID: 4354 RVA: 0x0000BC6D File Offset: 0x00009E6D
	private void Update()
	{
		this.machine.Update();
	}

	// Token: 0x06001103 RID: 4355 RVA: 0x000680A8 File Offset: 0x000662A8
	private void OnGUI()
	{
		if (base.Behaviour.IsCoolingDown && base.Behaviour.FocusTimeRemaining > 0f)
		{
			float num = Mathf.Clamp((float)Screen.height * 0.03f, 10f, 40f);
			float num2 = num * 10f;
			GUI.Label(new Rect(((float)Screen.width - num2) * 0.5f, (float)(Screen.height / 2 + 20), num2, num), "Charging Armor", BlueStonez.label_interparkbold_16pt);
			GUITools.DrawWarmupBar(new Rect(((float)Screen.width - num2) * 0.5f, (float)(Screen.height / 2 + 50), num2, num), base.Behaviour.FocusTimeTotal - base.Behaviour.FocusTimeRemaining, base.Behaviour.FocusTimeTotal);
		}
	}

	// Token: 0x04000E4C RID: 3660
	[SerializeField]
	private ArmorBuffConfiguration _config;

	// Token: 0x04000E4D RID: 3661
	private StateMachine machine = new StateMachine();

	// Token: 0x02000266 RID: 614
	private class ActivatedState : IState
	{
		// Token: 0x06001104 RID: 4356 RVA: 0x0000BC7A File Offset: 0x00009E7A
		public ActivatedState(ArmorBuffQuickItem configuration)
		{
			this._item = configuration;
		}

		// Token: 0x06001105 RID: 4357 RVA: 0x00068174 File Offset: 0x00066374
		public void OnEnter()
		{
			if (this._item._config.IncreaseTimes > 0)
			{
				this._increaseCounter = (float)this._item._config.IncreaseTimes;
				this._nextHealthIncrease = 0f;
			}
			else
			{
				this.SendHealthIncrease();
				this._item.machine.PopState(true);
			}
		}

		// Token: 0x06001106 RID: 4358 RVA: 0x00003C87 File Offset: 0x00001E87
		public void OnResume()
		{
		}

		// Token: 0x06001107 RID: 4359 RVA: 0x00003C87 File Offset: 0x00001E87
		public void OnExit()
		{
		}

		// Token: 0x06001108 RID: 4360 RVA: 0x000681D8 File Offset: 0x000663D8
		public void OnUpdate()
		{
			if (this._nextHealthIncrease < Time.time)
			{
				this._increaseCounter -= 1f;
				this._nextHealthIncrease = Time.time + (float)this._item._config.IncreaseFrequency / 1000f;
				this.SendHealthIncrease();
				if (this._increaseCounter <= 0f)
				{
					this._item.machine.PopState(true);
				}
			}
		}

		// Token: 0x06001109 RID: 4361 RVA: 0x00068254 File Offset: 0x00066454
		private void SendHealthIncrease()
		{
			int num;
			switch (this._item._config.ArmorIncrease)
			{
			case IncreaseStyle.Absolute:
				num = this._item._config.PointsGain;
				break;
			case IncreaseStyle.PercentFromStart:
				num = Mathf.RoundToInt(100f * Mathf.Clamp01((float)this._item._config.PointsGain / 100f));
				break;
			case IncreaseStyle.PercentFromMax:
				num = Mathf.RoundToInt(200f * Mathf.Clamp01((float)this._item._config.PointsGain / 100f));
				break;
			default:
				throw new NotImplementedException("SendArmorIncrease for type: " + this._item._config.ArmorIncrease);
			}
			GameState.Current.Actions.IncreaseHealthAndArmor(0, num);
			GameState.Current.PlayerData.ArmorPoints.Value += num;
		}

		// Token: 0x04000E4E RID: 3662
		private ArmorBuffQuickItem _item;

		// Token: 0x04000E4F RID: 3663
		private float _nextHealthIncrease;

		// Token: 0x04000E50 RID: 3664
		private float _increaseCounter;
	}
}
