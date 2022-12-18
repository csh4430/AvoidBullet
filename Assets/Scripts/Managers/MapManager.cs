using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Manager
{
    int mapSize = 20;
    public bool CheckMap(float x, float z)
    {
        if (x < -mapSize || x > mapSize || z < -mapSize || z > mapSize)
        {
            return false;
        }
        return true;
    }

    public bool CheckMap(Vector3 pos) => CheckMap(pos.x, pos.z);
}
