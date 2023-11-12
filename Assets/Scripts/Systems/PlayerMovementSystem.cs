using UnityEngine;

public class PlayerMovementSystem
{
	private float _speed;

	private float _sensitivity;

	private GameObject _player;

	private Camera _camera;

	private CharacterController _characterController;

	private float _pitch;

	private float _gravity;
	
	public PlayerMovementSystem(float speed, float sensitivity, Camera camera, CharacterController characterController) {
		_speed = speed;
		_sensitivity = sensitivity;
		_characterController = characterController;

		_player = GameObject.FindGameObjectWithTag("Player");
		_camera = camera;

		_pitch = 0;
		_gravity = 0;
	}

	public void Move(float x, float z) {
		if (_characterController.isGrounded) {
			_gravity = 0;
		}
		else {
			_gravity -= 9.81f * Time.deltaTime;
		}

		var moveVector = new Vector3(x, _gravity, z).normalized * _speed * Time.deltaTime;
		var moveDirection = _player.transform.TransformDirection(moveVector);

		_characterController.Move(moveDirection);
	}
	public void Look(float x, float y)
	{
		float yaw = x * _sensitivity;

		_player.transform.eulerAngles += new Vector3(0, yaw, 0);

		_pitch -= y * _sensitivity;
		_pitch = Mathf.Clamp(_pitch, -90, 90);

		_camera.transform.eulerAngles = new Vector3(_pitch, _player.transform.eulerAngles.y, 0);
	}
}