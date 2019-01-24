using System;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x02000262 RID: 610
public class AmmoBuffQuickItem : QuickItem
{
	// Token: 0x17000422 RID: 1058
	// (get) Token: 0x060010EE RID: 4334 RVA: 0x0000BBEE File Offset: 0x00009DEE
	// (set) Token: 0x060010EF RID: 4335 RVA: 0x0000BBF6 File Offset: 0x00009DF6
	public override QuickItemConfiguration Configuration
	{
		get
		{
			return this._config;
		}
		set
		{
			this._config = (AmmoBuffConfiguration)value;
		}
	}

	// Token: 0x060010F0 RID: 4336 RVA: 0x00067B24 File Offset: 0x00065D24
	protected override void OnActivated()
	{
		if (!this.machine.ContainsState(1))
		{
			this.machine.RegisterState(1, new AmmoBuffQuickItem.ActivatedState(this));
		}
		Singleton<QuickItemSfxController>.Instance.ShowThirdPersonEffect(GameState.Current.Player.Character, QuickItemLogic.AmmoPack, this._config.RobotLifeTimeMilliSeconds, this._config.ScrapsLifeTimeMilliSeconds, this._config.IsInstant);
		GameState.Current.Actions.ActivateQuickItem(QuickItemLogic.AmmoPack, this._config.RobotLifeTimeMilliSeconds, this._config.ScrapsLifeTimeMilliSeconds, this._config.IsInstant);
		this.machine.SetState(1);
	}

	// Token: 0x060010F1 RID: 4337 RVA: 0x0000BC04 File Offset: 0x00009E04
	private void Update()
	{
		this.machine.Update();
	}

	// Token: 0x060010F2 RID: 4338 RVA: 0x00067BD4 File Offset: 0x00065DD4
	private void OnGUI()
	{
		if (base.Behaviour.IsCoolingDown && base.Behaviour.FocusTimeRemaining > 0f)
		{
			float num = Mathf.Clamp((float)Screen.height * 0.03f, 10f, 40f);
			float num2 = num * 10f;
			GUI.Label(new Rect(((float)Screen.width - num2) * 0.5f, (float)(Screen.height / 2 + 20), num2, num), "Charging Ammo", BlueStonez.label_interparkbold_16pt);
			GUITools.DrawWarmupBar(new Rect(((float)Screen.width - num2) * 0.5f, (float)(Screen.height / 2 + 50), num2, num), base.Behaviour.FocusTimeTotal - base.Behaviour.FocusTimeRemaining, base.Behaviour.FocusTimeTotal);
		}
	}

	// Token: 0x04000E3F RID: 3647
	[SerializeField]
	private AmmoBuffConfiguration _config;

	// Token: 0x04000E40 RID: 3648
	private StateMachine machine = new StateMachine();

	// Token: 0x02000263 RID: 611
	private class ActivatedState : IState
	{
		// Token: 0x060010F3 RID: 4339 RVA: 0x0000BC11 File Offset: 0x00009E11
		public ActivatedState(AmmoBuffQuickItem configuration)
		{
			this._item = configuration;
		}

		// Token: 0x060010F4 RID: 4340 RVA: 0x00067CA0 File Offset: 0x00065EA0
		public void OnEnter()
		{
			if (this._item._config.IncreaseTimes > 0)
			{
				this._increaseCounter = (float)this._item._config.IncreaseTimes;
				this._nextHealthIncrease = 0f;
			}
			else
			{
				this.SendAmmoIncrease();
				this._item.machine.PopState(true);
			}
		}

		// Token: 0x060010F5 RID: 4341 RVA: 0x00003C87 File Offset: 0x00001E87
		public void OnExit()
		{
		}

		// Token: 0x060010F6 RID: 4342 RVA: 0x00003C87 File Offset: 0x00001E87
		public void OnResume()
		{
		}

		// Token: 0x060010F7 RID: 4343 RVA: 0x00067D04 File Offset: 0x00065F04
		public void OnUpdate()
		{
			if (this._nextHealthIncrease < Time.time)
			{
				this._increaseCounter -= 1f;
				this._nextHealthIncrease = Time.time + (float)this._item._config.IncreaseFrequency / 1000f;
				this.SendAmmoIncrease();
				if (this._increaseCounter <= 0f)
				{
					this._item.machine.PopState(true);
				}
			}
		}

		// Token: 0x060010F8 RID: 4344 RVA: 0x00067D80 File Offset: 0x00065F80
		private void SendAmmoIncrease()
		{
			switch (this._item._config.AmmoIncrease)
			{
			case IncreaseStyle.Absolute:
				foreach (object obj in Enum.GetValues(typeof(AmmoType)))
				{
					AmmoType t = (AmmoType)((int)obj);
					AmmoDepot.AddAmmoOfType(t, this._item._config.PointsGain);
				}
				break;
			case IncreaseStyle.PercentFromStart:
				foreach (object obj2 in Enum.GetValues(typeof(AmmoType)))
				{
					AmmoType t2 = (AmmoType)((int)obj2);
					AmmoDepot.AddStartAmmoOfType(t2, (float)this._item._config.PointsGain / 100f);
				}
				break;
			case IncreaseStyle.PercentFromMax:
				foreach (object obj3 in Enum.GetValues(typeof(AmmoType)))
				{
					AmmoType t3 = (AmmoType)((int)obj3);
					AmmoDepot.AddMaxAmmoOfType(t3, (float)this._item._config.PointsGain / 100f);
				}
				break;
			default:
				throw new NotImplementedException("SendAmmoIncrease for type: " + this._item._config.AmmoIncrease);
			}
		}

		// Token: 0x04000E41 RID: 3649
		private AmmoBuffQuickItem _item;

		// Token: 0x04000E42 RID: 3650
		private float _nextHealthIncrease;

		// Token: 0x04000E43 RID: 3651
		private float _increaseCounter;
	}
}
