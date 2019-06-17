using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Room
{

    private const int SMALL_SIZE = 2;
    private const int MEDIUM_SIZE = 3;
    private const int LARGE_SIZE = 4;

    Point _centerPoint;
    RoomsSize _size;
    RoomsType _type;
    List<Point> _points;
    List<Door> _doors;

    public Room(Point centerPoint, RoomsSize size, RoomsType type)
    {
        this._centerPoint = centerPoint;
        this._size = size;
        this._type = type;
        _points = new List<Point>();
        _doors = new List<Door>();
    }

    public Point getCenterPoint()
    {
        return _centerPoint;
    }

    public RoomsSize getSize()
    {
        return _size;
    }

    public List<Point> getPoints()
    {
        return _points;
    }

    public List<Door> GetDoors()
    {
        return _doors;
    }

    public List<Point> build()
    {
        ElementsT1Collection elementsT1 = new ElementsT1Collection();

        switch(_size)
        {
            case RoomsSize.Small:
                switch(_type)
                {
                    case RoomsType.Default:
                        bool isOccupied;
                        for (int i = _centerPoint.x - 1; i < _centerPoint.x + SMALL_SIZE; i++)
                            for (int j = _centerPoint.y - 1; j < _centerPoint.y + SMALL_SIZE; j++)
                                _points.Add(new Point(i, j, elementsT1.getElement(ElementsT1Collection.ElementsT1.SmallRoom)));
                        _points.Add(new Point(_centerPoint.x, _centerPoint.y + 2, elementsT1.getElement(ElementsT1Collection.ElementsT1.RoomDoors_N)));
                        _doors.Add(new Door(DirectionsEnum.North, true, new Point(_centerPoint.x, _centerPoint.y + 3)));

                        _points.Add(new Point(_centerPoint.x + 2, _centerPoint.y, elementsT1.getElement(ElementsT1Collection.ElementsT1.RoomDoors_E)));
                        _doors.Add(new Door(DirectionsEnum.East, true, new Point(_centerPoint.x + 3, _centerPoint.y)));

                        _points.Add(new Point(_centerPoint.x, _centerPoint.y - 2, elementsT1.getElement(ElementsT1Collection.ElementsT1.RoomDoors_S)));
                        _doors.Add(new Door(DirectionsEnum.South, true, new Point(_centerPoint.x, _centerPoint.y - 3)));

                        _points.Add(new Point(_centerPoint.x - 2, _centerPoint.y, elementsT1.getElement(ElementsT1Collection.ElementsT1.RoomDoors_W)));
                        _doors.Add(new Door(DirectionsEnum.West, true, new Point(_centerPoint.x - 3, _centerPoint.y)));
                        for (int i = _centerPoint.x - SMALL_SIZE; i <= _centerPoint.x + SMALL_SIZE; i++)
                            for (int j = _centerPoint.y - SMALL_SIZE; j <= _centerPoint.y + SMALL_SIZE; j++)
                            {
                                isOccupied = false;
                                foreach (Point point in _points)
                                {

                                    if (point.x == i && point.y == j)
                                    {
                                        isOccupied = true;
                                        break;
                                    }
                                }
                                if (!isOccupied)
                                    _points.Add(new Point(i, j, elementsT1.getElement(ElementsT1Collection.ElementsT1.Wall)));
                            }
                        
                        break;
                }
                break;
            case RoomsSize.Medium:
                break;
            case RoomsSize.Large:
                break;
        }

        return _points;
    }

    public bool isCollision(Room other)
    {
        switch (other.getSize())
        {
            case RoomsSize.Small:
                if (_size == RoomsSize.Small)
                {
                    if (Mathf.Abs(this._centerPoint.x - other._centerPoint.x) > SMALL_SIZE * 2 || Mathf.Abs(this._centerPoint.y - other._centerPoint.y) > SMALL_SIZE * 2)
                        return true;
                    else
                        return false;
                }
                break;
        }

        return false;
    }

    public bool isCollision(List<Room> rooms, int width, int height)
    {
        bool collision = false;
        if (rooms == null)
        {
            if (this._centerPoint.x < SMALL_SIZE * 3 || this._centerPoint.y < SMALL_SIZE * 3 || this._centerPoint.x > width - SMALL_SIZE * 3 || this._centerPoint.y > height - SMALL_SIZE * 3)
                collision = true;
        }
        else
        {
            foreach (Room room in rooms)
            {
                switch (room.getSize())
                {
                    case RoomsSize.Small:
                        if (!(Mathf.Abs(this._centerPoint.x - room._centerPoint.x) > (SMALL_SIZE * 3 + 1) || Mathf.Abs(this._centerPoint.y - room._centerPoint.y) > (SMALL_SIZE * 3 + 1)))
                            collision = true;
                        if (this._centerPoint.x < SMALL_SIZE * 3 || this._centerPoint.y < SMALL_SIZE * 3 || this._centerPoint.x > width - SMALL_SIZE * 3 || this._centerPoint.y > height - SMALL_SIZE * 3)
                            collision = true;
                        break;
                }
            }
        }
        if (rooms.Count == 0)
        {
            if (this._centerPoint.x < SMALL_SIZE * 3 || this._centerPoint.y < SMALL_SIZE * 3 || this._centerPoint.x > width - SMALL_SIZE * 3 || this._centerPoint.y > height - SMALL_SIZE * 3)
                collision = true;
        }
        return collision;
    }
}
