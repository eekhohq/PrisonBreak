using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : TerrainConfig
{
    public Terrain t;

    protected override void UpdateTerrainData(float[,] data)
    {
        t.terrainData.heightmapResolution = size.x;
        t.terrainData.SetHeights(0, 0, data);
        t.drawHeightmap = true;
    }
}
