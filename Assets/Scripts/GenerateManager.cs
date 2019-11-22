using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateManager : MonoBehaviour
{
    // アイテムプレハブを格納する変数
    public GameObject itemPrefab;

    // トラッププレハブを格納する変数
    public GameObject trapPrefab;

    // プライヤーのトランスフォームコンポーネントを格納する変数
    public Transform playerTransform;

    // 生成する間隔
    public float generataInterval;

    // 生成する間隔
    public float generateSpeed;

    // アイテムを生成する確率
    public float itemprobability;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 生成するメソッドを作る
    void Generate()
    {

        if(GiveProbability(itemprobability))
        {
            // 生成する位置
            Vector3 generateItemPosition = new Vector3(0, itemPrefab.transform.position.y, playerTransform.position.z + generataInterval);
            
            // アイテムを作成
            Instantiate(itemPrefab, generateItemPosition, Quaternion.identity);

        }
        else
        {
            // 生成する位置
            Vector3 generateTrapPosition = new Vector3(0, trapPrefab.transform.position.y, playerTransform.position.z + generataInterval);

            // トラップを作成
            Instantiate(trapPrefab, generateTrapPosition, trapPrefab.transform.rotation);
        }

        
        // なんども呼ばれるようにする
        Invoke("Generate", generateSpeed);
    }

    // 確立を出すメソッド
    bool GiveProbability(float probability)
    {
        // 1から100までの乱数
        float random = Random.Range(1.0f, 100.0f);

        // 確立を出す
        if(random <= probability)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
