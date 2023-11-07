using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovementSystem
{
	private float _speed;

	private float _sensitivity;

	private GameObject _player;

	private Camera _camera;

	private CharacterController _characterController;

	private float _pitch;

	public PlayerMovementSystem(float speed, float sensitivity, GameObject player, Camera camera, CharacterController characterController) {
		_speed = speed;
		_sensitivity = sensitivity;
		_player = player;
		_camera = camera;
		_characterController = characterController;
		_pitch = 0;
	}

	public void Move(float x, float z) {
		var moveVector = new Vector3(x, 0, z).normalized * _speed * Time.deltaTime;
		var moveDirection = _player.transform.TransformDirection(moveVector);
		_characterController.Move(moveDirection);
	}
	public void Look(float x, float y)
	{
		float yaw = x * _sensitivity;

		// Используем метод eulerAngles, чтобы работать с углами в градусах
		_player.transform.eulerAngles += new Vector3(0, yaw, 0);

		_pitch -= y * _sensitivity;
		_pitch = Mathf.Clamp(_pitch, -90, 90);

		// Поворачиваем камеру только по оси x, так как она дочерняя к персонажу
		_camera.transform.eulerAngles = new Vector3(_pitch, _player.transform.eulerAngles.y, 0);
	}
}