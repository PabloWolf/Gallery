using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    const int _x = 0;
    const int _y = 1;
    const int _zmov = 1;

    Camera pl_cam;
    public float[] sen = { 200f, 200f };
    float[] rot = { 0, 0 };
    public float x_max = 90;
    public float x_min = -90;


    public float speed = 10;

    public CharacterController con;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        pl_cam = GetComponentInChildren<Camera>();
        con = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CameraRot();

        Movement();
    }

    void CameraRot()
    {
        float m_x = Input.GetAxis("Mouse X") * sen[_x] * Time.deltaTime;
        float m_y = Input.GetAxis("Mouse Y") * sen[_y] * Time.deltaTime;

        rot[_x] -= m_y;
        rot[_x] = Mathf.Clamp(rot[_x], x_min, x_max);
        rot[_y] += m_x;

        pl_cam.transform.localRotation = Quaternion.Euler(rot[_x],0f, 0f);
        transform.localRotation = Quaternion.Euler(0f, rot[_y], 0f);
    }

    void Movement()
    {
        float[] move_input = { Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")};
        



        Vector3 move = transform.forward * move_input[_zmov] + transform.right * move_input[_x];

        if (move.magnitude > 1)
        {
            move = Vector3.Normalize(move);
        }
        move = move * speed * Time.deltaTime;

        con.Move(move);
    }
}
