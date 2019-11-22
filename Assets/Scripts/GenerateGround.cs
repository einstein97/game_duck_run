using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGround : MonoBehaviour
{
    // 地面のプレハブ
    public GameObject groundPrefab;

    // プレイヤーのトランスフォームコンポーネント
    public Transform playerTransform;

    // 地面のトランスフォームコンポーネント
    public Transform groundTransform;

    // 地面を管理するリスト
    public List<GameObject> groundList = new List<GameObject>();

    // 更新する時間
    public float UpdateSpeed;

    
    // Start is called before the first frame update
    void Start()
    {
        UpdateGround();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateGround()
    {
        // 次の地面を作って変数に格納
        GameObject nextGround = GenerateNextGround();

        // 作った地面をリストに格納
        groundList.Add(nextGround);

        // 数秒後に地面を作る
        Invoke("UpdateGround", UpdateSpeed);

        // 数秒後に地面を消す
        Invoke("DestroyOldestGround", UpdateSpeed);
    }

    GameObject GenerateNextGround()
    {
        // プレイヤーの位置を変数に格納
        float playerPosition = playerTransform.position.z;

        // 地面のながさ
        float groundScale = groundTransform.localScale.z;

        // 次の地面を作成する場所
        Vector3 nextGroundPosition = new Vector3(0, 0, playerPosition + groundScale);
        
        GameObject nextGround = Instantiate(groundPrefab, nextGroundPosition, Quaternion.identity);

        return nextGround;
    }

    // 一番古い地面を消すメソッド
    void DestroyOldestGround()
    {
        // リストに格納されている一番古い地面を変数に格納
        GameObject oldestGround = groundList[0];

        // リストから一番古い地面を取り除く
        groundList.RemoveAt(0);

        // 一番古い地面を消す
        Destroy(oldestGround);
    }
}
