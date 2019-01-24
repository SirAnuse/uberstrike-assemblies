using System;
using System.Collections.Generic;
using System.IO;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models;
using UberStrike.Core.Serialization;
using UberStrike.Core.Types;
using UnityEngine;

namespace UberStrike.Realtime.Client
{
	// Token: 0x0200032A RID: 810
	public abstract class BaseGameRoom : IEventDispatcher, IRoomLogic
	{
		// Token: 0x060012FB RID: 4859 RVA: 0x0000BDF2 File Offset: 0x00009FF2
		protected BaseGameRoom()
		{
			this.Operations = new GameRoomOperations(0);
		}

		// Token: 0x170003B6 RID: 950
		// (get) Token: 0x060012FC RID: 4860 RVA: 0x0000BE06 File Offset: 0x0000A006
		IOperationSender IRoomLogic.Operations
		{
			get
			{
				return this.Operations;
			}
		}

		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x060012FD RID: 4861 RVA: 0x0000BE0E File Offset: 0x0000A00E
		// (set) Token: 0x060012FE RID: 4862 RVA: 0x0000BE16 File Offset: 0x0000A016
		public GameRoomOperations Operations { get; private set; }

		// Token: 0x060012FF RID: 4863 RVA: 0x0002147C File Offset: 0x0001F67C
		public void OnEvent(byte id, byte[] data)
		{
			switch (id)
			{
			case 12:
				this.PowerUpPicked(data);
				break;
			case 13:
				this.SetPowerupState(data);
				break;
			case 14:
				this.ResetAllPowerups(data);
				break;
			case 15:
				this.DoorOpen(data);
				break;
			case 16:
				this.DisconnectCountdown(data);
				break;
			case 17:
				this.MatchStartCountdown(data);
				break;
			case 18:
				this.MatchStart(data);
				break;
			case 19:
				this.MatchEnd(data);
				break;
			case 20:
				this.TeamWins(data);
				break;
			case 21:
				this.WaitingForPlayers(data);
				break;
			case 22:
				this.PrepareNextRound(data);
				break;
			case 23:
				this.AllPlayers(data);
				break;
			case 24:
				this.AllPlayerDeltas(data);
				break;
			case 25:
				this.AllPlayerPositions(data);
				break;
			case 26:
				this.PlayerDelta(data);
				break;
			case 27:
				this.PlayerJumped(data);
				break;
			case 28:
				this.PlayerRespawnCountdown(data);
				break;
			case 29:
				this.PlayerRespawned(data);
				break;
			case 30:
				this.PlayerJoinedGame(data);
				break;
			case 31:
				this.JoinGameFailed(data);
				break;
			case 32:
				this.PlayerLeftGame(data);
				break;
			case 33:
				this.PlayerChangedTeam(data);
				break;
			case 34:
				this.JoinedAsSpectator(data);
				break;
			case 35:
				this.PlayersReadyUpdated(data);
				break;
			case 36:
				this.DamageEvent(data);
				break;
			case 37:
				this.PlayerKilled(data);
				break;
			case 38:
				this.UpdateRoundScore(data);
				break;
			case 39:
				this.KillsRemaining(data);
				break;
			case 40:
				this.LevelUp(data);
				break;
			case 41:
				this.KickPlayer(data);
				break;
			case 42:
				this.QuickItemEvent(data);
				break;
			case 43:
				this.SingleBulletFire(data);
				break;
			case 44:
				this.PlayerHit(data);
				break;
			case 45:
				this.RemoveProjectile(data);
				break;
			case 46:
				this.EmitProjectile(data);
				break;
			case 47:
				this.EmitQuickItem(data);
				break;
			case 48:
				this.ActivateQuickItem(data);
				break;
			case 49:
				this.ChatMessage(data);
				break;
			}
		}

		// Token: 0x06001300 RID: 4864
		protected abstract void OnPowerUpPicked(int id, byte flag);

		// Token: 0x06001301 RID: 4865
		protected abstract void OnSetPowerupState(List<int> states);

		// Token: 0x06001302 RID: 4866
		protected abstract void OnResetAllPowerups();

		// Token: 0x06001303 RID: 4867
		protected abstract void OnDoorOpen(int id);

		// Token: 0x06001304 RID: 4868
		protected abstract void OnDisconnectCountdown(byte countdown);

		// Token: 0x06001305 RID: 4869
		protected abstract void OnMatchStartCountdown(byte countdown);

		// Token: 0x06001306 RID: 4870
		protected abstract void OnMatchStart(int roundNumber, int endTime);

		// Token: 0x06001307 RID: 4871
		protected abstract void OnMatchEnd(EndOfMatchData data);

		// Token: 0x06001308 RID: 4872
		protected abstract void OnTeamWins(TeamID team);

		// Token: 0x06001309 RID: 4873
		protected abstract void OnWaitingForPlayers();

		// Token: 0x0600130A RID: 4874
		protected abstract void OnPrepareNextRound();

		// Token: 0x0600130B RID: 4875
		protected abstract void OnAllPlayers(List<GameActorInfo> allPlayers, List<PlayerMovement> allPositions, ushort gameframe);

		// Token: 0x0600130C RID: 4876
		protected abstract void OnAllPlayerDeltas(List<GameActorInfoDelta> allDeltas);

		// Token: 0x0600130D RID: 4877
		protected abstract void OnAllPlayerPositions(List<PlayerMovement> allPositions, ushort gameframe);

		// Token: 0x0600130E RID: 4878
		protected abstract void OnPlayerDelta(GameActorInfoDelta delta);

		// Token: 0x0600130F RID: 4879
		protected abstract void OnPlayerJumped(int cmid, Vector3 position);

		// Token: 0x06001310 RID: 4880
		protected abstract void OnPlayerRespawnCountdown(byte countdown);

		// Token: 0x06001311 RID: 4881
		protected abstract void OnPlayerRespawned(int cmid, Vector3 position, byte rotation);

		// Token: 0x06001312 RID: 4882
		protected abstract void OnPlayerJoinedGame(GameActorInfo player, PlayerMovement position);

		// Token: 0x06001313 RID: 4883
		protected abstract void OnJoinGameFailed(string message);

		// Token: 0x06001314 RID: 4884
		protected abstract void OnPlayerLeftGame(int cmid);

		// Token: 0x06001315 RID: 4885
		protected abstract void OnPlayerChangedTeam(int cmid, TeamID team);

		// Token: 0x06001316 RID: 4886
		protected abstract void OnJoinedAsSpectator();

		// Token: 0x06001317 RID: 4887
		protected abstract void OnPlayersReadyUpdated();

		// Token: 0x06001318 RID: 4888
		protected abstract void OnDamageEvent(DamageEvent damageEvent);

		// Token: 0x06001319 RID: 4889
		protected abstract void OnPlayerKilled(int shooter, int target, byte weaponClass, ushort damage, byte bodyPart, Vector3 direction);

		// Token: 0x0600131A RID: 4890
		protected abstract void OnUpdateRoundScore(int round, short blue, short red);

		// Token: 0x0600131B RID: 4891
		protected abstract void OnKillsRemaining(int killsRemaining, int leaderCmid);

		// Token: 0x0600131C RID: 4892
		protected abstract void OnLevelUp(int newLevel);

		// Token: 0x0600131D RID: 4893
		protected abstract void OnKickPlayer(string message);

		// Token: 0x0600131E RID: 4894
		protected abstract void OnQuickItemEvent(int cmid, byte eventType, int robotLifeTime, int scrapsLifeTime, bool isInstant);

		// Token: 0x0600131F RID: 4895
		protected abstract void OnSingleBulletFire(int cmid);

		// Token: 0x06001320 RID: 4896
		protected abstract void OnPlayerHit(Vector3 force);

		// Token: 0x06001321 RID: 4897
		protected abstract void OnRemoveProjectile(int projectileId, bool explode);

		// Token: 0x06001322 RID: 4898
		protected abstract void OnEmitProjectile(int cmid, Vector3 origin, Vector3 direction, byte slot, int projectileID, bool explode);

		// Token: 0x06001323 RID: 4899
		protected abstract void OnEmitQuickItem(Vector3 origin, Vector3 direction, int itemId, byte playerNumber, int projectileID);

		// Token: 0x06001324 RID: 4900
		protected abstract void OnActivateQuickItem(int cmid, QuickItemLogic logic, int robotLifeTime, int scrapsLifeTime, bool isInstant);

		// Token: 0x06001325 RID: 4901
		protected abstract void OnChatMessage(int cmid, string name, string message, MemberAccessLevel accessLevel, byte context);

		// Token: 0x06001326 RID: 4902 RVA: 0x000216FC File Offset: 0x0001F8FC
		private void PowerUpPicked(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				int id = Int32Proxy.Deserialize(memoryStream);
				byte flag = ByteProxy.Deserialize(memoryStream);
				this.OnPowerUpPicked(id, flag);
			}
		}

		// Token: 0x06001327 RID: 4903 RVA: 0x00021748 File Offset: 0x0001F948
		private void SetPowerupState(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				List<int> states = ListProxy<int>.Deserialize(memoryStream, new ListProxy<int>.Deserializer<int>(Int32Proxy.Deserialize));
				this.OnSetPowerupState(states);
			}
		}

		// Token: 0x06001328 RID: 4904 RVA: 0x00021798 File Offset: 0x0001F998
		private void ResetAllPowerups(byte[] _bytes)
		{
			using (new MemoryStream(_bytes))
			{
				this.OnResetAllPowerups();
			}
		}

		// Token: 0x06001329 RID: 4905 RVA: 0x000217D4 File Offset: 0x0001F9D4
		private void DoorOpen(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				int id = Int32Proxy.Deserialize(memoryStream);
				this.OnDoorOpen(id);
			}
		}

		// Token: 0x0600132A RID: 4906 RVA: 0x00021818 File Offset: 0x0001FA18
		private void DisconnectCountdown(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				byte countdown = ByteProxy.Deserialize(memoryStream);
				this.OnDisconnectCountdown(countdown);
			}
		}

		// Token: 0x0600132B RID: 4907 RVA: 0x0002185C File Offset: 0x0001FA5C
		private void MatchStartCountdown(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				byte countdown = ByteProxy.Deserialize(memoryStream);
				this.OnMatchStartCountdown(countdown);
			}
		}

		// Token: 0x0600132C RID: 4908 RVA: 0x000218A0 File Offset: 0x0001FAA0
		private void MatchStart(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				int roundNumber = Int32Proxy.Deserialize(memoryStream);
				int endTime = Int32Proxy.Deserialize(memoryStream);
				this.OnMatchStart(roundNumber, endTime);
			}
		}

		// Token: 0x0600132D RID: 4909 RVA: 0x000218EC File Offset: 0x0001FAEC
		private void MatchEnd(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				EndOfMatchData data = EndOfMatchDataProxy.Deserialize(memoryStream);
				this.OnMatchEnd(data);
			}
		}

		// Token: 0x0600132E RID: 4910 RVA: 0x00021930 File Offset: 0x0001FB30
		private void TeamWins(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				TeamID team = EnumProxy<TeamID>.Deserialize(memoryStream);
				this.OnTeamWins(team);
			}
		}

		// Token: 0x0600132F RID: 4911 RVA: 0x00021974 File Offset: 0x0001FB74
		private void WaitingForPlayers(byte[] _bytes)
		{
			using (new MemoryStream(_bytes))
			{
				this.OnWaitingForPlayers();
			}
		}

		// Token: 0x06001330 RID: 4912 RVA: 0x000219B0 File Offset: 0x0001FBB0
		private void PrepareNextRound(byte[] _bytes)
		{
			using (new MemoryStream(_bytes))
			{
				this.OnPrepareNextRound();
			}
		}

		// Token: 0x06001331 RID: 4913 RVA: 0x000219EC File Offset: 0x0001FBEC
		private void AllPlayers(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				List<GameActorInfo> allPlayers = ListProxy<GameActorInfo>.Deserialize(memoryStream, new ListProxy<GameActorInfo>.Deserializer<GameActorInfo>(GameActorInfoProxy.Deserialize));
				List<PlayerMovement> allPositions = ListProxy<PlayerMovement>.Deserialize(memoryStream, new ListProxy<PlayerMovement>.Deserializer<PlayerMovement>(PlayerMovementProxy.Deserialize));
				ushort gameframe = UInt16Proxy.Deserialize(memoryStream);
				this.OnAllPlayers(allPlayers, allPositions, gameframe);
			}
		}

		// Token: 0x06001332 RID: 4914 RVA: 0x00021A58 File Offset: 0x0001FC58
		private void AllPlayerDeltas(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				List<GameActorInfoDelta> allDeltas = ListProxy<GameActorInfoDelta>.Deserialize(memoryStream, new ListProxy<GameActorInfoDelta>.Deserializer<GameActorInfoDelta>(GameActorInfoDeltaProxy.Deserialize));
				this.OnAllPlayerDeltas(allDeltas);
			}
		}

		// Token: 0x06001333 RID: 4915 RVA: 0x00021AA8 File Offset: 0x0001FCA8
		private void AllPlayerPositions(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				List<PlayerMovement> allPositions = ListProxy<PlayerMovement>.Deserialize(memoryStream, new ListProxy<PlayerMovement>.Deserializer<PlayerMovement>(PlayerMovementProxy.Deserialize));
				ushort gameframe = UInt16Proxy.Deserialize(memoryStream);
				this.OnAllPlayerPositions(allPositions, gameframe);
			}
		}

		// Token: 0x06001334 RID: 4916 RVA: 0x00021B00 File Offset: 0x0001FD00
		private void PlayerDelta(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				GameActorInfoDelta delta = GameActorInfoDeltaProxy.Deserialize(memoryStream);
				this.OnPlayerDelta(delta);
			}
		}

		// Token: 0x06001335 RID: 4917 RVA: 0x00021B44 File Offset: 0x0001FD44
		private void PlayerJumped(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				int cmid = Int32Proxy.Deserialize(memoryStream);
				Vector3 position = Vector3Proxy.Deserialize(memoryStream);
				this.OnPlayerJumped(cmid, position);
			}
		}

		// Token: 0x06001336 RID: 4918 RVA: 0x00021B90 File Offset: 0x0001FD90
		private void PlayerRespawnCountdown(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				byte countdown = ByteProxy.Deserialize(memoryStream);
				this.OnPlayerRespawnCountdown(countdown);
			}
		}

		// Token: 0x06001337 RID: 4919 RVA: 0x00021BD4 File Offset: 0x0001FDD4
		private void PlayerRespawned(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				int cmid = Int32Proxy.Deserialize(memoryStream);
				Vector3 position = Vector3Proxy.Deserialize(memoryStream);
				byte rotation = ByteProxy.Deserialize(memoryStream);
				this.OnPlayerRespawned(cmid, position, rotation);
			}
		}

		// Token: 0x06001338 RID: 4920 RVA: 0x00021C28 File Offset: 0x0001FE28
		private void PlayerJoinedGame(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				GameActorInfo player = GameActorInfoProxy.Deserialize(memoryStream);
				PlayerMovement position = PlayerMovementProxy.Deserialize(memoryStream);
				this.OnPlayerJoinedGame(player, position);
			}
		}

		// Token: 0x06001339 RID: 4921 RVA: 0x00021C74 File Offset: 0x0001FE74
		private void JoinGameFailed(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				string message = StringProxy.Deserialize(memoryStream);
				this.OnJoinGameFailed(message);
			}
		}

		// Token: 0x0600133A RID: 4922 RVA: 0x00021CB8 File Offset: 0x0001FEB8
		private void PlayerLeftGame(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				int cmid = Int32Proxy.Deserialize(memoryStream);
				this.OnPlayerLeftGame(cmid);
			}
		}

		// Token: 0x0600133B RID: 4923 RVA: 0x00021CFC File Offset: 0x0001FEFC
		private void PlayerChangedTeam(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				int cmid = Int32Proxy.Deserialize(memoryStream);
				TeamID team = EnumProxy<TeamID>.Deserialize(memoryStream);
				this.OnPlayerChangedTeam(cmid, team);
			}
		}

		// Token: 0x0600133C RID: 4924 RVA: 0x00021D48 File Offset: 0x0001FF48
		private void JoinedAsSpectator(byte[] _bytes)
		{
			using (new MemoryStream(_bytes))
			{
				this.OnJoinedAsSpectator();
			}
		}

		// Token: 0x0600133D RID: 4925 RVA: 0x00021D84 File Offset: 0x0001FF84
		private void PlayersReadyUpdated(byte[] _bytes)
		{
			using (new MemoryStream(_bytes))
			{
				this.OnPlayersReadyUpdated();
			}
		}

		// Token: 0x0600133E RID: 4926 RVA: 0x00021DC0 File Offset: 0x0001FFC0
		private void DamageEvent(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				DamageEvent damageEvent = DamageEventProxy.Deserialize(memoryStream);
				this.OnDamageEvent(damageEvent);
			}
		}

		// Token: 0x0600133F RID: 4927 RVA: 0x00021E04 File Offset: 0x00020004
		private void PlayerKilled(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				int shooter = Int32Proxy.Deserialize(memoryStream);
				int target = Int32Proxy.Deserialize(memoryStream);
				byte weaponClass = ByteProxy.Deserialize(memoryStream);
				ushort damage = UInt16Proxy.Deserialize(memoryStream);
				byte bodyPart = ByteProxy.Deserialize(memoryStream);
				Vector3 direction = Vector3Proxy.Deserialize(memoryStream);
				this.OnPlayerKilled(shooter, target, weaponClass, damage, bodyPart, direction);
			}
		}

		// Token: 0x06001340 RID: 4928 RVA: 0x00021E78 File Offset: 0x00020078
		private void UpdateRoundScore(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				int round = Int32Proxy.Deserialize(memoryStream);
				short blue = Int16Proxy.Deserialize(memoryStream);
				short red = Int16Proxy.Deserialize(memoryStream);
				this.OnUpdateRoundScore(round, blue, red);
			}
		}

		// Token: 0x06001341 RID: 4929 RVA: 0x00021ECC File Offset: 0x000200CC
		private void KillsRemaining(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				int killsRemaining = Int32Proxy.Deserialize(memoryStream);
				int leaderCmid = Int32Proxy.Deserialize(memoryStream);
				this.OnKillsRemaining(killsRemaining, leaderCmid);
			}
		}

		// Token: 0x06001342 RID: 4930 RVA: 0x00021F18 File Offset: 0x00020118
		private void LevelUp(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				int newLevel = Int32Proxy.Deserialize(memoryStream);
				this.OnLevelUp(newLevel);
			}
		}

		// Token: 0x06001343 RID: 4931 RVA: 0x00021F5C File Offset: 0x0002015C
		private void KickPlayer(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				string message = StringProxy.Deserialize(memoryStream);
				this.OnKickPlayer(message);
			}
		}

		// Token: 0x06001344 RID: 4932 RVA: 0x00021FA0 File Offset: 0x000201A0
		private void QuickItemEvent(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				int cmid = Int32Proxy.Deserialize(memoryStream);
				byte eventType = ByteProxy.Deserialize(memoryStream);
				int robotLifeTime = Int32Proxy.Deserialize(memoryStream);
				int scrapsLifeTime = Int32Proxy.Deserialize(memoryStream);
				bool isInstant = BooleanProxy.Deserialize(memoryStream);
				this.OnQuickItemEvent(cmid, eventType, robotLifeTime, scrapsLifeTime, isInstant);
			}
		}

		// Token: 0x06001345 RID: 4933 RVA: 0x00022008 File Offset: 0x00020208
		private void SingleBulletFire(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				int cmid = Int32Proxy.Deserialize(memoryStream);
				this.OnSingleBulletFire(cmid);
			}
		}

		// Token: 0x06001346 RID: 4934 RVA: 0x0002204C File Offset: 0x0002024C
		private void PlayerHit(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				Vector3 force = Vector3Proxy.Deserialize(memoryStream);
				this.OnPlayerHit(force);
			}
		}

		// Token: 0x06001347 RID: 4935 RVA: 0x00022090 File Offset: 0x00020290
		private void RemoveProjectile(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				int projectileId = Int32Proxy.Deserialize(memoryStream);
				bool explode = BooleanProxy.Deserialize(memoryStream);
				this.OnRemoveProjectile(projectileId, explode);
			}
		}

		// Token: 0x06001348 RID: 4936 RVA: 0x000220DC File Offset: 0x000202DC
		private void EmitProjectile(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				int cmid = Int32Proxy.Deserialize(memoryStream);
				Vector3 origin = Vector3Proxy.Deserialize(memoryStream);
				Vector3 direction = Vector3Proxy.Deserialize(memoryStream);
				byte slot = ByteProxy.Deserialize(memoryStream);
				int projectileID = Int32Proxy.Deserialize(memoryStream);
				bool explode = BooleanProxy.Deserialize(memoryStream);
				this.OnEmitProjectile(cmid, origin, direction, slot, projectileID, explode);
			}
		}

		// Token: 0x06001349 RID: 4937 RVA: 0x00022150 File Offset: 0x00020350
		private void EmitQuickItem(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				Vector3 origin = Vector3Proxy.Deserialize(memoryStream);
				Vector3 direction = Vector3Proxy.Deserialize(memoryStream);
				int itemId = Int32Proxy.Deserialize(memoryStream);
				byte playerNumber = ByteProxy.Deserialize(memoryStream);
				int projectileID = Int32Proxy.Deserialize(memoryStream);
				this.OnEmitQuickItem(origin, direction, itemId, playerNumber, projectileID);
			}
		}

		// Token: 0x0600134A RID: 4938 RVA: 0x000221B8 File Offset: 0x000203B8
		private void ActivateQuickItem(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				int cmid = Int32Proxy.Deserialize(memoryStream);
				QuickItemLogic logic = EnumProxy<QuickItemLogic>.Deserialize(memoryStream);
				int robotLifeTime = Int32Proxy.Deserialize(memoryStream);
				int scrapsLifeTime = Int32Proxy.Deserialize(memoryStream);
				bool isInstant = BooleanProxy.Deserialize(memoryStream);
				this.OnActivateQuickItem(cmid, logic, robotLifeTime, scrapsLifeTime, isInstant);
			}
		}

		// Token: 0x0600134B RID: 4939 RVA: 0x00022220 File Offset: 0x00020420
		private void ChatMessage(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				int cmid = Int32Proxy.Deserialize(memoryStream);
				string name = StringProxy.Deserialize(memoryStream);
				string message = StringProxy.Deserialize(memoryStream);
				MemberAccessLevel accessLevel = EnumProxy<MemberAccessLevel>.Deserialize(memoryStream);
				byte context = ByteProxy.Deserialize(memoryStream);
				this.OnChatMessage(cmid, name, message, accessLevel, context);
			}
		}
	}
}
