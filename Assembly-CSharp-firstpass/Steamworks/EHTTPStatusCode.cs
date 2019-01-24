using System;

namespace Steamworks
{
	// Token: 0x0200018B RID: 395
	public enum EHTTPStatusCode
	{
		// Token: 0x0400088A RID: 2186
		k_EHTTPStatusCodeInvalid,
		// Token: 0x0400088B RID: 2187
		k_EHTTPStatusCode100Continue = 100,
		// Token: 0x0400088C RID: 2188
		k_EHTTPStatusCode101SwitchingProtocols,
		// Token: 0x0400088D RID: 2189
		k_EHTTPStatusCode200OK = 200,
		// Token: 0x0400088E RID: 2190
		k_EHTTPStatusCode201Created,
		// Token: 0x0400088F RID: 2191
		k_EHTTPStatusCode202Accepted,
		// Token: 0x04000890 RID: 2192
		k_EHTTPStatusCode203NonAuthoritative,
		// Token: 0x04000891 RID: 2193
		k_EHTTPStatusCode204NoContent,
		// Token: 0x04000892 RID: 2194
		k_EHTTPStatusCode205ResetContent,
		// Token: 0x04000893 RID: 2195
		k_EHTTPStatusCode206PartialContent,
		// Token: 0x04000894 RID: 2196
		k_EHTTPStatusCode300MultipleChoices = 300,
		// Token: 0x04000895 RID: 2197
		k_EHTTPStatusCode301MovedPermanently,
		// Token: 0x04000896 RID: 2198
		k_EHTTPStatusCode302Found,
		// Token: 0x04000897 RID: 2199
		k_EHTTPStatusCode303SeeOther,
		// Token: 0x04000898 RID: 2200
		k_EHTTPStatusCode304NotModified,
		// Token: 0x04000899 RID: 2201
		k_EHTTPStatusCode305UseProxy,
		// Token: 0x0400089A RID: 2202
		k_EHTTPStatusCode307TemporaryRedirect = 307,
		// Token: 0x0400089B RID: 2203
		k_EHTTPStatusCode400BadRequest = 400,
		// Token: 0x0400089C RID: 2204
		k_EHTTPStatusCode401Unauthorized,
		// Token: 0x0400089D RID: 2205
		k_EHTTPStatusCode402PaymentRequired,
		// Token: 0x0400089E RID: 2206
		k_EHTTPStatusCode403Forbidden,
		// Token: 0x0400089F RID: 2207
		k_EHTTPStatusCode404NotFound,
		// Token: 0x040008A0 RID: 2208
		k_EHTTPStatusCode405MethodNotAllowed,
		// Token: 0x040008A1 RID: 2209
		k_EHTTPStatusCode406NotAcceptable,
		// Token: 0x040008A2 RID: 2210
		k_EHTTPStatusCode407ProxyAuthRequired,
		// Token: 0x040008A3 RID: 2211
		k_EHTTPStatusCode408RequestTimeout,
		// Token: 0x040008A4 RID: 2212
		k_EHTTPStatusCode409Conflict,
		// Token: 0x040008A5 RID: 2213
		k_EHTTPStatusCode410Gone,
		// Token: 0x040008A6 RID: 2214
		k_EHTTPStatusCode411LengthRequired,
		// Token: 0x040008A7 RID: 2215
		k_EHTTPStatusCode412PreconditionFailed,
		// Token: 0x040008A8 RID: 2216
		k_EHTTPStatusCode413RequestEntityTooLarge,
		// Token: 0x040008A9 RID: 2217
		k_EHTTPStatusCode414RequestURITooLong,
		// Token: 0x040008AA RID: 2218
		k_EHTTPStatusCode415UnsupportedMediaType,
		// Token: 0x040008AB RID: 2219
		k_EHTTPStatusCode416RequestedRangeNotSatisfiable,
		// Token: 0x040008AC RID: 2220
		k_EHTTPStatusCode417ExpectationFailed,
		// Token: 0x040008AD RID: 2221
		k_EHTTPStatusCode4xxUnknown,
		// Token: 0x040008AE RID: 2222
		k_EHTTPStatusCode429TooManyRequests = 429,
		// Token: 0x040008AF RID: 2223
		k_EHTTPStatusCode500InternalServerError = 500,
		// Token: 0x040008B0 RID: 2224
		k_EHTTPStatusCode501NotImplemented,
		// Token: 0x040008B1 RID: 2225
		k_EHTTPStatusCode502BadGateway,
		// Token: 0x040008B2 RID: 2226
		k_EHTTPStatusCode503ServiceUnavailable,
		// Token: 0x040008B3 RID: 2227
		k_EHTTPStatusCode504GatewayTimeout,
		// Token: 0x040008B4 RID: 2228
		k_EHTTPStatusCode505HTTPVersionNotSupported,
		// Token: 0x040008B5 RID: 2229
		k_EHTTPStatusCode5xxUnknown = 599
	}
}
