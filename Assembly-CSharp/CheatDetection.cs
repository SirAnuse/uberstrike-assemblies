using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x020003BE RID: 958
public class CheatDetection : MonoBehaviour
{
	// Token: 0x06001C09 RID: 7177 RVA: 0x00012A42 File Offset: 0x00010C42
	public static void SyncSystemTime()
	{
		CheatDetection._gameTime = SystemTime.Running;
		CheatDetection._dateTime = DateTime.Now;
	}

	// Token: 0x17000638 RID: 1592
	// (get) Token: 0x06001C0A RID: 7178 RVA: 0x00012A58 File Offset: 0x00010C58
	private int GameTime
	{
		get
		{
			return SystemTime.Running - CheatDetection._gameTime;
		}
	}

	// Token: 0x17000639 RID: 1593
	// (get) Token: 0x06001C0B RID: 7179 RVA: 0x0008EDE4 File Offset: 0x0008CFE4
	private int RealTime
	{
		get
		{
			return (int)(DateTime.Now - CheatDetection._dateTime).TotalMilliseconds;
		}
	}

	// Token: 0x06001C0C RID: 7180 RVA: 0x0008EE0C File Offset: 0x0008D00C
	private IEnumerator StartCheckSecureMemory()
	{
		for (;;)
		{
			try
			{
				SecureMemoryMonitor.Instance.PerformCheck();
			}
			catch
			{
				AutoMonoBehaviour<CommConnectionManager>.Instance.DisableNetworkConnection("You have been disconnected. Please restart UberStrike.");
			}
			yield return new WaitForSeconds(10f);
		}
		yield break;
	}

	// Token: 0x06001C0D RID: 7181 RVA: 0x0008EE20 File Offset: 0x0008D020
	private IEnumerator StartNewSpeedhackDetection()
	{
		yield return new WaitForSeconds(5f);
		CheatDetection.SyncSystemTime();
		LimitedQueue<float> timeDifference = new LimitedQueue<float>(5);
		for (;;)
		{
			yield return new WaitForSeconds(5f);
			if (GameState.Current.HasJoinedGame)
			{
				timeDifference.Enqueue((float)this.GameTime / (float)this.RealTime);
				CheatDetection.SyncSystemTime();
				if (timeDifference.Count == 5)
				{
					float avg = this.averageSpeedHackResults(timeDifference);
					if (avg != -1f)
					{
						if ((double)avg >= 0.75)
						{
							break;
						}
						timeDifference.Clear();
					}
				}
			}
		}
		AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.Operations.SendSpeedhackDetectionNew(timeDifference.ToList<float>());
		yield break;
	}

	// Token: 0x06001C0E RID: 7182 RVA: 0x0008EE3C File Offset: 0x0008D03C
	private float averageSpeedHackResults(IEnumerable<float> list)
	{
		if (this.IsSpeedHacking(list))
		{
			CheatDetection._speedHack_table.Add(1f);
		}
		else
		{
			CheatDetection._speedHack_table.Add(0f);
		}
		if (CheatDetection._speedHack_table.Count == 10)
		{
			float num = 0f;
			foreach (float num2 in CheatDetection._speedHack_table)
			{
				float num3 = num2;
				num += num3;
			}
			float result = num / (float)CheatDetection._speedHack_table.Count;
			CheatDetection._speedHack_table.Clear();
			return result;
		}
		return -1f;
	}

	// Token: 0x06001C0F RID: 7183 RVA: 0x0008EEF8 File Offset: 0x0008D0F8
	private bool IsSpeedHacking(IEnumerable<float> list)
	{
		int num = 0;
		float num2 = 0f;
		foreach (float num3 in list)
		{
			float num4 = num3;
			num2 += num4;
			num++;
		}
		num2 /= (float)num;
		float num5 = 0f;
		foreach (float num6 in list)
		{
			float num7 = num6;
			num5 += Mathf.Pow(num7 - num2, 2f);
		}
		num5 /= (float)(num - 1);
		return num2 > 2f || (num2 > 1.1f && num5 < 0.02f);
	}

	// Token: 0x04001904 RID: 6404
	private static int _gameTime;

	// Token: 0x04001905 RID: 6405
	private static DateTime _dateTime;

	// Token: 0x04001906 RID: 6406
	private static List<float> _speedHack_table = new List<float>();
}
