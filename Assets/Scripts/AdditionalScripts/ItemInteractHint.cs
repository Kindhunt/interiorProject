using UnityEngine;

public class ItemInteractHint : MonoBehaviour
{
	private Renderer _renderer;
    
    private Material _material;

    [SerializeField]
    private Material _hintMaterial;

    void Start() {
        _renderer = GetComponent<Renderer>();
        _material = _renderer.material;
    }

	private void OnMouseEnter() {
		_renderer.material = _hintMaterial;
	}

    private void OnMouseExit() {
        _renderer.material = _material;
    }
}
