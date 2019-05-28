using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public static PlatformSpawner instance;

    [SerializeField]
    private GameObject goPlatform;

    private float fLeftMinX = -2f, fLeftMaxX = -1.2f, fRightMinX = 2f, fRightMaxX = 1.2f;
    private float fTresholdY = 2f;
    private float fLastY;

    [SerializeField]
    private int iSpawnCount = 8;

    private int iPlatformSpawned;

    [SerializeField]
    private Transform tPlatformParent;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        fLastY = transform.position.y;

        SpawnPlatforms();
    }

    public void SpawnPlatforms()
    {
        Vector2 v2tmp = transform.position;
        GameObject newPlatform = null;

        for (int i = 0; i < iSpawnCount; i++)
        {
            v2tmp.y = fLastY;

            if ((iPlatformSpawned % 2) == 0)
            {
                v2tmp.x = Random.Range(fLeftMinX, fLeftMaxX);
                newPlatform = Instantiate(goPlatform, v2tmp, Quaternion.identity);
            }
            else
            {
                v2tmp.x = Random.Range(fRightMinX, fRightMaxX);
                newPlatform = Instantiate(goPlatform, v2tmp, Quaternion.identity);
            }

            newPlatform.transform.parent = tPlatformParent;

            fLastY += fTresholdY;
            iPlatformSpawned++;
        }
    }
}
