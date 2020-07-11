using UnityEngine;

public class learn_nonstatic : MonoBehaviour
{
    // 儲存場景上物件或元件
    public GameObject santa;

    public Transform santaTran;

    public Camera cam;

    public ParticleSystem ps;

    // 靜態與非靜態差異
    // 非靜態需要有物件或元件

    // 存取
    // 非靜態屬性

    private void Start()
    {
        // 取得
        print(santa.tag);
        print(santa.layer);

        //存放
        //santaTran.position = new Vector3(0, 1, 0);
        //santaTran.localScale = new Vector3(1, 1, 1);
    }

    private void Update()
    {
        // 非靜態方法
        //santaTran.Rotate(0, 0, 60);
        santaTran.Translate(0.1f, 0, 0);
    }
}
