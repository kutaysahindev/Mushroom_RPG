using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public GameObject[] windows;
    public GameObject theMenu;

    public ItemButton[] itemButtons;

    public static GameMenu instance;
    public string selectedItem;
    public Item activeItem;

    public TextMeshProUGUI itemName, itemDescription, useButtonText;
    public TextMeshProUGUI goldText;

    public Image hoeImage;
    void Start()
    {
        instance = this;
        ShowItems();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (theMenu.activeInHierarchy)
            {
                theMenu.SetActive(false);
                CloseMenu();
            }
            else
            {
                theMenu.SetActive(true);
            }
        }

        goldText.text = GameManager.instance.currentGold.ToString() + "g";
    }

    public void ToggleWindow(int windowNumber)
    {
        for(int i= 0; i < windows.Length; i++)
        {
            if(i == windowNumber)
            {
                windows[i].SetActive(!windows[i].activeInHierarchy);
            }
            else
            {
                windows[i].SetActive(false);
            }
        }
    }

    public void CloseMenu()
    {
        for(int i = 0; i < windows.Length; i++)
        {
            windows[i].SetActive(false);
        }

        theMenu.SetActive(false);

        
    }

    public void ShowItems()
    {
        GameManager.instance.SortItems();

        for (int i = 0; i < itemButtons.Length; i++)
        {
            itemButtons[i].buttonValue = i;

            if (GameManager.instance.itemsHeld[i] != "")
            {
                itemButtons[i].buttonImage.gameObject.SetActive(true);
                itemButtons[i].buttonImage.sprite = GameManager.instance.GetItemDetails(GameManager.instance.itemsHeld[i]).itemSprite;
                itemButtons[i].amountText.text = GameManager.instance.numberOfItems[i].ToString();
            }
            else
            {
                itemButtons[i].buttonImage.gameObject.SetActive(false);
                itemButtons[i].amountText.text = "";
            }
        }
    }

    public void SelectItem(Item newItem)
    {
        activeItem = newItem;

        if (activeItem.isItem)
        {
            useButtonText.text = "Use";
        }
        if (activeItem.affectSkillHarvest)
        {
            useButtonText.text = "Equip";
        }

        itemName.text = activeItem.itemName;
        itemDescription.text = activeItem.desc;
    }

    public void DiscardItem()
    {
        if (activeItem != null)
        {
            GameManager.instance.RemoveItem(activeItem.itemName);
        }
    }

    public void UseItem()
    {
        activeItem.Use();
        hoeImage.enabled = true;
        
    }

    public void Exit()
    {
        Application.Quit();
    }
}
