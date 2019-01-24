using System;
using System.Collections.Generic;
using System.Text;
using UberStrike.Core.Models;
using UberStrike.Core.Models.Views;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x020003CF RID: 975
public static class MiscellaneousExtension
{
	// Token: 0x06001C8A RID: 7306
	public static string ToCustomString(this GameActorInfo info)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("Name: {0} - {1}/{2}\n", info.PlayerName, info.Cmid, info.PlayerId);
		stringBuilder.AppendLine("Play: " + CmunePrint.Flag<PlayerStates>(info.PlayerState));
		stringBuilder.AppendLine(string.Concat(new object[]
		{
			"CurrentWeapon: ",
			info.CurrentWeaponSlot,
			"/",
			info.CurrentWeaponID
		}));
		stringBuilder.AppendLine(string.Concat(new object[]
		{
			"Life: ",
			info.Health,
			"/",
			info.ArmorPoints
		}));
		stringBuilder.AppendLine("Team: " + info.TeamID);
		stringBuilder.AppendLine("Color: " + info.SkinColor);
		stringBuilder.AppendLine("Weapons: " + CmunePrint.Values(new object[]
		{
			info.Weapons
		}));
		stringBuilder.AppendLine("Gear: " + CmunePrint.Values(new object[]
		{
			info.Gear
		}));
		return stringBuilder.ToString();
	}

	// Token: 0x06001C8B RID: 7307
	public static Transform FindChildWithName(this Transform tr, string name)
	{
		foreach (Transform transform in tr.GetComponentsInChildren<Transform>(true))
		{
			if (transform.name == name)
			{
				return transform;
			}
		}
		return null;
	}

	// Token: 0x06001C8C RID: 7308
	public static void ShareParent(this Transform _this, Transform transform)
	{
		Vector3 localPosition = transform.localPosition;
		Quaternion localRotation = transform.localRotation;
		Vector3 localScale = transform.localScale;
		_this.parent = transform.parent;
		_this.localPosition = localPosition;
		_this.localRotation = localRotation;
		_this.localScale = localScale;
	}

	// Token: 0x06001C8D RID: 7309
	public static void Reparent(this Transform _this, Transform newParent)
	{
		Vector3 localPosition = _this.localPosition;
		Quaternion localRotation = _this.localRotation;
		Vector3 localScale = _this.localScale;
		_this.parent = newParent;
		_this.localPosition = localPosition;
		_this.localRotation = localRotation;
		_this.localScale = localScale;
	}

	// Token: 0x06001C8E RID: 7310
	public static string ToCustomString(this GameActorInfoDelta info)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Delta ").Append(info.Id).Append(":");
		foreach (KeyValuePair<GameActorInfoDelta.Keys, object> keyValuePair in info.Changes)
		{
			stringBuilder.Append(keyValuePair.Key.ToString()).Append("|");
		}
		return stringBuilder.ToString();
	}

	// Token: 0x06001C8F RID: 7311
	public static MapSettings Default(this MapSettings info)
	{
		return new MapSettings
		{
			KillsCurrent = 5,
			KillsMax = 100,
			KillsMin = 1,
			PlayersCurrent = 0,
			PlayersMax = 16,
			PlayersMin = 1,
			TimeCurrent = 60,
			TimeMax = 1800,
			TimeMin = 1
		};
	}
}
