using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayController : MonoBehaviour, IDisplayInputHandler
{
    private Canvas collectiblesCanvas;
    void Start()
    {
        collectiblesCanvas = GameObject.Find("CollectiblesCanvas").GetComponent<Canvas>();
    }
    public void DisplayCollectibles()
    {
        if (collectiblesCanvas)
        {
            collectiblesCanvas.enabled = !collectiblesCanvas.enabled;
        }
    }

}
