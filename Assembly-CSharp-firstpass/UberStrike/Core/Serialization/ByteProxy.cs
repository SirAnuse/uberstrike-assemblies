using System;
using System.IO;

namespace UberStrike.Core.Serialization
{
	// Token: 0x0200024C RID: 588
	public static class ByteProxy
	{
		// Token: 0x0600102F RID: 4143 RVA: 0x0000AD33 File Offset: 0x00008F33
		public static void Serialize(Stream bytes, byte instance)
		{
			bytes.WriteByte(instance);
		}

		// Token: 0x06001030 RID: 4144 RVA: 0x0000AD3C File Offset: 0x00008F3C
		public static byte Deserialize(Stream bytes)
		{
			return (byte)bytes.ReadByte();
		}
	}
}
