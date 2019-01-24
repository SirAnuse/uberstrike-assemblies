using System;

namespace UberStrike.Core.Models
{
	// Token: 0x02000215 RID: 533
	[Serializable]
	public class ConnectionAddress
	{
		// Token: 0x06000DCE RID: 3534 RVA: 0x00002050 File Offset: 0x00000250
		public ConnectionAddress()
		{
		}

		// Token: 0x06000DCF RID: 3535 RVA: 0x00011890 File Offset: 0x0000FA90
		public ConnectionAddress(string connection)
		{
			try
			{
				string[] array = connection.Split(new char[]
				{
					':'
				});
				this.Ipv4 = ConnectionAddress.ToInteger(array[0]);
				this.Port = ushort.Parse(array[1]);
			}
			catch
			{
			}
		}

		// Token: 0x06000DD0 RID: 3536 RVA: 0x0000995A File Offset: 0x00007B5A
		public ConnectionAddress(string ipAddress, ushort port)
		{
			this.Ipv4 = ConnectionAddress.ToInteger(ipAddress);
			this.Port = port;
		}

		// Token: 0x17000285 RID: 645
		// (get) Token: 0x06000DD1 RID: 3537 RVA: 0x00009975 File Offset: 0x00007B75
		// (set) Token: 0x06000DD2 RID: 3538 RVA: 0x0000997D File Offset: 0x00007B7D
		public int Ipv4 { get; set; }

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x06000DD3 RID: 3539 RVA: 0x00009986 File Offset: 0x00007B86
		// (set) Token: 0x06000DD4 RID: 3540 RVA: 0x0000998E File Offset: 0x00007B8E
		public ushort Port { get; set; }

		// Token: 0x17000287 RID: 647
		// (get) Token: 0x06000DD5 RID: 3541 RVA: 0x00009997 File Offset: 0x00007B97
		public string ConnectionString
		{
			get
			{
				return string.Format("{0}:{1}", ConnectionAddress.ToString(this.Ipv4), this.Port);
			}
		}

		// Token: 0x17000288 RID: 648
		// (get) Token: 0x06000DD6 RID: 3542 RVA: 0x000099B9 File Offset: 0x00007BB9
		public string IpAddress
		{
			get
			{
				return ConnectionAddress.ToString(this.Ipv4);
			}
		}

		// Token: 0x06000DD7 RID: 3543 RVA: 0x000118EC File Offset: 0x0000FAEC
		public static string ToString(int ipv4)
		{
			return string.Format("{0}.{1}.{2}.{3}", new object[]
			{
				ipv4 >> 24 & 255,
				ipv4 >> 16 & 255,
				ipv4 >> 8 & 255,
				ipv4 & 255
			});
		}

		// Token: 0x06000DD8 RID: 3544 RVA: 0x00011950 File Offset: 0x0000FB50
		public static int ToInteger(string ipAddress)
		{
			int num = 0;
			string[] array = ipAddress.Split(new char[]
			{
				'.'
			});
			if (array.Length == 4)
			{
				for (int i = 0; i < array.Length; i++)
				{
					num |= int.Parse(array[i]) << (3 - i) * 8;
				}
			}
			return num;
		}
	}
}
