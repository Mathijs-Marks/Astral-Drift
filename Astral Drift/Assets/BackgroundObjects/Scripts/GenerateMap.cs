using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

public class GenerateMap : MonoBehaviour
{
    public enum DrawMode { NoiseMap, Mesh };
    public DrawMode drawMode;

    public TerrainData terrainData;
    public NoiseData noiseData;
    public TextureData textureData;

    public Material terrainMaterial;

    public const int mapChunkSize = 239; //replaces mapWidth & mapHeight
    [Range(0,6)]
    public int editorPreviewLOD; //Changed from: levelOfDetail;
                                 //public int mapWidth = 10;
                                 //public int mapHeight = 10;

    public bool autoUpdate;


    Queue<MapThreadInfo<MapData>> mapDataThreadInfoQueue = new Queue<MapThreadInfo<MapData>>();
    Queue<MapThreadInfo<MeshData>> meshDataThreadInfoQueue = new Queue<MapThreadInfo<MeshData>>();

    private void Awake()
    {
        textureData.ApplyToMaterial(terrainMaterial);
        textureData.UpdateMeshHeights(terrainMaterial, terrainData.minHeight, terrainData.maxHeight);
    }
    void OnvaluesUpated()
    {
        if (!Application.isPlaying)
        {
            DrawMapInEditor();
        }
    }
    void onTextureValuesUpdated()
    {
        textureData.ApplyToMaterial(terrainMaterial);
    }
    public void DrawMapInEditor()
    {
        textureData.UpdateMeshHeights(terrainMaterial, terrainData.minHeight, terrainData.maxHeight);

        MapData mapData = MapDataGenerator(Vector2.zero);

        DisplayMap display = FindObjectOfType<DisplayMap>();
        if (drawMode == DrawMode.NoiseMap)
        {
            display.DrawTexture(TextureGenerator.HeightMapTexture(mapData.heightMap));
        }
        else if (drawMode == DrawMode.Mesh)
        {
            display.DrawMesh(GenerateMesh.GenerateTerrainMesh(mapData.heightMap, terrainData.meshHeightMultiplier, terrainData.meshHeightCurve, editorPreviewLOD));//mapChunkSize, mapChunkSize = mapWidth, mapHeight
        }
    }
    public void RequestMapData(Vector2 center, Action<MapData> callback)
    {
        ThreadStart threadStart = delegate
        {
            MapDataThread(center, callback);
        };

        new Thread(threadStart).Start();
    }
    void MapDataThread(Vector2 center, Action<MapData> callback)
    {
        MapData mapData = MapDataGenerator(center);
        lock (mapDataThreadInfoQueue)
        {
        mapDataThreadInfoQueue.Enqueue(new MapThreadInfo<MapData>(callback, mapData));
        }
    }
    public void RequestMeshData(MapData mapData, int lod, Action<MeshData> callback)
    {
        ThreadStart threadStart = delegate {
            MeshDataThread(mapData, lod, callback);
        };
        new Thread(threadStart).Start();
    }
    void MeshDataThread(MapData mapData, int lod,Action<MeshData> callback)
    {
        MeshData meshData = GenerateMesh.GenerateTerrainMesh(mapData.heightMap, terrainData.meshHeightMultiplier, terrainData.meshHeightCurve, lod /*Changed from levelOfDetail*/);
        lock (meshDataThreadInfoQueue)
        {
            meshDataThreadInfoQueue.Enqueue(new MapThreadInfo<MeshData>(callback, meshData));
        }
    }
    private void FixedUpdate()
    {
        if (mapDataThreadInfoQueue.Count > 0)
        {
            for(int i=0; i < mapDataThreadInfoQueue.Count; i++)
            {
                MapThreadInfo<MapData> threadInfo = mapDataThreadInfoQueue.Dequeue();
                threadInfo.callback(threadInfo.parameter);
            }
        }

        if (meshDataThreadInfoQueue.Count > 0)
        {
            for(int i = 0; i< meshDataThreadInfoQueue.Count; i++)
            {
                MapThreadInfo<MeshData> threadInfo = meshDataThreadInfoQueue.Dequeue();
                threadInfo.callback(threadInfo.parameter);
            }
        }
    }
    MapData MapDataGenerator(Vector2 center)
    {
       
        float[,] noiseMap = Noise.GenerateNoiseMap(mapChunkSize +2, mapChunkSize +2, noiseData.seed, noiseData.noiseScale, noiseData.octaves, noiseData.persistance, noiseData.lacunarity, center + noiseData.offset, noiseData.normalizeMode); //mapChunkSize, mapChunkSize = mapWidth, mapHeight

        for (int y = 0; y<mapChunkSize; y++) //mapChunkSize = mapheight
        {
            for(int x = 0; x<mapChunkSize; x++) //mapChunkSize = mapwidth
            {
                float currentHeight = noiseMap[x, y];
            }
        }
        return new MapData(noiseMap);
    }

    private void OnValidate()
    {
        if(terrainData != null)
        {
            terrainData.OnValuesUpdated -= OnvaluesUpated;
            terrainData.OnValuesUpdated += OnvaluesUpated;
        }
        if(noiseData != null)
        {
            noiseData.OnValuesUpdated -= OnvaluesUpated;
            noiseData.OnValuesUpdated += OnvaluesUpated;
        }
        if(textureData!= null)
        {
            textureData.OnValuesUpdated -= onTextureValuesUpdated;
            textureData.OnValuesUpdated += onTextureValuesUpdated;
        }
    }
    struct MapThreadInfo<T>
    {
        public readonly Action<T> callback;
        public readonly T parameter;

        public MapThreadInfo(Action<T> callback, T parameter)
        {
            this.callback = callback;
            this.parameter = parameter;
        }
    }
}
public struct MapData
{
    public readonly float[,] heightMap;

    public MapData(float[,] heightMap)
    {
        this.heightMap = heightMap;
   }
}