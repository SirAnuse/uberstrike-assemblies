using System;

namespace Steamworks
{
	// Token: 0x0200017A RID: 378
	public enum EResult
	{
		// Token: 0x0400078D RID: 1933
		k_EResultOK = 1,
		// Token: 0x0400078E RID: 1934
		k_EResultFail,
		// Token: 0x0400078F RID: 1935
		k_EResultNoConnection,
		// Token: 0x04000790 RID: 1936
		k_EResultInvalidPassword = 5,
		// Token: 0x04000791 RID: 1937
		k_EResultLoggedInElsewhere,
		// Token: 0x04000792 RID: 1938
		k_EResultInvalidProtocolVer,
		// Token: 0x04000793 RID: 1939
		k_EResultInvalidParam,
		// Token: 0x04000794 RID: 1940
		k_EResultFileNotFound,
		// Token: 0x04000795 RID: 1941
		k_EResultBusy,
		// Token: 0x04000796 RID: 1942
		k_EResultInvalidState,
		// Token: 0x04000797 RID: 1943
		k_EResultInvalidName,
		// Token: 0x04000798 RID: 1944
		k_EResultInvalidEmail,
		// Token: 0x04000799 RID: 1945
		k_EResultDuplicateName,
		// Token: 0x0400079A RID: 1946
		k_EResultAccessDenied,
		// Token: 0x0400079B RID: 1947
		k_EResultTimeout,
		// Token: 0x0400079C RID: 1948
		k_EResultBanned,
		// Token: 0x0400079D RID: 1949
		k_EResultAccountNotFound,
		// Token: 0x0400079E RID: 1950
		k_EResultInvalidSteamID,
		// Token: 0x0400079F RID: 1951
		k_EResultServiceUnavailable,
		// Token: 0x040007A0 RID: 1952
		k_EResultNotLoggedOn,
		// Token: 0x040007A1 RID: 1953
		k_EResultPending,
		// Token: 0x040007A2 RID: 1954
		k_EResultEncryptionFailure,
		// Token: 0x040007A3 RID: 1955
		k_EResultInsufficientPrivilege,
		// Token: 0x040007A4 RID: 1956
		k_EResultLimitExceeded,
		// Token: 0x040007A5 RID: 1957
		k_EResultRevoked,
		// Token: 0x040007A6 RID: 1958
		k_EResultExpired,
		// Token: 0x040007A7 RID: 1959
		k_EResultAlreadyRedeemed,
		// Token: 0x040007A8 RID: 1960
		k_EResultDuplicateRequest,
		// Token: 0x040007A9 RID: 1961
		k_EResultAlreadyOwned,
		// Token: 0x040007AA RID: 1962
		k_EResultIPNotFound,
		// Token: 0x040007AB RID: 1963
		k_EResultPersistFailed,
		// Token: 0x040007AC RID: 1964
		k_EResultLockingFailed,
		// Token: 0x040007AD RID: 1965
		k_EResultLogonSessionReplaced,
		// Token: 0x040007AE RID: 1966
		k_EResultConnectFailed,
		// Token: 0x040007AF RID: 1967
		k_EResultHandshakeFailed,
		// Token: 0x040007B0 RID: 1968
		k_EResultIOFailure,
		// Token: 0x040007B1 RID: 1969
		k_EResultRemoteDisconnect,
		// Token: 0x040007B2 RID: 1970
		k_EResultShoppingCartNotFound,
		// Token: 0x040007B3 RID: 1971
		k_EResultBlocked,
		// Token: 0x040007B4 RID: 1972
		k_EResultIgnored,
		// Token: 0x040007B5 RID: 1973
		k_EResultNoMatch,
		// Token: 0x040007B6 RID: 1974
		k_EResultAccountDisabled,
		// Token: 0x040007B7 RID: 1975
		k_EResultServiceReadOnly,
		// Token: 0x040007B8 RID: 1976
		k_EResultAccountNotFeatured,
		// Token: 0x040007B9 RID: 1977
		k_EResultAdministratorOK,
		// Token: 0x040007BA RID: 1978
		k_EResultContentVersion,
		// Token: 0x040007BB RID: 1979
		k_EResultTryAnotherCM,
		// Token: 0x040007BC RID: 1980
		k_EResultPasswordRequiredToKickSession,
		// Token: 0x040007BD RID: 1981
		k_EResultAlreadyLoggedInElsewhere,
		// Token: 0x040007BE RID: 1982
		k_EResultSuspended,
		// Token: 0x040007BF RID: 1983
		k_EResultCancelled,
		// Token: 0x040007C0 RID: 1984
		k_EResultDataCorruption,
		// Token: 0x040007C1 RID: 1985
		k_EResultDiskFull,
		// Token: 0x040007C2 RID: 1986
		k_EResultRemoteCallFailed,
		// Token: 0x040007C3 RID: 1987
		k_EResultPasswordUnset,
		// Token: 0x040007C4 RID: 1988
		k_EResultExternalAccountUnlinked,
		// Token: 0x040007C5 RID: 1989
		k_EResultPSNTicketInvalid,
		// Token: 0x040007C6 RID: 1990
		k_EResultExternalAccountAlreadyLinked,
		// Token: 0x040007C7 RID: 1991
		k_EResultRemoteFileConflict,
		// Token: 0x040007C8 RID: 1992
		k_EResultIllegalPassword,
		// Token: 0x040007C9 RID: 1993
		k_EResultSameAsPreviousValue,
		// Token: 0x040007CA RID: 1994
		k_EResultAccountLogonDenied,
		// Token: 0x040007CB RID: 1995
		k_EResultCannotUseOldPassword,
		// Token: 0x040007CC RID: 1996
		k_EResultInvalidLoginAuthCode,
		// Token: 0x040007CD RID: 1997
		k_EResultAccountLogonDeniedNoMail,
		// Token: 0x040007CE RID: 1998
		k_EResultHardwareNotCapableOfIPT,
		// Token: 0x040007CF RID: 1999
		k_EResultIPTInitError,
		// Token: 0x040007D0 RID: 2000
		k_EResultParentalControlRestricted,
		// Token: 0x040007D1 RID: 2001
		k_EResultFacebookQueryError,
		// Token: 0x040007D2 RID: 2002
		k_EResultExpiredLoginAuthCode,
		// Token: 0x040007D3 RID: 2003
		k_EResultIPLoginRestrictionFailed,
		// Token: 0x040007D4 RID: 2004
		k_EResultAccountLockedDown,
		// Token: 0x040007D5 RID: 2005
		k_EResultAccountLogonDeniedVerifiedEmailRequired,
		// Token: 0x040007D6 RID: 2006
		k_EResultNoMatchingURL,
		// Token: 0x040007D7 RID: 2007
		k_EResultBadResponse,
		// Token: 0x040007D8 RID: 2008
		k_EResultRequirePasswordReEntry,
		// Token: 0x040007D9 RID: 2009
		k_EResultValueOutOfRange,
		// Token: 0x040007DA RID: 2010
		k_EResultUnexpectedError,
		// Token: 0x040007DB RID: 2011
		k_EResultDisabled,
		// Token: 0x040007DC RID: 2012
		k_EResultInvalidCEGSubmission,
		// Token: 0x040007DD RID: 2013
		k_EResultRestrictedDevice,
		// Token: 0x040007DE RID: 2014
		k_EResultRegionLocked,
		// Token: 0x040007DF RID: 2015
		k_EResultRateLimitExceeded,
		// Token: 0x040007E0 RID: 2016
		k_EResultAccountLoginDeniedNeedTwoFactor,
		// Token: 0x040007E1 RID: 2017
		k_EResultItemDeleted,
		// Token: 0x040007E2 RID: 2018
		k_EResultAccountLoginDeniedThrottle,
		// Token: 0x040007E3 RID: 2019
		k_EResultTwoFactorCodeMismatch,
		// Token: 0x040007E4 RID: 2020
		k_EResultTwoFactorActivationCodeMismatch,
		// Token: 0x040007E5 RID: 2021
		k_EResultAccountAssociatedToMultiplePartners,
		// Token: 0x040007E6 RID: 2022
		k_EResultNotModified
	}
}
