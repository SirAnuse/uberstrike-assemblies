using System;
using System.IO;
using UberStrike.Core.Models;

namespace UberStrike.Core.Serialization
{
	// Token: 0x0200028D RID: 653
	public static class DamageEventProxy
	{
		// Token: 0x060010BD RID: 4285 RVA: 0x00016870 File Offset: 0x00014A70
		public static void Serialize(Stream stream, DamageEvent instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				ByteProxy.Serialize(memoryStream, instance.BodyPartFlag);
				if (instance.Damage != null)
				{
					DictionaryProxy<byte, byte>.Serialize(memoryStream, instance.Damage, new DictionaryProxy<byte, byte>.Serializer<byte>(ByteProxy.Serialize), new DictionaryProxy<byte, byte>.Serializer<byte>(ByteProxy.Serialize));
				}
				else
				{
					num |= 1;
				}
				Int32Proxy.Serialize(memoryStream, instance.DamageEffectFlag);
				SingleProxy.Serialize(memoryStream, instance.DamgeEffectValue);
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x060010BE RID: 4286 RVA: 0x00016914 File Offset: 0x00014B14
		public static DamageEvent Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			DamageEvent damageEvent = new DamageEvent();
			damageEvent.BodyPartFlag = ByteProxy.Deserialize(bytes);
			if ((num & 1) != 0)
			{
				damageEvent.Damage = DictionaryProxy<byte, byte>.Deserialize(bytes, new DictionaryProxy<byte, byte>.Deserializer<byte>(ByteProxy.Deserialize), new DictionaryProxy<byte, byte>.Deserializer<byte>(ByteProxy.Deserialize));
			}
			damageEvent.DamageEffectFlag = Int32Proxy.Deserialize(bytes);
			damageEvent.DamgeEffectValue = SingleProxy.Deserialize(bytes);
			return damageEvent;
		}
	}
}
