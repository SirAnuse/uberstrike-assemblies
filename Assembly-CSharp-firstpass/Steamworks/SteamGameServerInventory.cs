using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200019F RID: 415
	public static class SteamGameServerInventory
	{
		// Token: 0x060007FA RID: 2042 RVA: 0x00004DBD File Offset: 0x00002FBD
		public static EResult GetResultStatus(SteamInventoryResult_t resultHandle)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerInventory_GetResultStatus(resultHandle);
		}

		// Token: 0x060007FB RID: 2043 RVA: 0x00004DCA File Offset: 0x00002FCA
		public static bool GetResultItems(SteamInventoryResult_t resultHandle, SteamItemDetails_t[] pOutItemsArray, ref uint punOutItemsArraySize)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerInventory_GetResultItems(resultHandle, pOutItemsArray, ref punOutItemsArraySize);
		}

		// Token: 0x060007FC RID: 2044 RVA: 0x00004DD9 File Offset: 0x00002FD9
		public static uint GetResultTimestamp(SteamInventoryResult_t resultHandle)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerInventory_GetResultTimestamp(resultHandle);
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x00004DE6 File Offset: 0x00002FE6
		public static bool CheckResultSteamID(SteamInventoryResult_t resultHandle, CSteamID steamIDExpected)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerInventory_CheckResultSteamID(resultHandle, steamIDExpected);
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x00004DF4 File Offset: 0x00002FF4
		public static void DestroyResult(SteamInventoryResult_t resultHandle)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServerInventory_DestroyResult(resultHandle);
		}

		// Token: 0x060007FF RID: 2047 RVA: 0x00004E01 File Offset: 0x00003001
		public static bool GetAllItems(out SteamInventoryResult_t pResultHandle)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerInventory_GetAllItems(out pResultHandle);
		}

		// Token: 0x06000800 RID: 2048 RVA: 0x00004E0E File Offset: 0x0000300E
		public static bool GetItemsByID(out SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t[] pInstanceIDs, uint unCountInstanceIDs)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerInventory_GetItemsByID(out pResultHandle, pInstanceIDs, unCountInstanceIDs);
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x00004E1D File Offset: 0x0000301D
		public static bool SerializeResult(SteamInventoryResult_t resultHandle, byte[] pOutBuffer, out uint punOutBufferSize)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerInventory_SerializeResult(resultHandle, pOutBuffer, out punOutBufferSize);
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x00004E2C File Offset: 0x0000302C
		public static bool DeserializeResult(out SteamInventoryResult_t pOutResultHandle, byte[] pBuffer, uint unBufferSize, bool bRESERVED_MUST_BE_FALSE = false)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerInventory_DeserializeResult(out pOutResultHandle, pBuffer, unBufferSize, bRESERVED_MUST_BE_FALSE);
		}

		// Token: 0x06000803 RID: 2051 RVA: 0x00004E3C File Offset: 0x0000303C
		public static bool GenerateItems(out SteamInventoryResult_t pResultHandle, SteamItemDef_t[] pArrayItemDefs, uint[] punArrayQuantity, uint unArrayLength)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerInventory_GenerateItems(out pResultHandle, pArrayItemDefs, punArrayQuantity, unArrayLength);
		}

		// Token: 0x06000804 RID: 2052 RVA: 0x00004E4C File Offset: 0x0000304C
		public static bool GrantPromoItems(out SteamInventoryResult_t pResultHandle)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerInventory_GrantPromoItems(out pResultHandle);
		}

		// Token: 0x06000805 RID: 2053 RVA: 0x00004E59 File Offset: 0x00003059
		public static bool AddPromoItem(out SteamInventoryResult_t pResultHandle, SteamItemDef_t itemDef)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerInventory_AddPromoItem(out pResultHandle, itemDef);
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x00004E67 File Offset: 0x00003067
		public static bool AddPromoItems(out SteamInventoryResult_t pResultHandle, SteamItemDef_t[] pArrayItemDefs, uint unArrayLength)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerInventory_AddPromoItems(out pResultHandle, pArrayItemDefs, unArrayLength);
		}

		// Token: 0x06000807 RID: 2055 RVA: 0x00004E76 File Offset: 0x00003076
		public static bool ConsumeItem(out SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t itemConsume, uint unQuantity)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerInventory_ConsumeItem(out pResultHandle, itemConsume, unQuantity);
		}

		// Token: 0x06000808 RID: 2056 RVA: 0x00004E85 File Offset: 0x00003085
		public static bool ExchangeItems(out SteamInventoryResult_t pResultHandle, SteamItemDef_t[] pArrayGenerate, uint[] punArrayGenerateQuantity, uint unArrayGenerateLength, SteamItemInstanceID_t[] pArrayDestroy, uint[] punArrayDestroyQuantity, uint unArrayDestroyLength)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerInventory_ExchangeItems(out pResultHandle, pArrayGenerate, punArrayGenerateQuantity, unArrayGenerateLength, pArrayDestroy, punArrayDestroyQuantity, unArrayDestroyLength);
		}

		// Token: 0x06000809 RID: 2057 RVA: 0x00004E9B File Offset: 0x0000309B
		public static bool TransferItemQuantity(out SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t itemIdSource, uint unQuantity, SteamItemInstanceID_t itemIdDest)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerInventory_TransferItemQuantity(out pResultHandle, itemIdSource, unQuantity, itemIdDest);
		}

		// Token: 0x0600080A RID: 2058 RVA: 0x00004EAB File Offset: 0x000030AB
		public static void SendItemDropHeartbeat()
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServerInventory_SendItemDropHeartbeat();
		}

		// Token: 0x0600080B RID: 2059 RVA: 0x00004EB7 File Offset: 0x000030B7
		public static bool TriggerItemDrop(out SteamInventoryResult_t pResultHandle, SteamItemDef_t dropListDefinition)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerInventory_TriggerItemDrop(out pResultHandle, dropListDefinition);
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x00004EC5 File Offset: 0x000030C5
		public static bool TradeItems(out SteamInventoryResult_t pResultHandle, CSteamID steamIDTradePartner, SteamItemInstanceID_t[] pArrayGive, uint[] pArrayGiveQuantity, uint nArrayGiveLength, SteamItemInstanceID_t[] pArrayGet, uint[] pArrayGetQuantity, uint nArrayGetLength)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerInventory_TradeItems(out pResultHandle, steamIDTradePartner, pArrayGive, pArrayGiveQuantity, nArrayGiveLength, pArrayGet, pArrayGetQuantity, nArrayGetLength);
		}

		// Token: 0x0600080D RID: 2061 RVA: 0x00004EDD File Offset: 0x000030DD
		public static bool LoadItemDefinitions()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerInventory_LoadItemDefinitions();
		}

		// Token: 0x0600080E RID: 2062 RVA: 0x00004EE9 File Offset: 0x000030E9
		public static bool GetItemDefinitionIDs(SteamItemDef_t[] pItemDefIDs, out uint punItemDefIDsArraySize)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerInventory_GetItemDefinitionIDs(pItemDefIDs, out punItemDefIDsArraySize);
		}

		// Token: 0x0600080F RID: 2063 RVA: 0x0000F88C File Offset: 0x0000DA8C
		public static bool GetItemDefinitionProperty(SteamItemDef_t iDefinition, string pchPropertyName, out string pchValueBuffer, ref uint punValueBufferSize)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr intPtr = Marshal.AllocHGlobal((int)punValueBufferSize);
			bool flag = NativeMethods.ISteamGameServerInventory_GetItemDefinitionProperty(iDefinition, pchPropertyName, intPtr, ref punValueBufferSize);
			pchValueBuffer = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return flag;
		}
	}
}
