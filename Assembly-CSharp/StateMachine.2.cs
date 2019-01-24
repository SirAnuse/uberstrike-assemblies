using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000411 RID: 1041
public class StateMachine<T> where T : struct, IConvertible
{
	// Token: 0x06001D8D RID: 7565 RVA: 0x0001396F File Offset: 0x00011B6F
	public StateMachine()
	{
		this.registeredStates = new Dictionary<T, IState>();
		this.stateStack = new Stack<T>();
	}

	// Token: 0x14000026 RID: 38
	// (add) Token: 0x06001D8E RID: 7566 RVA: 0x00013998 File Offset: 0x00011B98
	// (remove) Token: 0x06001D8F RID: 7567 RVA: 0x000139B1 File Offset: 0x00011BB1
	public event Action<T> OnChanged;

	// Token: 0x1700066E RID: 1646
	// (get) Token: 0x06001D90 RID: 7568 RVA: 0x00092CDC File Offset: 0x00090EDC
	public T CurrentStateId
	{
		get
		{
			return (this.stateStack.Count <= 0) ? default(T) : this.stateStack.Peek();
		}
	}

	// Token: 0x06001D91 RID: 7569 RVA: 0x00092D14 File Offset: 0x00090F14
	public void SetState(T stateId)
	{
		if (this.ContainsState(stateId))
		{
			if (!stateId.Equals(this.CurrentStateId))
			{
				this.PopAllStates();
				this.stateStack.Push(stateId);
				this.GetState(stateId).OnEnter();
				if (this.OnChanged != null)
				{
					this.OnChanged(stateId);
				}
			}
			return;
		}
		throw new Exception("Unsupported state of type: " + stateId);
	}

	// Token: 0x06001D92 RID: 7570 RVA: 0x00092D9C File Offset: 0x00090F9C
	public void PushState(T stateId)
	{
		if (this.ContainsState(stateId))
		{
			if (!this.stateStack.Contains(stateId))
			{
				this.stateStack.Push(stateId);
				this.GetState(stateId).OnEnter();
				if (this.OnChanged != null)
				{
					this.OnChanged(stateId);
				}
			}
		}
		else
		{
			Debug.LogWarning("Unsupported state of type: " + stateId);
		}
	}

	// Token: 0x06001D93 RID: 7571 RVA: 0x00092E10 File Offset: 0x00091010
	public void PopState(bool resume = true)
	{
		if (this.stateStack.Count != 0)
		{
			this.CurrentState.OnExit();
			this.stateStack.Pop();
			if (resume && this.stateStack.Count != 0)
			{
				this.CurrentState.OnResume();
			}
			if (this.OnChanged != null && this.stateStack.Count > 0)
			{
				this.OnChanged(this.stateStack.Peek());
			}
		}
	}

	// Token: 0x06001D94 RID: 7572 RVA: 0x00092E98 File Offset: 0x00091098
	public void Reset()
	{
		this.PopAllStates();
		this.stateStack.Clear();
		this.registeredStates.Clear();
		this.Events.Clear();
		if (this.OnChanged != null)
		{
			this.OnChanged(default(T));
		}
	}

	// Token: 0x06001D95 RID: 7573 RVA: 0x00092EEC File Offset: 0x000910EC
	public void PopAllStates()
	{
		while (this.stateStack.Count > 0)
		{
			this.PopState(false);
		}
		if (this.OnChanged != null)
		{
			this.OnChanged(default(T));
		}
	}

	// Token: 0x06001D96 RID: 7574 RVA: 0x000139CA File Offset: 0x00011BCA
	public void RegisterState(T stateId, IState state)
	{
		if (!this.registeredStates.ContainsKey(stateId))
		{
			this.registeredStates.Add(stateId, state);
			return;
		}
		throw new Exception("StateMachine::RegisterState - state [" + stateId + "] already exists in the current registry");
	}

	// Token: 0x06001D97 RID: 7575 RVA: 0x00013A0A File Offset: 0x00011C0A
	public bool ContainsState(T stateId)
	{
		return this.registeredStates.ContainsKey(stateId);
	}

	// Token: 0x06001D98 RID: 7576 RVA: 0x00013A18 File Offset: 0x00011C18
	public void Update()
	{
		if (this.stateStack.Count > 0)
		{
			this.CurrentState.OnUpdate();
		}
	}

	// Token: 0x06001D99 RID: 7577 RVA: 0x00092F38 File Offset: 0x00091138
	public IState GetState(T stateId)
	{
		IState result;
		this.registeredStates.TryGetValue(stateId, out result);
		return result;
	}

	// Token: 0x1700066F RID: 1647
	// (get) Token: 0x06001D9A RID: 7578 RVA: 0x00013A36 File Offset: 0x00011C36
	private IState CurrentState
	{
		get
		{
			return this.GetState(this.CurrentStateId);
		}
	}

	// Token: 0x040019D2 RID: 6610
	public readonly global::EventHandler Events = new global::EventHandler();

	// Token: 0x040019D3 RID: 6611
	private Dictionary<T, IState> registeredStates;

	// Token: 0x040019D4 RID: 6612
	private Stack<T> stateStack;
}
