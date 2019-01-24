using System;
using UberStrike.Core.Models;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x02000396 RID: 918
public class RemoteCharacterState : ICharacterState
{
	// Token: 0x06001B22 RID: 6946 RVA: 0x0008BFAC File Offset: 0x0008A1AC
	public RemoteCharacterState(GameActorInfo info, PlayerMovement update)
	{
		this.debugger = new PositionSyncDebugger();
		this.Player = info;
		this.sampler.Reset(update.Position);
		this.PositionUpdate(update, 0);
		this.HorizontalRotation = Quaternion.Euler(0f, this.hRotationTarget, 0f);
		this.VerticalRotation = this.vRotationTarget;
	}

	// Token: 0x14000019 RID: 25
	// (add) Token: 0x06001B23 RID: 6947 RVA: 0x00011FB6 File Offset: 0x000101B6
	// (remove) Token: 0x06001B24 RID: 6948 RVA: 0x00011FCF File Offset: 0x000101CF
	public event Action<GameActorInfoDelta> OnDeltaUpdate = delegate(GameActorInfoDelta A_0)
	{
	};

	// Token: 0x1400001A RID: 26
	// (add) Token: 0x06001B25 RID: 6949 RVA: 0x00011FE8 File Offset: 0x000101E8
	// (remove) Token: 0x06001B26 RID: 6950 RVA: 0x00012001 File Offset: 0x00010201
	public event Action<PlayerMovement> OnPositionUpdate = delegate(PlayerMovement A_0)
	{
	};

	// Token: 0x1700060D RID: 1549
	// (get) Token: 0x06001B27 RID: 6951 RVA: 0x0001201A File Offset: 0x0001021A
	// (set) Token: 0x06001B28 RID: 6952 RVA: 0x00012022 File Offset: 0x00010222
	public GameActorInfo Player { get; private set; }

	// Token: 0x1700060E RID: 1550
	// (get) Token: 0x06001B29 RID: 6953 RVA: 0x0001202B File Offset: 0x0001022B
	// (set) Token: 0x06001B2A RID: 6954 RVA: 0x00012033 File Offset: 0x00010233
	public Vector3 Velocity { get; set; }

	// Token: 0x1700060F RID: 1551
	// (get) Token: 0x06001B2B RID: 6955 RVA: 0x0001203C File Offset: 0x0001023C
	// (set) Token: 0x06001B2C RID: 6956 RVA: 0x00012044 File Offset: 0x00010244
	public Vector3 Position { get; set; }

	// Token: 0x17000610 RID: 1552
	// (get) Token: 0x06001B2D RID: 6957 RVA: 0x0001204D File Offset: 0x0001024D
	// (set) Token: 0x06001B2E RID: 6958 RVA: 0x00012055 File Offset: 0x00010255
	public Quaternion HorizontalRotation { get; set; }

	// Token: 0x17000611 RID: 1553
	// (get) Token: 0x06001B2F RID: 6959 RVA: 0x0001205E File Offset: 0x0001025E
	// (set) Token: 0x06001B30 RID: 6960 RVA: 0x00012066 File Offset: 0x00010266
	public float VerticalRotation { get; set; }

	// Token: 0x17000612 RID: 1554
	// (get) Token: 0x06001B31 RID: 6961 RVA: 0x0001206F File Offset: 0x0001026F
	// (set) Token: 0x06001B32 RID: 6962 RVA: 0x00012077 File Offset: 0x00010277
	public MoveStates MovementState { get; set; }

	// Token: 0x17000613 RID: 1555
	// (get) Token: 0x06001B33 RID: 6963 RVA: 0x00012080 File Offset: 0x00010280
	// (set) Token: 0x06001B34 RID: 6964 RVA: 0x00012088 File Offset: 0x00010288
	public KeyState KeyState { get; set; }

	// Token: 0x06001B35 RID: 6965 RVA: 0x00012091 File Offset: 0x00010291
	public bool Is(MoveStates state)
	{
		return (byte)(this.MovementState & state) != 0;
	}

	// Token: 0x06001B36 RID: 6966 RVA: 0x0008C068 File Offset: 0x0008A268
	public void PositionUpdate(PlayerMovement update, ushort gameFrame)
	{
		this.MovementState = (MoveStates)update.MovementState;
		this.KeyState = (KeyState)update.KeyState;
		this.Velocity = update.Velocity;
		this.hRotationTarget = Conversion.Byte2Angle(update.HorizontalRotation);
		this.vRotationTarget = Conversion.Byte2Angle(update.VerticalRotation);
		this.sampler.Add(update, gameFrame);
		this.debugger.AddSample(update.Position, this.MovementState);
		this.InterpolateMovement();
		this.OnPositionUpdate(update);
	}

	// Token: 0x06001B37 RID: 6967 RVA: 0x000120A2 File Offset: 0x000102A2
	public void DeltaUpdate(GameActorInfoDelta update)
	{
		update.Apply(this.Player);
		this.OnDeltaUpdate(update);
	}

	// Token: 0x06001B38 RID: 6968 RVA: 0x000120BC File Offset: 0x000102BC
	public void SetPosition(Vector3 pos)
	{
		this.sampler.Reset(pos);
		this.InterpolateMovement();
	}

	// Token: 0x06001B39 RID: 6969 RVA: 0x0008C0FC File Offset: 0x0008A2FC
	public void InterpolateMovement()
	{
		if (Time.time > this.sampler.LastTime && this.KeyState != KeyState.Still)
		{
			this.sampler.Extrapolate();
		}
		this.Position = this.sampler.Lerp();
		this.HorizontalRotation = Quaternion.Lerp(this.HorizontalRotation, Quaternion.Euler(0f, this.hRotationTarget, 0f), Time.deltaTime * 5f);
		this.VerticalRotation = Mathf.LerpAngle(this.VerticalRotation, this.vRotationTarget, Time.deltaTime * 20f);
		if (this.VerticalRotation > 180f)
		{
			this.VerticalRotation -= 360f;
		}
	}

	// Token: 0x04001832 RID: 6194
	private PositionSyncDebugger debugger;

	// Token: 0x04001833 RID: 6195
	private float hRotationTarget;

	// Token: 0x04001834 RID: 6196
	private float vRotationTarget;

	// Token: 0x04001835 RID: 6197
	private RemoteCharacterState.PositionInterpolator sampler = new RemoteCharacterState.PositionInterpolator();

	// Token: 0x02000397 RID: 919
	private class PositionInterpolator
	{
		// Token: 0x06001B3C RID: 6972 RVA: 0x000120D0 File Offset: 0x000102D0
		public PositionInterpolator()
		{
			this.Reset(Vector3.zero);
		}

		// Token: 0x06001B3D RID: 6973 RVA: 0x0008C1BC File Offset: 0x0008A3BC
		public void Add(PlayerMovement m, ushort gameFrame)
		{
			if (Mathf.Abs((int)gameFrame - this.sampleA.GameFrame) > 5)
			{
				this.baseGameFrame = (int)gameFrame;
				this.baseTime = Time.time;
				this.avgFrameTime = 0.1f;
			}
			else
			{
				this.avgFrameTime = (Time.time - this.baseTime) / (float)((int)gameFrame - this.baseGameFrame);
				if (float.IsNaN(this.avgFrameTime) || float.IsInfinity(this.avgFrameTime) || this.avgFrameTime < 0.01f)
				{
					this.avgFrameTime = 0.1f;
				}
			}
			Vector3 vector = this.Lerp();
			if ((int)gameFrame == this.sampleA.GameFrame)
			{
				this.sampleA = new RemoteCharacterState.PositionInterpolator.Packet
				{
					Position = m.Position,
					Time = this.baseTime + (float)((int)gameFrame - this.baseGameFrame) * this.avgFrameTime + this.timeWindow * this.avgFrameTime,
					GameFrame = (int)gameFrame
				};
			}
			else
			{
				this.sampleC = this.sampleB;
				this.sampleB = this.sampleA;
				this.sampleA = new RemoteCharacterState.PositionInterpolator.Packet
				{
					Position = m.Position,
					Time = this.baseTime + (float)((int)gameFrame - this.baseGameFrame) * this.avgFrameTime + this.timeWindow * this.avgFrameTime,
					GameFrame = (int)gameFrame
				};
				Vector3 vector2 = this.Lerp();
			}
		}

		// Token: 0x06001B3E RID: 6974 RVA: 0x0008C338 File Offset: 0x0008A538
		public Vector3 Lerp()
		{
			if (Time.time > this.sampleB.Time)
			{
				float t = 1f - Mathf.Clamp01(this.sampleA.Time - Time.time) / Mathf.Max(this.sampleA.Time - this.sampleB.Time, 0.05f);
				return Vector3.Lerp(this.sampleB.Position, this.sampleA.Position, t);
			}
			float t2 = 1f - Mathf.Clamp01(this.sampleB.Time - Time.time) / Mathf.Max(this.sampleB.Time - this.sampleC.Time, 0.05f);
			return Vector3.Lerp(this.sampleC.Position, this.sampleB.Position, t2);
		}

		// Token: 0x06001B3F RID: 6975 RVA: 0x0008C414 File Offset: 0x0008A614
		public void Reset(Vector3 pos)
		{
			this.sampleA = new RemoteCharacterState.PositionInterpolator.Packet
			{
				Position = pos,
				Time = Time.time + this.timeWindow * this.avgFrameTime
			};
			this.sampleB = new RemoteCharacterState.PositionInterpolator.Packet
			{
				Position = pos,
				Time = Time.time + this.timeWindow * this.avgFrameTime - 1f * this.avgFrameTime
			};
			this.sampleC = new RemoteCharacterState.PositionInterpolator.Packet
			{
				Position = pos,
				Time = Time.time + this.timeWindow * this.avgFrameTime - 2f * this.avgFrameTime
			};
			this.baseGameFrame = 0;
		}

		// Token: 0x17000614 RID: 1556
		// (get) Token: 0x06001B40 RID: 6976 RVA: 0x000120EE File Offset: 0x000102EE
		public float LastTime
		{
			get
			{
				return this.sampleA.Time;
			}
		}

		// Token: 0x06001B41 RID: 6977 RVA: 0x0008C4CC File Offset: 0x0008A6CC
		internal void Extrapolate()
		{
			this.Add(new PlayerMovement
			{
				Position = this.sampleA.Position + (this.sampleA.Position - this.sampleB.Position)
			}, (ushort)(this.sampleA.GameFrame + 1));
		}

		// Token: 0x04001841 RID: 6209
		private RemoteCharacterState.PositionInterpolator.Packet sampleA;

		// Token: 0x04001842 RID: 6210
		private RemoteCharacterState.PositionInterpolator.Packet sampleB;

		// Token: 0x04001843 RID: 6211
		private RemoteCharacterState.PositionInterpolator.Packet sampleC;

		// Token: 0x04001844 RID: 6212
		private float timeWindow = 1.5f;

		// Token: 0x04001845 RID: 6213
		private int baseGameFrame;

		// Token: 0x04001846 RID: 6214
		private float baseTime;

		// Token: 0x04001847 RID: 6215
		private float avgFrameTime;

		// Token: 0x02000398 RID: 920
		private class Packet
		{
			// Token: 0x04001848 RID: 6216
			public Vector3 Position;

			// Token: 0x04001849 RID: 6217
			public float Time;

			// Token: 0x0400184A RID: 6218
			public int GameFrame;

			// Token: 0x0400184B RID: 6219
			public float ArrivalTime;
		}
	}
}
