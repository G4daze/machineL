using UnityEngine;

public class dia : MonoBehaviour
{
    
    public static bool complete;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "hammer")
        {


            complete = true;
        }



    }


}
