using System;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x02000393 RID: 915
public interface ICharacterState
{
	// Token: 0x14000017 RID: 23
	// (add) Token: 0x06001B10 RID: 6928
	// (remove) Token: 0x06001B11 RID: 6929
	event Action<GameActorInfoDelta> OnDeltaUpdate;

	// Token: 0x14000018 RID: 24
	// (add) Token: 0x06001B12 RID: 6930
	// (remove) Token: 0x06001B13 RID: 6931
	event Action<PlayerMovement> OnPositionUpdate;

	// Token: 0x17000606 RID: 1542
	// (get) Token: 0x06001B14 RID: 6932
	GameActorInfo Player { get; }

	// Token: 0x17000607 RID: 1543
	// (get) Token: 0x06001B15 RID: 6933
	Vector3 Velocity { get; }

	// Token: 0x17000608 RID: 1544
	// (get) Token: 0x06001B16 RID: 6934
	Vector3 Position { get; }

	// Token: 0x17000609 RID: 1545
	// (get) Token: 0x06001B17 RID: 6935
	Quaternion HorizontalRotation { get; }

	// Token: 0x1700060A RID: 1546
	// (get) Token: 0x06001B18 RID: 6936
	float VerticalRotation { get; }

	// Token: 0x1700060B RID: 1547
	// (get) Token: 0x06001B19 RID: 6937
	// (set) Token: 0x06001B1A RID: 6938
	MoveStates MovementState { get; set; }

	// Token: 0x1700060C RID: 1548
	// (get) Token: 0x06001B1B RID: 6939
	KeyState KeyState { get; }

	// Token: 0x06001B1C RID: 6940
	bool Is(MoveStates state);

	// Token: 0x06001B1D RID: 6941
	void DeltaUpdate(GameActorInfoDelta update);

	// Token: 0x06001B1E RID: 6942
	void PositionUpdate(PlayerMovement update, ushort gameFrame);
}
