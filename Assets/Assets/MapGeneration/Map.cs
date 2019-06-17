using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    private (byte type, byte id, byte height, byte rotation)[] _data;
    private int _mapWidth, _mapHeight;

    public Map((byte type, byte id, byte height, byte rotation)[] data, int mapWidth, int mapHeight)
    {
        this._data = data;
        this._mapHeight = mapHeight;
        this._mapWidth = mapWidth;
    }

    public (byte type, byte id, byte height, byte rotation)[] getData()
    {
        return _data;
    }
    public int getMapWidth()
    {
        return _mapWidth;
    }
    public int getMapHeight()
    {
        return _mapHeight;
    }
}
