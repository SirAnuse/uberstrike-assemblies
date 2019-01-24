using System;
using System.IO;
using UberStrike.Core.Serialization;
using UnityEngine;

// Token: 0x020002C1 RID: 705
public class AxisInputChannel : IInputChannel
{
	// Token: 0x0600139E RID: 5022 RVA: 0x0000D5A7 File Offset: 0x0000B7A7
	public AxisInputChannel(string axis)
	{
		this._axis = axis;
		this._axisName = this._axis;
	}

	// Token: 0x0600139F RID: 5023 RVA: 0x0000D5E3 File Offset: 0x0000B7E3
	public AxisInputChannel(string axis, float deadRange) : this(axis)
	{
		this._deadRange = deadRange;
	}

	// Token: 0x060013A0 RID: 5024 RVA: 0x00071630 File Offset: 0x0006F830
	public AxisInputChannel(string axis, float deadRange, AxisInputChannel.AxisReadingMethod method) : this(axis, deadRange)
	{
		this._axisReading = method;
		if (method != AxisInputChannel.AxisReadingMethod.PositiveOnly)
		{
			if (method == AxisInputChannel.AxisReadingMethod.NegativeOnly)
			{
				this._axisName += " Up";
			}
		}
		else
		{
			this._axisName += " Down";
		}
	}

	// Token: 0x060013A1 RID: 5025 RVA: 0x00071698 File Offset: 0x0006F898
	public void Listen()
	{
		this._lastValue = this._value;
		this._value = this.RawValue();
		AxisInputChannel.AxisReadingMethod axisReading = this._axisReading;
		if (axisReading != AxisInputChannel.AxisReadingMethod.PositiveOnly)
		{
			if (axisReading == AxisInputChannel.AxisReadingMethod.NegativeOnly)
			{
				if (this._value > 0f)
				{
					this._value = 0f;
				}
			}
		}
		else if (this._value < 0f)
		{
			this._value = 0f;
		}
		if (Mathf.Abs(this._value) < this._deadRange)
		{
			this._value = 0f;
		}
	}

	// Token: 0x060013A2 RID: 5026 RVA: 0x0000D5F3 File Offset: 0x0000B7F3
	public void Reset()
	{
		this._value = 0f;
		this._lastValue = 0f;
	}

	// Token: 0x060013A3 RID: 5027 RVA: 0x0000D60B File Offset: 0x0000B80B
	public float RawValue()
	{
		return Input.GetAxis(this._axis);
	}

	// Token: 0x060013A4 RID: 5028 RVA: 0x0000D618 File Offset: 0x0000B818
	public override string ToString()
	{
		return this._axis;
	}

	// Token: 0x060013A5 RID: 5029 RVA: 0x00071738 File Offset: 0x0006F938
	public override bool Equals(object obj)
	{
		if (obj is AxisInputChannel)
		{
			AxisInputChannel axisInputChannel = obj as AxisInputChannel;
			if (axisInputChannel.Axis == this.Axis)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060013A6 RID: 5030 RVA: 0x0000D49E File Offset: 0x0000B69E
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	// Token: 0x170004B3 RID: 1203
	// (get) Token: 0x060013A7 RID: 5031 RVA: 0x0000D618 File Offset: 0x0000B818
	public string Axis
	{
		get
		{
			return this._axis;
		}
	}

	// Token: 0x170004B4 RID: 1204
	// (get) Token: 0x060013A8 RID: 5032 RVA: 0x0000D620 File Offset: 0x0000B820
	public string Name
	{
		get
		{
			return this._axisName;
		}
	}

	// Token: 0x170004B5 RID: 1205
	// (get) Token: 0x060013A9 RID: 5033 RVA: 0x0000D628 File Offset: 0x0000B828
	// (set) Token: 0x060013AA RID: 5034 RVA: 0x00071770 File Offset: 0x0006F970
	public float Value
	{
		get
		{
			return this._value;
		}
		set
		{
			this._lastValue = value;
			this._value = value;
		}
	}

	// Token: 0x170004B6 RID: 1206
	// (get) Token: 0x060013AB RID: 5035 RVA: 0x0000505C File Offset: 0x0000325C
	public InputChannelType ChannelType
	{
		get
		{
			return InputChannelType.Axis;
		}
	}

	// Token: 0x170004B7 RID: 1207
	// (get) Token: 0x060013AC RID: 5036 RVA: 0x0000D630 File Offset: 0x0000B830
	public bool IsPressed
	{
		get
		{
			return this._value != 0f;
		}
	}

	// Token: 0x170004B8 RID: 1208
	// (get) Token: 0x060013AD RID: 5037 RVA: 0x0000D642 File Offset: 0x0000B842
	public bool IsChanged
	{
		get
		{
			return this._lastValue != this._value;
		}
	}

	// Token: 0x060013AE RID: 5038 RVA: 0x0000D655 File Offset: 0x0000B855
	public void Serialize(MemoryStream stream)
	{
		StringProxy.Serialize(stream, this._axis);
		SingleProxy.Serialize(stream, this._deadRange);
		EnumProxy<AxisInputChannel.AxisReadingMethod>.Serialize(stream, this._axisReading);
	}

	// Token: 0x060013AF RID: 5039 RVA: 0x00071790 File Offset: 0x0006F990
	public static AxisInputChannel FromBytes(MemoryStream stream)
	{
		string axis = StringProxy.Deserialize(stream);
		float deadRange = SingleProxy.Deserialize(stream);
		AxisInputChannel.AxisReadingMethod method = EnumProxy<AxisInputChannel.AxisReadingMethod>.Deserialize(stream);
		return new AxisInputChannel(axis, deadRange, method);
	}

	// Token: 0x0400134A RID: 4938
	private string _axis = string.Empty;

	// Token: 0x0400134B RID: 4939
	private string _axisName = string.Empty;

	// Token: 0x0400134C RID: 4940
	private float _value;

	// Token: 0x0400134D RID: 4941
	private float _lastValue;

	// Token: 0x0400134E RID: 4942
	private float _deadRange = 0.1f;

	// Token: 0x0400134F RID: 4943
	private AxisInputChannel.AxisReadingMethod _axisReading;

	// Token: 0x020002C2 RID: 706
	public enum AxisReadingMethod
	{
		// Token: 0x04001351 RID: 4945
		All,
		// Token: 0x04001352 RID: 4946
		PositiveOnly,
		// Token: 0x04001353 RID: 4947
		NegativeOnly
	}
}
