﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationAlgorithms
{

    private int _width;
    private int _height;
    private Texture2D _mapSchema;
    private List<Room> _rooms;

    private ElementsT1Collection _t1Elements = new ElementsT1Collection();


    public GenerationAlgorithms(int width, int height, Texture2D mapSchema)
    {
        this._width = width;
        this._height = height;
        this._mapSchema = mapSchema;
        this._rooms = new List<Room>();
    }


    // Tier 1

        public Texture2D create()
    {

        List<Point> startEndPoints = createStartEndPoints();

        Point startPoint = startEndPoints[0];
        Point endPoint = startEndPoints[1];

        updateMapSchema(startEndPoints);

        updateMapSchema(createRooms(16));

        createPath(20);

        createPathFromTo( startPoint,  _rooms[_rooms.Count/2].GetDoors()[0].accessPoint);
        createPathFromTo( endPoint, _rooms[_rooms.Count / 4].GetDoors()[2].accessPoint);

        fillRestPoints();

        return _mapSchema;
    }

    public List<Point> createStartEndPoints()
    {

        Point startPoint = new Point(Mathf.RoundToInt(Random.Range(3, _width)*0.2f), Mathf.RoundToInt(Random.Range(1, _height)*0.4f), _t1Elements.getElement(ElementsT1Collection.ElementsT1.StartPoint));
        Point endPoint;
        List<Point> points = new List<Point>();
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

        endPoint = new Point(xEndPoint, yEndPoint, _t1Elements.getElement(ElementsT1Collection.ElementsT1.EndPoint));


        points.Add(startPoint);
        points.Add(endPoint);

        return points;
    }

    public List<Point> createPath(int pathsCount)
    {
        List<Point> points = new List<Point>();
        Door startDoor = new Door();
        Door endDoor = new Door();
        int doorNumber, startRoomNumber, endRoomNumber;
        for (int i = 0; i < pathsCount; i++)
        {
            startRoomNumber = Random.Range(0, _rooms.Count);
            Room startRoom = _rooms[startRoomNumber];
            doorNumber = Random.Range(0, 3);
            if (startRoom.GetDoors()[doorNumber].isAvailable)
            {
                startDoor = startRoom.GetDoors()[doorNumber];
            }

            do
            {
                endRoomNumber = Random.Range(0, _rooms.Count);
            } while (endRoomNumber == startRoomNumber);

            Room endRoom = _rooms[endRoomNumber];
            doorNumber = Random.Range(0, 3);
            if (endRoom.GetDoors()[doorNumber].isAvailable)
            {
                endDoor = endRoom.GetDoors()[doorNumber];
            }
            drawX(startDoor.accessPoint, endDoor.accessPoint);
        }

        return points;
    }

    public void createPathFromTo(Point startPoint, Point endPoint)
    {
        drawX(startPoint, endPoint);
    }

    private void drawX(Point startPoint, Point endPoint)
    {
        int x = startPoint.x;
        int y = startPoint.y;
        int unit = 1;
        List<Point> points = new List<Point>();

        if (endPoint.x < startPoint.x)
            unit *= -1;

        while (true)
        {
            Color32 currentPointColor = _mapSchema.GetPixel(x, y);
            if ((currentPointColor.r != 205 &&
                currentPointColor.g != 205 &&
                currentPointColor.b != 205 &&
                currentPointColor.a != 205) && 
                (currentPointColor.r != _t1Elements.getElement(ElementsT1Collection.ElementsT1.Path).r &&
                currentPointColor.r != _t1Elements.getElement(ElementsT1Collection.ElementsT1.Path).g &&
                currentPointColor.r != _t1Elements.getElement(ElementsT1Collection.ElementsT1.Path).b &&
                currentPointColor.r != _t1Elements.getElement(ElementsT1Collection.ElementsT1.Path).a)
                )
            {
                if(y != endPoint.y)
                { drawY(new Point(x - unit, y), endPoint);
                    break;
                }
                break; // TODO
            }

            if(x == endPoint.x + unit)
            {
                if(y != endPoint.y)
                {
                    drawY(new Point(x - unit, y), endPoint);
                    break;
                }
                break;
                // TODO
            }

            if(y == endPoint.y && x == endPoint.x)
            {
                points.Add(new Point(x, y, _t1Elements.getElement(ElementsT1Collection.ElementsT1.Path)));
                break;
            }

            if(x < 2 || x > _width-2)
            { break; }


         points.Add(new Point(x, y, _t1Elements.getElement(ElementsT1Collection.ElementsT1.Path)));
            x+=unit;
        }

        //points.Add(new Point(endDoors.accessPoint.x, endDoors.accessPoint.y, new Color(200 / 255f, 0, 200 / 255f, 1))); // tymczasowo
        updateMapSchema(points); // tymczasowo
    }

    private void drawY(Point startPoint, Point endPoint)
    {
        int x = startPoint.x;
        int y = startPoint.y;
        int unit = 1;
        List<Point> points = new List<Point>();

        if (endPoint.y < startPoint.y)
            unit *= -1;
        while(true)
        {
            Color32 currentPointColor = _mapSchema.GetPixel(x, y);
            if ((currentPointColor.r != 205 &&
                currentPointColor.g != 205 &&
                currentPointColor.b != 205 &&
                currentPointColor.a != 205) &&
                (currentPointColor.r != _t1Elements.getElement(ElementsT1Collection.ElementsT1.Path).r &&
                currentPointColor.r != _t1Elements.getElement(ElementsT1Collection.ElementsT1.Path).g &&
                currentPointColor.r != _t1Elements.getElement(ElementsT1Collection.ElementsT1.Path).b &&
                currentPointColor.r != _t1Elements.getElement(ElementsT1Collection.ElementsT1.Path).a))
            {
                if (x != endPoint.x)
                {
                    drawX(new Point(x, y - unit), endPoint);
                    break;
                }
                break; // TODO
            }

            if(y == endPoint.y + unit)
            {
                if (x != endPoint.x)
                {
                    drawX(new Point(x, y - unit), endPoint);
                    break;
                }
                break;
                // TODO
            }

            if (y == endPoint.y && x == endPoint.x)
            {
                points.Add(new Point(x, y, _t1Elements.getElement(ElementsT1Collection.ElementsT1.Path)));
                break;
            }

            if (y < 2 || y > _height -2)
            { break; }

            points.Add(new Point(x, y, _t1Elements.getElement(ElementsT1Collection.ElementsT1.Path)));
            y += unit;
        }

        updateMapSchema(points); // tymczasowo
    }

    public List<Point> createRooms(int count)
    {
        List<Point> points = new List<Point>();
        Room room;
        for (int i = 1; i < count; i++)
        {
            do
            {
                room = new Room(new Point(Random.Range(1, _width), Random.Range(1, _height), _t1Elements.getElement(ElementsT1Collection.ElementsT1.SmallRoom)),
                    RoomsSize.Small,
                    RoomsType.Default);
                room.build();
            } while (room.isCollision(_rooms, _width, _height) || isOccupied(room.getPoints()));
            _rooms.Add(room);
            points.AddRange(room.getPoints());
        }
        return points;
    }

    private void fillRestPoints()
    {
        for(int i =0; i<_width;i++)
            for(int j =0; j<_height;j++)
            {
                Color32 currentPixel = _mapSchema.GetPixel(i, j);
                if (
                    currentPixel.r == 205 &&
                    currentPixel.g == 205 &&
                    currentPixel.b == 205 &&
                    currentPixel.a == 205
                    )
                    _mapSchema.SetPixel(i, j, _t1Elements.getElement(ElementsT1Collection.ElementsT1.Wall));

            }
    }

    private bool isOccupied(Point point)
    {
        Color32 currentPixel = _mapSchema.GetPixel(point.x, point.y);
        if (currentPixel.r != 205 &&
            currentPixel.g != 205 &&
            currentPixel.b != 205 &&
            currentPixel.a != 205
            )
            return true;
        return false;
    }

    private bool isOccupied(List<Point> points)
    {
        foreach(Point point in points)
        {
            Color32 currentPixel = _mapSchema.GetPixel(point.x, point.y);
            if (currentPixel.r != 205 &&
                currentPixel.g != 205 &&
                currentPixel.b != 205 &&
                currentPixel.a != 205
                )
                return true;
        }
        return false;
    }

    private void updateMapSchema(List<Point> points)
    {
        foreach (Point point in points)
            _mapSchema.SetPixel(point.x, point.y, point.color);
    }

}