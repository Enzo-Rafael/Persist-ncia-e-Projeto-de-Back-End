using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadBackendText : MonoBehaviour
{
    public static LoadBackendText instace;
    public Text txtLabel;
    int part;
    string url;
    void Start()
    {
        instace = this;
        txtLabel.text = "Ola";
        
    }

    public void Scoroutine(int num){
        part = num;
        StartCoroutine("LoadText");
    }

    IEnumerator LoadText() {
        if(part == 1){
         url = "https://raw.githubusercontent.com/Enzo-Rafael/Persist-ncia-e-Projeto-de-Back-End/refs/heads/main/Texto.txt";
        }if(part == 2){
         url = "https://raw.githubusercontent.com/Enzo-Rafael/Persist-ncia-e-Projeto-de-Back-End/refs/heads/main/TextoP2.txt";
        }if(part == 3){
         url = "https://raw.githubusercontent.com/Enzo-Rafael/Persist-ncia-e-Projeto-de-Back-End/refs/heads/main/TextoP3.txt";
        }
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
        if(request.result == UnityWebRequest.Result.Success){
             txtLabel.text = request.downloadHandler.text;
        }
    }
}
