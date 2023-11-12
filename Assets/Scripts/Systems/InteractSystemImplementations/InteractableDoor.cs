using System.Collections;
using UnityEngine;

public class InteractableDoor : MonoBehaviour, IInteractionSystem
{
	[SerializeField]
	private float _speed = 3f;

	private bool _isOpen = false;
	private Quaternion _targetRotation;

	public void Interact()
	{
		StopCoroutine("RotateDoor");
		
		if (_isOpen) {
			CloseDoor();
		}
		else {
			OpenDoor();
		}
	}
	private void OpenDoor()
	{
		_isOpen = true;

		_targetRotation = Quaternion.Euler(new Vector3(0f, -90f, 0f));
		StartCoroutine("RotateDoor");
	}
	private void CloseDoor()
	{
		_isOpen = false;

		_targetRotation = Quaternion.Euler(Vector3.zero);
		StartCoroutine("RotateDoor");
	}
	private IEnumerator RotateDoor()
	{
		while (transform.rotation != _targetRotation)
		{
			// ѕлавно интерполируем текущий угол поворота двери к целевому
			transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, _speed * Time.deltaTime);

			// ѕриостанавливаем выполнение корутины до следующего кадра
			yield return null;
		}
	}
}
