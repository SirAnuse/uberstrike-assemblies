using System;
using UnityEngine;

// Token: 0x020003DA RID: 986
public static class Mathfx
{
	// Token: 0x06001CCA RID: 7370 RVA: 0x00013215 File Offset: 0x00011415
	public static float NormAmplitude(float a)
	{
		return (a + 1f) * 0.5f;
	}

	// Token: 0x06001CCB RID: 7371 RVA: 0x00013224 File Offset: 0x00011424
	public static float Hermite(float start, float end, float value)
	{
		return Mathf.Lerp(start, end, value * value * (3f - 2f * value));
	}

	// Token: 0x06001CCC RID: 7372 RVA: 0x0001323E File Offset: 0x0001143E
	public static float Gauss(float start, float end, float value)
	{
		return Mathf.Lerp(start, end, (1f + Mathf.Cos(value - 3.14159274f)) / 2f);
	}

	// Token: 0x06001CCD RID: 7373 RVA: 0x0001325F File Offset: 0x0001145F
	public static float Sinerp(float start, float end, float value)
	{
		return Mathf.Lerp(start, end, Mathf.Sin(value * 3.14159274f * 0.5f));
	}

	// Token: 0x06001CCE RID: 7374 RVA: 0x00091400 File Offset: 0x0008F600
	public static float Berp(float start, float end, float value)
	{
		value = Mathf.Clamp01(value);
		value = (Mathf.Sin(value * 3.14159274f * (0.2f + 2.5f * value * value * value)) * Mathf.Pow(1f - value, 2.2f) + value) * (1f + 1.2f * (1f - value));
		return start + (end - start) * value;
	}

	// Token: 0x06001CCF RID: 7375 RVA: 0x00091464 File Offset: 0x0008F664
	public static float SmoothStep(float x, float min, float max)
	{
		x = Mathf.Clamp(x, min, max);
		float num = (x - min) / (max - min);
		float num2 = (x - min) / (max - min);
		return -2f * num * num * num + 3f * num2 * num2;
	}

	// Token: 0x06001CD0 RID: 7376 RVA: 0x0001327A File Offset: 0x0001147A
	public static float Lerp(float start, float end, float value)
	{
		return (1f - value) * start + value * end;
	}

	// Token: 0x06001CD1 RID: 7377 RVA: 0x000914A0 File Offset: 0x0008F6A0
	public static Vector3 NearestPoint(Vector3 lineStart, Vector3 lineEnd, Vector3 point)
	{
		Vector3 vector = Vector3.Normalize(lineEnd - lineStart);
		float d = Vector3.Dot(point - lineStart, vector) / Vector3.Dot(vector, vector);
		return lineStart + d * vector;
	}

	// Token: 0x06001CD2 RID: 7378 RVA: 0x000914E0 File Offset: 0x0008F6E0
	public static Vector3 NearestPointStrict(Vector3 lineStart, Vector3 lineEnd, Vector3 point)
	{
		Vector3 vector = lineEnd - lineStart;
		Vector3 vector2 = Vector3.Normalize(vector);
		float value = Vector3.Dot(point - lineStart, vector2) / Vector3.Dot(vector2, vector2);
		return lineStart + Mathf.Clamp(value, 0f, Vector3.Magnitude(vector)) * vector2;
	}

	// Token: 0x06001CD3 RID: 7379 RVA: 0x00013289 File Offset: 0x00011489
	public static float Bounce(float x)
	{
		return Mathf.Abs(Mathf.Sin(6.28f * (x + 1f) * (x + 1f)) * (1f - x));
	}

	// Token: 0x06001CD4 RID: 7380 RVA: 0x000132B2 File Offset: 0x000114B2
	public static bool Approx(float val, float about, float range)
	{
		return Mathf.Abs(val - about) < range;
	}

	// Token: 0x06001CD5 RID: 7381 RVA: 0x00091530 File Offset: 0x0008F730
	public static bool Approx(Vector3 val, Vector3 about, float range)
	{
		return (val - about).sqrMagnitude < range * range;
	}

	// Token: 0x06001CD6 RID: 7382 RVA: 0x00091554 File Offset: 0x0008F754
	public static float ProjectedAngle(Vector3 a, Vector3 b)
	{
		float num = Vector3.Angle(a, b);
		return (Vector3.Dot(a, Mathfx._rotate90 * b) >= 0f) ? num : (360f - num);
	}

	// Token: 0x06001CD7 RID: 7383 RVA: 0x000132BF File Offset: 0x000114BF
	public static Vector3 ProjectVector3(Vector3 v, Vector3 normal)
	{
		return v - Vector3.Dot(v, normal) * normal;
	}

	// Token: 0x06001CD8 RID: 7384 RVA: 0x000132D4 File Offset: 0x000114D4
	public static float ClampAngle(float angle, float min, float max)
	{
		return Mathf.Clamp(angle % 360f, min, max);
	}

	// Token: 0x06001CD9 RID: 7385 RVA: 0x000132E4 File Offset: 0x000114E4
	public static int Sign(float s)
	{
		return (s != 0f) ? ((s >= 0f) ? 1 : -1) : 0;
	}

	// Token: 0x06001CDA RID: 7386 RVA: 0x00013309 File Offset: 0x00011509
	public static short Clamp(short v, short min, short max)
	{
		if (v < min)
		{
			return min;
		}
		if (v > max)
		{
			return max;
		}
		return v;
	}

	// Token: 0x06001CDB RID: 7387 RVA: 0x00013309 File Offset: 0x00011509
	public static int Clamp(int v, int min, int max)
	{
		if (v < min)
		{
			return min;
		}
		if (v > max)
		{
			return max;
		}
		return v;
	}

	// Token: 0x06001CDC RID: 7388 RVA: 0x0001331E File Offset: 0x0001151E
	public static float Clamp(float v, float min, float max)
	{
		if (v < min)
		{
			return min;
		}
		if (v > max)
		{
			return max;
		}
		return v;
	}

	// Token: 0x06001CDD RID: 7389 RVA: 0x00013309 File Offset: 0x00011509
	public static byte Clamp(byte v, byte min, byte max)
	{
		if (v < min)
		{
			return min;
		}
		if (v > max)
		{
			return max;
		}
		return v;
	}

	// Token: 0x06001CDE RID: 7390 RVA: 0x00091594 File Offset: 0x0008F794
	public static float Ease(float t, EaseType easeType)
	{
		switch (easeType)
		{
		case EaseType.In:
			return Mathf.Lerp(0f, 1f, 1f - Mathf.Cos(t * 3.14159274f * 0.5f));
		case EaseType.Out:
			return Mathf.Lerp(0f, 1f, Mathf.Sin(t * 3.14159274f * 0.5f));
		case EaseType.InOut:
			return Mathf.SmoothStep(0f, 1f, t);
		case EaseType.Berp:
			return Mathfx.Berp(0f, 1f, t);
		default:
			return t;
		}
	}

	// Token: 0x06001CDF RID: 7391 RVA: 0x00091630 File Offset: 0x0008F830
	public static Vector2 RotateVector2AboutPoint(Vector2 input, Vector2 center, float degRotate)
	{
		Vector3 vector = Quaternion.AngleAxis(degRotate, new Vector3(0f, 0f, 1f)) * (input - center);
		return center + new Vector2(vector.x, vector.y);
	}

	// Token: 0x0400198C RID: 6540
	public const float PI = 3.14159f;

	// Token: 0x0400198D RID: 6541
	public const float FOUR_PI = 12.56636f;

	// Token: 0x0400198E RID: 6542
	public const float TWO_PI = 6.28318f;

	// Token: 0x0400198F RID: 6543
	public const float PI_HALF = 1.570795f;

	// Token: 0x04001990 RID: 6544
	public const float PI_FOURTH = 0.7853975f;

	// Token: 0x04001991 RID: 6545
	private static readonly Quaternion _rotate90 = Quaternion.AngleAxis(90f, Vector3.up);
}
