using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private Vector3 direction;

    private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetDirection(Vector3 dir,float spd)
    {
        direction = dir.normalized;
        speed = spd;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
