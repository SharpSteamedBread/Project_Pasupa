using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DroppableUI : MonoBehaviour, IDropHandler
{
	private	Image			image;
	private	RectTransform	rect;

	private void Awake()
	{
		image	= GetComponent<Image>();
		rect	= GetComponent<RectTransform>();
	}


	/// <summary>
	/// 현재 아이템 슬롯 영역 내부에서 드롭을 했을 때 1회 호출
	/// </summary>
	public void OnDrop(PointerEventData eventData)
	{
		// pointerDrag는 현재 드래그하고 있는 대상(=아이템)
		if ( eventData.pointerDrag != null )
		{
			// 드래그하고 있는 대상의 부모를 현재 오브젝트로 설정하고, 위치를 현재 오브젝트 위치와 동일하게 설정
			eventData.pointerDrag.transform.SetParent(transform);
			eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
		}
	}
}

