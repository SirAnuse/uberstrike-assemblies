using System;
using System.Collections.Generic;
using Cmune.Core.Models.Views;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x0200003A RID: 58
	[Serializable]
	public class ApplicationView
	{
		// Token: 0x0600000D RID: 13 RVA: 0x000020C9 File Offset: 0x000002C9
		public ApplicationView()
		{
			this.Servers = new List<PhotonView>();
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000020DC File Offset: 0x000002DC
		public ApplicationView(string version, BuildType build, ChannelType channel)
		{
			this.Version = version;
			this.Build = build;
			this.Channel = channel;
			this.Servers = new List<PhotonView>();
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000CD74 File Offset: 0x0000AF74
		public ApplicationView(int applicationVersionId, string version, BuildType build, ChannelType channel, string fileName, DateTime releaseDate, DateTime? expirationDate, bool isCurrent, string supportUrl, int photonGroupId, List<PhotonView> servers)
		{
			int remainingTime = -1;
			if (expirationDate != null && expirationDate != null)
			{
				DateTime value = expirationDate.Value;
				if (value.CompareTo(DateTime.UtcNow) <= 0)
				{
					remainingTime = 0;
				}
				else
				{
					remainingTime = (int)Math.Floor(DateTime.UtcNow.Subtract(value).TotalMinutes);
				}
			}
			this.SetApplication(applicationVersionId, version, build, channel, fileName, releaseDate, expirationDate, remainingTime, isCurrent, supportUrl, photonGroupId, servers);
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000010 RID: 16 RVA: 0x00002104 File Offset: 0x00000304
		// (set) Token: 0x06000011 RID: 17 RVA: 0x0000210C File Offset: 0x0000030C
		public int ApplicationVersionId { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000012 RID: 18 RVA: 0x00002115 File Offset: 0x00000315
		// (set) Token: 0x06000013 RID: 19 RVA: 0x0000211D File Offset: 0x0000031D
		public string Version { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000014 RID: 20 RVA: 0x00002126 File Offset: 0x00000326
		// (set) Token: 0x06000015 RID: 21 RVA: 0x0000212E File Offset: 0x0000032E
		public BuildType Build { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000016 RID: 22 RVA: 0x00002137 File Offset: 0x00000337
		// (set) Token: 0x06000017 RID: 23 RVA: 0x0000213F File Offset: 0x0000033F
		public ChannelType Channel { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000018 RID: 24 RVA: 0x00002148 File Offset: 0x00000348
		// (set) Token: 0x06000019 RID: 25 RVA: 0x00002150 File Offset: 0x00000350
		public string FileName { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600001A RID: 26 RVA: 0x00002159 File Offset: 0x00000359
		// (set) Token: 0x0600001B RID: 27 RVA: 0x00002161 File Offset: 0x00000361
		public DateTime ReleaseDate { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600001C RID: 28 RVA: 0x0000216A File Offset: 0x0000036A
		// (set) Token: 0x0600001D RID: 29 RVA: 0x00002172 File Offset: 0x00000372
		public DateTime? ExpirationDate { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600001E RID: 30 RVA: 0x0000217B File Offset: 0x0000037B
		// (set) Token: 0x0600001F RID: 31 RVA: 0x00002183 File Offset: 0x00000383
		public int RemainingTime { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000020 RID: 32 RVA: 0x0000218C File Offset: 0x0000038C
		// (set) Token: 0x06000021 RID: 33 RVA: 0x00002194 File Offset: 0x00000394
		public bool IsCurrent { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000022 RID: 34 RVA: 0x0000219D File Offset: 0x0000039D
		// (set) Token: 0x06000023 RID: 35 RVA: 0x000021A5 File Offset: 0x000003A5
		public List<PhotonView> Servers { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000024 RID: 36 RVA: 0x000021AE File Offset: 0x000003AE
		// (set) Token: 0x06000025 RID: 37 RVA: 0x000021B6 File Offset: 0x000003B6
		public string SupportUrl { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000026 RID: 38 RVA: 0x000021BF File Offset: 0x000003BF
		// (set) Token: 0x06000027 RID: 39 RVA: 0x000021C7 File Offset: 0x000003C7
		public int PhotonGroupId { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000028 RID: 40 RVA: 0x000021D0 File Offset: 0x000003D0
		// (set) Token: 0x06000029 RID: 41 RVA: 0x000021D8 File Offset: 0x000003D8
		public string PhotonGroupName { get; set; }

		// Token: 0x0600002A RID: 42 RVA: 0x0000CDFC File Offset: 0x0000AFFC
		private void SetApplication(int applicationVersionID, string version, BuildType build, ChannelType channel, string fileName, DateTime releaseDate, DateTime? expirationDate, int remainingTime, bool isCurrent, string supportUrl, int photonGroupId, List<PhotonView> servers)
		{
			this.ApplicationVersionId = applicationVersionID;
			this.Version = version;
			this.Build = build;
			this.Channel = channel;
			this.FileName = fileName;
			this.ReleaseDate = releaseDate;
			this.ExpirationDate = expirationDate;
			this.RemainingTime = remainingTime;
			this.IsCurrent = isCurrent;
			this.SupportUrl = supportUrl;
			this.PhotonGroupId = photonGroupId;
			if (servers != null)
			{
				this.Servers = servers;
			}
			else
			{
				this.Servers = new List<PhotonView>();
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x0000CE80 File Offset: 0x0000B080
		public override string ToString()
		{
			string text = "[Application: ";
			string text2 = text;
			text = string.Concat(new object[]
			{
				text2,
				"[ID: ",
				this.ApplicationVersionId,
				"][version: ",
				this.Version,
				"][Build: ",
				this.Build,
				"][Channel: ",
				this.Channel,
				"][File name: ",
				this.FileName,
				"][Release date: ",
				this.ReleaseDate,
				"][Expiration date: ",
				this.ExpirationDate,
				"][Remaining time: ",
				this.RemainingTime,
				"][Is current: ",
				this.IsCurrent,
				"][Support URL: ",
				this.SupportUrl,
				"]"
			});
			text += "[Servers]";
			foreach (PhotonView photonView in this.Servers)
			{
				text += photonView.ToString();
			}
			text += "[/Servers]]";
			text += "]";
			return text;
		}
	}
}
