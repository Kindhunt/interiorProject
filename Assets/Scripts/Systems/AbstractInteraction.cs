using UnityEngine;

class AbstractInteraction<T> : MonoBehaviour
{
	[SerializeField]
	protected Transform _interactSource;

	[SerializeField]
	protected float _interactDistance;

	[SerializeField]
	private Camera _playerCamera;

	public bool IsBusy => _isBusy;
	private bool _isBusy;

	protected T _interacted;

	protected bool CheckRaycast()
	{
		if (Input.GetKeyDown(KeyCode.E)) {
			if (Physics.Raycast(_playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f)),
					out RaycastHit hitInfo,
					_interactDistance))
			{
				return hitInfo.collider.gameObject.TryGetComponent(out _interacted);
			}
		}
		return false;
	}
}