using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020003D6 RID: 982
public static class MaterialUtil
{
	// Token: 0x06001CBA RID: 7354 RVA: 0x00090B9C File Offset: 0x0008ED9C
	public static void SetFloat(Material m, string propertyName, float value)
	{
		if (m && m.HasProperty(propertyName))
		{
			MaterialUtil.MaterialCache materialCache;
			if (!MaterialUtil._cache.TryGetValue(m, out materialCache))
			{
				materialCache = new MaterialUtil.MaterialCache();
				MaterialUtil._cache[m] = materialCache;
			}
			if (!materialCache.Floats.ContainsKey(propertyName))
			{
				materialCache.Floats[propertyName] = m.GetFloat(propertyName);
			}
			m.SetFloat(propertyName, value);
		}
		else
		{
			Debug.LogError(string.Format("Property<float> '{0}' not found in Material {1}", propertyName, (!m) ? "NULL" : m.name));
		}
	}

	// Token: 0x06001CBB RID: 7355 RVA: 0x00090C40 File Offset: 0x0008EE40
	public static void SetColor(Material m, string propertyName, Color value)
	{
		if (m && m.HasProperty(propertyName))
		{
			MaterialUtil.MaterialCache materialCache;
			if (!MaterialUtil._cache.TryGetValue(m, out materialCache))
			{
				materialCache = new MaterialUtil.MaterialCache();
				MaterialUtil._cache[m] = materialCache;
			}
			if (!materialCache.Colors.ContainsKey(propertyName))
			{
				materialCache.Colors[propertyName] = m.GetColor(propertyName);
			}
			m.SetColor(propertyName, value);
		}
		else
		{
			Debug.LogError(string.Format("Property<Color> '{0}' not found in Material {1}", propertyName, (!m) ? "NULL" : m.name));
		}
	}

	// Token: 0x06001CBC RID: 7356 RVA: 0x00090CE4 File Offset: 0x0008EEE4
	public static void SetTextureOffset(Material m, string propertyName, Vector2 value)
	{
		if (m && m.HasProperty(propertyName))
		{
			MaterialUtil.MaterialCache materialCache;
			if (!MaterialUtil._cache.TryGetValue(m, out materialCache))
			{
				materialCache = new MaterialUtil.MaterialCache();
				MaterialUtil._cache[m] = materialCache;
			}
			if (!materialCache.TextureOffset.ContainsKey(propertyName))
			{
				materialCache.TextureOffset[propertyName] = m.GetTextureOffset(propertyName);
			}
			m.SetTextureOffset(propertyName, value);
		}
		else
		{
			Debug.LogError(string.Format("Property<Vector2> '{0}' not found in Material {1}", propertyName, (!m) ? "NULL" : m.name));
		}
	}

	// Token: 0x06001CBD RID: 7357 RVA: 0x00090D88 File Offset: 0x0008EF88
	public static void SetTexture(Material m, string propertyName, Texture value)
	{
		if (m && m.HasProperty(propertyName))
		{
			MaterialUtil.MaterialCache materialCache;
			if (!MaterialUtil._cache.TryGetValue(m, out materialCache))
			{
				materialCache = new MaterialUtil.MaterialCache();
				MaterialUtil._cache[m] = materialCache;
			}
			if (!materialCache.Texture.ContainsKey(propertyName))
			{
				materialCache.Texture[propertyName] = m.GetTexture(propertyName);
			}
			m.SetTexture(propertyName, value);
		}
		else
		{
			Debug.LogError(string.Format("Property<Texture> '{0}' not found in Material {1}", propertyName, (!m) ? "NULL" : m.name));
		}
	}

	// Token: 0x06001CBE RID: 7358 RVA: 0x00090E2C File Offset: 0x0008F02C
	public static void Reset(Material m)
	{
		MaterialUtil.MaterialCache materialCache;
		if (MaterialUtil._cache.TryGetValue(m, out materialCache))
		{
			foreach (KeyValuePair<string, Color> keyValuePair in materialCache.Colors)
			{
				m.SetColor(keyValuePair.Key, keyValuePair.Value);
			}
			foreach (KeyValuePair<string, float> keyValuePair2 in materialCache.Floats)
			{
				m.SetFloat(keyValuePair2.Key, keyValuePair2.Value);
			}
			foreach (KeyValuePair<string, Vector2> keyValuePair3 in materialCache.TextureOffset)
			{
				m.SetTextureOffset(keyValuePair3.Key, keyValuePair3.Value);
			}
		}
	}

	// Token: 0x04001981 RID: 6529
	private static Dictionary<Material, MaterialUtil.MaterialCache> _cache = new Dictionary<Material, MaterialUtil.MaterialCache>();

	// Token: 0x020003D7 RID: 983
	private class MaterialCache
	{
		// Token: 0x04001982 RID: 6530
		public Dictionary<string, Color> Colors = new Dictionary<string, Color>();

		// Token: 0x04001983 RID: 6531
		public Dictionary<string, float> Floats = new Dictionary<string, float>();

		// Token: 0x04001984 RID: 6532
		public Dictionary<string, Vector2> TextureOffset = new Dictionary<string, Vector2>();

		// Token: 0x04001985 RID: 6533
		public Dictionary<string, Texture> Texture = new Dictionary<string, Texture>();
	}
}
