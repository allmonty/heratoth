using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransitionTrigger : MonoBehaviour {

	[SerializeField] RoomTracker roomTracker = null;
	[SerializeField] string room1 = "";
	[SerializeField] string room2 = "";

	 void OnTriggerExit(Collider other){
		 if(other.gameObject.layer == LayerMask.NameToLayer("Player")){
		 	roomTracker.walkedThroughDoor(room1, room2);
		 }
	 }
}
