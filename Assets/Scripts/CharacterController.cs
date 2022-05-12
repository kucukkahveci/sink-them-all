using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Animator _animator;
    private Camera _camera;

    public float TurnSpeed;
    public float Speed;
    public float LerpValue;
    public LayerMask Layer;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _camera = Camera.main;
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Movement();
        }
        else
        {
            if (_animator.GetBool("running"))
            {
                _animator.SetBool("running", false);
            }
        }
    }

    private void Movement()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = _camera.transform.localPosition.z;

        Ray _ray = _camera.ScreenPointToRay(mousePos);          
        RaycastHit _hit;                                        

        if(Physics.Raycast(_ray, out _hit, Mathf.Infinity, Layer))     // ?
        {
            Vector3 _hitVector = _hit.point;                    
            _hitVector.y = transform.position.y;

            transform.position = Vector3.MoveTowards(transform.position, Vector3.Lerp(transform.position, _hitVector, LerpValue), Time.deltaTime * Speed);
            Vector3 _newMovePoint = new Vector3(_hit.point.x, transform.position.y, _hit.point.z);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_newMovePoint - transform.position),TurnSpeed * Time.deltaTime);

            if (!_animator.GetBool("running"))
            {
                _animator.SetBool("running", true);
            }
        }
    }
}
