using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Level : ScriptableObject
{
    [Range(-3f, -1.5f)]
    public float fLeftMinX;

    [Range(-3f, -1.5f)]
    public float fLeftMaxX;

    [Range(1.5f, 3f)]
    public float fRightMinX;

    [Range(1.5f, 3f)]
    public float fRightMaxX;

    [Range(0.2f, 1f)]
    public float fScale = 1f;

    public float fTresholdY = 2f;

    [Range(10, 400)]
    public int iNumberOfPlatforms;

    [Range(0, 400)]
    public int iNumberOfReversePlatforms;
}
