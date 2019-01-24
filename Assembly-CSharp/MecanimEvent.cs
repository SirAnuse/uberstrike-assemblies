using System;
using System.Collections.Generic;

// Token: 0x020002EF RID: 751
[Serializable]
public class MecanimEvent
{
	// Token: 0x06001587 RID: 5511 RVA: 0x0000E6E2 File Offset: 0x0000C8E2
	public MecanimEvent()
	{
		this.condition = new EventCondition();
	}

	// Token: 0x06001588 RID: 5512 RVA: 0x00078874 File Offset: 0x00076A74
	public MecanimEvent(MecanimEvent other)
	{
		this.normalizedTime = other.normalizedTime;
		this.functionName = other.functionName;
		this.paramType = other.paramType;
		switch (this.paramType)
		{
		case MecanimEventParamTypes.Int32:
			this.intParam = other.intParam;
			break;
		case MecanimEventParamTypes.Float:
			this.floatParam = other.floatParam;
			break;
		case MecanimEventParamTypes.String:
			this.stringParam = other.stringParam;
			break;
		case MecanimEventParamTypes.Boolean:
			this.boolParam = other.boolParam;
			break;
		}
		this.condition = new EventCondition();
		this.condition.conditions = new List<EventConditionEntry>(other.condition.conditions);
		this.critical = other.critical;
	}

	// Token: 0x17000531 RID: 1329
	// (get) Token: 0x0600158A RID: 5514 RVA: 0x0000E6FD File Offset: 0x0000C8FD
	// (set) Token: 0x06001589 RID: 5513 RVA: 0x0000E6F5 File Offset: 0x0000C8F5
	public static EventContext Context { get; protected set; }

	// Token: 0x17000532 RID: 1330
	// (get) Token: 0x0600158B RID: 5515 RVA: 0x00078948 File Offset: 0x00076B48
	public object parameter
	{
		get
		{
			switch (this.paramType)
			{
			case MecanimEventParamTypes.Int32:
				return this.intParam;
			case MecanimEventParamTypes.Float:
				return this.floatParam;
			case MecanimEventParamTypes.String:
				return this.stringParam;
			case MecanimEventParamTypes.Boolean:
				return this.boolParam;
			default:
				return null;
			}
		}
	}

	// Token: 0x0600158C RID: 5516 RVA: 0x0000E704 File Offset: 0x0000C904
	public void SetContext(EventContext context)
	{
		this.context = context;
		this.context.current = this;
	}

	// Token: 0x0600158D RID: 5517 RVA: 0x0000E719 File Offset: 0x0000C919
	public static void SetCurrentContext(MecanimEvent e)
	{
		MecanimEvent.Context = e.context;
	}

	// Token: 0x0400142E RID: 5166
	public string functionName;

	// Token: 0x0400142F RID: 5167
	public float normalizedTime;

	// Token: 0x04001430 RID: 5168
	public MecanimEventParamTypes paramType;

	// Token: 0x04001431 RID: 5169
	public int intParam;

	// Token: 0x04001432 RID: 5170
	public float floatParam;

	// Token: 0x04001433 RID: 5171
	public string stringParam;

	// Token: 0x04001434 RID: 5172
	public bool boolParam;

	// Token: 0x04001435 RID: 5173
	public EventCondition condition;

	// Token: 0x04001436 RID: 5174
	public bool critical;

	// Token: 0x04001437 RID: 5175
	private EventContext context;
}
