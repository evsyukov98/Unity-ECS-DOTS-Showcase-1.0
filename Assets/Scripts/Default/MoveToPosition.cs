using UnityEngine;

public class MoveToPosition : MonoBehaviour
{
    public Vector3 target; 
    public float speed = 5f;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}