using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class builder : MonoBehaviour
{
    public GameObject block1;
    public GameObject block2;
    public int mapWidth = 3;
    public int mapHeight = 3;
    private float gridSize = 5.9f;

    //notation for testing purposes: (element_number, rotation, ???) representing (R,G,B) values from loaded map
    private (byte type, byte rotation, byte)[] testMap = {(1,1,0), (1,1,0), (1,1,0),
                                                          (2,0,0), (0,0,0), (1,0,0),
                                                          (1,1,0), (1,1,0), (1,1,0)};

    void Start()
    {
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                int pixelNumber = y * mapHeight + x;
                Vector3 pos = new Vector3(x+5, 0, y+5) * gridSize;
                GameObject spawner = new GameObject();

                switch ((int)testMap[pixelNumber].type)
                {
                    case 1:
                        spawner = Instantiate(block1, pos, Quaternion.identity);
                        rescale(spawner, gridSize, 5.8f, gridSize);

                        break;
                    case 2:
                        spawner = Instantiate(block2, pos, Quaternion.identity);
                        rescale(spawner, gridSize, 5.8f, gridSize+0.1f);
                        break;
                }

                spawner.transform.Rotate(0, 90f * (int)testMap[pixelNumber].rotation, 0, Space.World);

            }
        }
    }

    public void rescale(GameObject gameObj, float newSizeX, float newSizeY, float newSizeZ)
    {

        Vector3 size = gameObj.GetComponent<Renderer>().bounds.size;

        Vector3 rescale = gameObj.transform.localScale;

        rescale.x = newSizeX * rescale.x / size.x;
        rescale.y = newSizeY * rescale.y / size.y;
        rescale.z = newSizeZ * rescale.z / size.z;

        gameObj.transform.localScale = rescale;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
