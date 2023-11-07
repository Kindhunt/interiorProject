using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _sensitivity;
    [SerializeField] private Camera _camera;
    [SerializeField] private CharacterController _characterController;

    private PlayerMovementSystem _movementSystem;

    void Start() {
        // _camera = GetComponent<Camera>();
        _characterController = GetComponent<CharacterController>();

        _movementSystem = new PlayerMovementSystem(_speed, _sensitivity, gameObject, _camera, _characterController);
        _camera.transform.position = transform.position;
        _camera.transform.SetParent(transform);

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
        _movementSystem.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _movementSystem.Look(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }
}
