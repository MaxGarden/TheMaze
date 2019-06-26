using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    private List<(byte type, byte id, byte rotation)> _data;
    private int _mapWidth, _mapHeight;

    public Map(List<(byte type, byte id, byte rotation)> data, int mapWidth, int mapHeight)
    {
        this._data = data;
        this._mapHeight = mapHeight;
        this._mapWidth = mapWidth;
    }

    public Map() { }

    public List<(byte type, byte id, byte rotation)> getData()
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
