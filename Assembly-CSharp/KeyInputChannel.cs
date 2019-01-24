using System;
using System.IO;
using UberStrike.Core.Serialization;
using UnityEngine;

// Token: 0x020002BF RID: 703
public class KeyInputChannel : IInputChannel
{
	// Token: 0x0600137E RID: 4990 RVA: 0x0000D423 File Offset: 0x0000B623
	public KeyInputChannel(KeyCode positiveKey)
	{
		this._positiveKey = positiveKey;
		this.InitKeyName();
	}

	// Token: 0x0600137F RID: 4991 RVA: 0x00071158 File Offset: 0x0006F358
	private void InitKeyName()
	{
		KeyCode positiveKey = this._positiveKey;
		switch (positiveKey)
		{
		case KeyCode.Keypad0:
			this._name = "Keypad 0";
			break;
		case KeyCode.Keypad1:
			this._name = "Keypad 1";
			break;
		case KeyCode.Keypad2:
			this._name = "Keypad 2";
			break;
		case KeyCode.Keypad3:
			this._name = "Keypad 3";
			break;
		case KeyCode.Keypad4:
			this._name = "Keypad 4";
			break;
		case KeyCode.Keypad5:
			this._name = "Keypad 5";
			break;
		case KeyCode.Keypad6:
			this._name = "Keypad 6";
			break;
		case KeyCode.Keypad7:
			this._name = "Keypad 7";
			break;
		case KeyCode.Keypad8:
			this._name = "Keypad 8";
			break;
		case KeyCode.Keypad9:
			this._name = "Keypad 9";
			break;
		case KeyCode.KeypadPeriod:
			this._name = "Keypad Period";
			break;
		case KeyCode.KeypadDivide:
			this._name = "Keypad Divide";
			break;
		case KeyCode.KeypadMultiply:
			this._name = "Keypad Multiply";
			break;
		case KeyCode.KeypadMinus:
			this._name = "Keypad Minus";
			break;
		case KeyCode.KeypadPlus:
			this._name = "Keypad Plus";
			break;
		case KeyCode.KeypadEnter:
			this._name = "Keypad Enter";
			break;
		case KeyCode.KeypadEquals:
			this._name = "Keypad Equals";
			break;
		case KeyCode.UpArrow:
			this._name = "Up Arrow";
			break;
		case KeyCode.DownArrow:
			this._name = "Down Arrow";
			break;
		case KeyCode.RightArrow:
			this._name = "Right Arrow";
			break;
		case KeyCode.LeftArrow:
			this._name = "Left Arrow";
			break;
		default:
			switch (positiveKey)
			{
			case KeyCode.Alpha0:
				this._name = "0";
				break;
			case KeyCode.Alpha1:
				this._name = "1";
				break;
			case KeyCode.Alpha2:
				this._name = "2";
				break;
			case KeyCode.Alpha3:
				this._name = "3";
				break;
			case KeyCode.Alpha4:
				this._name = "4";
				break;
			case KeyCode.Alpha5:
				this._name = "5";
				break;
			case KeyCode.Alpha6:
				this._name = "6";
				break;
			case KeyCode.Alpha7:
				this._name = "7";
				break;
			case KeyCode.Alpha8:
				this._name = "8";
				break;
			case KeyCode.Alpha9:
				this._name = "9";
				break;
			default:
				this._name = this._positiveKey.ToString();
				break;
			}
			break;
		case KeyCode.RightShift:
			this._name = "Right Shift";
			break;
		case KeyCode.LeftShift:
			this._name = "Left Shift";
			break;
		case KeyCode.RightControl:
			this._name = "Right Ctrl";
			break;
		case KeyCode.LeftControl:
			this._name = "Left Ctrl";
			break;
		case KeyCode.RightAlt:
			this._name = "Right Alt";
			break;
		case KeyCode.LeftAlt:
			this._name = "Left Alt";
			break;
		}
	}

	// Token: 0x06001380 RID: 4992 RVA: 0x0000D443 File Offset: 0x0000B643
	public void Listen()
	{
		this._wasDown = this._isDown;
		this._isDown = Input.GetKey(this._positiveKey);
	}

	// Token: 0x06001381 RID: 4993 RVA: 0x0000D462 File Offset: 0x0000B662
	public void Reset()
	{
		this._wasDown = false;
		this._isDown = false;
	}

	// Token: 0x06001382 RID: 4994 RVA: 0x0000D472 File Offset: 0x0000B672
	public float RawValue()
	{
		return (float)((!Input.GetKey(this._positiveKey)) ? 0 : 1);
	}

	// Token: 0x06001383 RID: 4995 RVA: 0x0000D48C File Offset: 0x0000B68C
	public override string ToString()
	{
		return this._positiveKey.ToString();
	}

	// Token: 0x06001384 RID: 4996 RVA: 0x000714F0 File Offset: 0x0006F6F0
	public override bool Equals(object obj)
	{
		if (obj is KeyInputChannel)
		{
			KeyInputChannel keyInputChannel = obj as KeyInputChannel;
			if (keyInputChannel.Key == this.Key)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06001385 RID: 4997 RVA: 0x0000D49E File Offset: 0x0000B69E
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	// Token: 0x170004A9 RID: 1193
	// (get) Token: 0x06001386 RID: 4998 RVA: 0x0000D4A6 File Offset: 0x0000B6A6
	public KeyCode Key
	{
		get
		{
			return this._positiveKey;
		}
	}

	// Token: 0x170004AA RID: 1194
	// (get) Token: 0x06001387 RID: 4999 RVA: 0x0000D4AE File Offset: 0x0000B6AE
	public string Name
	{
		get
		{
			return this._name;
		}
	}

	// Token: 0x170004AB RID: 1195
	// (get) Token: 0x06001388 RID: 5000 RVA: 0x00003C84 File Offset: 0x00001E84
	public InputChannelType ChannelType
	{
		get
		{
			return InputChannelType.Key;
		}
	}

	// Token: 0x170004AC RID: 1196
	// (get) Token: 0x06001389 RID: 5001 RVA: 0x0000D4B6 File Offset: 0x0000B6B6
	// (set) Token: 0x0600138A RID: 5002 RVA: 0x00071524 File Offset: 0x0006F724
	public float Value
	{
		get
		{
			return (float)((!this._isDown) ? 0 : 1);
		}
		set
		{
			this._isDown = (this._wasDown = ((value == 0f) ? false : true));
		}
	}

	// Token: 0x170004AD RID: 1197
	// (get) Token: 0x0600138B RID: 5003 RVA: 0x0000D4CB File Offset: 0x0000B6CB
	public bool IsChanged
	{
		get
		{
			return this._isDown != this._wasDown;
		}
	}

	// Token: 0x0600138C RID: 5004 RVA: 0x0000D4DE File Offset: 0x0000B6DE
	public void Serialize(MemoryStream stream)
	{
		EnumProxy<KeyCode>.Serialize(stream, this._positiveKey);
	}

	// Token: 0x0600138D RID: 5005 RVA: 0x00071554 File Offset: 0x0006F754
	public static KeyInputChannel FromBytes(MemoryStream stream)
	{
		KeyCode positiveKey = EnumProxy<KeyCode>.Deserialize(stream);
		return new KeyInputChannel(positiveKey);
	}

	// Token: 0x04001343 RID: 4931
	private bool _wasDown;

	// Token: 0x04001344 RID: 4932
	private bool _isDown;

	// Token: 0x04001345 RID: 4933
	private KeyCode _positiveKey;

	// Token: 0x04001346 RID: 4934
	private string _name = string.Empty;
}
