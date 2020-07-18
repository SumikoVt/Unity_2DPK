using UnityEngine;

public class Lerp_learn : MonoBehaviour
{
    public int A = 0;
    public int B = 10;



    private void Start()
    {
        float r = Mathf.Lerp(A, B, 0.7F);

        print(r);
    }
}
