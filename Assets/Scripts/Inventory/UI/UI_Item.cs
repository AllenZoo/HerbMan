
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UI_Item : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Image image;
    private TextMeshProUGUI countText;

    private Item item;
    [SerializeField] private int count;
    [SerializeField] Item.SystemType systemType;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
        image = transform.Find("image").GetComponent<Image>();
        countText = transform.Find("countText").GetComponent<TextMeshProUGUI>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .5f;
        canvasGroup.blocksRaycasts = false;
        UI_ItemDrag.Instance.Show(item);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        UI_ItemDrag.Instance.Hide();
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public string GetTag()
    {
        return this.tag;
    }
    public int GetCount()
    {
        return count;
    }
    public Item.SystemType GetSystemType()
    {
        return systemType;
    }
    public void SetSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }
    public void SetTag(string tag)
    {
        this.gameObject.tag = tag;
    }
    public void SetCount(int count)
    {
        this.count = count;
    }
    public void SetSystemType(Item.SystemType systemType)
    {
        this.systemType = systemType;
    }
    public void RefreshCountText()
    {
        if (count > 1)
        {
            countText.SetText("x" + count.ToString());
        }
        else
        {
            countText.SetText("");
        }
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

