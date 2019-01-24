using System;
using UberStrike.Core.Types;

// Token: 0x0200025D RID: 605
public class ItemUtil
{
	// Token: 0x060010C2 RID: 4290 RVA: 0x00067124 File Offset: 0x00065324
	public static UberstrikeItemClass ItemClassFromSlot(global::LoadoutSlotType slot)
	{
		UberstrikeItemClass result = (UberstrikeItemClass)0;
		switch (slot)
		{
		case global::LoadoutSlotType.GearHead:
			result = UberstrikeItemClass.GearHead;
			break;
		case global::LoadoutSlotType.GearFace:
			result = UberstrikeItemClass.GearFace;
			break;
		case global::LoadoutSlotType.GearGloves:
			result = UberstrikeItemClass.GearGloves;
			break;
		case global::LoadoutSlotType.GearUpperBody:
			result = UberstrikeItemClass.GearUpperBody;
			break;
		case global::LoadoutSlotType.GearLowerBody:
			result = UberstrikeItemClass.GearLowerBody;
			break;
		case global::LoadoutSlotType.GearBoots:
			result = UberstrikeItemClass.GearBoots;
			break;
		case global::LoadoutSlotType.GearHolo:
			result = UberstrikeItemClass.GearHolo;
			break;
		}
		return result;
	}

	// Token: 0x060010C3 RID: 4291 RVA: 0x00067198 File Offset: 0x00065398
	public static global::LoadoutSlotType SlotFromItemClass(UberstrikeItemClass itemClass)
	{
		global::LoadoutSlotType result = global::LoadoutSlotType.None;
		switch (itemClass)
		{
		case UberstrikeItemClass.GearBoots:
			result = global::LoadoutSlotType.GearBoots;
			break;
		case UberstrikeItemClass.GearHead:
			result = global::LoadoutSlotType.GearHead;
			break;
		case UberstrikeItemClass.GearFace:
			result = global::LoadoutSlotType.GearFace;
			break;
		case UberstrikeItemClass.GearUpperBody:
			result = global::LoadoutSlotType.GearUpperBody;
			break;
		case UberstrikeItemClass.GearLowerBody:
			result = global::LoadoutSlotType.GearLowerBody;
			break;
		case UberstrikeItemClass.GearGloves:
			result = global::LoadoutSlotType.GearGloves;
			break;
		case UberstrikeItemClass.GearHolo:
			result = global::LoadoutSlotType.GearHolo;
			break;
		}
		return result;
	}
}
