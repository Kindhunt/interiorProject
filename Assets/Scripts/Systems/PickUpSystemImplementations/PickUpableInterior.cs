using Assets.Scripts.AdditionalScripts;
using UnityEngine;

public class PickUpableInterior : MonoBehaviour, IPickUpSystem
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
	}

	public void PickUp() 
	{		
		transform.position = _hand.localPosition;
		transform.rotation = _hand.localRotation;

		transform.SetParent(_hand.transform, false);

		_isPicked = true;

		_silhouette.CreateSilhouette(Instantiate(gameObject));
	}
	public void Drop()
	{
		transform.SetParent(null);

		transform.position = _silhouette.ItemSilhouette.transform.position;
		transform.rotation = _silhouette.ItemSilhouette.transform.rotation;

		_isPicked = false;

		_silhouette.DisposeSilhouette();
	}
	public bool IsPicked() {
		return _isPicked;
	}
}
