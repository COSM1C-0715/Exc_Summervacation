using UnityEngine;

public class Playermove : MonoBehaviour
{
    [SerializeField, Header("âÒì]ó ")]
    private float RotateScale;
    [SerializeField,Header("à⁄ìÆó ")]
    private float MoveScale;
    [SerializeField,Header("íÜêgÇ™å©ÇΩÇ¢ÇæÇØ")]
    private Matrix4x4 P_Matrix = Matrix4x4.identity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Update is called once per frame
    void Update()
    {
        var rad = 0.0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rad = RotateScale;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rad = -RotateScale;
        }
        var R_Matrix = Matrix4x4.Rotate(Quaternion.Euler(0,rad,0));

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

        P_Matrix = P_Matrix * (T_Matrix * R_Matrix);

        transform.position = P_Matrix.GetColumn(3);
        transform.rotation = P_Matrix.rotation;
        transform.localScale = P_Matrix.lossyScale;
    }
}
