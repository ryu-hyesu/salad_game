using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class corn : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 DefaultPos;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvas;

    private bool isDroppedInBowl = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GameObject.FindObjectOfType<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isDroppedInBowl) return;

        DefaultPos = rectTransform.position;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDroppedInBowl) return;

        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out pos
        );
        rectTransform.localPosition = pos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isDroppedInBowl) return;

        GameObject bowlObj = GameObject.FindGameObjectWithTag("Bowl");

        if (bowlObj != null)
        {
            RectTransform bowlRect = bowlObj.GetComponent<RectTransform>();

            if (RectTransformUtility.RectangleContainsScreenPoint(bowlRect, eventData.position, eventData.pressEventCamera))
            {
                // 콘을 보울 안에 넣고 보울의 왼쪽 위에 위치시킴
                rectTransform.SetParent(bowlRect);

                Vector3 offset = new Vector3(
                    -bowlRect.rect.width / 2 + rectTransform.rect.width / 2,
                    bowlRect.rect.height / 2 - rectTransform.rect.height / 2,
                    0
                );
                rectTransform.localPosition = offset;

                isDroppedInBowl = true;
                canvasGroup.blocksRaycasts = true;
                return;
            }
        }

        // 볼 안에 안 들어갔을 때
        rectTransform.position = DefaultPos;
        canvasGroup.blocksRaycasts = true;
    }
}