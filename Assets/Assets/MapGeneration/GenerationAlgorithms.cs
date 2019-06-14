using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationAlgorithms
{

    private int _width;
    private int _height;
    private Point _startPoint;
    private Point _endPoint;

    public Point[,] _points;

    public GenerationAlgorithms(int width, int height)
    {
        this._width = width;
        this._height = height;
        _points = new Point[width, height];
    }
    // Tier 1

    public List<Point> createStartEndPoints()
    {
        Point startPoint = new Point(Mathf.RoundToInt(Random.Range(1, _width)*0.2f), Mathf.RoundToInt(Random.Range(1, _height)*0.4f));
        Point endPoint = new Point(Mathf.RoundToInt(_width*0.8f),Mathf.RoundToInt(_height*0.8f));
        int xEndPoint, yEndPoint;

        float distanceModifier = Random.Range(0.8f, 0.95f);

        int remainingDistX = _width - startPoint.x;
        int remainingDistY_positive = _height - startPoint.y;
        int remainingDistY_negative = startPoint.y;
        bool directionY;

        if (remainingDistY_negative < _height / 2)
            directionY = (Random.value > 0.2f);
        else
            directionY = (Random.value > 0.8f);

        xEndPoint = Mathf.RoundToInt(remainingDistX * distanceModifier);
        if (directionY)
            yEndPoint = Mathf.RoundToInt(remainingDistY_positive * distanceModifier);
        else
            yEndPoint = Mathf.RoundToInt(remainingDistY_negative * distanceModifier);

        endPoint = new Point(xEndPoint, yEndPoint);
        List<Point> toReturn = new List<Point>();
        toReturn.Add(startPoint);
        toReturn.Add(endPoint);
        return toReturn;
    }


    public List<Point> createPath()
    {

        int small = Random.Range(2, 5);


        int x = _startPoint.x, y = _startPoint.y;
        List<Point> toReturn = new List<Point>();

        //for(int y =0; y<_height;y++)
        //{
        //    for(int x = 0; x<_width, x++)
        //    {

        //    }
        //}




        while(x != _endPoint.x && y!= _endPoint.y)
        {
            Point currentPoint = _points[x, y];
            DirectionsEnum dir = DirectionsEnum.None;
            switch(dir)
            {
                case DirectionsEnum.East:

                break;
            }
        }

        return toReturn;
    }

    public List<Point> createRooms(int count)
    {
        List<Point> toReturn = new List<Point>();
        List<Room> rooms = new List<Room>();
        Room room = new Room(new Point(Random.Range(1, _width), Random.Range(1, _height)), RoomsSize.Small);
        rooms.Add(room);
        for (int i = 1; i < count; i++)
        {
            do
            {
                room = new Room(new Point(Random.Range(1, _width), Random.Range(1, _height)), RoomsSize.Small);
            } while (!room.isCollision(rooms));
            rooms.Add(room);
        }

        return toReturn;
    }
}