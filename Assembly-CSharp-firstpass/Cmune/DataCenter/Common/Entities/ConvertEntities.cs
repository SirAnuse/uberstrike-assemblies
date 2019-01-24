using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x0200004A RID: 74
	public class ConvertEntities
	{
		// Token: 0x06000102 RID: 258 RVA: 0x0000D66C File Offset: 0x0000B86C
		public static MemberOperationResult ConvertMemberRegistration(MemberRegistrationResult memberRegistration)
		{
			MemberOperationResult result = MemberOperationResult.Ok;
			switch (memberRegistration)
			{
			case MemberRegistrationResult.Ok:
				result = MemberOperationResult.Ok;
				break;
			case MemberRegistrationResult.InvalidName:
				result = MemberOperationResult.InvalidName;
				break;
			case MemberRegistrationResult.DuplicateName:
				result = MemberOperationResult.DuplicateName;
				break;
			case MemberRegistrationResult.InvalidHandle:
				result = MemberOperationResult.InvalidHandle;
				break;
			case MemberRegistrationResult.DuplicateHandle:
				result = MemberOperationResult.DuplicateHandle;
				break;
			case MemberRegistrationResult.InvalidEsns:
				result = MemberOperationResult.InvalidEsns;
				break;
			}
			return result;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000D6E4 File Offset: 0x0000B8E4
		public static MemberRegistrationResult ConvertMemberOperation(MemberOperationResult memberOperation)
		{
			MemberRegistrationResult result = MemberRegistrationResult.Ok;
			switch (memberOperation)
			{
			case MemberOperationResult.Ok:
				result = MemberRegistrationResult.Ok;
				break;
			default:
				switch (memberOperation)
				{
				case MemberOperationResult.InvalidName:
					result = MemberRegistrationResult.InvalidName;
					break;
				case MemberOperationResult.OffensiveName:
					result = MemberRegistrationResult.OffensiveName;
					break;
				}
				break;
			case MemberOperationResult.DuplicateEmail:
				result = MemberRegistrationResult.DuplicateEmail;
				break;
			case MemberOperationResult.DuplicateName:
				result = MemberRegistrationResult.DuplicateName;
				break;
			case MemberOperationResult.DuplicateEmailName:
				result = MemberRegistrationResult.DuplicateEmailName;
				break;
			}
			return result;
		}
	}
}
