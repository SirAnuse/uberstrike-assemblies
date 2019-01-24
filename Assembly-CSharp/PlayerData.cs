using System;
using System.Collections.Generic;
using UberStrike.Core.Models;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x0200038F RID: 911
public class PlayerData : ICharacterState
{
	// Token: 0x06001ABB RID: 6843 RVA: 0x0008B6AC File Offset: 0x000898AC
	public PlayerData()
	{
		this.Player = new GameActorInfo();
		this.Health.AddEvent(delegate(int el)
		{
			this.Player.Health = (short)el;
		}, null);
		this.ArmorPoints.AddEvent(delegate(int el)
		{
			this.Player.ArmorPoints = (byte)el;
		}, null);
	}

	// Token: 0x14000013 RID: 19
	// (add) Token: 0x06001ABD RID: 6845 RVA: 0x00011B82 File Offset: 0x0000FD82
	// (remove) Token: 0x06001ABE RID: 6846 RVA: 0x00011B9B File Offset: 0x0000FD9B
	public event Action<GameActorInfoDelta> OnDeltaUpdate = delegate(GameActorInfoDelta A_0)
	{
	};

	// Token: 0x14000014 RID: 20
	// (add) Token: 0x06001ABF RID: 6847 RVA: 0x00011BB4 File Offset: 0x0000FDB4
	// (remove) Token: 0x06001AC0 RID: 6848 RVA: 0x00011BCD File Offset: 0x0000FDCD
	public event Action<PlayerMovement> OnPositionUpdate = delegate(PlayerMovement A_0)
	{
	};

	// Token: 0x14000015 RID: 21
	// (add) Token: 0x06001AC1 RID: 6849 RVA: 0x00011BE6 File Offset: 0x0000FDE6
	// (remove) Token: 0x06001AC2 RID: 6850 RVA: 0x00011BFF File Offset: 0x0000FDFF
	public event Action<Vector3> SendJumpUpdate = delegate(Vector3 A_0)
	{
	};

	// Token: 0x14000016 RID: 22
	// (add) Token: 0x06001AC3 RID: 6851 RVA: 0x00011C18 File Offset: 0x0000FE18
	// (remove) Token: 0x06001AC4 RID: 6852 RVA: 0x00011C31 File Offset: 0x0000FE31
	public event Action<ShortVector3, ShortVector3, byte, byte, byte> SendMovementUpdate = delegate(ShortVector3 A_0, ShortVector3 A_1, byte A_2, byte A_3, byte A_4)
	{
	};

	// Token: 0x170005F4 RID: 1524
	// (get) Token: 0x06001AC5 RID: 6853 RVA: 0x00011C4A File Offset: 0x0000FE4A
	public int ArmorPointCapacity
	{
		get
		{
			return (int)this.Player.ArmorPointCapacity;
		}
	}

	// Token: 0x170005F5 RID: 1525
	// (get) Token: 0x06001AC6 RID: 6854 RVA: 0x00011C57 File Offset: 0x0000FE57
	public PlayerStates PlayerState
	{
		get
		{
			return this.Player.PlayerState;
		}
	}

	// Token: 0x170005F6 RID: 1526
	// (get) Token: 0x06001AC7 RID: 6855 RVA: 0x00011C64 File Offset: 0x0000FE64
	// (set) Token: 0x06001AC8 RID: 6856 RVA: 0x00011C6C File Offset: 0x0000FE6C
	public MoveStates MovementState { get; set; }

	// Token: 0x170005F7 RID: 1527
	// (get) Token: 0x06001AC9 RID: 6857 RVA: 0x00011C75 File Offset: 0x0000FE75
	// (set) Token: 0x06001ACA RID: 6858 RVA: 0x00011C7D File Offset: 0x0000FE7D
	public KeyState KeyState { get; private set; }

	// Token: 0x170005F8 RID: 1528
	// (get) Token: 0x06001ACB RID: 6859 RVA: 0x00011C86 File Offset: 0x0000FE86
	// (set) Token: 0x06001ACC RID: 6860 RVA: 0x00011C8E File Offset: 0x0000FE8E
	public Vector3 Velocity { get; set; }

	// Token: 0x170005F9 RID: 1529
	// (get) Token: 0x06001ACD RID: 6861 RVA: 0x00011C97 File Offset: 0x0000FE97
	public Vector3 Position
	{
		get
		{
			return (!(GameState.Current.Player != null)) ? Vector3.zero : GameState.Current.Player.transform.position;
		}
	}

	// Token: 0x170005FA RID: 1530
	// (get) Token: 0x06001ACE RID: 6862 RVA: 0x00011CCC File Offset: 0x0000FECC
	public Quaternion HorizontalRotation
	{
		get
		{
			return UserInput.HorizontalRotation;
		}
	}

	// Token: 0x170005FB RID: 1531
	// (get) Token: 0x06001ACF RID: 6863 RVA: 0x0008B894 File Offset: 0x00089A94
	public float VerticalRotation
	{
		get
		{
			return UserInput.VerticalRotation.eulerAngles.x;
		}
	}

	// Token: 0x06001AD0 RID: 6864 RVA: 0x0008B8B8 File Offset: 0x00089AB8
	public void Reset()
	{
		int num = 0;
		Singleton<LoadoutManager>.Instance.GetArmorValues(out num);
		this.Player.ArmorPointCapacity = (byte)num;
		this.Player.PlayerState = PlayerStates.None;
		this.KeyState = KeyState.Still;
		this.MovementState = MoveStates.None;
		this.Velocity = Vector3.zero;
		this.Health.Value = 100;
		this.ArmorPoints.Value = num;
	}

	// Token: 0x06001AD1 RID: 6865 RVA: 0x00011CD3 File Offset: 0x0000FED3
	public void InitializePlayer()
	{
		this.Reset();
	}

	// Token: 0x06001AD2 RID: 6866 RVA: 0x00011CDB File Offset: 0x0000FEDB
	public void SwitchWeaponSlot(int slot)
	{
		this.Actions.SwitchWeapon((byte)slot);
		this.Player.CurrentWeaponSlot = (byte)slot;
	}

	// Token: 0x06001AD3 RID: 6867 RVA: 0x00011CFC File Offset: 0x0000FEFC
	public void SetPing(int ping)
	{
		if ((int)this.Player.Ping != ping)
		{
			this.Player.Ping = (ushort)ping;
			this.Actions.UpdatePing(this.Player.Ping);
		}
	}

	// Token: 0x06001AD4 RID: 6868 RVA: 0x00011D37 File Offset: 0x0000FF37
	public float GetAbsorptionRate()
	{
		return 0.66f;
	}

	// Token: 0x06001AD5 RID: 6869 RVA: 0x0008B920 File Offset: 0x00089B20
	public void GetArmorDamage(short damage, BodyPart part, out short healthDamage, out byte armorDamage)
	{
		if (this.ArmorPoints > 0)
		{
			int value = Mathf.CeilToInt(this.GetAbsorptionRate() * (float)damage);
			armorDamage = (byte)Mathf.Clamp(value, 0, this.ArmorPoints);
			healthDamage = (short)(damage - (short)armorDamage);
		}
		else
		{
			armorDamage = 0;
			healthDamage = damage;
		}
	}

	// Token: 0x06001AD6 RID: 6870 RVA: 0x00011D3E File Offset: 0x0000FF3E
	public void Set(MoveStates state, bool on)
	{
		if (on)
		{
			this.MovementState |= state;
		}
		else
		{
			this.MovementState &= ~state;
		}
	}

	// Token: 0x06001AD7 RID: 6871 RVA: 0x0008B978 File Offset: 0x00089B78
	public void Set(PlayerStates state, bool on)
	{
		if (on)
		{
			GameActorInfo player = this.Player;
			player.PlayerState |= state;
			if (state != PlayerStates.Paused)
			{
				if (state != PlayerStates.Sniping)
				{
					if (state == PlayerStates.Shooting)
					{
						this.Actions.AutomaticFire(true);
					}
				}
				else
				{
					this.Actions.SniperMode(true);
				}
			}
			else
			{
				this.Actions.PausePlayer(true);
			}
		}
		else
		{
			GameActorInfo player2 = this.Player;
			player2.PlayerState &= ~state;
			if (state != PlayerStates.Paused)
			{
				if (state != PlayerStates.Sniping)
				{
					if (state == PlayerStates.Shooting)
					{
						this.Actions.AutomaticFire(false);
					}
				}
				else
				{
					this.Actions.SniperMode(false);
				}
			}
			else
			{
				this.Actions.PausePlayer(false);
			}
		}
	}

	// Token: 0x06001AD8 RID: 6872 RVA: 0x0008BA78 File Offset: 0x00089C78
	public void Set(KeyState state, bool on)
	{
		if (on && !this.Is(state))
		{
			this.KeyState |= state;
			this.Actions.UpdateKeyState((byte)this.KeyState);
		}
		else if (!on && this.Is(state))
		{
			this.KeyState &= ~state;
			this.Actions.UpdateKeyState((byte)this.KeyState);
		}
	}

	// Token: 0x06001AD9 RID: 6873 RVA: 0x00011D6B File Offset: 0x0000FF6B
	public void ResetKeys()
	{
		if (this.KeyState != KeyState.Still)
		{
			this.KeyState = KeyState.Still;
			this.Actions.UpdateKeyState((byte)this.KeyState);
		}
	}

	// Token: 0x06001ADA RID: 6874 RVA: 0x00011D95 File Offset: 0x0000FF95
	public bool Is(MoveStates state)
	{
		return (byte)(this.MovementState & state) != 0;
	}

	// Token: 0x06001ADB RID: 6875 RVA: 0x00011DA6 File Offset: 0x0000FFA6
	public bool Is(PlayerStates state)
	{
		return (byte)(this.PlayerState & state) != 0;
	}

	// Token: 0x06001ADC RID: 6876 RVA: 0x00011DB7 File Offset: 0x0000FFB7
	public bool Is(KeyState state)
	{
		return (byte)(this.KeyState & state) != 0;
	}

	// Token: 0x170005FC RID: 1532
	// (get) Token: 0x06001ADD RID: 6877 RVA: 0x00011DC8 File Offset: 0x0000FFC8
	public bool IsOnline
	{
		get
		{
			return !this.Is(PlayerStates.Offline);
		}
	}

	// Token: 0x170005FD RID: 1533
	// (get) Token: 0x06001ADE RID: 6878 RVA: 0x00011DD5 File Offset: 0x0000FFD5
	public bool IsAlive
	{
		get
		{
			return (byte)(this.PlayerState & PlayerStates.Dead) == 0;
		}
	}

	// Token: 0x170005FE RID: 1534
	// (get) Token: 0x06001ADF RID: 6879 RVA: 0x00011DE3 File Offset: 0x0000FFE3
	public bool IsSpectator
	{
		get
		{
			return (byte)(this.PlayerState & PlayerStates.Spectator) != 0;
		}
	}

	// Token: 0x170005FF RID: 1535
	// (get) Token: 0x06001AE0 RID: 6880 RVA: 0x00011DF4 File Offset: 0x0000FFF4
	public bool IsUnderWater
	{
		get
		{
			return (byte)(this.MovementState & (MoveStates.Swimming | MoveStates.Diving)) != 0;
		}
	}

	// Token: 0x17000600 RID: 1536
	// (get) Token: 0x06001AE1 RID: 6881 RVA: 0x00011E06 File Offset: 0x00010006
	public Vector3 CurrentOffset
	{
		get
		{
			return ((byte)(this.MovementState & MoveStates.Ducked) != 0) ? PlayerData.CrouchingOffset : PlayerData.StandingOffset;
		}
	}

	// Token: 0x17000601 RID: 1537
	// (get) Token: 0x06001AE2 RID: 6882 RVA: 0x00011E25 File Offset: 0x00010025
	public Vector3 ShootingPoint
	{
		get
		{
			return GameState.Current.Player.transform.position + this.CurrentOffset;
		}
	}

	// Token: 0x17000602 RID: 1538
	// (get) Token: 0x06001AE3 RID: 6883 RVA: 0x00011E46 File Offset: 0x00010046
	public Vector3 ShootingDirection
	{
		get
		{
			return UserInput.Rotation * Vector3.forward;
		}
	}

	// Token: 0x17000603 RID: 1539
	// (get) Token: 0x06001AE4 RID: 6884 RVA: 0x00011E57 File Offset: 0x00010057
	// (set) Token: 0x06001AE5 RID: 6885 RVA: 0x00011E5F File Offset: 0x0001005F
	public GameActorInfo Player { get; set; }

	// Token: 0x06001AE6 RID: 6886 RVA: 0x0008BAFC File Offset: 0x00089CFC
	public void DeltaUpdate(GameActorInfoDelta delta)
	{
		foreach (KeyValuePair<GameActorInfoDelta.Keys, object> keyValuePair in delta.Changes)
		{
			GameActorInfoDelta.Keys key = keyValuePair.Key;
			if (key != GameActorInfoDelta.Keys.ArmorPoints)
			{
				if (key != GameActorInfoDelta.Keys.Health)
				{
					if (key == GameActorInfoDelta.Keys.PlayerState)
					{
						this.Player.PlayerState = (PlayerStates)((byte)keyValuePair.Value);
					}
				}
				else
				{
					this.Health.Value = (int)((short)keyValuePair.Value);
				}
			}
			else
			{
				this.ArmorPoints.Value = (int)((byte)keyValuePair.Value);
			}
		}
		delta.Apply(this.Player);
		this.OnDeltaUpdate(delta);
	}

	// Token: 0x06001AE7 RID: 6887 RVA: 0x00003C87 File Offset: 0x00001E87
	public void PositionUpdate(PlayerMovement update, ushort gameFrame)
	{
	}

	// Token: 0x06001AE8 RID: 6888 RVA: 0x0008BBE0 File Offset: 0x00089DE0
	public void LandingUpdate()
	{
		this.posSyncFrame = Time.realtimeSinceStartup + 0.05f;
		byte arg = Convert.ToByte(this.MovementState | MoveStates.Landed);
		this.SendMovementUpdate(GameState.Current.Player.transform.position, GameState.Current.Player.MoveController.Velocity, Conversion.Angle2Byte(this.HorizontalRotation.eulerAngles.y), Conversion.Angle2Byte(this.VerticalRotation), arg);
	}

	// Token: 0x06001AE9 RID: 6889 RVA: 0x00011E68 File Offset: 0x00010068
	public void JumpingUpdate()
	{
		this.Set(MoveStates.Jumping, true);
		if (GameState.Current.Player != null)
		{
			this.SendJumpUpdate(GameState.Current.Player.transform.position);
		}
	}

	// Token: 0x06001AEA RID: 6890 RVA: 0x0008BC74 File Offset: 0x00089E74
	public void SendUpdates()
	{
		if (GameState.Current.IsInGame && this.IsAlive && this.posSyncFrame <= Time.realtimeSinceStartup && this.SendMovementUpdate != null)
		{
			this.posSyncFrame = Time.realtimeSinceStartup + 0.05f;
			if (this.cache.Update(GameState.Current.Player.transform.position, Conversion.Angle2Byte(this.HorizontalRotation.eulerAngles.y), Conversion.Angle2Byte(this.VerticalRotation), (byte)this.MovementState))
			{
				this.SendMovementUpdate(this.cache.Position, GameState.Current.Player.MoveController.Velocity, this.cache.HRotation, this.cache.VRotation, this.cache.MovementState);
				Singleton<GameStateController>.Instance.Client.Peer.SendOutgoingCommands();
			}
		}
	}

	// Token: 0x04001802 RID: 6146
	public readonly PlayerActions Actions = new PlayerActions();

	// Token: 0x04001803 RID: 6147
	private float posSyncFrame;

	// Token: 0x04001804 RID: 6148
	private float shotSyncFrame;

	// Token: 0x04001805 RID: 6149
	public IntegerProperty Health = new IntegerProperty(0, 0, 200);

	// Token: 0x04001806 RID: 6150
	public IntegerProperty ArmorPoints = new IntegerProperty(0, 0, 200);

	// Token: 0x04001807 RID: 6151
	public IntegerProperty ArmorCarried = new IntegerProperty(0, 0, 200);

	// Token: 0x04001808 RID: 6152
	public IntegerProperty RemainingTime = new IntegerProperty(0, 0, int.MaxValue);

	// Token: 0x04001809 RID: 6153
	public IntegerProperty RemainingKills = new IntegerProperty(0, 0, int.MaxValue);

	// Token: 0x0400180A RID: 6154
	public Property<TeamID> Team = new Property<TeamID>(TeamID.NONE);

	// Token: 0x0400180B RID: 6155
	public IntegerProperty BlueTeamScore = new IntegerProperty(0, 0, int.MaxValue);

	// Token: 0x0400180C RID: 6156
	public IntegerProperty RedTeamScore = new IntegerProperty(0, 0, int.MaxValue);

	// Token: 0x0400180D RID: 6157
	public Property<Dictionary<LoadoutSlotType, IUnityItem>> LoadoutWeapons = new Property<Dictionary<LoadoutSlotType, IUnityItem>>();

	// Token: 0x0400180E RID: 6158
	public Property<WeaponSlot> ActiveWeapon = new Property<WeaponSlot>();

	// Token: 0x0400180F RID: 6159
	public Property<WeaponSlot> NextActiveWeapon = new Property<WeaponSlot>();

	// Token: 0x04001810 RID: 6160
	public IntegerProperty Ammo = new IntegerProperty(0, 0, int.MaxValue);

	// Token: 0x04001811 RID: 6161
	public Property<WeaponSlot> WeaponFired = new Property<WeaponSlot>();

	// Token: 0x04001812 RID: 6162
	public Property<TeamID> FocusedPlayerTeam = new Property<TeamID>(TeamID.NONE);

	// Token: 0x04001813 RID: 6163
	public Property<DamageInfo> AppliedDamage = new Property<DamageInfo>();

	// Token: 0x04001814 RID: 6164
	public Property<bool> IsIronSighted = new Property<bool>(false);

	// Token: 0x04001815 RID: 6165
	public Property<bool> IsZoomedIn = new Property<bool>(false);

	// Token: 0x04001816 RID: 6166
	public static readonly Vector3 StandingOffset = new Vector3(0f, 0.65f, 0f);

	// Token: 0x04001817 RID: 6167
	public static readonly Vector3 CrouchingOffset = new Vector3(0f, 0.1f, 0f);

	// Token: 0x04001818 RID: 6168
	private MovementUpdateCache cache = new MovementUpdateCache();
}
