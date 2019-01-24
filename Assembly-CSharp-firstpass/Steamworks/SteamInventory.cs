using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020001A5 RID: 421
	public static class SteamInventory
	{
		// Token: 0x06000884 RID: 2180 RVA: 0x0000557C File Offset: 0x0000377C
		public static EResult GetResultStatus(SteamInventoryResult_t resultHandle)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_GetResultStatus(resultHandle);
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x00005589 File Offset: 0x00003789
		public static bool GetResultItems(SteamInventoryResult_t resultHandle, SteamItemDetails_t[] pOutItemsArray, ref uint punOutItemsArraySize)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_GetResultItems(resultHandle, pOutItemsArray, ref punOutItemsArraySize);
		}

		// Token: 0x06000886 RID: 2182 RVA: 0x00005598 File Offset: 0x00003798
		public static uint GetResultTimestamp(SteamInventoryResult_t resultHandle)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_GetResultTimestamp(resultHandle);
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x000055A5 File Offset: 0x000037A5
		public static bool CheckResultSteamID(SteamInventoryResult_t resultHandle, CSteamID steamIDExpected)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_CheckResultSteamID(resultHandle, steamIDExpected);
		}

		// Token: 0x06000888 RID: 2184 RVA: 0x000055B3 File Offset: 0x000037B3
		public static void DestroyResult(SteamInventoryResult_t resultHandle)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamInventory_DestroyResult(resultHandle);
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x000055C0 File Offset: 0x000037C0
		public static bool GetAllItems(out SteamInventoryResult_t pResultHandle)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_GetAllItems(out pResultHandle);
		}

		// Token: 0x0600088A RID: 2186 RVA: 0x000055CD File Offset: 0x000037CD
		public static bool GetItemsByID(out SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t[] pInstanceIDs, uint unCountInstanceIDs)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_GetItemsByID(out pResultHandle, pInstanceIDs, unCountInstanceIDs);
		}

		// Token: 0x0600088B RID: 2187 RVA: 0x000055DC File Offset: 0x000037DC
		public static bool SerializeResult(SteamInventoryResult_t resultHandle, byte[] pOutBuffer, out uint punOutBufferSize)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_SerializeResult(resultHandle, pOutBuffer, out punOutBufferSize);
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x000055EB File Offset: 0x000037EB
		public static bool DeserializeResult(out SteamInventoryResult_t pOutResultHandle, byte[] pBuffer, uint unBufferSize, bool bRESERVED_MUST_BE_FALSE = false)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_DeserializeResult(out pOutResultHandle, pBuffer, unBufferSize, bRESERVED_MUST_BE_FALSE);
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x000055FB File Offset: 0x000037FB
		public static bool GenerateItems(out SteamInventoryResult_t pResultHandle, SteamItemDef_t[] pArrayItemDefs, uint[] punArrayQuantity, uint unArrayLength)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_GenerateItems(out pResultHandle, pArrayItemDefs, punArrayQuantity, unArrayLength);
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x0000560B File Offset: 0x0000380B
		public static bool GrantPromoItems(out SteamInventoryResult_t pResultHandle)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_GrantPromoItems(out pResultHandle);
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x00005618 File Offset: 0x00003818
		public static bool AddPromoItem(out SteamInventoryResult_t pResultHandle, SteamItemDef_t itemDef)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_AddPromoItem(out pResultHandle, itemDef);
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x00005626 File Offset: 0x00003826
		public static bool AddPromoItems(out SteamInventoryResult_t pResultHandle, SteamItemDef_t[] pArrayItemDefs, uint unArrayLength)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_AddPromoItems(out pResultHandle, pArrayItemDefs, unArrayLength);
		}

		// Token: 0x06000891 RID: 2193 RVA: 0x00005635 File Offset: 0x00003835
		public static bool ConsumeItem(out SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t itemConsume, uint unQuantity)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_ConsumeItem(out pResultHandle, itemConsume, unQuantity);
		}

		// Token: 0x06000892 RID: 2194 RVA: 0x00005644 File Offset: 0x00003844
		public static bool ExchangeItems(out SteamInventoryResult_t pResultHandle, SteamItemDef_t[] pArrayGenerate, uint[] punArrayGenerateQuantity, uint unArrayGenerateLength, SteamItemInstanceID_t[] pArrayDestroy, uint[] punArrayDestroyQuantity, uint unArrayDestroyLength)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_ExchangeItems(out pResultHandle, pArrayGenerate, punArrayGenerateQuantity, unArrayGenerateLength, pArrayDestroy, punArrayDestroyQuantity, unArrayDestroyLength);
		}

		// Token: 0x06000893 RID: 2195 RVA: 0x0000565A File Offset: 0x0000385A
		public static bool TransferItemQuantity(out SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t itemIdSource, uint unQuantity, SteamItemInstanceID_t itemIdDest)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_TransferItemQuantity(out pResultHandle, itemIdSource, unQuantity, itemIdDest);
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x0000566A File Offset: 0x0000386A
		public static void SendItemDropHeartbeat()
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamInventory_SendItemDropHeartbeat();
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x00005676 File Offset: 0x00003876
		public static bool TriggerItemDrop(out SteamInventoryResult_t pResultHandle, SteamItemDef_t dropListDefinition)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_TriggerItemDrop(out pResultHandle, dropListDefinition);
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x00005684 File Offset: 0x00003884
		public static bool TradeItems(out SteamInventoryResult_t pResultHandle, CSteamID steamIDTradePartner, SteamItemInstanceID_t[] pArrayGive, uint[] pArrayGiveQuantity, uint nArrayGiveLength, SteamItemInstanceID_t[] pArrayGet, uint[] pArrayGetQuantity, uint nArrayGetLength)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_TradeItems(out pResultHandle, steamIDTradePartner, pArrayGive, pArrayGiveQuantity, nArrayGiveLength, pArrayGet, pArrayGetQuantity, nArrayGetLength);
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x0000569C File Offset: 0x0000389C
		public static bool LoadItemDefinitions()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_LoadItemDefinitions();
		}

		// Token: 0x06000898 RID: 2200 RVA: 0x000056A8 File Offset: 0x000038A8
		public static bool GetItemDefinitionIDs(SteamItemDef_t[] pItemDefIDs, out uint punItemDefIDsArraySize)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamInventory_GetItemDefinitionIDs(pItemDefIDs, out punItemDefIDsArraySize);
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x0000F908 File Offset: 0x0000DB08
		public static bool GetItemDefinitionProperty(SteamItemDef_t iDefinition, string pchPropertyName, out string pchValueBuffer, ref uint punValueBufferSize)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal((int)punValueBufferSize);
			bool flag = NativeMethods.ISteamInventory_GetItemDefinitionProperty(iDefinition, pchPropertyName, intPtr, ref punValueBufferSize);
			pchValueBuffer = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return flag;
		}
	}
}
