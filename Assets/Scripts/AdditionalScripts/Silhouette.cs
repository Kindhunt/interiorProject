using UnityEngine;

namespace Assets.Scripts.AdditionalScripts
{
	internal class Silhouette : MonoBehaviour
	{
		[SerializeField]
		LayerMask _layer;

		[SerializeField]
		private Camera _playerCamera;

		[SerializeField]
		private Material _silhouetteMaterial;

		// [SerializeField]
		private Color _color;

		// private float _itemHeight;
		public GameObject ItemSilhouette => _itemSilhouette;
		private GameObject _itemSilhouette;

		public bool Placeable => _placeable;
		private bool _placeable = false;
		
		public void CreateSilhouette(GameObject gameObject) {
			_itemSilhouette = gameObject;
			// _itemHeight = _itemSilhouette.GetComponent<MeshRenderer>().bounds.size.y;
			_itemSilhouette.GetComponent<Collider>().enabled = true;
			_itemSilhouette.GetComponent<Collider>().isTrigger = true;
			_itemSilhouette.GetComponent<ItemInteractHint>().enabled = false;
			_itemSilhouette.GetComponent<Renderer>().material = _silhouetteMaterial;
		}

		public void DisposeSilhouette() {
			Destroy(_itemSilhouette);
		}

		public void MoveSilhouette(float placeDistance)
		{
			if (Physics.Raycast(_playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f)), 
				out RaycastHit hit, placeDistance, _layer)) 
			{
				_placeable = true;
				_itemSilhouette.SetActive(true);
				_itemSilhouette.transform.position = new Vector3(hit.point.x, hit.point.y + 0.01f, hit.point.z);
			}
			else {
				_placeable = false;
				_itemSilhouette.SetActive(false);
			}

			_itemSilhouette.transform.eulerAngles += new Vector3(0, 50 * Input.GetAxis("Mouse ScrollWheel"), 0);
		}
	}
}
