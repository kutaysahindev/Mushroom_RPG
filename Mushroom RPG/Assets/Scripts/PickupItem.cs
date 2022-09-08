using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{

    public bool canPickup;

    public Quest quest;

    void Start()
    {
        
    }

    void Update()
    {
        if (canPickup && Input.GetKeyDown(KeyCode.E) && PlayerController.instance.canHarvest)
        {

                quest.goal.MushroomCollected();
                if (quest.goal.IsReached())
                {
                    GameManager.instance.currentGold += quest.goldReward;
                    quest.Complete();
                }

            GameManager.instance.AddItem(GetComponent<Item>().itemName);
            Destroy(gameObject);
            

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canPickup = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canPickup = false;
        }
    }
}
