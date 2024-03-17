using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public struct WorldSettings
    {
        public float yKillPlane;
    }

    WorldSettings worldSettings;

    void Awake()
    {
        instance = this;
        worldSettings.yKillPlane = -10.0f;
    }

    public bool IsInWorldBounds(Vector3 position)
    {
        if (position.y < worldSettings.yKillPlane)
        {
            return false;
        }
        return true;
    }
}
