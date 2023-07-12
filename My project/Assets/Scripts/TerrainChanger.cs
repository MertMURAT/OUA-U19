using UnityEngine;

public class TerrainChanger : MonoBehaviour
{
    public static TerrainChanger instance;

    private TreePrototype[] cacheTree;
    private DetailPrototype[] cacheDetail;

    public TreePrototype[] treeType;
    public DetailPrototype[] detailType;

    public GameObject swapTrees;
    public GameObject swapDetails;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        cacheTree = Terrain.activeTerrain.terrainData.treePrototypes;
        cacheDetail = Terrain.activeTerrain.terrainData.detailPrototypes;

        treeType = Terrain.activeTerrain.terrainData.treePrototypes;
        detailType = Terrain.activeTerrain.terrainData.detailPrototypes;
    }

    public void ChangeTree()
    {
        treeType[0].prefab = swapTrees;
        Terrain.activeTerrain.terrainData.treePrototypes = treeType;
    }

    public void ChangeDetail()
    {
        detailType[0].prototype = swapDetails;
        Terrain.activeTerrain.terrainData.detailPrototypes = detailType;
    }


    void OnApplicationQuit()
    {
        Terrain.activeTerrain.terrainData.treePrototypes = cacheTree;
        Terrain.activeTerrain.terrainData.detailPrototypes = cacheDetail;
    }
}