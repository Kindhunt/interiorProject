using Assets.Scripts.AdditionalScripts;
using UnityEngine;

public class InteractableInterior : MonoBehaviour, IInteractionSystem
{
	[SerializeField]
	private Transform _hand;

	[SerializeField]
	private float _placeDistance;

	private Silhouette _silhouette;
	private bool _isPicked = false;
	
	void Start() {
		_silhouette = GetComponent<Silhouette>();
	}

	void Update() {
		if (_isPicked) {
			_silhouette.MoveSilhouette(_placeDistance);
		}

		if (Input.GetKeyDown(KeyCode.E)) {
			Interact();
		}
	}

	public void Interact() {
		if (!_isPicked) GetObject();
		else {
			if (_silhouette.Placeable)
				PlaceObject();
		}
	}
	private void GetObject() 
	{		
		transform.position = _hand.localPosition;
		transform.rotation = _hand.localRotation;

		transform.SetParent(_hand.transform, false);

		_isPicked = true;

		_silhouette.CreateSilhouette(Instantiate(gameObject));
	}
	private void PlaceObject()
	{
		transform.SetParent(null);

		transform.position = _silhouette.ItemSilhouette.transform.position;
		transform.rotation = _silhouette.ItemSilhouette.transform.rotation;

		_isPicked = false;

		_silhouette.DisposeSilhouette();
	}
}
