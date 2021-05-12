using System.Collections;
using System.Collections.Generic;
using System; 
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField]
    private GameObject[] tilePrefabs;

    [SerializeField]
    private CameraMovement cameraMovement;


    public Dictionary<Point, TileScript> Tiles { get; set; }

  


    private Point StartSpawn, EndSpawn;

    [SerializeField]
    private GameObject StartPortalPrefab;

    [SerializeField]
    private GameObject EndPortalPrefab;

    public float Tilesize
    {
        get { return tilePrefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
}
    void Start()
    {
        CreateLevel();
    }

    void Update()
    {
       
    }


    private void CreateLevel()
    {
        Tiles = new Dictionary<Point, TileScript>();

        string[] mapData = ReadLevelText();

        int mapX = mapData[0].ToCharArray().Length;
        int mapY = mapData.Length;

        Vector3 maxTile = Vector3.zero;

    Vector3 worldstart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        // 카메라의 제일 왼쪽 끝 시작점의 좌표를 받아옴

        for (int y = 0; y < mapY; y++) // y축 positions
        {
            char[] newTiles = mapData[y].ToCharArray();

            for(int x = 0; x < mapX; x++)// x축 positions
            {
               PlaceTile(newTiles[x].ToString(), x, y, worldstart);
            }
        }

        maxTile = Tiles[new Point(mapX - 1, mapY - 1)].transform.position;

        cameraMovement.SetLimits(new Vector3(maxTile.x + Tilesize, maxTile.y - Tilesize));

        SpawnPortals();

    }

    private void PlaceTile(string tileType, int x, int y, Vector3 worldstart)
    {
        int tileIndex = int.Parse(tileType);

        TileScript newTile = Instantiate(tilePrefabs[tileIndex]).GetComponent<TileScript>();
        // 타일 오브젝트를 만듬
        newTile.Setup(new Point(x, y), new Vector3(worldstart.x + (Tilesize * x), worldstart.y - (Tilesize * y), 0));
        // 새로운 타일에 x,y를 곱해서 일정한 간격으로 떨어뜨려 놓음

    }

    private string[] ReadLevelText()
    {
        TextAsset binddata = Resources.Load("Level") as TextAsset;
        //레벨 텍스터 파일을 가져옴

        string data = binddata.text.Replace(Environment.NewLine, string.Empty);

        return data.Split('-');     
    }

    private void SpawnPortals()
    {
        StartSpawn = new Point(0, 0);

        Instantiate(StartPortalPrefab, Tiles[StartSpawn].GetComponent<TileScript>().WorldPosition, Quaternion.identity);

        EndSpawn = new Point(3, 11);

        Instantiate(EndPortalPrefab, Tiles[EndSpawn].GetComponent<TileScript>().WorldPosition, Quaternion.identity);
    }

}
