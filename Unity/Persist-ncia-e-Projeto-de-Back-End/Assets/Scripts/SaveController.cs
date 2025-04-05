using UnityEngine;
using System.IO;
using System.Collections.Generic;
public class SaveController : MonoBehaviour
{
    public GameObject[] prefabs;
    public PlayerMove player;
    public ScoreHUD hud;
    string path;


    void Start()
    {
        path = Application.persistentDataPath + "/save.json";
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)){
            Save();
        }
        if(Input.GetKeyDown(KeyCode.L)){
            Load();
        }
        if(Input.GetKeyDown(KeyCode.J)){
            Clear();
        }
    }
    void Save(){
        CubePoints[] cubes = FindObjectsByType<CubePoints>(FindObjectsSortMode.None);
        PlayerData playerData = AdapterData.GetPlayerData(player);
        ScoreData scoreHUD = AdapterData.GetScoreData(hud);
        List<CubesData> cubesDataList = new List<CubesData>();
        foreach(CubePoints cube in cubes){
            cubesDataList.Add(AdapterData.GetCubesData(cube));
        }
        SceneData sceneData = new SceneData();
        sceneData.player = playerData;
        sceneData.score = scoreHUD;
        sceneData.cubes = cubesDataList.ToArray();
        string json = JsonUtility.ToJson(sceneData);
        Debug.Log(json);
        File.WriteAllText(path, json);
    }
    void Load(){
        Clear();
        Destroy(FindAnyObjectByType<PlayerMove>().gameObject);
        string json = File.ReadAllText(path);
        ScoreHUD.instace.ScoreUpdate(0);
        SceneData data = JsonUtility.FromJson<SceneData>(json);
        Instantiate(player, data.player.position, Quaternion.identity);
        AdapterData.GetScore(data.score, ref hud);
        ScoreHUD.instace.ScoreUpdate(ScoreHUD.instace.points);
        foreach(CubesData cubesData in data.cubes){
            if(cubesData.name == (prefabs[0].name + "(Clone)"))
            {
                Instantiate(prefabs[0], cubesData.position, Quaternion.identity);
            }
            if(cubesData.name == (prefabs[1].name + "(Clone)"))
            {
                Instantiate(prefabs[1], cubesData.position, Quaternion.identity);
            }
            if(cubesData.name == (prefabs[2].name + "(Clone)"))
            {
                Instantiate(prefabs[2], cubesData.position, Quaternion.identity);
            }
            if(cubesData.name == (prefabs[3].name + "(Clone)"))
            {
                Instantiate(prefabs[3], cubesData.position, Quaternion.identity);
            }
        }
    }
    void Clear(){
        CubePoints[] cubes = FindObjectsByType<CubePoints>(FindObjectsSortMode.None);
        foreach(CubePoints cube in cubes){
            Destroy(cube.gameObject);
        }
    }
}
