using System;
using System.Collections.Generic;
using System.IO;
using UberStrike.Core.Models;
using UberStrike.Core.Serialization;
using UberStrike.Core.Types;
using UnityEngine;

namespace UberStrike.Realtime.Client
{
	// Token: 0x02000328 RID: 808
	public sealed class GameRoomOperations : IOperationSender
	{
		// Token: 0x060012C1 RID: 4801 RVA: 0x0000BD7D File Offset: 0x00009F7D
		public GameRoomOperations(byte id = 0)
		{
			this.__id = id;
		}

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x060012C2 RID: 4802 RVA: 0x0000BD8C File Offset: 0x00009F8C
		// (remove) Token: 0x060012C3 RID: 4803 RVA: 0x0000BDA5 File Offset: 0x00009FA5
		public event RemoteProcedureCall SendOperation
		{
			add
			{
				this.sendOperation = (RemoteProcedureCall)Delegate.Combine(this.sendOperation, value);
			}
			remove
			{
				this.sendOperation = (RemoteProcedureCall)Delegate.Remove(this.sendOperation, value);
			}
		}

		// Token: 0x060012C4 RID: 4804 RVA: 0x0002024C File Offset: 0x0001E44C
		public void SendJoinGame(TeamID team)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				EnumProxy<TeamID>.Serialize(memoryStream, team);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(1, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012C5 RID: 4805 RVA: 0x000202C0 File Offset: 0x0001E4C0
		public void SendJoinAsSpectator()
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(2, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012C6 RID: 4806 RVA: 0x0002032C File Offset: 0x0001E52C
		public void SendPowerUpRespawnTimes(List<ushort> respawnTimes)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				ListProxy<ushort>.Serialize(memoryStream, respawnTimes, new ListProxy<ushort>.Serializer<ushort>(UInt16Proxy.Serialize));
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(3, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012C7 RID: 4807 RVA: 0x000203AC File Offset: 0x0001E5AC
		public void SendPowerUpPicked(int powerupId, byte type, byte value)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, powerupId);
				ByteProxy.Serialize(memoryStream, type);
				ByteProxy.Serialize(memoryStream, value);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(4, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012C8 RID: 4808 RVA: 0x0002042C File Offset: 0x0001E62C
		public void SendIncreaseHealthAndArmor(byte health, byte armor)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				ByteProxy.Serialize(memoryStream, health);
				ByteProxy.Serialize(memoryStream, armor);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(5, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012C9 RID: 4809 RVA: 0x000204A8 File Offset: 0x0001E6A8
		public void SendOpenDoor(int doorId)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, doorId);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(6, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012CA RID: 4810 RVA: 0x0002051C File Offset: 0x0001E71C
		public void SendSpawnPositions(TeamID team, List<Vector3> positions, List<byte> rotations)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				EnumProxy<TeamID>.Serialize(memoryStream, team);
				ListProxy<Vector3>.Serialize(memoryStream, positions, new ListProxy<Vector3>.Serializer<Vector3>(Vector3Proxy.Serialize));
				ListProxy<byte>.Serialize(memoryStream, rotations, new ListProxy<byte>.Serializer<byte>(ByteProxy.Serialize));
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(7, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012CB RID: 4811 RVA: 0x000205B4 File Offset: 0x0001E7B4
		public void SendRespawnRequest()
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(8, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012CC RID: 4812 RVA: 0x00020620 File Offset: 0x0001E820
		public void SendDirectHitDamage(int target, byte bodyPart, byte bullets)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, target);
				ByteProxy.Serialize(memoryStream, bodyPart);
				ByteProxy.Serialize(memoryStream, bullets);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(9, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012CD RID: 4813 RVA: 0x000206A4 File Offset: 0x0001E8A4
		public void SendExplosionDamage(int target, byte slot, byte distance, Vector3 force)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, target);
				ByteProxy.Serialize(memoryStream, slot);
				ByteProxy.Serialize(memoryStream, distance);
				Vector3Proxy.Serialize(memoryStream, force);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(10, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012CE RID: 4814 RVA: 0x00020730 File Offset: 0x0001E930
		public void SendDirectDamage(ushort damage)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				UInt16Proxy.Serialize(memoryStream, damage);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(11, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012CF RID: 4815 RVA: 0x000207A4 File Offset: 0x0001E9A4
		public void SendDirectDeath()
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(12, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012D0 RID: 4816 RVA: 0x00020810 File Offset: 0x0001EA10
		public void SendJump(Vector3 position)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Vector3Proxy.Serialize(memoryStream, position);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(13, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012D1 RID: 4817 RVA: 0x00020884 File Offset: 0x0001EA84
		public void SendUpdatePositionAndRotation(ShortVector3 position, ShortVector3 velocity, byte hrot, byte vrot, byte moveState)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				ShortVector3Proxy.Serialize(memoryStream, position);
				ShortVector3Proxy.Serialize(memoryStream, velocity);
				ByteProxy.Serialize(memoryStream, hrot);
				ByteProxy.Serialize(memoryStream, vrot);
				ByteProxy.Serialize(memoryStream, moveState);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(14, customOpParameters, false, 0, false);
				}
			}
		}

		// Token: 0x060012D2 RID: 4818 RVA: 0x00020918 File Offset: 0x0001EB18
		public void SendKickPlayer(int cmid)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, cmid);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(15, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012D3 RID: 4819 RVA: 0x0002098C File Offset: 0x0001EB8C
		public void SendIsFiring(bool on)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				BooleanProxy.Serialize(memoryStream, on);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(16, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012D4 RID: 4820 RVA: 0x00020A00 File Offset: 0x0001EC00
		public void SendIsReadyForNextMatch(bool on)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				BooleanProxy.Serialize(memoryStream, on);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(17, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012D5 RID: 4821 RVA: 0x00020A74 File Offset: 0x0001EC74
		public void SendIsPaused(bool on)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				BooleanProxy.Serialize(memoryStream, on);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(18, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012D6 RID: 4822 RVA: 0x00020AE8 File Offset: 0x0001ECE8
		public void SendIsInSniperMode(bool on)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				BooleanProxy.Serialize(memoryStream, on);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(19, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012D7 RID: 4823 RVA: 0x00020B5C File Offset: 0x0001ED5C
		public void SendSingleBulletFire()
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(20, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012D8 RID: 4824 RVA: 0x00020BC8 File Offset: 0x0001EDC8
		public void SendSwitchWeapon(byte weaponSlot)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				ByteProxy.Serialize(memoryStream, weaponSlot);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(21, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012D9 RID: 4825 RVA: 0x00020C3C File Offset: 0x0001EE3C
		public void SendSwitchTeam()
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(22, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012DA RID: 4826 RVA: 0x00020CA8 File Offset: 0x0001EEA8
		public void SendChangeGear(int head, int face, int upperBody, int lowerBody, int gloves, int boots, int holo)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, head);
				Int32Proxy.Serialize(memoryStream, face);
				Int32Proxy.Serialize(memoryStream, upperBody);
				Int32Proxy.Serialize(memoryStream, lowerBody);
				Int32Proxy.Serialize(memoryStream, gloves);
				Int32Proxy.Serialize(memoryStream, boots);
				Int32Proxy.Serialize(memoryStream, holo);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(23, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012DB RID: 4827 RVA: 0x00020D4C File Offset: 0x0001EF4C
		public void SendEmitProjectile(Vector3 origin, Vector3 direction, byte slot, int projectileID, bool explode)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Vector3Proxy.Serialize(memoryStream, origin);
				Vector3Proxy.Serialize(memoryStream, direction);
				ByteProxy.Serialize(memoryStream, slot);
				Int32Proxy.Serialize(memoryStream, projectileID);
				BooleanProxy.Serialize(memoryStream, explode);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(24, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012DC RID: 4828 RVA: 0x00020DE0 File Offset: 0x0001EFE0
		public void SendEmitQuickItem(Vector3 origin, Vector3 direction, int itemId, byte playerNumber, int projectileID)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Vector3Proxy.Serialize(memoryStream, origin);
				Vector3Proxy.Serialize(memoryStream, direction);
				Int32Proxy.Serialize(memoryStream, itemId);
				ByteProxy.Serialize(memoryStream, playerNumber);
				Int32Proxy.Serialize(memoryStream, projectileID);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(25, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012DD RID: 4829 RVA: 0x00020E74 File Offset: 0x0001F074
		public void SendRemoveProjectile(int projectileId, bool explode)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, projectileId);
				BooleanProxy.Serialize(memoryStream, explode);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(26, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012DE RID: 4830 RVA: 0x00020EF0 File Offset: 0x0001F0F0
		public void SendHitFeedback(int targetCmid, Vector3 force)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, targetCmid);
				Vector3Proxy.Serialize(memoryStream, force);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(27, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012DF RID: 4831 RVA: 0x00020F6C File Offset: 0x0001F16C
		public void SendActivateQuickItem(QuickItemLogic logic, int robotLifeTime, int scrapsLifeTime, bool isInstant)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				EnumProxy<QuickItemLogic>.Serialize(memoryStream, logic);
				Int32Proxy.Serialize(memoryStream, robotLifeTime);
				Int32Proxy.Serialize(memoryStream, scrapsLifeTime);
				BooleanProxy.Serialize(memoryStream, isInstant);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(28, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012E0 RID: 4832 RVA: 0x00020FF8 File Offset: 0x0001F1F8
		public void SendChatMessage(string message, byte context)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, message);
				ByteProxy.Serialize(memoryStream, context);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(29, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x04000D5D RID: 3421
		private byte __id;

		// Token: 0x04000D5E RID: 3422
		private RemoteProcedureCall sendOperation;
	}
}
