using System;

namespace Steamworks
{
	// Token: 0x020001A3 RID: 419
	public static class SteamHTMLSurface
	{
		// Token: 0x06000849 RID: 2121 RVA: 0x0000522F File Offset: 0x0000342F
		public static bool Init()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTMLSurface_Init();
		}

		// Token: 0x0600084A RID: 2122 RVA: 0x0000523B File Offset: 0x0000343B
		public static bool Shutdown()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTMLSurface_Shutdown();
		}

		// Token: 0x0600084B RID: 2123 RVA: 0x00005247 File Offset: 0x00003447
		public static SteamAPICall_t CreateBrowser(string pchUserAgent, string pchUserCSS)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamHTMLSurface_CreateBrowser(pchUserAgent, pchUserCSS);
		}

		// Token: 0x0600084C RID: 2124 RVA: 0x0000525A File Offset: 0x0000345A
		public static void RemoveBrowser(HHTMLBrowser unBrowserHandle)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_RemoveBrowser(unBrowserHandle);
		}

		// Token: 0x0600084D RID: 2125 RVA: 0x00005267 File Offset: 0x00003467
		public static void LoadURL(HHTMLBrowser unBrowserHandle, string pchURL, string pchPostData)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_LoadURL(unBrowserHandle, pchURL, pchPostData);
		}

		// Token: 0x0600084E RID: 2126 RVA: 0x00005276 File Offset: 0x00003476
		public static void SetSize(HHTMLBrowser unBrowserHandle, uint unWidth, uint unHeight)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_SetSize(unBrowserHandle, unWidth, unHeight);
		}

		// Token: 0x0600084F RID: 2127 RVA: 0x00005285 File Offset: 0x00003485
		public static void StopLoad(HHTMLBrowser unBrowserHandle)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_StopLoad(unBrowserHandle);
		}

		// Token: 0x06000850 RID: 2128 RVA: 0x00005292 File Offset: 0x00003492
		public static void Reload(HHTMLBrowser unBrowserHandle)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_Reload(unBrowserHandle);
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x0000529F File Offset: 0x0000349F
		public static void GoBack(HHTMLBrowser unBrowserHandle)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_GoBack(unBrowserHandle);
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x000052AC File Offset: 0x000034AC
		public static void GoForward(HHTMLBrowser unBrowserHandle)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_GoForward(unBrowserHandle);
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x000052B9 File Offset: 0x000034B9
		public static void AddHeader(HHTMLBrowser unBrowserHandle, string pchKey, string pchValue)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_AddHeader(unBrowserHandle, pchKey, pchValue);
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x000052C8 File Offset: 0x000034C8
		public static void ExecuteJavascript(HHTMLBrowser unBrowserHandle, string pchScript)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_ExecuteJavascript(unBrowserHandle, pchScript);
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x000052D6 File Offset: 0x000034D6
		public static void MouseUp(HHTMLBrowser unBrowserHandle, EHTMLMouseButton eMouseButton)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_MouseUp(unBrowserHandle, eMouseButton);
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x000052E4 File Offset: 0x000034E4
		public static void MouseDown(HHTMLBrowser unBrowserHandle, EHTMLMouseButton eMouseButton)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_MouseDown(unBrowserHandle, eMouseButton);
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x000052F2 File Offset: 0x000034F2
		public static void MouseDoubleClick(HHTMLBrowser unBrowserHandle, EHTMLMouseButton eMouseButton)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_MouseDoubleClick(unBrowserHandle, eMouseButton);
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x00005300 File Offset: 0x00003500
		public static void MouseMove(HHTMLBrowser unBrowserHandle, int x, int y)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_MouseMove(unBrowserHandle, x, y);
		}

		// Token: 0x06000859 RID: 2137 RVA: 0x0000530F File Offset: 0x0000350F
		public static void MouseWheel(HHTMLBrowser unBrowserHandle, int nDelta)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_MouseWheel(unBrowserHandle, nDelta);
		}

		// Token: 0x0600085A RID: 2138 RVA: 0x0000531D File Offset: 0x0000351D
		public static void KeyDown(HHTMLBrowser unBrowserHandle, uint nNativeKeyCode, EHTMLKeyModifiers eHTMLKeyModifiers)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_KeyDown(unBrowserHandle, nNativeKeyCode, eHTMLKeyModifiers);
		}

		// Token: 0x0600085B RID: 2139 RVA: 0x0000532C File Offset: 0x0000352C
		public static void KeyUp(HHTMLBrowser unBrowserHandle, uint nNativeKeyCode, EHTMLKeyModifiers eHTMLKeyModifiers)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_KeyUp(unBrowserHandle, nNativeKeyCode, eHTMLKeyModifiers);
		}

		// Token: 0x0600085C RID: 2140 RVA: 0x0000533B File Offset: 0x0000353B
		public static void KeyChar(HHTMLBrowser unBrowserHandle, uint cUnicodeChar, EHTMLKeyModifiers eHTMLKeyModifiers)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_KeyChar(unBrowserHandle, cUnicodeChar, eHTMLKeyModifiers);
		}

		// Token: 0x0600085D RID: 2141 RVA: 0x0000534A File Offset: 0x0000354A
		public static void SetHorizontalScroll(HHTMLBrowser unBrowserHandle, uint nAbsolutePixelScroll)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_SetHorizontalScroll(unBrowserHandle, nAbsolutePixelScroll);
		}

		// Token: 0x0600085E RID: 2142 RVA: 0x00005358 File Offset: 0x00003558
		public static void SetVerticalScroll(HHTMLBrowser unBrowserHandle, uint nAbsolutePixelScroll)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_SetVerticalScroll(unBrowserHandle, nAbsolutePixelScroll);
		}

		// Token: 0x0600085F RID: 2143 RVA: 0x00005366 File Offset: 0x00003566
		public static void SetKeyFocus(HHTMLBrowser unBrowserHandle, bool bHasKeyFocus)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_SetKeyFocus(unBrowserHandle, bHasKeyFocus);
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x00005374 File Offset: 0x00003574
		public static void ViewSource(HHTMLBrowser unBrowserHandle)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_ViewSource(unBrowserHandle);
		}

		// Token: 0x06000861 RID: 2145 RVA: 0x00005381 File Offset: 0x00003581
		public static void CopyToClipboard(HHTMLBrowser unBrowserHandle)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_CopyToClipboard(unBrowserHandle);
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x0000538E File Offset: 0x0000358E
		public static void PasteFromClipboard(HHTMLBrowser unBrowserHandle)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_PasteFromClipboard(unBrowserHandle);
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x0000539B File Offset: 0x0000359B
		public static void Find(HHTMLBrowser unBrowserHandle, string pchSearchStr, bool bCurrentlyInFind, bool bReverse)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_Find(unBrowserHandle, pchSearchStr, bCurrentlyInFind, bReverse);
		}

		// Token: 0x06000864 RID: 2148 RVA: 0x000053AB File Offset: 0x000035AB
		public static void StopFind(HHTMLBrowser unBrowserHandle)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_StopFind(unBrowserHandle);
		}

		// Token: 0x06000865 RID: 2149 RVA: 0x000053B8 File Offset: 0x000035B8
		public static void GetLinkAtPosition(HHTMLBrowser unBrowserHandle, int x, int y)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_GetLinkAtPosition(unBrowserHandle, x, y);
		}

		// Token: 0x06000866 RID: 2150 RVA: 0x000053C7 File Offset: 0x000035C7
		public static void SetCookie(string pchHostname, string pchKey, string pchValue, string pchPath = "/", uint nExpires = 0u, bool bSecure = false, bool bHTTPOnly = false)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_SetCookie(pchHostname, pchKey, pchValue, pchPath, nExpires, bSecure, bHTTPOnly);
		}

		// Token: 0x06000867 RID: 2151 RVA: 0x000053DD File Offset: 0x000035DD
		public static void SetPageScaleFactor(HHTMLBrowser unBrowserHandle, float flZoom, int nPointX, int nPointY)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_SetPageScaleFactor(unBrowserHandle, flZoom, nPointX, nPointY);
		}

		// Token: 0x06000868 RID: 2152 RVA: 0x000053ED File Offset: 0x000035ED
		public static void AllowStartRequest(HHTMLBrowser unBrowserHandle, bool bAllowed)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_AllowStartRequest(unBrowserHandle, bAllowed);
		}

		// Token: 0x06000869 RID: 2153 RVA: 0x000053FB File Offset: 0x000035FB
		public static void JSDialogResponse(HHTMLBrowser unBrowserHandle, bool bResult)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_JSDialogResponse(unBrowserHandle, bResult);
		}

		// Token: 0x0600086A RID: 2154 RVA: 0x00005409 File Offset: 0x00003609
		public static void FileLoadDialogResponse(HHTMLBrowser unBrowserHandle, IntPtr pchSelectedFiles)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamHTMLSurface_FileLoadDialogResponse(unBrowserHandle, pchSelectedFiles);
		}
	}
}
