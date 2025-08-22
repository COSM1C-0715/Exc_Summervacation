using UnityEngine;

public class BulletControll : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private int bulletCount;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private int radius;
    [SerializeField]
    private float forwardOffset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Z))
        {
            ShootCircleInFront();
        }
    }

    void ShootCircleInFront()
    {
        if(bulletPrefab==null) return;

        Vector3 forwardCenter = transform.position + transform.forward * forwardOffset;

        for(int i=0;i<bulletCount;i++)
        {
            float angle = i * (360f / bulletCount);

            Vector3 localPos = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0) * radius;

            Vector3 worldPos = forwardCenter + localPos;

            GameObject bullet = Instantiate(bulletPrefab,worldPos,Quaternion.identity);

            Vector3 shootdir = transform.forward;

            BulletMove bm = bullet.GetComponent<BulletMove>();
            if(bm!=null)
            {
                bm.SetDirection(shootdir, bulletSpeed);
            }
        }
    }
}
