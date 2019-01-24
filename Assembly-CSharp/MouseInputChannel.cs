using System;
using System.IO;
using UberStrike.Core.Serialization;
using UnityEngine;

// Token: 0x020002C0 RID: 704
public class MouseInputChannel : IInputChannel
{
	// Token: 0x0600138E RID: 5006 RVA: 0x0000D4EC File Offset: 0x0000B6EC
	public MouseInputChannel(int button)
	{
		this._button = button;
	}

	// Token: 0x0600138F RID: 5007 RVA: 0x0000D4FB File Offset: 0x0000B6FB
	public void Listen()
	{
		this._wasDown = this._isDown;
		this._isDown = Input.GetMouseButton(this._button);
	}

	// Token: 0x06001390 RID: 5008 RVA: 0x0000D51A File Offset: 0x0000B71A
	public float RawValue()
	{
		return (float)((!Input.GetMouseButton(this._button)) ? 0 : 1);
	}

	// Token: 0x06001391 RID: 5009 RVA: 0x0000D534 File Offset: 0x0000B734
	public void Reset()
	{
		this._wasDown = false;
		this._isDown = false;
	}

	// Token: 0x06001392 RID: 5010 RVA: 0x0000D544 File Offset: 0x0000B744
	public override string ToString()
	{
		return string.Format("Mouse {0}", this._button);
	}

	// Token: 0x06001393 RID: 5011 RVA: 0x00071570 File Offset: 0x0006F770
	public override bool Equals(object obj)
	{
		if (obj is MouseInputChannel)
		{
			MouseInputChannel mouseInputChannel = obj as MouseInputChannel;
			if (mouseInputChannel.Button == this.Button)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06001394 RID: 5012 RVA: 0x0000D49E File Offset: 0x0000B69E
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	// Token: 0x06001395 RID: 5013 RVA: 0x000715A4 File Offset: 0x0006F7A4
	private string ConvertMouseButtonName(int _button)
	{
		if (_button == 0)
		{
			return "Left Mousebutton";
		}
		if (_button != 1)
		{
			return string.Format("Mouse {0}", _button);
		}
		return "Right Mousebutton";
	}

	// Token: 0x170004AE RID: 1198
	// (get) Token: 0x06001396 RID: 5014 RVA: 0x0000D55B File Offset: 0x0000B75B
	public int Button
	{
		get
		{
			return this._button;
		}
	}

	// Token: 0x170004AF RID: 1199
	// (get) Token: 0x06001397 RID: 5015 RVA: 0x0000D563 File Offset: 0x0000B763
	public string Name
	{
		get
		{
			return this.ConvertMouseButtonName(this._button);
		}
	}

	// Token: 0x170004B0 RID: 1200
	// (get) Token: 0x06001398 RID: 5016 RVA: 0x00004D4D File Offset: 0x00002F4D
	public InputChannelType ChannelType
	{
		get
		{
			return InputChannelType.Mouse;
		}
	}

	// Token: 0x170004B1 RID: 1201
	// (get) Token: 0x06001399 RID: 5017 RVA: 0x0000D571 File Offset: 0x0000B771
	// (set) Token: 0x0600139A RID: 5018 RVA: 0x000715E4 File Offset: 0x0006F7E4
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

	// Token: 0x170004B2 RID: 1202
	// (get) Token: 0x0600139B RID: 5019 RVA: 0x0000D586 File Offset: 0x0000B786
	public bool IsChanged
	{
		get
		{
			return this._isDown != this._wasDown;
		}
	}

	// Token: 0x0600139C RID: 5020 RVA: 0x0000D599 File Offset: 0x0000B799
	public void Serialize(MemoryStream stream)
	{
		Int32Proxy.Serialize(stream, this._button);
	}

	// Token: 0x0600139D RID: 5021 RVA: 0x00071614 File Offset: 0x0006F814
	public static MouseInputChannel FromBytes(MemoryStream stream)
	{
		int button = Int32Proxy.Deserialize(stream);
		return new MouseInputChannel(button);
	}

	// Token: 0x04001347 RID: 4935
	private bool _wasDown;

	// Token: 0x04001348 RID: 4936
	private bool _isDown;

	// Token: 0x04001349 RID: 4937
	private int _button;
}
