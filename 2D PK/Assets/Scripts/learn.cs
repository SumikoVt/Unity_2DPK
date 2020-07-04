using UnityEngine;

public class learn : MonoBehaviour
{
    private void Start()
    {
        // 靜態成員用法
        // 靜態屬性 Property = 欄位 Field (儲存資料)
        //語法 : 類別名稱, 靜態屬性名稱
        print(Mathf.PI);
        print(Mathf.Infinity);
        print(Random.Range(100, 501));
    }

    private void Update()
    {
        //print(Random.value);
        //print(Time.time);
    }
}
