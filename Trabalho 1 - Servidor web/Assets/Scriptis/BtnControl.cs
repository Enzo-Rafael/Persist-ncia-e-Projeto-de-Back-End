using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnControl : MonoBehaviour
{
    public int num;

    public void OnClckEnter(){
        LoadBackendText.instace.Scoroutine(num);
        LoadBackendImage.instance.Scoroutine(num);
    }
}
