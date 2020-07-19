
using UnityEngine;
using UnityEngine.UI;

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

    [Header("金幣文字")]
    public Text textcoin;
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
    public AudioClip soundCoin;
    public AudioClip afterDie;
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
    [Header("血條")]
    public Image imgHp;

    private float hpMax;
    [Header("音效")]
    public AudioSource aud;
    [Header("結束畫面")]
    public GameObject final;
    [Header("標題")]
    public Text textTitle;
    [Header("本次的金幣數量")]
    public Text textCurrent;

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
        if (rig.velocity.magnitude < 3)
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
                aud.PlayOneShot(soundJump, 0.3f);
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
            aud.PlayOneShot(soundSlide, 0.1f);
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
        hp -= 20;                        // 血量遞減 20

        imgHp.fillAmount = hp / hpMax;   // 血條.填滿長度 = 血量 / 血量最大值
        aud.PlayOneShot(soundDamage, 0.7f);

        if (hp <= 0) Dead();
    }

    /// <summary>
    /// 吃金幣 : 金幣數量增加, 更新介面, 金幣音效
    /// </summary>
    /// (參數) 語法 : 參數類型.參數名稱
    private void EatCoin(Collider2D collision)
    {
        coin++;                           // 金幣數量增加1
        Destroy(collision.gameObject);    // 刪除(碰到物件.遊戲物件)
        textcoin.text = "金幣:" + coin;   // 文字介面.文字內容 = "金幣:" + 金幣數量
        aud.PlayOneShot(soundCoin, 0.2f);
    }

    /// <summary>
    /// 死亡 : 撥放死亡動畫, 遊戲結束
    /// </summary>
    private void Dead()
    {
        if (dead) return;                // 如果 死亡 就 跳出
        dead = true;
        ani.SetTrigger("死亡觸發");      // 死亡觸發
        final.SetActive(true);           // 結束畫面.啟動設定(是)
        textTitle.text = "你死了?????";
        textCurrent.text = "本次的金幣數量:" + coin;
        aud.PlayOneShot(afterDie, 1);
        speed = 0;
        rig.velocity = Vector3.zero;
    }

    private void Pass()
    {
        final.SetActive(true);
        textTitle.text = "恭喜你獲勝了!";
        textCurrent.text = "本次的金幣數量:" + coin;
        speed = 0;
        rig.velocity = Vector3.zero;
    }
    #endregion

    #region  事件區域

    // 開始 Start
    // 播放遊戲時啟動一次
    // 初始化 :

    private void Start()
    {
        hpMax = hp;
    }
    // 更新 Update
    // 播放遊戲後一秒執行約60次 - 60FPS
    // 移動, 監聽玩家鍵盤 滑鼠與觸控

    private void Update()
    {
        if (dead) return;

        Slide();

        if (transform.position.y <= -6) Dead();
    }

    /// <summary>
    /// 固定更新事件:一秒執行50次, 只要有剛體就寫在 FixedUpdate 這
    /// </summary>
    private void FixedUpdate()
    {
        if (dead) return;

        Jump();
        Move();
    }

    /// <summary>
    /// 碰撞事件:碰到物件開始執行一次
    /// 碰到有碰撞器的物件執行
    /// 沒有勾選 Is Trigger
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 如果 碰到物件 的 名稱 等於 "地板"
        if (collision.gameObject.name == "地板")
        {
            isGround = true;
        }

        // 如果 碰到物件 的 名稱 等於 "地板" 並且 玩家的 Y 大於 地板的 Y
        if (collision.gameObject.name == "懸浮地板")
        {
            isGround = true;
        }
    }

    /// <summary>
    /// 觸發事件:碰到勾選 Is Trigger 的物件執行一次
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "金幣")          // 如果 碰到物件.標欠 == "金幣"
        {
            EatCoin(collision);               // 呼叫吃金幣方法(金幣碰撞)
        }

        if (collision.tag == "障礙物")
        {
            Hit();
        }

        if (collision.name == "傳送門")
        {
            Pass();
        }
    }
    #endregion
}
