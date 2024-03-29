using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class ProceduralUtils
{
    [Serializable]
    public struct TreeLayerData
    {
        public string name;
        public int index;
        public float minHeight;
        public float maxHeight;
        public float density;

        public TreeLayerData(string name, int index, float minHeight, float maxHeight, float density)
        {
            this.name = name;
            this.index = index;
            this.minHeight = minHeight;
            this.maxHeight = maxHeight;
            this.density = density;
        }

        public bool Generate(float height)
        {
            return height < maxHeight && height > minHeight && UnityEngine.Random.value < density;
        }
    }

        public static Texture2D GenerateTexture2D(float[,] data)
    {
        int width = data.GetLength(0);
        int height = data.GetLength(1);

        Texture2D texture = new Texture2D(width, height);
        Color[] colors = new Color[width * height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int i = x + width * y;
                float value = data[x, y];
                colors[i] = new Color(value, value, value);
            }
        }

        texture.SetPixels(colors);
        texture.Apply();

        return texture;
    }

    public static float Map(float value, float valueMin, float valueMax, float resultMin, float resultMax)
    {
        if (resultMin == resultMax) return resultMin;
        if (valueMin == valueMax) return resultMax;
        return resultMin + (value - valueMin) * (resultMax - resultMin) / (valueMax - valueMin);
    }

    public static float[,] IslandFilter(float [,] data, float innerRadius, float outerRadius)
    {
        Vector2Int center = new Vector2Int(data.GetLength(0) / 2, data.GetLength(1) / 2);
        for (int y = 0; y < data.GetLength(1); y++)
        {
            for (int x = 0; x < data.GetLength(0); x++)
            {
                Vector2Int point = new Vector2Int(x, y);
                float distance = Vector2.Distance(center, point);
                float multiplier;

                if (distance < innerRadius)
                {
                    multiplier = 1;
                }
                else if (distance > outerRadius)
                {
                    multiplier = 0;
                }
                else
                {
                    multiplier = Map(distance, innerRadius, outerRadius, 1f, 0f);
                }

                data[x, y] *= multiplier;
            }
        }
        
        return data;
    }

    public static float[,] GenerateTerrainData(int width, int height, float scale, float baseAmplitude, int octaves, float lacunarity, float persistence, Vector3 offset)
    {
        float[,] result = new float[width, height];

        float maxValue = float.MinValue;
        float minValue = float.MaxValue;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                result[x, y] = 0f;
                float frequency = scale;
                float amplitude = baseAmplitude;
                for (int o = 0; o < octaves; o++)
                {
                    frequency *= lacunarity;
                    amplitude *= persistence;
                    result[x, y] += (GetPerlinValue(x + offset.x, y + offset.y, frequency, amplitude) + offset.z / 100.0f);
                    if (result[x, y] > maxValue)
                    {
                        maxValue = result[x, y];
                    }
                    if (result[x, y] < minValue)
                    {
                        minValue = result[x, y];
                    }
                }
            }
        }

        return result;
    }

    [Serializable]
    public struct LayerData
    {
        public string name;
        public float heightTrigger;
        public float fadeAmount;

        public LayerData(string name, float heightTrigger, float fadeAmount)
        {
            this.name = name;
            this.heightTrigger = heightTrigger;
            this.fadeAmount = fadeAmount;
        }
    }

    public static float[,,] GenerateTextureData(float[,] terrainData, LayerData[] layers)
    {
        int width = terrainData.GetLength(0);
        int height = terrainData.GetLength(1);
        float[,,] map = new float[width, height, layers.Length];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float value = terrainData[x, y];
                for (int l = 0; l < layers.Length; l++)
                {
                    float mapValue;
                    float d = value - layers[l].heightTrigger;
                    if (l == 0)
                    {
                        mapValue = Mathf.Clamp(Map(value, layers[l].heightTrigger, layers[l].heightTrigger + layers[l].fadeAmount, 1f, 0f), 0, 1);

                    }
                    else
                    {
                        if (value > layers[l].heightTrigger)
                        {
                            //Fade up
                            mapValue = Mathf.Clamp(Map(value, layers[l].heightTrigger, layers[l].heightTrigger + layers[l].fadeAmount, 1f, 0f), 0, 1);
                        }
                        else if (value < layers[l - 1].heightTrigger + layers[l - 1].fadeAmount)
                        {
                            //Fade down
                            mapValue = Mathf.Clamp(Map(value, layers[l - 1].heightTrigger, layers[l - 1].heightTrigger + layers[l - 1].fadeAmount, 0f, 1f), 0, 1);
                        }
                        else
                        {
                            //Middle
                            mapValue = 1;
                        }
                    }

                    map[x, y, l] = mapValue;

                }
            }
        }

        return map;
    }

    public static float GetPerlinValue(float x, float y, float frequency, float amplitude)
    {
        float result = (Mathf.PerlinNoise(x * frequency, y * frequency) * 2f - 1) * amplitude;

        return result;
    }
}