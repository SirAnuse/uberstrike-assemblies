using System;
using System.Text;
using UnityEngine;

// Token: 0x02000252 RID: 594
public class QuickItemBehaviour
{
	// Token: 0x06001062 RID: 4194 RVA: 0x0000B6A1 File Offset: 0x000098A1
	public QuickItemBehaviour(QuickItem item, Action onActivated)
	{
		this._item = item;
		this.OnActivated = onActivated;
		this._machine = new StateMachine();
		this._coolDownState = new QuickItemBehaviour.CoolingDownState(this);
		this._machine.RegisterState(1, this._coolDownState);
	}

	// Token: 0x170003F4 RID: 1012
	// (get) Token: 0x06001063 RID: 4195 RVA: 0x0000B6E0 File Offset: 0x000098E0
	public float CoolDownTimeRemaining
	{
		get
		{
			return Mathf.Max(this._coolDownState.TimeOut - Time.time, 0f);
		}
	}

	// Token: 0x170003F5 RID: 1013
	// (get) Token: 0x06001064 RID: 4196 RVA: 0x0000B6FD File Offset: 0x000098FD
	public float CoolDownTimeTotal
	{
		get
		{
			return (float)this._item.Configuration.CoolDownTime / 1000f;
		}
	}

	// Token: 0x170003F6 RID: 1014
	// (get) Token: 0x06001065 RID: 4197 RVA: 0x0000B716 File Offset: 0x00009916
	public float FocusTimeRemaining
	{
		get
		{
			return 0f;
		}
	}

	// Token: 0x170003F7 RID: 1015
	// (get) Token: 0x06001066 RID: 4198 RVA: 0x0000B71D File Offset: 0x0000991D
	public float FocusTimeTotal
	{
		get
		{
			return (float)this._item.Configuration.WarmUpTime / 1000f;
		}
	}

	// Token: 0x170003F8 RID: 1016
	// (get) Token: 0x06001067 RID: 4199 RVA: 0x0000B736 File Offset: 0x00009936
	public float ChargingTimeRemaining
	{
		get
		{
			return Mathf.Max(this._chargeTimeOut - Time.time, 0f);
		}
	}

	// Token: 0x170003F9 RID: 1017
	// (get) Token: 0x06001068 RID: 4200 RVA: 0x0000B74E File Offset: 0x0000994E
	public float ChargingTimeTotal
	{
		get
		{
			return (float)this._item.Configuration.RechargeTime / 1000f;
		}
	}

	// Token: 0x170003FA RID: 1018
	// (get) Token: 0x06001069 RID: 4201 RVA: 0x0000B767 File Offset: 0x00009967
	public bool IsCoolingDown
	{
		get
		{
			return this._machine.CurrentStateId > 0;
		}
	}

	// Token: 0x170003FB RID: 1019
	// (get) Token: 0x0600106A RID: 4202 RVA: 0x0000B777 File Offset: 0x00009977
	public float CooldownProgress
	{
		get
		{
			return (!this.IsCoolingDown) ? 1f : (1f - this.CoolDownTimeRemaining / this.CoolDownTimeTotal);
		}
	}

	// Token: 0x0600106B RID: 4203 RVA: 0x00065FD8 File Offset: 0x000641D8
	private void Activate()
	{
		if (this.CurrentAmount == this._item.Configuration.AmountRemaining)
		{
			this._chargeTimeOut = Time.time + (float)this._item.Configuration.RechargeTime / 1000f;
		}
		if (this._item.Configuration.CoolDownTime > 0)
		{
			this._machine.PushState(1);
		}
		this.CurrentAmount--;
		GameData.Instance.OnQuickItemsChanged.Fire();
		if (this.OnActivated != null)
		{
			this.OnActivated();
		}
	}

	// Token: 0x0600106C RID: 4204 RVA: 0x0000B7A1 File Offset: 0x000099A1
	public bool Run()
	{
		if (this.CurrentAmount > 0 && this._machine.CurrentStateId == 0)
		{
			AutoMonoBehaviour<UnityRuntime>.Instance.OnUpdate += this.Update;
			this.Activate();
			return true;
		}
		return false;
	}

	// Token: 0x0600106D RID: 4205 RVA: 0x00066078 File Offset: 0x00064278
	private void Update()
	{
		this._machine.Update();
		if (this._item.Configuration.RechargeTime > 0 && this._chargeTimeOut < Time.time && this.CurrentAmount < this._item.Configuration.AmountRemaining)
		{
			this.CurrentAmount = Mathf.Min(this.CurrentAmount + 1, this._item.Configuration.AmountRemaining);
			GameData.Instance.OnQuickItemsChanged.Fire();
			if (this.CurrentAmount < this._item.Configuration.AmountRemaining)
			{
				this._chargeTimeOut = Time.time + (float)this._item.Configuration.RechargeTime / 1000f;
			}
		}
		if (this._machine.CurrentStateId == 0 && this.CurrentAmount == this._item.Configuration.AmountRemaining)
		{
			AutoMonoBehaviour<UnityRuntime>.Instance.OnUpdate -= this.Update;
		}
	}

	// Token: 0x0600106E RID: 4206 RVA: 0x00066184 File Offset: 0x00064384
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("Name: " + this._item.Configuration.Name);
		stringBuilder.AppendLine("IsBusy: " + this.IsCoolingDown);
		stringBuilder.AppendLine("State: " + this._machine.CurrentStateId);
		stringBuilder.AppendLine("Amount Current: " + this.CurrentAmount);
		stringBuilder.AppendLine("Amount Total: " + this._item.Configuration.AmountRemaining);
		stringBuilder.AppendLine("Time: " + this.CoolDownTimeRemaining.ToString("F2") + " || " + this.ChargingTimeRemaining.ToString("F2"));
		return stringBuilder.ToString();
	}

	// Token: 0x04000DFE RID: 3582
	private StateMachine _machine;

	// Token: 0x04000DFF RID: 3583
	private QuickItemBehaviour.CoolingDownState _coolDownState;

	// Token: 0x04000E00 RID: 3584
	private QuickItem _item;

	// Token: 0x04000E01 RID: 3585
	private float _chargeTimeOut;

	// Token: 0x04000E02 RID: 3586
	public Action OnActivated;

	// Token: 0x04000E03 RID: 3587
	public int CurrentAmount;

	// Token: 0x04000E04 RID: 3588
	public GameInputKey FocusKey;

	// Token: 0x02000253 RID: 595
	private enum States
	{
		// Token: 0x04000E06 RID: 3590
		CoolingDown = 1
	}

	// Token: 0x02000254 RID: 596
	private class CoolingDownState : IState
	{
		// Token: 0x0600106F RID: 4207 RVA: 0x0000B7DE File Offset: 0x000099DE
		public CoolingDownState(QuickItemBehaviour behaviour)
		{
			this.behaviour = behaviour;
		}

		// Token: 0x170003FC RID: 1020
		// (get) Token: 0x06001070 RID: 4208 RVA: 0x0000B7ED File Offset: 0x000099ED
		// (set) Token: 0x06001071 RID: 4209 RVA: 0x0000B7F5 File Offset: 0x000099F5
		public float TimeOut { get; private set; }

		// Token: 0x06001072 RID: 4210 RVA: 0x0000B7FE File Offset: 0x000099FE
		public void OnEnter()
		{
			this.TimeOut = Time.time + (float)this.behaviour._item.Configuration.CoolDownTime / 1000f;
		}

		// Token: 0x06001073 RID: 4211 RVA: 0x00003C87 File Offset: 0x00001E87
		public void OnResume()
		{
		}

		// Token: 0x06001074 RID: 4212 RVA: 0x00003C87 File Offset: 0x00001E87
		public void OnExit()
		{
		}

		// Token: 0x06001075 RID: 4213 RVA: 0x0006627C File Offset: 0x0006447C
		public void OnUpdate()
		{
			GameData.Instance.OnQuickItemsCooldown.Fire(Array.IndexOf<QuickItem>(Singleton<QuickItemController>.Instance.QuickItems, this.behaviour._item), this.behaviour.CooldownProgress);
			float num = Mathf.Clamp01(this.behaviour.CoolDownTimeRemaining / this.behaviour.CoolDownTimeTotal);
			if (num == 0f)
			{
				this.behaviour._machine.PopState(true);
			}
		}

		// Token: 0x04000E07 RID: 3591
		private QuickItemBehaviour behaviour;
	}
}
