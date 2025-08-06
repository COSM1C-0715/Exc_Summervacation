using UnityEngine;

public class enemy_ : MonoBehaviour
{
    public void SetTarget(bool enable)
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        mr.materials[0].color = enable? Color.red:Color.white;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
