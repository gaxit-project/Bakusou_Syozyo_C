//resultシーンのCanvas→Panel内のScoreにアタッチ、Rank TextにはScoreを入れる
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public static int[] rank = new int[3] {0, 0, 0}; //1位から3位までのランキング、初期値が0なのでマイナスのときはランキングを更新しない
    [SerializeField] Text rankText;
    private bool flag = true; //flagがtrueならランキングの更新ができる、falseなら更新を停止する
    private int tmp = 0;
    public static int rankScore; //ゴールした時のスコア

    // Start is called before the first frame update
    void Start()
    {
        flag = true;
        rankScore = (int)GameManager.countdownSeconds * 1000 + MinusTime.minusScore; //残りの制限時間*1000+障害物に当たった時のマイナス
        MinusTime.minusScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < rank.Length; i++)
        {
            if (rank[i] < rankScore && flag && Goal.goal) //flagが0でランキング内のスコアより大きい場合更新
            {
                if(rank[0] < rankScore) //1位のスコアより大きい場合、1位と2位のスコア入れ換え、2位と3位のスコアを入れ換える
                {
                    tmp = rank[1];
                    rank[2] = tmp;
                    tmp = rank[0];
                    rank[1] = tmp;
                }else if(rank[1] < rankScore) //2位のスコアより大きい場合、2位と3位のスコアを入れ換える
                {
                    tmp = rank[1];
                    rank[2] = tmp;
                }
                rank[i] = rankScore;
                flag = false;
            }
        }
        rankText.text = "1位：" + rank[0].ToString() + "\n2位：" + rank[1].ToString() + "\n3位：" + rank[2].ToString(); //ランキングの表示
    }
}
