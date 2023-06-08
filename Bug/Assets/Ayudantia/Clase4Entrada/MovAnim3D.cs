using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovAnim3D : MonoBehaviour
{
    private Rigidbody _rb;

    private Animator _animator;
    
    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.W)) {
            _animator.SetInteger("moveZ",1);
        } else {
            _animator.SetInteger("moveZ",0);
        }
    }
}
