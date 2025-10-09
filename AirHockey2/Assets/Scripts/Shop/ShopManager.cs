using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    public int[,] Items = new int[5,5];
    public int PuckPoints;
    public int ItemCost;
    public TMP_Text PuckPointsText;
    ShopItemInfo ItemInfo;

    void Start()
    {
        PuckPointsText.text = "Puck Points:" + PuckPoints.ToString();
        //Get Item ID

        Items[1, 1] = 1;
        Items[1, 2] = 2;
        Items[1, 3] = 3;
        Items[1, 4] = 4;
        //Items[1, 5] = 5;

        //Get Item Cost

        Items[2, 1] = 500;
        Items[2, 2] = ItemInfo.ItemCost;
        Items[2, 3] = ItemInfo.ItemCost;
        Items[2, 4] = ItemInfo.ItemCost;
        Items[2, 5] = ItemInfo.ItemCost;




    }

    public void BuyItem()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (PuckPoints >= Items[2, ButtonRef.GetComponent<ShopItemInfo>().ItemID] && 
            ButtonRef.GetComponent<ShopItemInfo>().Purchased == false)
        {
            PuckPoints -= Items[2, ButtonRef.GetComponent<ShopItemInfo>().ItemID];
            ButtonRef.GetComponent<ShopItemInfo>().Purchased = true;
            PuckPointsText.text = "Puck Points:" + PuckPoints.ToString();
        }
    }
}
