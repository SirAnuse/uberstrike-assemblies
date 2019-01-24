using System;
using System.IO;
using UberStrike.Core.Models;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000290 RID: 656
	public static class PlayerMovementProxy
	{
		// Token: 0x060010C3 RID: 4291 RVA: 0x00016F34 File Offset: 0x00015134
		public static void Serialize(Stream stream, PlayerMovement instance)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				ByteProxy.Serialize(memoryStream, instance.HorizontalRotation);
				ByteProxy.Serialize(memoryStream, instance.KeyState);
				ByteProxy.Serialize(memoryStream, instance.MovementState);
				ByteProxy.Serialize(memoryStream, instance.Number);
				ShortVector3Proxy.Serialize(memoryStream, instance.Position);
				ShortVector3Proxy.Serialize(memoryStream, instance.Velocity);
				ByteProxy.Serialize(memoryStream, instance.VerticalRotation);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x060010C4 RID: 4292 RVA: 0x00016FC4 File Offset: 0x000151C4
		public static PlayerMovement Deserialize(Stream bytes)
		{
			return new PlayerMovement
			{
				HorizontalRotation = ByteProxy.Deserialize(bytes),
				KeyState = ByteProxy.Deserialize(bytes),
				MovementState = ByteProxy.Deserialize(bytes),
				Number = ByteProxy.Deserialize(bytes),
				Position = ShortVector3Proxy.Deserialize(bytes),
				Velocity = ShortVector3Proxy.Deserialize(bytes),
				VerticalRotation = ByteProxy.Deserialize(bytes)
			};
		}
	}
}
