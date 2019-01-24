using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000071 RID: 113
	public sealed class CallResult<T>
	{
		// Token: 0x0600037F RID: 895 RVA: 0x00003E96 File Offset: 0x00002096
		public CallResult(CallResult<T>.APIDispatchDelegate func = null)
		{
			this.m_Func = func;
			this.BuildCCallbackBase();
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000380 RID: 896 RVA: 0x00003ED6 File Offset: 0x000020D6
		// (remove) Token: 0x06000381 RID: 897 RVA: 0x00003EEF File Offset: 0x000020EF
		private event CallResult<T>.APIDispatchDelegate m_Func;

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06000382 RID: 898 RVA: 0x00003F08 File Offset: 0x00002108
		public SteamAPICall_t Handle
		{
			get
			{
				return this.m_hAPICall;
			}
		}

		// Token: 0x06000383 RID: 899 RVA: 0x00003F10 File Offset: 0x00002110
		public static CallResult<T> Create(CallResult<T>.APIDispatchDelegate func = null)
		{
			return new CallResult<T>(func);
		}

		// Token: 0x06000384 RID: 900 RVA: 0x0000E9C8 File Offset: 0x0000CBC8
		~CallResult()
		{
			this.Cancel();
			if (this.m_pVTable != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.m_pVTable);
			}
			if (this.m_pCCallbackBase.IsAllocated)
			{
				this.m_pCCallbackBase.Free();
			}
		}

		// Token: 0x06000385 RID: 901 RVA: 0x0000EA34 File Offset: 0x0000CC34
		public void Set(SteamAPICall_t hAPICall, CallResult<T>.APIDispatchDelegate func = null)
		{
			if (func != null)
			{
				this.m_Func = func;
			}
			if (this.m_Func == null)
			{
				throw new Exception("CallResult function was null, you must either set it in the CallResult Constructor or in Set()");
			}
			if (this.m_hAPICall != SteamAPICall_t.Invalid)
			{
				NativeMethods.SteamAPI_UnregisterCallResult(this.m_pCCallbackBase.AddrOfPinnedObject(), (ulong)this.m_hAPICall);
			}
			this.m_hAPICall = hAPICall;
			if (hAPICall != SteamAPICall_t.Invalid)
			{
				NativeMethods.SteamAPI_RegisterCallResult(this.m_pCCallbackBase.AddrOfPinnedObject(), (ulong)hAPICall);
			}
		}

		// Token: 0x06000386 RID: 902 RVA: 0x00003F18 File Offset: 0x00002118
		public bool IsActive()
		{
			return this.m_hAPICall != SteamAPICall_t.Invalid;
		}

		// Token: 0x06000387 RID: 903 RVA: 0x00003F2A File Offset: 0x0000212A
		public void Cancel()
		{
			if (this.m_hAPICall != SteamAPICall_t.Invalid)
			{
				NativeMethods.SteamAPI_UnregisterCallResult(this.m_pCCallbackBase.AddrOfPinnedObject(), (ulong)this.m_hAPICall);
				this.m_hAPICall = SteamAPICall_t.Invalid;
			}
		}

		// Token: 0x06000388 RID: 904 RVA: 0x00003F67 File Offset: 0x00002167
		public void SetGameserverFlag()
		{
			CCallbackBase ccallbackBase = this.m_CCallbackBase;
			ccallbackBase.m_nCallbackFlags |= 2;
		}

		// Token: 0x06000389 RID: 905 RVA: 0x0000EAC4 File Offset: 0x0000CCC4
		private void OnRunCallback(IntPtr pvParam)
		{
			this.m_hAPICall = SteamAPICall_t.Invalid;
			try
			{
				this.m_Func((T)((object)Marshal.PtrToStructure(pvParam, typeof(T))), false);
			}
			catch (Exception e)
			{
				CallbackDispatcher.ExceptionHandler(e);
			}
		}

		// Token: 0x0600038A RID: 906 RVA: 0x0000EB20 File Offset: 0x0000CD20
		private void OnRunCallResult(IntPtr pvParam, bool bFailed, ulong hSteamAPICall)
		{
			SteamAPICall_t x = (SteamAPICall_t)hSteamAPICall;
			if (x == this.m_hAPICall)
			{
				try
				{
					this.m_Func((T)((object)Marshal.PtrToStructure(pvParam, typeof(T))), bFailed);
				}
				catch (Exception e)
				{
					CallbackDispatcher.ExceptionHandler(e);
				}
				if (x == this.m_hAPICall)
				{
					this.m_hAPICall = SteamAPICall_t.Invalid;
				}
			}
		}

		// Token: 0x0600038B RID: 907 RVA: 0x00003F7D File Offset: 0x0000217D
		private int OnGetCallbackSizeBytes()
		{
			return this.m_size;
		}

		// Token: 0x0600038C RID: 908 RVA: 0x0000EBA4 File Offset: 0x0000CDA4
		private void BuildCCallbackBase()
		{
			this.VTable = new CCallbackBaseVTable
			{
				m_RunCallback = new CCallbackBaseVTable.RunCBDel(this.OnRunCallback),
				m_RunCallResult = new CCallbackBaseVTable.RunCRDel(this.OnRunCallResult),
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

		// Token: 0x040002FB RID: 763
		private CCallbackBaseVTable VTable;

		// Token: 0x040002FC RID: 764
		private IntPtr m_pVTable = IntPtr.Zero;

		// Token: 0x040002FD RID: 765
		private CCallbackBase m_CCallbackBase;

		// Token: 0x040002FE RID: 766
		private GCHandle m_pCCallbackBase;

		// Token: 0x040002FF RID: 767
		private SteamAPICall_t m_hAPICall = SteamAPICall_t.Invalid;

		// Token: 0x04000300 RID: 768
		private readonly int m_size = Marshal.SizeOf(typeof(T));

		// Token: 0x02000072 RID: 114
		// (Invoke) Token: 0x0600038E RID: 910
		public delegate void APIDispatchDelegate(T param, bool bIOFailure);
	}
}
