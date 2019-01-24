using System;

// Token: 0x0200041A RID: 1050
public static class UberstrikeLayerMasks
{
	// Token: 0x040019EA RID: 6634
	public static readonly int IdentificationMask = LayerUtil.CreateLayerMask(new UberstrikeLayer[]
	{
		UberstrikeLayer.RemotePlayer,
		UberstrikeLayer.Default,
		UberstrikeLayer.GloballyLit
	});

	// Token: 0x040019EB RID: 6635
	public static readonly int CrouchMask = ~LayerUtil.CreateLayerMask(new UberstrikeLayer[]
	{
		UberstrikeLayer.LocalPlayer,
		UberstrikeLayer.Controller,
		UberstrikeLayer.IgnoreRaycast,
		UberstrikeLayer.Trigger,
		UberstrikeLayer.TransparentFX
	});

	// Token: 0x040019EC RID: 6636
	public static readonly int ShootMask = ~LayerUtil.CreateLayerMask(new UberstrikeLayer[]
	{
		UberstrikeLayer.LocalPlayer,
		UberstrikeLayer.Controller,
		UberstrikeLayer.IgnoreRaycast,
		UberstrikeLayer.Trigger,
		UberstrikeLayer.TransparentFX,
		UberstrikeLayer.Raidbot
	});

	// Token: 0x040019ED RID: 6637
	public static readonly int ShootMaskRemotePlayer = ~LayerUtil.CreateLayerMask(new UberstrikeLayer[]
	{
		UberstrikeLayer.Controller,
		UberstrikeLayer.IgnoreRaycast,
		UberstrikeLayer.Trigger,
		UberstrikeLayer.TransparentFX,
		UberstrikeLayer.Raidbot
	});

	// Token: 0x040019EE RID: 6638
	public static readonly int RemoteRocketMask = ~LayerUtil.CreateLayerMask(new UberstrikeLayer[]
	{
		UberstrikeLayer.RemotePlayer,
		UberstrikeLayer.Controller,
		UberstrikeLayer.Teleporter,
		UberstrikeLayer.LocalProjectile,
		UberstrikeLayer.RemoteProjectile,
		UberstrikeLayer.IgnoreRaycast,
		UberstrikeLayer.Trigger,
		UberstrikeLayer.TransparentFX
	});

	// Token: 0x040019EF RID: 6639
	public static readonly int LocalRocketMask = ~LayerUtil.CreateLayerMask(new UberstrikeLayer[]
	{
		UberstrikeLayer.LocalPlayer,
		UberstrikeLayer.Controller,
		UberstrikeLayer.Teleporter,
		UberstrikeLayer.LocalProjectile,
		UberstrikeLayer.RemoteProjectile,
		UberstrikeLayer.IgnoreRaycast,
		UberstrikeLayer.Trigger,
		UberstrikeLayer.TransparentFX,
		UberstrikeLayer.Raidbot
	});

	// Token: 0x040019F0 RID: 6640
	public static readonly int ExplosionMask = LayerUtil.CreateLayerMask(new UberstrikeLayer[]
	{
		UberstrikeLayer.LocalPlayer,
		UberstrikeLayer.RemotePlayer,
		UberstrikeLayer.Props,
		UberstrikeLayer.Raidbot,
		UberstrikeLayer.Ragdoll
	});

	// Token: 0x040019F1 RID: 6641
	public static readonly int GrenadeCollisionMask = LayerUtil.CreateLayerMask(new UberstrikeLayer[]
	{
		UberstrikeLayer.RemotePlayer
	});

	// Token: 0x040019F2 RID: 6642
	public static readonly int GrenadeMask = LayerUtil.CreateLayerMask(new UberstrikeLayer[]
	{
		UberstrikeLayer.LocalPlayer,
		UberstrikeLayer.RemotePlayer,
		UberstrikeLayer.Props,
		UberstrikeLayer.Raidbot
	});

	// Token: 0x040019F3 RID: 6643
	public static readonly int ProtectionMask = ~LayerUtil.CreateLayerMask(new UberstrikeLayer[]
	{
		UberstrikeLayer.LocalProjectile,
		UberstrikeLayer.RemoteProjectile,
		UberstrikeLayer.LocalPlayer,
		UberstrikeLayer.RemotePlayer,
		UberstrikeLayer.Controller,
		UberstrikeLayer.Props,
		UberstrikeLayer.Ragdoll,
		UberstrikeLayer.IgnoreRaycast,
		UberstrikeLayer.Trigger,
		UberstrikeLayer.TransparentFX
	});

	// Token: 0x040019F4 RID: 6644
	public static readonly int WaterMask = LayerUtil.CreateLayerMask(new UberstrikeLayer[]
	{
		UberstrikeLayer.Water
	});
}
