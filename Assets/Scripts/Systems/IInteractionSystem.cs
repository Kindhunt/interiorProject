using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction {
	private IInteractionSystem _interactionSystem;
	public IInteractionSystem InteractionSystem { get { return _interactionSystem; } }
	public Interaction(IInteractionSystem interactionSystem) { 
		_interactionSystem = interactionSystem; 
	}
}

public interface IInteractionSystem {
	public void Interact();
}

