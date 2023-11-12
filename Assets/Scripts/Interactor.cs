using UnityEngine;

class Interactor : AbstractInteraction<IInteractionSystem>
{
	public void Update()
	{
		if (CheckRaycast()) {
			_interacted.Interact();
		}
	}
}