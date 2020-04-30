using UnityEngine;
using MLAgents;
using MLAgents.Sensors;

public class hammer : Agent
{
    [Header("速度"), Range(1, 50)]
    public float speed = 10;
    /// <summary>
    /// 機器人鋼體
    /// </summary>
    private Rigidbody righammer;
    /// <summary>
    /// 愛心鋼體 
    /// </summary>
    private Rigidbody righeart;
    private Rigidbody rigdia;

    private void Start()
    {
        
        righammer = GetComponent<Rigidbody>();
        righeart = GameObject.Find("Heart").GetComponent<Rigidbody>();
        righeart = GameObject.Find("Diamondo5side").GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        righammer.velocity = Vector3.zero;
        righammer.angularVelocity = Vector3.zero;
        righeart.velocity = Vector3.zero;
        righeart.angularVelocity = Vector3.zero;

        Vector3 poshammer = new Vector3(Random.Range(-6f, 6f), Random.Range(0.65f,3.67f), Random.Range(-6f, 0f));
        transform.position = poshammer;

        Heart.complete = false;
        dia.complete = false;
        
    }

    /// <summary>
    /// 收集觀測資料
    /// </summary>
    ///<param name="sensor"></param>
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(righammer.position);
        sensor.AddObservation(righammer.velocity.x);
        sensor.AddObservation(righammer.velocity.y);
        sensor.AddObservation(righammer.velocity.z);

    }
    /// <summary>
    /// 動作:控制機器人與回饋
    /// </summary>
    /// <param name="vectorAction"></param>
    public override void OnActionReceived(float[] vectorAction)
    {
        Vector3 control = Vector3.zero;
        control.x = vectorAction[0];
        control.z = vectorAction[1];
        righammer.AddForce(control * speed);

        if (Heart.complete)
        {
            SetReward(1);
            EndEpisode();
        }
        if (dia.complete)
        {
            SetReward(-1);
            EndEpisode();

        }


    }
    


}
