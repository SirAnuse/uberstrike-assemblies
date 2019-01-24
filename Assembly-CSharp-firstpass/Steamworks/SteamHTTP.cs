using System;

namespace Steamworks
{
	// Token: 0x020001A4 RID: 420
	public static class SteamHTTP
	{
		// Token: 0x0600086B RID: 2155 RVA: 0x00005417 File Offset: 0x00003617
		public static HTTPRequestHandle CreateHTTPRequest(EHTTPMethod eHTTPRequestMethod, string pchAbsoluteURL)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_CreateHTTPRequest(eHTTPRequestMethod, pchAbsoluteURL);
		}

		// Token: 0x0600086C RID: 2156 RVA: 0x00005425 File Offset: 0x00003625
		public static bool SetHTTPRequestContextValue(HTTPRequestHandle hRequest, ulong ulContextValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_SetHTTPRequestContextValue(hRequest, ulContextValue);
		}

		// Token: 0x0600086D RID: 2157 RVA: 0x00005433 File Offset: 0x00003633
		public static bool SetHTTPRequestNetworkActivityTimeout(HTTPRequestHandle hRequest, uint unTimeoutSeconds)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_SetHTTPRequestNetworkActivityTimeout(hRequest, unTimeoutSeconds);
		}

		// Token: 0x0600086E RID: 2158 RVA: 0x00005441 File Offset: 0x00003641
		public static bool SetHTTPRequestHeaderValue(HTTPRequestHandle hRequest, string pchHeaderName, string pchHeaderValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_SetHTTPRequestHeaderValue(hRequest, pchHeaderName, pchHeaderValue);
		}

		// Token: 0x0600086F RID: 2159 RVA: 0x00005450 File Offset: 0x00003650
		public static bool SetHTTPRequestGetOrPostParameter(HTTPRequestHandle hRequest, string pchParamName, string pchParamValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_SetHTTPRequestGetOrPostParameter(hRequest, pchParamName, pchParamValue);
		}

		// Token: 0x06000870 RID: 2160 RVA: 0x0000545F File Offset: 0x0000365F
		public static bool SendHTTPRequest(HTTPRequestHandle hRequest, out SteamAPICall_t pCallHandle)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_SendHTTPRequest(hRequest, out pCallHandle);
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x0000546D File Offset: 0x0000366D
		public static bool SendHTTPRequestAndStreamResponse(HTTPRequestHandle hRequest, out SteamAPICall_t pCallHandle)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_SendHTTPRequestAndStreamResponse(hRequest, out pCallHandle);
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x0000547B File Offset: 0x0000367B
		public static bool DeferHTTPRequest(HTTPRequestHandle hRequest)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_DeferHTTPRequest(hRequest);
		}

		// Token: 0x06000873 RID: 2163 RVA: 0x00005488 File Offset: 0x00003688
		public static bool PrioritizeHTTPRequest(HTTPRequestHandle hRequest)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_PrioritizeHTTPRequest(hRequest);
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x00005495 File Offset: 0x00003695
		public static bool GetHTTPResponseHeaderSize(HTTPRequestHandle hRequest, string pchHeaderName, out uint unResponseHeaderSize)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_GetHTTPResponseHeaderSize(hRequest, pchHeaderName, out unResponseHeaderSize);
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x000054A4 File Offset: 0x000036A4
		public static bool GetHTTPResponseHeaderValue(HTTPRequestHandle hRequest, string pchHeaderName, byte[] pHeaderValueBuffer, uint unBufferSize)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_GetHTTPResponseHeaderValue(hRequest, pchHeaderName, pHeaderValueBuffer, unBufferSize);
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x000054B4 File Offset: 0x000036B4
		public static bool GetHTTPResponseBodySize(HTTPRequestHandle hRequest, out uint unBodySize)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_GetHTTPResponseBodySize(hRequest, out unBodySize);
		}

		// Token: 0x06000877 RID: 2167 RVA: 0x000054C2 File Offset: 0x000036C2
		public static bool GetHTTPResponseBodyData(HTTPRequestHandle hRequest, byte[] pBodyDataBuffer, uint unBufferSize)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_GetHTTPResponseBodyData(hRequest, pBodyDataBuffer, unBufferSize);
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x000054D1 File Offset: 0x000036D1
		public static bool GetHTTPStreamingResponseBodyData(HTTPRequestHandle hRequest, uint cOffset, byte[] pBodyDataBuffer, uint unBufferSize)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_GetHTTPStreamingResponseBodyData(hRequest, cOffset, pBodyDataBuffer, unBufferSize);
		}

		// Token: 0x06000879 RID: 2169 RVA: 0x000054E1 File Offset: 0x000036E1
		public static bool ReleaseHTTPRequest(HTTPRequestHandle hRequest)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_ReleaseHTTPRequest(hRequest);
		}

		// Token: 0x0600087A RID: 2170 RVA: 0x000054EE File Offset: 0x000036EE
		public static bool GetHTTPDownloadProgressPct(HTTPRequestHandle hRequest, out float pflPercentOut)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_GetHTTPDownloadProgressPct(hRequest, out pflPercentOut);
		}

		// Token: 0x0600087B RID: 2171 RVA: 0x000054FC File Offset: 0x000036FC
		public static bool SetHTTPRequestRawPostBody(HTTPRequestHandle hRequest, string pchContentType, byte[] pubBody, uint unBodyLen)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_SetHTTPRequestRawPostBody(hRequest, pchContentType, pubBody, unBodyLen);
		}

		// Token: 0x0600087C RID: 2172 RVA: 0x0000550C File Offset: 0x0000370C
		public static HTTPCookieContainerHandle CreateCookieContainer(bool bAllowResponsesToModify)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_CreateCookieContainer(bAllowResponsesToModify);
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x00005519 File Offset: 0x00003719
		public static bool ReleaseCookieContainer(HTTPCookieContainerHandle hCookieContainer)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_ReleaseCookieContainer(hCookieContainer);
		}

		// Token: 0x0600087E RID: 2174 RVA: 0x00005526 File Offset: 0x00003726
		public static bool SetCookie(HTTPCookieContainerHandle hCookieContainer, string pchHost, string pchUrl, string pchCookie)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_SetCookie(hCookieContainer, pchHost, pchUrl, pchCookie);
		}

		// Token: 0x0600087F RID: 2175 RVA: 0x00005536 File Offset: 0x00003736
		public static bool SetHTTPRequestCookieContainer(HTTPRequestHandle hRequest, HTTPCookieContainerHandle hCookieContainer)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_SetHTTPRequestCookieContainer(hRequest, hCookieContainer);
		}

		// Token: 0x06000880 RID: 2176 RVA: 0x00005544 File Offset: 0x00003744
		public static bool SetHTTPRequestUserAgentInfo(HTTPRequestHandle hRequest, string pchUserAgentInfo)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_SetHTTPRequestUserAgentInfo(hRequest, pchUserAgentInfo);
		}

		// Token: 0x06000881 RID: 2177 RVA: 0x00005552 File Offset: 0x00003752
		public static bool SetHTTPRequestRequiresVerifiedCertificate(HTTPRequestHandle hRequest, bool bRequireVerifiedCertificate)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_SetHTTPRequestRequiresVerifiedCertificate(hRequest, bRequireVerifiedCertificate);
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x00005560 File Offset: 0x00003760
		public static bool SetHTTPRequestAbsoluteTimeoutMS(HTTPRequestHandle hRequest, uint unMilliseconds)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_SetHTTPRequestAbsoluteTimeoutMS(hRequest, unMilliseconds);
		}

		// Token: 0x06000883 RID: 2179 RVA: 0x0000556E File Offset: 0x0000376E
		public static bool GetHTTPRequestWasTimedOut(HTTPRequestHandle hRequest, out bool pbWasTimedOut)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_GetHTTPRequestWasTimedOut(hRequest, out pbWasTimedOut);
		}
	}
}
