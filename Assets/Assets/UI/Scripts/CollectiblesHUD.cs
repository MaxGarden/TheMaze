using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectiblesHUD : MonoBehaviour
{
    private Inventory inventory;
    public GameObject collectiblePrefab;
    public GameObject[] collectiblePrefabs;
    private CollectibleTemplate[] collectibles;
    public Sprite icon;

     private void OnEnable()
     {
         inventory = PlayerContext.MainPlayer.Inventory;
         inventory.OnCollectiblesChanged += CollectiblesChanged;
     }

     private void OnDisable()
     {
         inventory.OnCollectiblesChanged -= CollectiblesChanged;
     }

    void Start()
    {

        GameObject test = (GameObject)Instantiate(collectiblePrefab, transform.position, transform.rotation);
    }

    void CollectiblesChanged()
    {
        foreach (var entry in inventory.Collectibles)
        {
            var collectible = entry.Key;

            for (int i = 0; i < collectibles.Length; i++)
            {
                if(collectible == collectibles[i])
                {
                    UpdateUI(i, entry.Value);
                    return;
                }
            }
            CreateUI(entry.Value);
            collectibles[collectibles.Length] = collectible;
        }

        
    }

    void UpdateUI(int index, int score)
    {
        collectiblePrefabs[index].GetComponent<Text>().text = score.ToString();
    }

    void CreateUI(int score)
    {
        collectiblePrefabs[collectiblePrefabs.Length] = Instantiate(collectiblePrefab, GetComponentInParent<Image>().transform);
        collectiblePrefabs[collectiblePrefabs.Length].GetComponent<Text>().text = score.ToString();
        collectiblePrefabs[collectiblePrefabs.Length].GetComponent<Image>().sprite = icon;
    }
    
}
