using UnityEngine;

public class test11 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody go;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 m_Input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        // if (m_Input.magnitude < 0.01f)
        //     return;
        
        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        go.MovePosition(go.position + m_Input * Time.fixedDeltaTime * 10f);

        if (Input.GetKeyDown(KeyCode.P))
        {
            go.AddForce(-transform.forward * 10f, ForceMode.Acceleration);
        }
    }
}
