using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // 画面遷移するメソッド
    public void ChangeScene() 
    {
        //画面遷移
        SceneManager.LoadScene("GameScene");
    }
}
