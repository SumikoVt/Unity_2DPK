using UnityEngine;

public class learn_static : MonoBehaviour
{
    private void Start()
    {
        // 靜態成員用法
        // 靜態屬性 Property = 欄位 Field (儲存資料)
        // 語法 : 類別名稱, 靜態屬性名稱
        print(Mathf.PI);
        print(Mathf.Infinity);
        print(Random.Range(100, 501));

        // 靜態方法 Method
        // 語法:類別名稱.靜態方法名稱(對應參數)
        print(Mathf.Abs(-999));

        // 取得 100-500 隨機值
        print(Random.Range(100, 501));

        // 呼叫方法
        Test();
        Test();

        Skill("火焰");
        Skill("水");
        Skill("閃電");
    }

    private void Update()
    {
        // print(Random.value);
        // print(Time.time);             
    }

    // 方法
    // 可以被按鈕呼叫

    // 語法
    // 修飾詞 傳回類型 方法名稱() { 程式內容 }
    // void 無傳回

    private void Test()
    {
        print("測試方法");
    }

    // 參數:類型 名稱
    private void Skill(string s)
    {
        print("施放技能:" + s);
        print("播放音效");
    }
}
