using System;
using System.IO;
using UberStrike.Core.Types;
using UberStrike.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x0200029C RID: 668
	public static class ItemQuickUseConfigViewProxy
	{
		// Token: 0x060010DB RID: 4315 RVA: 0x000180F0 File Offset: 0x000162F0
		public static void Serialize(Stream stream, ItemQuickUseConfigView instance)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				EnumProxy<QuickItemLogic>.Serialize(memoryStream, instance.BehaviourType);
				Int32Proxy.Serialize(memoryStream, instance.CoolDownTime);
				Int32Proxy.Serialize(memoryStream, instance.ItemId);
				Int32Proxy.Serialize(memoryStream, instance.LevelRequired);
				Int32Proxy.Serialize(memoryStream, instance.UsesPerGame);
				Int32Proxy.Serialize(memoryStream, instance.UsesPerLife);
				Int32Proxy.Serialize(memoryStream, instance.UsesPerRound);
				Int32Proxy.Serialize(memoryStream, instance.WarmUpTime);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x060010DC RID: 4316 RVA: 0x0001818C File Offset: 0x0001638C
		public static ItemQuickUseConfigView Deserialize(Stream bytes)
		{
			return new ItemQuickUseConfigView
			{
				BehaviourType = EnumProxy<QuickItemLogic>.Deserialize(bytes),
				CoolDownTime = Int32Proxy.Deserialize(bytes),
				ItemId = Int32Proxy.Deserialize(bytes),
				LevelRequired = Int32Proxy.Deserialize(bytes),
				UsesPerGame = Int32Proxy.Deserialize(bytes),
				UsesPerLife = Int32Proxy.Deserialize(bytes),
				UsesPerRound = Int32Proxy.Deserialize(bytes),
				WarmUpTime = Int32Proxy.Deserialize(bytes)
			};
		}
	}
}
