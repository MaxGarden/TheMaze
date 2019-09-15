using System.Collections;
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

        updateMapSchema(createRooms(25)); //16

        createPath(35); // 20


        // Path from startPoint/endPoint to room

        Room roomStartAccess = _rooms[_rooms.Count / 2];
        Room roomEndAccess = _rooms[_rooms.Count / 4];
        int doorNumber;
        do
        {
            doorNumber = Random.Range(0, 3);
        } while (!roomStartAccess.GetDoors()[doorNumber].isAvailable);
        createPathFromTo( startPoint, roomStartAccess.GetDoors()[doorNumber].accessPoint);
        do
        {
            doorNumber = Random.Range(0, 3);
        } while (!roomStartAccess.GetDoors()[doorNumber].isAvailable);
        createPathFromTo( endPoint, roomEndAccess.GetDoors()[doorNumber].accessPoint);

        fillRestPoints();

        return _mapSchema;
    }

    public List<Point> createStartEndPoints()
    {

        Point startPoint = new Point(Mathf.RoundToInt(Random.Range(5, _width/2)*0.5f), Mathf.RoundToInt(Random.Range(4, _height)*0.4f), _t1Elements.getElement(ElementsT1Collection.ElementsT1.StartPoint));
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
        DoorElement startDoor = new DoorElement();
        DoorElement endDoor = new DoorElement();
        int doorNumber, startRoomNumber, endRoomNumber;
        for (int i = 0; i < pathsCount; i++)
        {
            startRoomNumber = Random.Range(0, _rooms.Count);
            Room startRoom = _rooms[startRoomNumber];
            do
            {
                doorNumber = Random.Range(0, 3);
                startDoor = startRoom.GetDoors()[doorNumber];
            } while (!startRoom.GetDoors()[doorNumber].isAvailable); 

                do
            {
                endRoomNumber = Random.Range(0, _rooms.Count);
            } while (endRoomNumber == startRoomNumber);

            Room endRoom = _rooms[endRoomNumber];
            do
            {
                doorNumber = Random.Range(0, 3);
                endDoor = endRoom.GetDoors()[doorNumber];
            } while (!endRoom.GetDoors()[doorNumber].isAvailable); 
                createPathFromTo(startDoor.accessPoint, endDoor.accessPoint);

            //drawX(startDoor.accessPoint, endDoor.accessPoint);
        }

        return points;
    }

    public void createPathFromTo(Point startPoint, Point endPoint)
    {
        drawX(startPoint, endPoint);
        Point currentPoint = startPoint;
        bool xDirect;
        if (Random.Range(0.0f, 1.0f) > 0.5f)
        {
            currentPoint = drawX(currentPoint, endPoint);
            xDirect = false;
        }
        else
        {
            currentPoint = drawY(currentPoint, endPoint);
            xDirect = true;
        }

        bool done = false;

        while (!done)
        {
            if (xDirect)
            {
                currentPoint = drawX(currentPoint, endPoint);
                if (currentPoint.x == -1 && currentPoint.y == -1)
                    done = true;
                xDirect = false;
            }
            else
            {
                currentPoint = drawY(currentPoint, endPoint);
                if (currentPoint.x == -1 && currentPoint.y == -1)
                    done = true;
                xDirect = true;
            }
        }
    }

    private Point drawX(Point startPoint, Point endPoint)
    {
        int x = startPoint.x;
        int y = startPoint.y;
        int unit = 1;
        List<Point> points = new List<Point>();
        Point END_POINT = new Point(-1, -1);
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
                {
                    //drawY(new Point(x - unit, y), endPoint);
                    updateMapSchema(points);
                    return new Point(x - unit, y);
                }
                break; // TODO
            }

            if(x == endPoint.x + unit)
            {
                if(y != endPoint.y)
                {
                    //drawY(new Point(x - unit, y), endPoint);
                    updateMapSchema(points);
                    return new Point(x - unit, y);
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
        return END_POINT;
    }

    private Point drawY(Point startPoint, Point endPoint)
    {
        int x = startPoint.x;
        int y = startPoint.y;
        int unit = 1;
        List<Point> points = new List<Point>();
        Point END_POINT = new Point(-1, -1);

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
                    //drawX(new Point(x, y - unit), endPoint);
                    updateMapSchema(points);
                    return new Point(x, y - unit);
                }
                break; // TODO
            }

            if(y == endPoint.y + unit)
            {
                if (x != endPoint.x)
                {
                    //drawX(new Point(x, y - unit), endPoint);
                    updateMapSchema(points);
                    return new Point(x, y - unit);
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
        return END_POINT;
    }

    public List<Point> createRooms(int count)
    {
        List<Point> points = new List<Point>();
        Room room;
        for (int i = 1; i < count; i++)
        {
            RoomsType type = (RoomsType)Random.Range(0, 5);
            do
            {
                room = new Room(new Point(Random.Range(1, _width), Random.Range(1, _height), _t1Elements.getElement(ElementsT1Collection.ElementsT1.SmallRoom)),
                    RoomsSize.Small,
                    type);
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