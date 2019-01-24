using System;
using System.IO;
using System.Text;
using UberStrike.Core.Serialization;
using UnityEngine;

// Token: 0x020002EA RID: 746
public class UserInputMap
{
	// Token: 0x06001567 RID: 5479 RVA: 0x0000E5C2 File Offset: 0x0000C7C2
	public UserInputMap(string description, GameInputKey s, IInputChannel channel = null, bool isConfigurable = true, bool isEventSender = true, KeyCode prefix = KeyCode.None)
	{
		this._prefix = prefix;
		this.IsConfigurable = isConfigurable;
		this.IsEventSender = isEventSender;
		this.Channel = channel;
		this.Slot = s;
		this.Description = description;
	}

	// Token: 0x06001568 RID: 5480 RVA: 0x0007836C File Offset: 0x0007656C
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(this.Description);
		stringBuilder.AppendFormat(": {0}", this.Channel);
		return stringBuilder.ToString();
	}

	// Token: 0x06001569 RID: 5481 RVA: 0x000783A0 File Offset: 0x000765A0
	public string GetPlayerPrefs()
	{
		string result;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			if (this.Channel is KeyInputChannel)
			{
				ByteProxy.Serialize(memoryStream, 0);
				this.Channel.Serialize(memoryStream);
			}
			else if (this.Channel is MouseInputChannel)
			{
				ByteProxy.Serialize(memoryStream, 1);
				this.Channel.Serialize(memoryStream);
			}
			else if (this.Channel is AxisInputChannel)
			{
				ByteProxy.Serialize(memoryStream, 2);
				this.Channel.Serialize(memoryStream);
			}
			else if (this.Channel is ButtonInputChannel)
			{
				ByteProxy.Serialize(memoryStream, 3);
				this.Channel.Serialize(memoryStream);
			}
			else
			{
				ByteProxy.Serialize(memoryStream, byte.MaxValue);
			}
			result = WWW.EscapeURL(Encoding.ASCII.GetString(memoryStream.ToArray()), Encoding.ASCII);
		}
		return result;
	}

	// Token: 0x0600156A RID: 5482 RVA: 0x000784A4 File Offset: 0x000766A4
	public void ReadPlayerPrefs(string pref)
	{
		byte[] bytes = Encoding.ASCII.GetBytes(WWW.UnEscapeURL(pref, Encoding.ASCII));
		using (MemoryStream memoryStream = new MemoryStream(bytes))
		{
			switch (ByteProxy.Deserialize(memoryStream))
			{
			case 0:
				this.Channel = KeyInputChannel.FromBytes(memoryStream);
				break;
			case 1:
				this.Channel = MouseInputChannel.FromBytes(memoryStream);
				break;
			case 2:
				this.Channel = AxisInputChannel.FromBytes(memoryStream);
				break;
			case 3:
				this.Channel = ButtonInputChannel.FromBytes(memoryStream);
				break;
			}
		}
	}

	// Token: 0x17000521 RID: 1313
	// (get) Token: 0x0600156B RID: 5483 RVA: 0x0000E5F7 File Offset: 0x0000C7F7
	// (set) Token: 0x0600156C RID: 5484 RVA: 0x0000E5FF File Offset: 0x0000C7FF
	public GameInputKey Slot { get; private set; }

	// Token: 0x17000522 RID: 1314
	// (get) Token: 0x0600156D RID: 5485 RVA: 0x0000E608 File Offset: 0x0000C808
	// (set) Token: 0x0600156E RID: 5486 RVA: 0x0000E610 File Offset: 0x0000C810
	public string Description { get; private set; }

	// Token: 0x17000523 RID: 1315
	// (get) Token: 0x0600156F RID: 5487 RVA: 0x00078558 File Offset: 0x00076758
	public string Assignment
	{
		get
		{
			if (this.Channel == null)
			{
				return "None";
			}
			return (this._prefix == KeyCode.None) ? this.Channel.Name : string.Format("{0} + {1}", this.PrintKeyCode(this._prefix), this.Channel.Name);
		}
	}

	// Token: 0x06001570 RID: 5488 RVA: 0x000785B4 File Offset: 0x000767B4
	private string PrintKeyCode(KeyCode keyCode)
	{
		switch (keyCode)
		{
		case KeyCode.RightShift:
			return "Right Shift";
		case KeyCode.LeftShift:
			return "Left Shift";
		case KeyCode.RightControl:
			return "Right Ctrl";
		case KeyCode.LeftControl:
			return "Left Ctrl";
		case KeyCode.RightAlt:
			return "Right Alt";
		case KeyCode.LeftAlt:
			return "Left Alt";
		default:
			return keyCode.ToString();
		}
	}

	// Token: 0x17000524 RID: 1316
	// (get) Token: 0x06001571 RID: 5489 RVA: 0x0000E619 File Offset: 0x0000C819
	// (set) Token: 0x06001572 RID: 5490 RVA: 0x0000E621 File Offset: 0x0000C821
	public IInputChannel Channel { get; set; }

	// Token: 0x17000525 RID: 1317
	// (get) Token: 0x06001573 RID: 5491 RVA: 0x0000E62A File Offset: 0x0000C82A
	// (set) Token: 0x06001574 RID: 5492 RVA: 0x0000E632 File Offset: 0x0000C832
	public bool IsConfigurable { get; set; }

	// Token: 0x17000526 RID: 1318
	// (get) Token: 0x06001575 RID: 5493 RVA: 0x0007861C File Offset: 0x0007681C
	public float Value
	{
		get
		{
			if (this.Channel != null)
			{
				bool flag = this._prefix == KeyCode.None || Input.GetKey(this._prefix);
				return (!flag) ? 0f : this.Channel.Value;
			}
			return 0f;
		}
	}

	// Token: 0x06001576 RID: 5494 RVA: 0x0000E63B File Offset: 0x0000C83B
	public float RawValue()
	{
		if (this.Channel != null && (this._prefix == KeyCode.None || Input.GetKey(this._prefix)))
		{
			return this.Channel.RawValue();
		}
		return 0f;
	}

	// Token: 0x17000527 RID: 1319
	// (get) Token: 0x06001577 RID: 5495 RVA: 0x0000E674 File Offset: 0x0000C874
	// (set) Token: 0x06001578 RID: 5496 RVA: 0x0000E67C File Offset: 0x0000C87C
	public bool IsEventSender { get; private set; }

	// Token: 0x0400140D RID: 5133
	private KeyCode _prefix;
}
