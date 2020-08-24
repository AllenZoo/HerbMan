
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemUI : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Image image;
    private Item item;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
        image = transform.Find("image").GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .5f;
        canvasGroup.blocksRaycasts = false;
        ItemDragUI.Instance.Show(item);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        ItemDragUI.Instance.Hide();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void SetSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void SetItem(Item item)
    {
        this.item = item;
        SetSprite(Item.GetSprite(item.itemType));
    }

}

