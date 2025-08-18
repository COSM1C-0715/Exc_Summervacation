using UnityEngine;

public class Playermove : MonoBehaviour
{
    [SerializeField,Header("軸にするオブジェクト")]
    private Transform _axis;
    [SerializeField, Header("視野角")]
    private float ViewAngle;
    [SerializeField, Header("回転量")]
    private float RotateScale;
    [SerializeField,Header("移動量")]
    private float MoveScale;
    public float ViewRadian { get => ViewAngle * Mathf.Deg2Rad; }
    [SerializeField, Header("中身が見たいだけ")]
    private Matrix4x4 P_Matrix = Matrix4x4.identity;

    public Matrix4x4 worldMatrix { get => P_Matrix; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Update is called once per frame
    
    void Update()
    {
        P_Matrix = _axis.localToWorldMatrix;

        var q = Quaternion.identity;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            q = Quaternion.AngleAxis(RotateScale,_axis.up);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            q = Quaternion.AngleAxis(-RotateScale, _axis.up);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            q = Quaternion.AngleAxis(-RotateScale, _axis.right);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            q = Quaternion.AngleAxis(RotateScale, _axis.right);
        }
        transform.rotation = q * transform.rotation;

        var vec = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            vec.z = MoveScale;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            vec.z = -MoveScale;
        }

        var T_Matrix = Matrix4x4.Translate(vec);

        P_Matrix = P_Matrix * T_Matrix;

        transform.position = P_Matrix.GetColumn(3);
        transform.localScale = P_Matrix.lossyScale;
    }
}
