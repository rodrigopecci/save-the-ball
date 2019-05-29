using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public static PlatformSpawner instance;

    [SerializeField]
    private GameObject goPlatform, goPlatformReverse;

    private float fLeftMinX = -2.5f, fLeftMaxX = -1.5f, fRightMinX = 2.5f, fRightMaxX = 1.5f;
    private float fScaleMin = 0.5f, fScaleMax = 1f;
    private float fTresholdY = 2f;
    private float fLastY;

    [SerializeField]
    private int iSpawnCount = 8;

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

        float fPlatformMultiplier = ((GameManager.instance.iScore * GameManager.instance.fDifficultyMultiplier) > 80f ? 80f : (GameManager.instance.iScore * GameManager.instance.fDifficultyMultiplier));
        float fScaleMinMultiplier = (fScaleMin - (fPlatformMultiplier * 0.01f) < 0.1f ? 0.1f : fScaleMin - (fPlatformMultiplier * 0.01f));
        float fScaleMaxMultiplier = (fScaleMax - (fPlatformMultiplier * 0.01f) < 0.2f ? 0.2f : fScaleMax - (fPlatformMultiplier * 0.01f));

        //Debug.Log("iScore: " + GameManager.instance.iScore + " - fDifficultyMultiplier : " + GameManager.instance.fDifficultyMultiplier + " - multi : " + GameManager.instance.iScore * GameManager.instance.fDifficultyMultiplier);
        //Debug.Log("fScaleMinMultiplier : " + fScaleMinMultiplier + " - fScaleMaxMultiplier : " + fScaleMaxMultiplier);

        for (int i = 0; i < iSpawnCount; i++)
        {
            v2tmp.y = fLastY;

            if (Random.Range(0, 10) > 5)
            {
                v2tmp.x = Random.Range(fLeftMinX, fLeftMaxX);
                newPlatform = Instantiate((Random.Range(0f, 100f) > fPlatformMultiplier ? goPlatform : goPlatformReverse), v2tmp, Quaternion.identity);
            } else
            {
                v2tmp.x = Random.Range(fRightMinX, fRightMaxX);
                newPlatform = Instantiate((Random.Range(0f, 100f) > fPlatformMultiplier ? goPlatform : goPlatformReverse), v2tmp, Quaternion.identity);
            }

            newPlatform.transform.localScale = new Vector3(Random.Range(fScaleMinMultiplier, fScaleMaxMultiplier), newPlatform.transform.localScale.y);
            newPlatform.transform.parent = tPlatformParent;

            fLastY += fTresholdY;
        }
    }
}
