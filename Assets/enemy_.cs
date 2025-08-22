using UnityEngine;

public class enemy_ : MonoBehaviour
{
    [SerializeField, Header("ˆÚ“®‘¬“x")]
    private float speed;

    [SerializeField, Header("•ûŒü‚ð•Ï‚¦‚éŽžŠÔ")]
    private float changeTime;

    [SerializeField, Header("”¼Œa")]
    private float Range;

    private float timer;
    private Vector3 dir;
    private Vector3 startPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) ChangeDirection();

        Matrix4x4 moveMatrix = Matrix4x4.Translate(dir * speed * Time.deltaTime);

        Matrix4x4 newMatrix = transform.localToWorldMatrix * moveMatrix;
        Vector3 newPos = newMatrix.GetColumn(3);

        if(Vector3.Distance(startPos,newPos) > Range)
        {
            dir = -dir;
        }
        else
        {
            transform.position = newPos;
        }
    }

    void ChangeDirection()
    {
        dir = Random.onUnitSphere;
        timer = changeTime;
    }
    public void SetTarget(bool enable)
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        mr.materials[0].color = enable ? Color.red : Color.gray;
    }
}
