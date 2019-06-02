using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public static PlatformSpawner instance;

    [SerializeField]
    private GameObject goPlatform, goPlatformReverse, goPlatformEnd;

    [SerializeField]
    private List<Level> levels = new List<Level>();

    private float fLastY;

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
        Level level = levels[GameManager.instance.iLevel-1];

        if (level != null)
        {
            Vector2 v2tmp = transform.position;
            GameObject newPlatform = null;
            
            int numberOfReversePlatforms = level.iNumberOfReversePlatforms;

            for (int i = 0; i < level.iNumberOfPlatforms; i++)
            {
                v2tmp.y = fLastY;

                if (Random.Range(0, 10) > 5)
                {
                    v2tmp.x = Random.Range(level.fLeftMinX, level.fLeftMaxX);
                } else
                {
                    v2tmp.x = Random.Range(level.fRightMinX, level.fRightMaxX);
                }
                
                if (numberOfReversePlatforms > 0 && Random.Range(0, 100) > 80)
                {
                    newPlatform = Instantiate(goPlatformReverse, v2tmp, Quaternion.identity);
                    numberOfReversePlatforms--;
                } else
                {
                    newPlatform = Instantiate(goPlatform, v2tmp, Quaternion.identity);
                }

                newPlatform.transform.localScale = new Vector3(level.fScale, newPlatform.transform.localScale.y);
                newPlatform.transform.parent = tPlatformParent;

                fLastY += level.fTresholdY;
            }

            v2tmp.y = fLastY;
            v2tmp.x = 0f;

            newPlatform = Instantiate(goPlatformEnd, v2tmp, Quaternion.identity);
            newPlatform.transform.parent = tPlatformParent;
        }
    }
}
