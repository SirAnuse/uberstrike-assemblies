using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200006F RID: 111
	public sealed class Callback<T>
	{
		// Token: 0x0600036E RID: 878 RVA: 0x00003DE6 File Offset: 0x00001FE6
		public Callback(Callback<T>.DispatchDelegate func, bool bGameServer = false)
		{
			this.m_bGameServer = bGameServer;
			this.BuildCCallbackBase();
			this.Register(func);
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600036F RID: 879 RVA: 0x00003E22 File Offset: 0x00002022
		// (remove) Token: 0x06000370 RID: 880 RVA: 0x00003E3B File Offset: 0x0000203B
		private event Callback<T>.DispatchDelegate m_Func;

		// Token: 0x06000371 RID: 881 RVA: 0x00003E54 File Offset: 0x00002054
		public static Callback<T> Create(Callback<T>.DispatchDelegate func)
		{
			return new Callback<T>(func, false);
		}

		// Token: 0x06000372 RID: 882 RVA: 0x00003E5D File Offset: 0x0000205D
		public static Callback<T> CreateGameServer(Callback<T>.DispatchDelegate func)
		{
			return new Callback<T>(func, true);
		}

		// Token: 0x06000373 RID: 883 RVA: 0x0000E7E0 File Offset: 0x0000C9E0
		~Callback()
		{
			this.Unregister();
			if (this.m_pVTable != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.m_pVTable);
			}
			if (this.m_pCCallbackBase.IsAllocated)
			{
				this.m_pCCallbackBase.Free();
			}
		}

		// Token: 0x06000374 RID: 884 RVA: 0x0000E84C File Offset: 0x0000CA4C
		public void Register(Callback<T>.DispatchDelegate func)
		{
			if (func == null)
			{
				throw new Exception("Callback function must not be null.");
			}
			if ((this.m_CCallbackBase.m_nCallbackFlags & 1) == 1)
			{
				this.Unregister();
			}
			if (this.m_bGameServer)
			{
				this.SetGameserverFlag();
			}
			this.m_Func = func;
			NativeMethods.SteamAPI_RegisterCallback(this.m_pCCallbackBase.AddrOfPinnedObject(), CallbackIdentities.GetCallbackIdentity(typeof(T)));
		}

		// Token: 0x06000375 RID: 885 RVA: 0x00003E66 File Offset: 0x00002066
		public void Unregister()
		{
			NativeMethods.SteamAPI_UnregisterCallback(this.m_pCCallbackBase.AddrOfPinnedObject());
		}

		// Token: 0x06000376 RID: 886 RVA: 0x00003E78 File Offset: 0x00002078
		public void SetGameserverFlag()
		{
			CCallbackBase ccallbackBase = this.m_CCallbackBase;
			ccallbackBase.m_nCallbackFlags |= 2;
		}

		// Token: 0x06000377 RID: 887 RVA: 0x0000E8BC File Offset: 0x0000CABC
		private void OnRunCallback(IntPtr pvParam)
		{
			try
			{
				this.m_Func((T)((object)Marshal.PtrToStructure(pvParam, typeof(T))));
			}
			catch (Exception e)
			{
				CallbackDispatcher.ExceptionHandler(e);
			}
		}

		// Token: 0x06000378 RID: 888 RVA: 0x0000E8BC File Offset: 0x0000CABC
		private void OnRunCallResult(IntPtr pvParam, bool bFailed, ulong hSteamAPICall)
		{
			try
			{
				this.m_Func((T)((object)Marshal.PtrToStructure(pvParam, typeof(T))));
			}
			catch (Exception e)
			{
				CallbackDispatcher.ExceptionHandler(e);
			}
		}

		// Token: 0x06000379 RID: 889 RVA: 0x00003E8E File Offset: 0x0000208E
		private int OnGetCallbackSizeBytes()
		{
			return this.m_size;
		}

		// Token: 0x0600037A RID: 890 RVA: 0x0000E90C File Offset: 0x0000CB0C
		private void BuildCCallbackBase()
		{
			this.VTable = new CCallbackBaseVTable
			{
				m_RunCallResult = new CCallbackBaseVTable.RunCRDel(this.OnRunCallResult),
				m_RunCallback = new CCallbackBaseVTable.RunCBDel(this.OnRunCallback),
				m_GetCallbackSizeBytes = new CCallbackBaseVTable.GetCallbackSizeBytesDel(this.OnGetCallbackSizeBytes)
			};
			this.m_pVTable = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CCallbackBaseVTable)));
			Marshal.StructureToPtr(this.VTable, this.m_pVTable, false);
			this.m_CCallbackBase = new CCallbackBase
			{
				m_vfptr = this.m_pVTable,
				m_iCallback = CallbackIdentities.GetCallbackIdentity(typeof(T))
			};
			this.m_pCCallbackBase = GCHandle.Alloc(this.m_CCallbackBase, GCHandleType.Pinned);
		}

		// Token: 0x040002F4 RID: 756
		private CCallbackBaseVTable VTable;

		// Token: 0x040002F5 RID: 757
		private IntPtr m_pVTable = IntPtr.Zero;

		// Token: 0x040002F6 RID: 758
		private CCallbackBase m_CCallbackBase;

		// Token: 0x040002F7 RID: 759
		private GCHandle m_pCCallbackBase;

		// Token: 0x040002F8 RID: 760
		private bool m_bGameServer;

		// Token: 0x040002F9 RID: 761
		private readonly int m_size = Marshal.SizeOf(typeof(T));

		// Token: 0x02000070 RID: 112
		// (Invoke) Token: 0x0600037C RID: 892
		public delegate void DispatchDelegate(T param);
	}
}
