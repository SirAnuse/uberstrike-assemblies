using System;
using UberStrike.Core.Models;

// Token: 0x02000366 RID: 870
public class SoundSimulator
{
	// Token: 0x0600186B RID: 6251 RVA: 0x00010580 File Offset: 0x0000E780
	public SoundSimulator(CharacterConfig character)
	{
		this.character = character;
	}

	// Token: 0x0600186C RID: 6252 RVA: 0x000832B8 File Offset: 0x000814B8
	public void Update()
	{
		if (this.character == null || this.character.Avatar == null || this.character.State == null)
		{
			return;
		}
		bool flag = (byte)(this.character.State.MovementState & (MoveStates.Grounded | MoveStates.Wading | MoveStates.Swimming | MoveStates.Diving)) != 0;
		bool flag2 = (this.character.State.Is(MoveStates.Diving) && this.character.State.KeyState != KeyState.Still) || (byte)(this.character.State.KeyState & KeyState.Walking) != 0;
		if (!this.isGrounded && this.character.State.Is(MoveStates.Grounded))
		{
			this.character.Avatar.Decorator.PlayFootSound(this.character.WalkingSoundSpeed);
		}
		else if (flag && flag2)
		{
			if (this.character.State.Is(MoveStates.Wading))
			{
				this.character.Avatar.Decorator.PlayFootSound(this.character.WalkingSoundSpeed, FootStepSoundType.Water);
			}
			else if (this.character.State.Is(MoveStates.Swimming))
			{
				this.character.Avatar.Decorator.PlayFootSound(this.character.SwimSoundSpeed, FootStepSoundType.Swim);
			}
			else if (this.character.State.Is(MoveStates.Diving))
			{
				this.character.Avatar.Decorator.PlayFootSound(this.character.DiveSoundSpeed, FootStepSoundType.Dive);
			}
			else
			{
				this.character.Avatar.Decorator.PlayFootSound(this.character.WalkingSoundSpeed);
			}
		}
		this.isGrounded = this.character.State.Is(MoveStates.Grounded);
	}

	// Token: 0x04001703 RID: 5891
	private CharacterConfig character;

	// Token: 0x04001704 RID: 5892
	private bool isGrounded = true;
}
