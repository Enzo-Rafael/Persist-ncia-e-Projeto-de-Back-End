using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadBackendImage : MonoBehaviour
{
    public static LoadBackendImage instance;
    public Image img;
    int part;
    string url;
    void Start()
    {
        instance = this;
    }
    public void Scoroutine(int num){
        part = num;
        StartCoroutine("LoadImage");
    }
     
     IEnumerator LoadImage(){
        if(part == 1){
         url = "https://raw.githubusercontent.com/Enzo-Rafael/Persist-ncia-e-Projeto-de-Back-End/refs/heads/main/SP-StudioP1.png";
        }if(part == 2){
         url = "https://raw.githubusercontent.com/Enzo-Rafael/Persist-ncia-e-Projeto-de-Back-End/refs/heads/main/SP-StudioP2.png";
        }if(part == 3){
         url = "https://raw.githubusercontent.com/Enzo-Rafael/Persist-ncia-e-Projeto-de-Back-End/refs/heads/main/SP-StudioP3.png";
        }

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();
        if(request.result == UnityWebRequest.Result.Success){
            Texture2D tex = ((DownloadHandlerTexture) request.downloadHandler).texture;
            Rect rect = new Rect(0, 0, tex.width, tex.height);
            Vector2 center = new Vector2(tex.width / 2.0f, tex.height / 2.0f);
            Sprite sprite = Sprite.Create(tex, rect, center);
            img.sprite = sprite;
        }
    }
}
