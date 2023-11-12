using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] 
    private float _speed;
    
    [SerializeField] 
    private float _sensitivity;
    
    //[SerializeField] 
    private Camera _camera;
    
    // [SerializeField] 
    private CharacterController _characterController;

    private PlayerMovementSystem _movementSystem;

    void Start() {
        _camera = Camera.main; // TO-DO: Переопределить
        _characterController = GetComponent<CharacterController>();

        _movementSystem = new PlayerMovementSystem(_speed, _sensitivity, _camera, _characterController);
        _camera.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
        _movementSystem.Move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _movementSystem.Look(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }
}
