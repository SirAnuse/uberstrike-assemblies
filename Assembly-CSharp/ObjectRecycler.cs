using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Token: 0x020003DD RID: 989
public class ObjectRecycler
{
	// Token: 0x06001CE4 RID: 7396 RVA: 0x000916E4 File Offset: 0x0008F8E4
	public ObjectRecycler(GameObject gameObject, int initialCapacity, GameObject parentObject = null)
	{
		this._objectList = new List<GameObject>(initialCapacity);
		this._objectToRecycle = gameObject;
		this._parentObject = parentObject;
		for (int i = 0; i < initialCapacity; i++)
		{
			GameObject gameObject2 = UnityEngine.Object.Instantiate(this._objectToRecycle) as GameObject;
			gameObject2.gameObject.SetActive(false);
			if (parentObject != null)
			{
				gameObject2.transform.parent = this._parentObject.transform;
			}
			this._objectList.Add(gameObject2);
		}
	}

	// Token: 0x06001CE5 RID: 7397 RVA: 0x00091770 File Offset: 0x0008F970
	public GameObject GetNextFree()
	{
		GameObject gameObject = (from item in this._objectList
		where !item.activeSelf
		select item).FirstOrDefault<GameObject>();
		if (gameObject == null)
		{
			gameObject = (UnityEngine.Object.Instantiate(this._objectToRecycle) as GameObject);
			if (this._parentObject != null)
			{
				gameObject.transform.parent = this._parentObject.transform;
			}
			this._objectList.Add(gameObject);
		}
		gameObject.SetActive(true);
		return gameObject;
	}

	// Token: 0x06001CE6 RID: 7398 RVA: 0x000133B8 File Offset: 0x000115B8
	public void FreeObject(GameObject objectToFree)
	{
		objectToFree.gameObject.SetActive(false);
	}

	// Token: 0x04001998 RID: 6552
	private List<GameObject> _objectList;

	// Token: 0x04001999 RID: 6553
	private GameObject _objectToRecycle;

	// Token: 0x0400199A RID: 6554
	private GameObject _parentObject;
}
