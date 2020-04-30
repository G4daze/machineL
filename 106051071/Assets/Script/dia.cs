using UnityEngine;

public class dia : MonoBehaviour
{
    ///<summary>
    ///有沒有敲到愛心
    /// </summary>
    public static bool complete;

    /// <summary>
    /// 觸發開始事件: 碰到勾選Is Trigger 物件會執行一次
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Diamondo5side")
        {


            complete = true;
        }



    }


}
