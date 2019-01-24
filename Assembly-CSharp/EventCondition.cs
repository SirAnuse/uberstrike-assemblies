using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002F0 RID: 752
[Serializable]
public class EventCondition
{
	// Token: 0x0600158F RID: 5519 RVA: 0x000789A8 File Offset: 0x00076BA8
	public bool Test(Animator animator)
	{
		if (this.conditions.Count == 0)
		{
			return true;
		}
		foreach (EventConditionEntry eventConditionEntry in this.conditions)
		{
			if (!string.IsNullOrEmpty(eventConditionEntry.conditionParam))
			{
				switch (eventConditionEntry.conditionParamType)
				{
				case EventConditionParamTypes.Int:
				{
					int integer = animator.GetInteger(eventConditionEntry.conditionParam);
					switch (eventConditionEntry.conditionMode)
					{
					case EventConditionModes.Equal:
						if (integer != eventConditionEntry.intValue)
						{
							return false;
						}
						break;
					case EventConditionModes.NotEqual:
						if (integer == eventConditionEntry.intValue)
						{
							return false;
						}
						break;
					case EventConditionModes.GreaterThan:
						if (integer <= eventConditionEntry.intValue)
						{
							return false;
						}
						break;
					case EventConditionModes.LessThan:
						if (integer >= eventConditionEntry.intValue)
						{
							return false;
						}
						break;
					case EventConditionModes.GreaterEqualThan:
						if (integer < eventConditionEntry.intValue)
						{
							return false;
						}
						break;
					case EventConditionModes.LessEqualThan:
						if (integer > eventConditionEntry.intValue)
						{
							return false;
						}
						break;
					}
					break;
				}
				case EventConditionParamTypes.Float:
				{
					float @float = animator.GetFloat(eventConditionEntry.conditionParam);
					EventConditionModes conditionMode = eventConditionEntry.conditionMode;
					if (conditionMode != EventConditionModes.GreaterThan)
					{
						if (conditionMode == EventConditionModes.LessThan)
						{
							if (@float >= eventConditionEntry.floatValue)
							{
								return false;
							}
						}
					}
					else if (@float <= eventConditionEntry.floatValue)
					{
						return false;
					}
					break;
				}
				case EventConditionParamTypes.Boolean:
				{
					bool @bool = animator.GetBool(eventConditionEntry.conditionParam);
					if (@bool != eventConditionEntry.boolValue)
					{
						return false;
					}
					break;
				}
				}
			}
		}
		return true;
	}

	// Token: 0x04001439 RID: 5177
	public List<EventConditionEntry> conditions = new List<EventConditionEntry>();
}
