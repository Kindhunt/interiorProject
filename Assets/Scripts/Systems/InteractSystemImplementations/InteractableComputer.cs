using UnityEngine;

public class InteractableComputer : MonoBehaviour, IInteractionSystem
{
	[SerializeField]
	private Canvas _pcCanvas;
	
	private bool _isOpen = false;
	public void Interact() {
		if (_isOpen) {
			_isOpen = false;
		}
		else {
			_isOpen = true;
		}
		_pcCanvas.gameObject.SetActive(_isOpen);
	}
}
