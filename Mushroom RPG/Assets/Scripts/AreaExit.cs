using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{

    public string areaToLoad;
    public string areaTo;
    public string areaFrom;

    public AreaEntrance entrance;

    public float waitToLoad = 1f;
    private bool shouldLoadAfterFade;
    void Start()
    {
        entrance.transitionName = areaFrom;
    }

    private void Update()
    {
        if (shouldLoadAfterFade)
        {
            waitToLoad -= Time.deltaTime;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            SceneManager.LoadScene(areaToLoad);
            PlayerController.instance.areaTransitionName = areaTo;
        }
    }
}
