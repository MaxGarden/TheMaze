using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectiblesHUD : MonoBehaviour
{
    private Inventory inventory;
    private List<GameObject> collectiblePrefabs;
    private List<CollectibleTemplate> collectibles;

    public GameObject collectiblePrefab;
    public Sprite icon;

     private void OnEnable()
     {
         collectiblePrefabs = new List<GameObject>();
         collectibles = new List<CollectibleTemplate>();
         inventory = PlayerContext.MainPlayer.Inventory;
         inventory.OnCollectiblesChanged += CollectiblesChanged;
     }

     private void OnDisable()
     {
         inventory.OnCollectiblesChanged -= CollectiblesChanged;
     }


    void CollectiblesChanged()
    {
        foreach (var entry in inventory.Collectibles)
        {
            var collectible = entry.Key;

            for (int i = 0; i < collectibles.Count; i++)
            {
                if(collectible == collectibles[i])
                {
                    UpdateUI(i, entry.Value);
                    return;
                }
            }
            CreateUI(entry.Value);
            collectibles.Add(collectible);
        }

        
    }

    void UpdateUI(int index, int score)
    {
        collectiblePrefabs[index].GetComponentInChildren<Text>().text = score.ToString();
    }

    void CreateUI(int score)
    {
         GameObject added = Instantiate(collectiblePrefab, transform);
         if(added)
         {
            added.GetComponentInChildren<Text>().text = score.ToString();
            added.GetComponentInChildren<Image>().sprite = icon;
            collectiblePrefabs.Add(added);
         }

    }

}
