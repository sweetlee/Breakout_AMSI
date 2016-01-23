using UnityEngine;
using System.Collections;

public class BrickModel : MonoBehaviour {

	public int brickHitPoints;

	// Use this for initialization
	void Start () {
		this.updateColor();
	}

	public void updateColor(){
		Renderer renderer = this.gameObject.GetComponent<Renderer>();
		Debug.Log(renderer.material.color);
		renderer.material.EnableKeyword("_Color");
		if(brickHitPoints == 1){
			renderer.material.SetColor("_Color", new Color(0f,0f,1.0f));
		}else if(brickHitPoints == 2){
			renderer.material.SetColor("_Color", new Color(0f,1.0f,0f));
		}else if (brickHitPoints == 3){
			renderer.material.SetColor("_Color", new Color(1.0f,0f,0f));
		}
	}
}
