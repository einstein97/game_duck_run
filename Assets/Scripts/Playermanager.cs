using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermanager : MonoBehaviour
{
    // キャラクターコントローラーを格納する変数
    CharacterController characterController;

    // ゲームマネージャー
    public GameManager gameManager;

    // サウンドエフェクトマネージャー
    public SoundEffectManager soundEffectManager;

    Vector3 moveDirection = new Vector3(0, 0, 0);

    //　アニメーターコンポーネントを格納する変数
    Animator animator;

    // 重力
    public float gravity = 0.002f;

    // ジャンプ力
    public float JumpPower = 0.12f;

    //　スピード
    public float speed = 0.03f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // タップした時の記述
        if(Input.GetMouseButtonDown(0) == true)
        {
            Jump();
        }

    　　 Walk();

        characterController.Move(moveDirection);

        moveDirection.y -= gravity;
    }

    // プレイヤーが気絶しているか判断するメソッド
    bool IsStun()
    {
        return speed <= 0;
    }


    void Jump()
    {
        // 気絶していたらジャンプしない
        if(IsStun())
        {
            return; // return 以降が呼び出されなくなる
        }

        moveDirection.y = JumpPower;

        // ジャンプする音
        soundEffectManager.MakeJumpSound();
    }

    void Walk()
    {
        moveDirection.z = speed;

        // 歩くアニメーションを追加
        animator.SetBool("walk", moveDirection.z > 0);
    }

    // 気絶するメソッド
    void Stun()
    {
        // 気絶するアニメーションを呼び出す
        animator.SetTrigger("stun");

        // 立ち止まらせる
        speed = 0;

        soundEffectManager.MakeStunSound();
    }

    private void OnTriggerEnter(Collider other)
    {
        // アイテムとすれ違ったら
        if(other.gameObject.tag == "Item")
        {
            // スコアを加算する
            gameManager.AddScore();    

            // アイテムを消す
            Destroy(other.gameObject); 

            // アイテムを獲得する音
            soundEffectManager.MakeItemSound();
        }
    }

    // プレイヤーがぶつかった時の処理
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // トラップとぶつかったら
        if(hit.gameObject.tag == "Trap")
        {
            gameManager.DisplayGameoverCanvas();

            // 気絶させる
            Stun();
        }
    }
}
