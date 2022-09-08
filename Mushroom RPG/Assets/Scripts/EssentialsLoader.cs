using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    
    public GameObject player;
    public GameObject gameMan;
    void Awake()
    {
        
       

        if(PlayerController.instance == null)
        {
            Instantiate(player);
        }
        

        if(GameManager.instance == null)
        {
            Instantiate(gameMan);
        }
        
    }

    void Update()
    {
        
    }
}
