using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002FD RID: 765
public class NGUIScrollList : MonoBehaviour
{
	// Token: 0x17000533 RID: 1331
	// (get) Token: 0x060015AB RID: 5547 RVA: 0x0000E804 File Offset: 0x0000CA04
	public UIDraggablePanel Panel
	{
		get
		{
			return this.dragPanel;
		}
	}

	// Token: 0x17000534 RID: 1332
	// (get) Token: 0x060015AC RID: 5548 RVA: 0x0000E80C File Offset: 0x0000CA0C
	public List<GameObject> ActiveElements
	{
		get
		{
			return (this.activeElements != null) ? this.activeElements : this.elements;
		}
	}

	// Token: 0x060015AD RID: 5549 RVA: 0x0000E82A File Offset: 0x0000CA2A
	private void OnEnable()
	{
		this.centeringTool.onFinished = delegate()
		{
			this.UpdateSelection(this.centeringTool.centeredObject);
		};
	}

	// Token: 0x060015AE RID: 5550 RVA: 0x00079694 File Offset: 0x00077894
	public void UpdateCircularList()
	{
		if (this.scrollType != NGUIScrollList.ScrollType.NotCircular && this.ActiveElements.Count > 1)
		{
			NGUITools.SetActiveChildren(this.grid.gameObject, false);
			GameObject gameObject = this.ActiveElements[this.GetPreviousIndex(this.SelectedElement.Value)];
			GameObject gameObject2 = this.ActiveElements[this.GetNextIndex(this.SelectedElement.Value)];
			GameObject gameObject3 = null;
			GameObject gameObject4 = null;
			if (this.scrollType == NGUIScrollList.ScrollType.Visible3)
			{
				gameObject3 = this.ActiveElements[this.GetPreviousIndex(gameObject)];
				gameObject4 = this.ActiveElements[this.GetNextIndex(gameObject2)];
			}
			if (gameObject == gameObject2)
			{
				if (this.helperElement != null)
				{
					UnityEngine.Object.DestroyImmediate(this.helperElement);
				}
				this.helperElement = NGUITools.AddChild(this.grid.gameObject, gameObject2);
				gameObject = this.helperElement;
				this.helperElementReference = gameObject2;
			}
			if (gameObject3 == null || gameObject4 == null)
			{
				gameObject.name = "0";
				this.SelectedElement.Value.name = "1";
				gameObject2.name = "2";
			}
			else
			{
				gameObject3.name = "0";
				gameObject.name = "1";
				this.SelectedElement.Value.name = "2";
				gameObject2.name = "3";
				gameObject4.name = ((!(gameObject == gameObject4)) ? "4" : "0");
				gameObject3.SetActive(true);
				gameObject4.SetActive(true);
			}
			gameObject.SetActive(true);
			this.SelectedElement.Value.SetActive(true);
			gameObject2.SetActive(true);
			this.grid.sorted = true;
			this.grid.Reposition();
			this.SpringToElement(this.SelectedElement.Value, 100f);
		}
	}

	// Token: 0x060015AF RID: 5551 RVA: 0x00079884 File Offset: 0x00077A84
	private int GetPreviousIndex(GameObject element)
	{
		int num = Mathf.Clamp(this.ActiveElements.IndexOf(element), 0, this.ActiveElements.Count - 1);
		return (num != 0) ? (num - 1) : (this.ActiveElements.Count - 1);
	}

	// Token: 0x060015B0 RID: 5552 RVA: 0x000798CC File Offset: 0x00077ACC
	private int GetNextIndex(GameObject element)
	{
		int num = Mathf.Clamp(this.ActiveElements.IndexOf(element), 0, this.ActiveElements.Count - 1);
		return (num != this.ActiveElements.Count - 1) ? (num + 1) : 0;
	}

	// Token: 0x060015B1 RID: 5553 RVA: 0x0000E843 File Offset: 0x0000CA43
	public void Reposition()
	{
		this.grid.Reposition();
	}

	// Token: 0x060015B2 RID: 5554 RVA: 0x0000E850 File Offset: 0x0000CA50
	public void SpringToElement(GameObject element, float springDuration = 100f)
	{
		if (element != null)
		{
			this.dragPanel.SpringToSelection(element, springDuration);
		}
	}

	// Token: 0x060015B3 RID: 5555 RVA: 0x0000E86B File Offset: 0x0000CA6B
	public void SelectElement(GameObject element, float springDuration)
	{
		if (element != null)
		{
			this.SpringToElement(element, springDuration);
			this.UpdateSelection(element);
		}
	}

	// Token: 0x060015B4 RID: 5556 RVA: 0x00079918 File Offset: 0x00077B18
	private void UpdateSelection(GameObject newSelection)
	{
		if (this.SelectedElement.Value != newSelection)
		{
			this.SelectedElement.Value = ((!(newSelection == this.helperElement)) ? newSelection : this.helperElementReference);
			if (this.ActiveElements.Contains(this.SelectedElement.Value))
			{
				this.SelectedIndex.Value = this.ActiveElements.IndexOf(this.SelectedElement.Value);
			}
			this.UpdateCircularList();
		}
	}

	// Token: 0x060015B5 RID: 5557 RVA: 0x000799A8 File Offset: 0x00077BA8
	public void SetActiveElements(List<GameObject> newElements)
	{
		this.elements.ForEach(delegate(GameObject el)
		{
			if (el != null)
			{
				NGUITools.SetActive(el, newElements.Contains(el));
			}
		});
		this.activeElements = newElements;
		if (this.helperElement != null)
		{
			UnityEngine.Object.DestroyImmediate(this.helperElement);
		}
		this.grid.Reposition();
	}

	// Token: 0x04001468 RID: 5224
	public NGUIScrollList.ScrollType scrollType;

	// Token: 0x04001469 RID: 5225
	[SerializeField]
	private UIDraggablePanel dragPanel;

	// Token: 0x0400146A RID: 5226
	[SerializeField]
	private UIGrid grid;

	// Token: 0x0400146B RID: 5227
	public UICenterOnChild centeringTool;

	// Token: 0x0400146C RID: 5228
	[SerializeField]
	private List<GameObject> elements = new List<GameObject>();

	// Token: 0x0400146D RID: 5229
	public Property<GameObject> SelectedElement = new Property<GameObject>();

	// Token: 0x0400146E RID: 5230
	public IntegerProperty SelectedIndex = new IntegerProperty(0, 0, int.MaxValue);

	// Token: 0x0400146F RID: 5231
	private List<GameObject> activeElements;

	// Token: 0x04001470 RID: 5232
	private GameObject helperElement;

	// Token: 0x04001471 RID: 5233
	private GameObject helperElementReference;

	// Token: 0x020002FE RID: 766
	public enum ScrollType
	{
		// Token: 0x04001473 RID: 5235
		NotCircular,
		// Token: 0x04001474 RID: 5236
		Visible1,
		// Token: 0x04001475 RID: 5237
		Visible3
	}
}
