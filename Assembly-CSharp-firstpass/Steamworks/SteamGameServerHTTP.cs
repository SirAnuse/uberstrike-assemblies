using System;

namespace Steamworks
{
	// Token: 0x0200019E RID: 414
	public static class SteamGameServerHTTP
	{
		// Token: 0x060007E1 RID: 2017 RVA: 0x00004C58 File Offset: 0x00002E58
		public static HTTPRequestHandle CreateHTTPRequest(EHTTPMethod eHTTPRequestMethod, string pchAbsoluteURL)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_CreateHTTPRequest(eHTTPRequestMethod, pchAbsoluteURL);
		}

		// Token: 0x060007E2 RID: 2018 RVA: 0x00004C66 File Offset: 0x00002E66
		public static bool SetHTTPRequestContextValue(HTTPRequestHandle hRequest, ulong ulContextValue)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_SetHTTPRequestContextValue(hRequest, ulContextValue);
		}

		// Token: 0x060007E3 RID: 2019 RVA: 0x00004C74 File Offset: 0x00002E74
		public static bool SetHTTPRequestNetworkActivityTimeout(HTTPRequestHandle hRequest, uint unTimeoutSeconds)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_SetHTTPRequestNetworkActivityTimeout(hRequest, unTimeoutSeconds);
		}

		// Token: 0x060007E4 RID: 2020 RVA: 0x00004C82 File Offset: 0x00002E82
		public static bool SetHTTPRequestHeaderValue(HTTPRequestHandle hRequest, string pchHeaderName, string pchHeaderValue)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_SetHTTPRequestHeaderValue(hRequest, pchHeaderName, pchHeaderValue);
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x00004C91 File Offset: 0x00002E91
		public static bool SetHTTPRequestGetOrPostParameter(HTTPRequestHandle hRequest, string pchParamName, string pchParamValue)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_SetHTTPRequestGetOrPostParameter(hRequest, pchParamName, pchParamValue);
		}

		// Token: 0x060007E6 RID: 2022 RVA: 0x00004CA0 File Offset: 0x00002EA0
		public static bool SendHTTPRequest(HTTPRequestHandle hRequest, out SteamAPICall_t pCallHandle)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_SendHTTPRequest(hRequest, out pCallHandle);
		}

		// Token: 0x060007E7 RID: 2023 RVA: 0x00004CAE File Offset: 0x00002EAE
		public static bool SendHTTPRequestAndStreamResponse(HTTPRequestHandle hRequest, out SteamAPICall_t pCallHandle)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_SendHTTPRequestAndStreamResponse(hRequest, out pCallHandle);
		}

		// Token: 0x060007E8 RID: 2024 RVA: 0x00004CBC File Offset: 0x00002EBC
		public static bool DeferHTTPRequest(HTTPRequestHandle hRequest)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_DeferHTTPRequest(hRequest);
		}

		// Token: 0x060007E9 RID: 2025 RVA: 0x00004CC9 File Offset: 0x00002EC9
		public static bool PrioritizeHTTPRequest(HTTPRequestHandle hRequest)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_PrioritizeHTTPRequest(hRequest);
		}

		// Token: 0x060007EA RID: 2026 RVA: 0x00004CD6 File Offset: 0x00002ED6
		public static bool GetHTTPResponseHeaderSize(HTTPRequestHandle hRequest, string pchHeaderName, out uint unResponseHeaderSize)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_GetHTTPResponseHeaderSize(hRequest, pchHeaderName, out unResponseHeaderSize);
		}

		// Token: 0x060007EB RID: 2027 RVA: 0x00004CE5 File Offset: 0x00002EE5
		public static bool GetHTTPResponseHeaderValue(HTTPRequestHandle hRequest, string pchHeaderName, byte[] pHeaderValueBuffer, uint unBufferSize)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_GetHTTPResponseHeaderValue(hRequest, pchHeaderName, pHeaderValueBuffer, unBufferSize);
		}

		// Token: 0x060007EC RID: 2028 RVA: 0x00004CF5 File Offset: 0x00002EF5
		public static bool GetHTTPResponseBodySize(HTTPRequestHandle hRequest, out uint unBodySize)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_GetHTTPResponseBodySize(hRequest, out unBodySize);
		}

		// Token: 0x060007ED RID: 2029 RVA: 0x00004D03 File Offset: 0x00002F03
		public static bool GetHTTPResponseBodyData(HTTPRequestHandle hRequest, byte[] pBodyDataBuffer, uint unBufferSize)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_GetHTTPResponseBodyData(hRequest, pBodyDataBuffer, unBufferSize);
		}

		// Token: 0x060007EE RID: 2030 RVA: 0x00004D12 File Offset: 0x00002F12
		public static bool GetHTTPStreamingResponseBodyData(HTTPRequestHandle hRequest, uint cOffset, byte[] pBodyDataBuffer, uint unBufferSize)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_GetHTTPStreamingResponseBodyData(hRequest, cOffset, pBodyDataBuffer, unBufferSize);
		}

		// Token: 0x060007EF RID: 2031 RVA: 0x00004D22 File Offset: 0x00002F22
		public static bool ReleaseHTTPRequest(HTTPRequestHandle hRequest)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_ReleaseHTTPRequest(hRequest);
		}

		// Token: 0x060007F0 RID: 2032 RVA: 0x00004D2F File Offset: 0x00002F2F
		public static bool GetHTTPDownloadProgressPct(HTTPRequestHandle hRequest, out float pflPercentOut)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_GetHTTPDownloadProgressPct(hRequest, out pflPercentOut);
		}

		// Token: 0x060007F1 RID: 2033 RVA: 0x00004D3D File Offset: 0x00002F3D
		public static bool SetHTTPRequestRawPostBody(HTTPRequestHandle hRequest, string pchContentType, byte[] pubBody, uint unBodyLen)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_SetHTTPRequestRawPostBody(hRequest, pchContentType, pubBody, unBodyLen);
		}

		// Token: 0x060007F2 RID: 2034 RVA: 0x00004D4D File Offset: 0x00002F4D
		public static HTTPCookieContainerHandle CreateCookieContainer(bool bAllowResponsesToModify)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_CreateCookieContainer(bAllowResponsesToModify);
		}

		// Token: 0x060007F3 RID: 2035 RVA: 0x00004D5A File Offset: 0x00002F5A
		public static bool ReleaseCookieContainer(HTTPCookieContainerHandle hCookieContainer)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_ReleaseCookieContainer(hCookieContainer);
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x00004D67 File Offset: 0x00002F67
		public static bool SetCookie(HTTPCookieContainerHandle hCookieContainer, string pchHost, string pchUrl, string pchCookie)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_SetCookie(hCookieContainer, pchHost, pchUrl, pchCookie);
		}

		// Token: 0x060007F5 RID: 2037 RVA: 0x00004D77 File Offset: 0x00002F77
		public static bool SetHTTPRequestCookieContainer(HTTPRequestHandle hRequest, HTTPCookieContainerHandle hCookieContainer)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_SetHTTPRequestCookieContainer(hRequest, hCookieContainer);
		}

		// Token: 0x060007F6 RID: 2038 RVA: 0x00004D85 File Offset: 0x00002F85
		public static bool SetHTTPRequestUserAgentInfo(HTTPRequestHandle hRequest, string pchUserAgentInfo)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_SetHTTPRequestUserAgentInfo(hRequest, pchUserAgentInfo);
		}

		// Token: 0x060007F7 RID: 2039 RVA: 0x00004D93 File Offset: 0x00002F93
		public static bool SetHTTPRequestRequiresVerifiedCertificate(HTTPRequestHandle hRequest, bool bRequireVerifiedCertificate)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_SetHTTPRequestRequiresVerifiedCertificate(hRequest, bRequireVerifiedCertificate);
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x00004DA1 File Offset: 0x00002FA1
		public static bool SetHTTPRequestAbsoluteTimeoutMS(HTTPRequestHandle hRequest, uint unMilliseconds)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_SetHTTPRequestAbsoluteTimeoutMS(hRequest, unMilliseconds);
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x00004DAF File Offset: 0x00002FAF
		public static bool GetHTTPRequestWasTimedOut(HTTPRequestHandle hRequest, out bool pbWasTimedOut)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_GetHTTPRequestWasTimedOut(hRequest, out pbWasTimedOut);
		}
	}
}
