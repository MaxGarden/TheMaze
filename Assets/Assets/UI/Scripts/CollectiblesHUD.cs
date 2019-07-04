using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectiblesHUD : MonoBehaviour
{
    private List<GameObject> collectiblePrefabs;
    private List<CollectibleTemplate> collectibles;

    public GameObject collectiblePrefab;
   // public Sprite icon;

     private void Start()
     {
         collectiblePrefabs = new List<GameObject>();
         collectibles = new List<CollectibleTemplate>();
        PlayerContext.MainPlayer.Inventory.OnCollectiblesChanged += CollectiblesChanged;
     }

     private void OnDestroy()
     {
        PlayerContext.MainPlayer.Inventory.OnCollectiblesChanged -= CollectiblesChanged;
     }


    void CollectiblesChanged()
    {
        foreach (var entry in PlayerContext.MainPlayer.Inventory.Collectibles)
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

            CreateUI(entry.Value, collectible.Icon);
            collectibles.Add(collectible);
        }

        
    }

    void UpdateUI(int index, int score)
    {
        collectiblePrefabs[index].GetComponentInChildren<Text>().text = score.ToString();
    }

    void CreateUI(int score, Sprite icon)
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
