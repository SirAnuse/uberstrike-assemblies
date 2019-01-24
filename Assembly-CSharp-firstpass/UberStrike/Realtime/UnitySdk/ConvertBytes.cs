using System;

namespace UberStrike.Realtime.UnitySdk
{
	// Token: 0x0200033F RID: 831
	public static class ConvertBytes
	{
		// Token: 0x0600138B RID: 5003 RVA: 0x0000BFE5 File Offset: 0x0000A1E5
		public static float ToKiloBytes(ulong bytes)
		{
			return Convert.ToSingle(bytes * 0.0009765625);
		}

		// Token: 0x0600138C RID: 5004 RVA: 0x0000BFF9 File Offset: 0x0000A1F9
		public static float ToKiloBytes(int bytes)
		{
			return Convert.ToSingle((double)bytes * 0.0009765625);
		}

		// Token: 0x0600138D RID: 5005 RVA: 0x0000BFF9 File Offset: 0x0000A1F9
		public static float ToKiloBytes(long bytes)
		{
			return Convert.ToSingle((double)bytes * 0.0009765625);
		}

		// Token: 0x0600138E RID: 5006 RVA: 0x0000C00C File Offset: 0x0000A20C
		public static float ToMegaBytes(ulong bytes)
		{
			return Convert.ToSingle(bytes * 0.0009765625 * 0.0009765625);
		}

		// Token: 0x0600138F RID: 5007 RVA: 0x0000C02A File Offset: 0x0000A22A
		public static float ToMegaBytes(long bytes)
		{
			return Convert.ToSingle((double)bytes * 0.0009765625 * 0.0009765625);
		}

		// Token: 0x06001390 RID: 5008 RVA: 0x0000C02A File Offset: 0x0000A22A
		public static float ToMegaBytes(int bytes)
		{
			return Convert.ToSingle((double)bytes * 0.0009765625 * 0.0009765625);
		}

		// Token: 0x06001391 RID: 5009 RVA: 0x0000C047 File Offset: 0x0000A247
		public static float ToGigaBytes(ulong bytes)
		{
			return Convert.ToSingle(bytes * 0.0009765625 * 0.0009765625 * 0.0009765625);
		}

		// Token: 0x06001392 RID: 5010 RVA: 0x0000C06F File Offset: 0x0000A26F
		public static float ToGigaBytes(long bytes)
		{
			return Convert.ToSingle((double)bytes * 0.0009765625 * 0.0009765625 * 0.0009765625);
		}

		// Token: 0x06001393 RID: 5011 RVA: 0x0000C06F File Offset: 0x0000A26F
		public static float ToGigaBytes(int bytes)
		{
			return Convert.ToSingle((double)bytes * 0.0009765625 * 0.0009765625 * 0.0009765625);
		}

		// Token: 0x04000E06 RID: 3590
		private const double toKilo = 0.0009765625;
	}
}
