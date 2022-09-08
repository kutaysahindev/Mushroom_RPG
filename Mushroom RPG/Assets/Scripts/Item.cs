using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool isItem;
    public string itemName;
    public string desc;
    public Sprite itemSprite;
    public bool affectSkillHarvest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use()
    {
        if (isItem && itemName == "Hoe")
        {
            PlayerController.instance.canHarvest = true;
            GameManager.instance.RemoveItem(itemName);
        }
    }
}
