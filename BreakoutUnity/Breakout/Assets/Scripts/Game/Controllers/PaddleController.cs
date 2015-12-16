using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour {

	public PaddleModel paddleModel;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject objectHit=null;
		this.handleTouchOnUpdate(objectHit);
		this.handleMouseOnUpdate(objectHit);

	}

	void handleTouchOnUpdate(GameObject objectHit){
		
		foreach(Touch touch in Input.touches){
			if(touch.phase == TouchPhase.Began){
				Ray ray = Camera.main.ScreenPointToRay(touch.position);
				RaycastHit hit;
				if(Physics.Raycast(ray, out hit)){
					if(hit.collider.gameObject.Equals(paddleModel)){
						objectHit = hit.collider.gameObject;
					}
				}
			}else if(touch.phase == TouchPhase.Moved){
				if(objectHit){
					objectHit.transform.position = new Vector3(touch.position.x,touch.position.y,0);
				}
			}else if(touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled){
				objectHit = null;
			}
		}
	}
	void handleMouseOnUpdate(GameObject objectHit){
		if(Input.GetMouseButton(0)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)){
				if(paddleModel.canMove){
					paddleModel.transform.position = new Vector2(hit.point.x, paddleModel.gameObject.transform.position.y);
				}
			}
		}
	}

}
