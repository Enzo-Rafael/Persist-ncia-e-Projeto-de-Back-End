using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
public class SaveController : MonoBehaviour
{
    public GameObject[] prefabs;
    public PlayerMove player;
    public ScoreHUD hud;
    string path;
    string level;

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
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            level = "saveL1";
            StartCoroutine("LoadOnline");
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            level = "saveL2";
            StartCoroutine("LoadOnline");
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

    IEnumerator LoadOnline(){
        string url = "https://raw.githubusercontent.com/Enzo-Rafael/Persist-ncia-e-Projeto-de-Back-End/refs/heads/main/Trabalho%2002%20-%20Load%20Level%20e%20JSON/" + level + ".json";
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
        if(request.result == UnityWebRequest.Result.Success){
            string json = request.downloadHandler.text;
            Clear();
            //Destroy(FindAnyObjectByType<PlayerMove>().gameObject);
            ScoreHUD.instace.ScoreUpdate(0);
            SceneData data = JsonUtility.FromJson<SceneData>(json);
            //Instantiate(player, data.player.position, Quaternion.identity);
            AdapterData.GetPlayer(data.player, ref player);
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
    }
}
