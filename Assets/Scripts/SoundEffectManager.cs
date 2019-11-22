using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    // ジャンプする音
    public AudioClip soundJump;

    // 気絶する音
    public AudioClip soundStun;

    // アイテムを獲得する音
    public AudioClip soundItem;

    // オーディオソースコンポーネント
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ジャンプする音を鳴らすメソッド
    public void MakeJumpSound()
    {
        audioSource.PlayOneShot(soundJump);
    }

    // 気絶する音を鳴らすメソッド
    public void MakeStunSound()
    {
        audioSource.PlayOneShot(soundStun);
    }

    // アイテムを獲得する音を鳴らすメソッド
    public void MakeItemSound()
    {
        audioSource.PlayOneShot(soundItem);
    }

}
