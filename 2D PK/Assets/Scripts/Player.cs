
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

    [Header("角色移動速度"), Range(1, 1500)]
    public int speed = 50;
    [Header("角色血量")]
    public float hp = 999.9f;
    [Header("金幣數量")]
    public int coin;
    [Header("動畫控制器"), Range(100, 2000)]
    public int height = 500;
    [Header("音效區域")]
    public AudioClip soundJump;
    public AudioClip soundSlide;
    public AudioClip soundDamage;
    [Header("角色是否死亡")]
    public bool dead;
    [Header("動畫控制器")]
    public Animator ani;
    [Header("膠囊碰撞器")]
    public CapsuleCollider2D cc2d;
    [Header("剛體")]
    public Rigidbody2D rig;
    /// <summary>
    /// 是否在地板上
    /// </summary>
    public bool isGround;
    #endregion

    #region 方法區域

    // C# 括號符號都是成對出現的:() {} [] '' ""
    // 摘要 - 方法的說明
    // 在方法上方新增///

    // 自訂方法 - 不會執行的, 需要呼叫
    // API - 功能倉庫
    // 輸出功能 print("字串")

    private void Move()
    {
        if (rig.velocity.magnitude < 5)
        {
            // 剛體.增加推力(二維向量)
            rig.AddForce(new Vector2(speed, 0));
        }
    }

    /// <summary>
    /// 角色的跳躍功能 : 跳躍動畫, 播放跳躍音效, 碰撞範圍往上跳
    /// </summary>
    private void Jump()
    {
        bool key = Input.GetKey(KeyCode.Space);

        // 顛倒運算子 !
        // 作用:將布林值變成相反
        // !true ------ false

        ani.SetBool("跳躍開關", !isGround);

        // 如果在地板上
        if (isGround)
        {
            if (key)
            {
                isGround = false;                                       // 不再地板上
                rig.AddForce(new Vector2(0, height));                   // 剛體.增加推力(二維向量)
            }

        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void Slide()
    {
        // 布林值 = 輸入.取得案件(按鍵代碼.左Ctrl)
        bool key = Input.GetKey(KeyCode.LeftControl);

        //動畫控制器代號
        ani.SetBool("滑行開關", key);

        if (key)
        {
            cc2d.offset = new Vector2(-0.7657909f, -1.55f);         //位移
            cc2d.size = new Vector2(1.682096f, 2.02f);              //尺寸
        }
        else
        {
            cc2d.offset = new Vector2(-0.7657909f, 0.1767215f);     //位移
            cc2d.size = new Vector2(1.682096f, 5.255785f);          //尺寸
        }
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

    }
    // 更新 Update
    // 播放遊戲後一秒執行約60次 - 60FPS
    // 移動, 監聽玩家鍵盤 滑鼠與觸控

    private void Update()
    {
        Slide();        
    }

    /// <summary>
    /// 固定更新事件:一秒執行50次, 只要有剛體就寫在 FixedUpdate 這
    /// </summary>
    private void FixedUpdate()
    {
        Jump();
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "地板")
        {
            isGround = true;
        }
    }
    #endregion
}
