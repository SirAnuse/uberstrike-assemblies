using System;
using System.Collections.Generic;
using System.Linq;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001DA RID: 474
	public class FacebookBasicStatisticView : EsnsBasicStatisticView
	{
		// Token: 0x06000B96 RID: 2966 RVA: 0x0000857F File Offset: 0x0000677F
		public FacebookBasicStatisticView(long facebookId, string firstName, string picturePath, string name, int xp, int level, int cmid) : base(name, xp, level, cmid)
		{
			this.FacebookId = facebookId;
			this.FirstName = firstName;
			this.PicturePath = picturePath;
		}

		// Token: 0x06000B97 RID: 2967 RVA: 0x000085A4 File Offset: 0x000067A4
		public FacebookBasicStatisticView(long facebookId, string firstName, string picturePath)
		{
			this.FacebookId = facebookId;
			this.FirstName = firstName;
			this.PicturePath = picturePath;
		}

		// Token: 0x06000B98 RID: 2968 RVA: 0x000085C1 File Offset: 0x000067C1
		public FacebookBasicStatisticView()
		{
			this.FacebookId = 0L;
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06000B99 RID: 2969 RVA: 0x000085D1 File Offset: 0x000067D1
		// (set) Token: 0x06000B9A RID: 2970 RVA: 0x000085D9 File Offset: 0x000067D9
		public long FacebookId { get; set; }

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06000B9B RID: 2971 RVA: 0x000085E2 File Offset: 0x000067E2
		// (set) Token: 0x06000B9C RID: 2972 RVA: 0x000085EA File Offset: 0x000067EA
		public string FirstName { get; set; }

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x06000B9D RID: 2973 RVA: 0x000085F3 File Offset: 0x000067F3
		// (set) Token: 0x06000B9E RID: 2974 RVA: 0x000085FB File Offset: 0x000067FB
		public string PicturePath
		{
			get
			{
				return this._picturePath;
			}
			set
			{
				if (value.StartsWith("http:"))
				{
					value = value.Replace("http:", "https:");
				}
				this._picturePath = value;
			}
		}

		// Token: 0x06000B9F RID: 2975 RVA: 0x0000FDC4 File Offset: 0x0000DFC4
		public static List<FacebookBasicStatisticView> Rank(List<FacebookBasicStatisticView> views, int friendsDisplayedCount)
		{
			List<FacebookBasicStatisticView> list = new List<FacebookBasicStatisticView>();
			FacebookBasicStatisticView facebookBasicStatisticView = null;
			if (views.Count > 0)
			{
				facebookBasicStatisticView = views[0];
			}
			views = (from v in views
			orderby v.XP descending
			select v).ToList<FacebookBasicStatisticView>();
			int num = 1;
			foreach (FacebookBasicStatisticView facebookBasicStatisticView2 in views)
			{
				if (facebookBasicStatisticView2.Cmid != 0)
				{
					facebookBasicStatisticView2.SocialRank = num;
					num++;
				}
			}
			list.Add(facebookBasicStatisticView);
			num = 0;
			int num2 = 0;
			while (num2 < friendsDisplayedCount && num2 < views.Count)
			{
				if (views[num2].FacebookId != facebookBasicStatisticView.FacebookId)
				{
					list.Add(views[num2]);
					num++;
				}
				num2++;
			}
			while (list.Count < friendsDisplayedCount + 1)
			{
				list.Add(new FacebookBasicStatisticView());
			}
			return list;
		}

		// Token: 0x0400096B RID: 2411
		private string _picturePath;
	}
}
