using System;
using System.IO;
using UberStrike.Core.Serialization;
using UnityEngine;

// Token: 0x020002C3 RID: 707
public class ButtonInputChannel : IInputChannel
{
	// Token: 0x060013B0 RID: 5040 RVA: 0x0000D67B File Offset: 0x0000B87B
	public ButtonInputChannel(string button)
	{
		this._button = button;
	}

	// Token: 0x060013B1 RID: 5041 RVA: 0x0000D695 File Offset: 0x0000B895
	public void Listen()
	{
		this._wasDown = this._isDown;
		this._isDown = (Input.GetButton(this._button) && !Input.GetMouseButton(0));
	}

	// Token: 0x060013B2 RID: 5042 RVA: 0x0000D6C5 File Offset: 0x0000B8C5
	public void Reset()
	{
		this._wasDown = false;
		this._isDown = false;
	}

	// Token: 0x060013B3 RID: 5043 RVA: 0x0000D6D5 File Offset: 0x0000B8D5
	public float RawValue()
	{
		return (float)((!Input.GetButton(this._button)) ? 0 : 1);
	}

	// Token: 0x060013B4 RID: 5044 RVA: 0x0000D6EF File Offset: 0x0000B8EF
	public override string ToString()
	{
		return this._button;
	}

	// Token: 0x060013B5 RID: 5045 RVA: 0x000717BC File Offset: 0x0006F9BC
	public override bool Equals(object obj)
	{
		if (obj is ButtonInputChannel)
		{
			ButtonInputChannel buttonInputChannel = obj as ButtonInputChannel;
			if (buttonInputChannel.Button == this.Button)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060013B6 RID: 5046 RVA: 0x0000D49E File Offset: 0x0000B69E
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	// Token: 0x170004B9 RID: 1209
	// (get) Token: 0x060013B7 RID: 5047 RVA: 0x0000D6EF File Offset: 0x0000B8EF
	public string Button
	{
		get
		{
			return this._button;
		}
	}

	// Token: 0x170004BA RID: 1210
	// (get) Token: 0x060013B8 RID: 5048 RVA: 0x0000D6EF File Offset: 0x0000B8EF
	public string Name
	{
		get
		{
			return this._button;
		}
	}

	// Token: 0x170004BB RID: 1211
	// (get) Token: 0x060013B9 RID: 5049 RVA: 0x0000D6F7 File Offset: 0x0000B8F7
	public float Value
	{
		get
		{
			return (float)((!this._isDown) ? 0 : 1);
		}
	}

	// Token: 0x170004BC RID: 1212
	// (get) Token: 0x060013BA RID: 5050 RVA: 0x0000505C File Offset: 0x0000325C
	public InputChannelType ChannelType
	{
		get
		{
			return InputChannelType.Axis;
		}
	}

	// Token: 0x170004BD RID: 1213
	// (get) Token: 0x060013BB RID: 5051 RVA: 0x0000D70C File Offset: 0x0000B90C
	public bool IsPressed
	{
		get
		{
			return this._isDown;
		}
	}

	// Token: 0x170004BE RID: 1214
	// (get) Token: 0x060013BC RID: 5052 RVA: 0x0000D714 File Offset: 0x0000B914
	public bool IsChanged
	{
		get
		{
			return this._wasDown != this._isDown;
		}
	}

	// Token: 0x060013BD RID: 5053 RVA: 0x0000D727 File Offset: 0x0000B927
	public void Serialize(MemoryStream stream)
	{
		StringProxy.Serialize(stream, this._button);
	}

	// Token: 0x060013BE RID: 5054 RVA: 0x000717F4 File Offset: 0x0006F9F4
	public static ButtonInputChannel FromBytes(MemoryStream stream)
	{
		string button = StringProxy.Deserialize(stream);
		return new ButtonInputChannel(button);
	}

	// Token: 0x04001354 RID: 4948
	private bool _isDown;

	// Token: 0x04001355 RID: 4949
	private bool _wasDown;

	// Token: 0x04001356 RID: 4950
	private string _button = string.Empty;
}
