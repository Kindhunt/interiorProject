using UnityEngine;

namespace Assets.Scripts
{
	public class Interactor : MonoBehaviour
	{
		[SerializeField]
		private Transform _interactSource;

		[SerializeField]
		private float _interactDistance;

		public void Update() {
			if (Input.GetKeyDown(KeyCode.E)) {
				if (Physics.Raycast(new Ray(_interactSource.position, _interactSource.forward), 
					out RaycastHit hitInfo, 
					_interactDistance)) { 
					if (hitInfo.collider.gameObject.TryGetComponent(out IInteractionSystem interaction)) {
						interaction.Interact();
					}
				}
			}
		}
	}
}
