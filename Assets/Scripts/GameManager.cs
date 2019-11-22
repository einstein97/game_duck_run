using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UIをスクリプトで使えるようにする
using UnityEngine.UI;

// 画面遷移のメソッドが使えるようにする
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // スコアテキストを取得
    public Text scoreText;

    // ゲームオーバーキャンバスを格納する変数
    public GameObject gameoverCanvas;

    // スコア
    int score;

    // クリアナンバー
    public int clearNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // スコアがクリアナンバーに達した時
        if(score == clearNumber)
        {
            // ゲームクリアにする
            SceneManager.LoadScene("ClearScene");
        }
    }

    // スコアを加算するメソッド
    public void AddScore()
    {
        // スコアを加算する
        score++;

        // スコアテキストの表示を変更する
        scoreText.text = "SCORE:" + score;
    }

    // リトライボタンを押した時の処理
    public void PushRetryButton()
    {
        // タイトル画面に遷移する
        SceneManager.LoadScene("TitleScene");
    }

    // ゲームオーバーキャンバスを表示
    public void DisplayGameoverCanvas()
    {
        // ゲームオーバーキャンバスを表示
        gameoverCanvas.SetActive(true);
    }
}
