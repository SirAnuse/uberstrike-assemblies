using System;

// Token: 0x0200038E RID: 910
public class PlayerActions
{
	// Token: 0x06001AB1 RID: 6833 RVA: 0x00011B40 File Offset: 0x0000FD40
	public PlayerActions()
	{
		this.Clear();
	}

	// Token: 0x06001AB2 RID: 6834 RVA: 0x0008B584 File Offset: 0x00089784
	public void Clear()
	{
		this.UpdateKeyState = delegate(byte A_0)
		{
		};
		this.UpdateMovementState = delegate(byte A_0)
		{
		};
		this.SwitchWeapon = delegate(byte A_0)
		{
		};
		this.UpdatePing = delegate(ushort A_0)
		{
		};
		this.PausePlayer = delegate(bool A_0)
		{
		};
		this.AutomaticFire = delegate(bool A_0)
		{
		};
		this.SniperMode = delegate(bool A_0)
		{
		};
		this.SetReadyForNextGame = delegate(bool A_0)
		{
		};
	}

	// Token: 0x040017F2 RID: 6130
	public Action<byte> UpdateKeyState;

	// Token: 0x040017F3 RID: 6131
	public Action<byte> UpdateMovementState;

	// Token: 0x040017F4 RID: 6132
	public Action<byte> SwitchWeapon;

	// Token: 0x040017F5 RID: 6133
	public Action<ushort> UpdatePing;

	// Token: 0x040017F6 RID: 6134
	public Action<bool> PausePlayer;

	// Token: 0x040017F7 RID: 6135
	public Action<bool> AutomaticFire;

	// Token: 0x040017F8 RID: 6136
	public Action<bool> SniperMode;

	// Token: 0x040017F9 RID: 6137
	public Action<bool> SetReadyForNextGame;
}
