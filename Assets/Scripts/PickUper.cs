using UnityEditor.PackageManager;
using UnityEngine;

namespace Assets.Scripts
{
	internal class PickUper : AbstractInteraction<IPickUpSystem>
	{
		private bool _isPick = false;
		public void Update()
		{
			if (!_isPick) {
				if (CheckRaycast()) {
					_interacted.PickUp();
				}
			}
			else {
				if (Input.GetKeyDown(KeyCode.E)) {
					_interacted.Drop();
				}
			}
			_isPick = _interacted.IsPicked();
		}
	}
}
