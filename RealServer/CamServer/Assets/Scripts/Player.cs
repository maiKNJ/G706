using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int id;
    public string username;

    private Packet _packet;
    private float moveSpeed = 5f / Constants.TICKS_PER_SEC;
    private bool[] inputs;

    public void Initialize(int _id, string _username)
    {
        id = _id;
        username = _username;

       // inputs = new bool[4];
    }

    public void FixedUpdate()
    {
        //Vector2 _inputDirection = Vector2.zero;
        //if (inputs[0])
        //{
        //    _inputDirection.y += 1;
        //}
        //if (inputs[1])
        //{
        //    _inputDirection.y -= 1;
        //}
        //if (inputs[2])
        //{
        //    _inputDirection.x -= 1;
        //}
        //if (inputs[3])
        //{
        //    _inputDirection.x += 1;
        //}

        //Move(_inputDirection);
        ServerHandle.PlayerMovement(id, _packet);
        
    }

   /* private void Move(Vector2 _inputDirection)
    {
        
        Vector3 _moveDirection = transform.right * _inputDirection.x + transform.forward * _inputDirection.y;
        transform.position += _moveDirection * moveSpeed;

        ServerSend.PlayerPosition(this);
        ServerSend.PlayerRotation(this);
    }*/

    public void SetInput(Vector3 _position, Quaternion _rotation)
    {
        /// <summary>Test speed for transform:
        /// the baseline 1
        /// 0.05f
        /// 0.5f
        /// 1
        /// 1.5f
        /// 2
        /// </summary>
        /// 

        Vector3 prev_pos = transform.position;
        transform.position = Vector3.Lerp(prev_pos, _position, 0.65f);
        //Vector3.Lerp(prev_pos, _position, 0.65f);
        //_position * 1.65f;

        /// <summary>Test speed for rotation:
        /// the baseline is 1
        /// 0.05f
        /// 0.5f
        /// 1
        /// 1.5f
        /// 2
        /// using 0.7f
        /// </summary>
        
        transform.rotation = new Quaternion(_rotation.x * 0.05f,  _rotation.y * 0.05f, _rotation.z* 0.05f, _rotation.w);

        //Mathf.Lerp(transform.rotation.y*0.85f, _rotation.y*0.85f, 0.02f)

    }
}
