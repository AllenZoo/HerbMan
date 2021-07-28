using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shop))]
public class Shop_Handler : MonoBehaviour
{
    [SerializeField] private ItemObject tempItem;
    private Shop shopRef;

    private void Awake()
    {
        shopRef = GetComponent<Shop>();
    }

    private void Start()
    {
        //shopRef.AddItemToList(tempItem, Shop.ShopList.sell);
        //shopRef.AddItemToList(tempItem, Shop.ShopList.sell);
        //shopRef.AddItemToList(tempItem, Shop.ShopList.sell);
        //shopRef.AddItemToList(tempItem, Shop.ShopList.sell);
        //shopRef.AddItemToList(tempItem, Shop.ShopList.sell);
        //shopRef.AddItemToList(tempItem, Shop.ShopList.sell);
        //shopRef.AddItemToList(tempItem, Shop.ShopList.sell);
    }
}
