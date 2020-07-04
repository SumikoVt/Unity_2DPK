
using UnityEngine;

public class Player : MonoBehaviour
{
    // 單行註解 2020.07.04 Sumiko
    // 說明:

    /* 多行註解
     * 多行註解
     * 多行註解
     * */

    #region 欄位區域

    // 命名規則
    // 1. 使用有意義名稱
    // 2. 不要使用數字開頭
    // 3. 不要使用特殊符號包含:@#/* 空格
    // 4. 可以使用中文 不建議

    // 欄位語法
    // 修飾詞 類型 欄位名稱 = 值;
    // 沒有 = 值
    // 整數,浮點數 預設值:0
    // 字串 預設值 ""
    // 布林值 預設值 false

    // 私人 private - 僅限於此類別使用 | 不會顯示 - 預設值
    // 公開 public - 所有類別皆可使用  | 會顯示

    // 欄位屬性 [屬性名稱()]
    // 標題 Header
    // 提示 ToolTip
    // 範圍 Range
    // 範例 - [Header("Speed"), Tooltip("Player's movespeed"), Range(10, 1500)]

    [Range(10, 1500)]
    public int speed = 50;
    public float hp = 999.9f;
    public int coin;
    [Range(100, 2000)]
    public int height = 500;
    public AudioClip soundJump;
    public AudioClip soundSlide;
    public AudioClip soundDamage;
    public bool dead;
    #endregion

    #region 方法區域

    // C# 括號符號都是成對出現的:() {} [] '' ""
    // 摘要 - 方法的說明
    // 在方法上方新增///

    // 自訂方法 - 不會執行的, 需要呼叫
    // API - 功能倉庫
    // 輸出功能 print("字串")

    /// <summary>
    /// 角色的跳躍功能 : 跳躍動畫, 播放跳躍音效, 碰撞範圍往上跳
    /// </summary>
    private void Jump()
    {
        print("跳躍");
    }

    /// <summary>
    /// 
    /// </summary>
    private void Slide()
    {
        print("滑行");
    }

    /// <summary>
    /// 角色的碰撞受傷反應 : 扣血, 播放受傷音效
    /// </summary>
    private void Hit()
    {

    }

    /// <summary>
    /// 吃金幣 : 金幣數量增加, 更新介面, 金幣音效
    /// </summary>
    private void EatCoin()
    {

    }

    /// <summary>
    /// 死亡 : 撥放死亡動畫, 遊戲結束
    /// </summary>
    private void Dead()
    {

    }
    #endregion

    #region  事件區域

    // 開始 Start
    // 播放遊戲時啟動一次
    // 初始化 :

    private void Start()
    {
        // 呼叫跳躍方法
        Jump();
    }
    // 更新 Update
    // 播放遊戲後一秒執行約60次 - 60FPS
    // 移動, 監聽玩家鍵盤 滑鼠與觸控

    private void Update()
    {
        Slide();
    }
    #endregion
}
