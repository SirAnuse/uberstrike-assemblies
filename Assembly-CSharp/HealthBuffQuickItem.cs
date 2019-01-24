using System;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x0200026C RID: 620
public class HealthBuffQuickItem : QuickItem
{
	// Token: 0x17000437 RID: 1079
	// (get) Token: 0x06001144 RID: 4420 RVA: 0x0000C001 File Offset: 0x0000A201
	// (set) Token: 0x06001145 RID: 4421 RVA: 0x0000C009 File Offset: 0x0000A209
	public override QuickItemConfiguration Configuration
	{
		get
		{
			return this._config;
		}
		set
		{
			this._config = (HealthBuffConfiguration)value;
		}
	}

	// Token: 0x06001146 RID: 4422 RVA: 0x00068CFC File Offset: 0x00066EFC
	protected override void OnActivated()
	{
		if (!this.machine.ContainsState(1))
		{
			this.machine.RegisterState(1, new HealthBuffQuickItem.ActivatedState(this));
		}
		Singleton<QuickItemSfxController>.Instance.ShowThirdPersonEffect(GameState.Current.Player.Character, QuickItemLogic.HealthPack, this._config.RobotLifeTimeMilliSeconds, this._config.ScrapsLifeTimeMilliSeconds, this._config.IsHealInstant);
		GameState.Current.Actions.ActivateQuickItem(QuickItemLogic.HealthPack, this._config.RobotLifeTimeMilliSeconds, this._config.ScrapsLifeTimeMilliSeconds, this._config.IsHealInstant);
		this.machine.SetState(1);
	}

	// Token: 0x06001147 RID: 4423 RVA: 0x0000C017 File Offset: 0x0000A217
	private void Update()
	{
		this.machine.Update();
	}

	// Token: 0x06001148 RID: 4424 RVA: 0x00068DAC File Offset: 0x00066FAC
	private void OnGUI()
	{
		if (base.Behaviour.IsCoolingDown && base.Behaviour.FocusTimeRemaining > 0f)
		{
			float num = Mathf.Clamp((float)Screen.height * 0.03f, 10f, 40f);
			float num2 = num * 10f;
			GUI.Label(new Rect(((float)Screen.width - num2) * 0.5f, (float)(Screen.height / 2 + 20), num2, num), "Charging Health", BlueStonez.label_interparkbold_16pt);
			GUITools.DrawWarmupBar(new Rect(((float)Screen.width - num2) * 0.5f, (float)(Screen.height / 2 + 50), num2, num), base.Behaviour.FocusTimeTotal - base.Behaviour.FocusTimeRemaining, base.Behaviour.FocusTimeTotal);
		}
	}

	// Token: 0x04000E70 RID: 3696
	[SerializeField]
	private HealthBuffConfiguration _config;

	// Token: 0x04000E71 RID: 3697
	private StateMachine machine = new StateMachine();

	// Token: 0x0200026D RID: 621
	private class ActivatedState : IState
	{
		// Token: 0x06001149 RID: 4425 RVA: 0x0000C024 File Offset: 0x0000A224
		public ActivatedState(HealthBuffQuickItem configuration)
		{
			this._item = configuration;
		}

		// Token: 0x0600114A RID: 4426 RVA: 0x00068E78 File Offset: 0x00067078
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

		// Token: 0x0600114B RID: 4427 RVA: 0x00003C87 File Offset: 0x00001E87
		public void OnResume()
		{
		}

		// Token: 0x0600114C RID: 4428 RVA: 0x00003C87 File Offset: 0x00001E87
		public void OnExit()
		{
		}

		// Token: 0x0600114D RID: 4429 RVA: 0x00068EDC File Offset: 0x000670DC
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

		// Token: 0x0600114E RID: 4430 RVA: 0x00068F58 File Offset: 0x00067158
		private void SendHealthIncrease()
		{
			int num;
			switch (this._item._config.HealthIncrease)
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
				throw new NotImplementedException("SendHealthIncrease for type: " + this._item._config.HealthIncrease);
			}
			GameState.Current.Actions.IncreaseHealthAndArmor(num, 0);
			GameState.Current.PlayerData.Health.Value += num;
		}

		// Token: 0x04000E72 RID: 3698
		private HealthBuffQuickItem _item;

		// Token: 0x04000E73 RID: 3699
		private float _nextHealthIncrease;

		// Token: 0x04000E74 RID: 3700
		private float _increaseCounter;
	}
}
