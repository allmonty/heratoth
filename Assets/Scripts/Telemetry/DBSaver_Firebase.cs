
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine;

//[CreateAssetMenu(fileName = "DBSaver_Firebase", menuName = "Telemetry/DBSaver_Firebase")]
public class DBSaver_Firebase{

	public string dbUrl = "https://estudo-2f608.firebaseio.com/";

	DatabaseReference reference;

	public DBSaver_Firebase()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(dbUrl);

        this.reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

	public void savePlayerData(string json) {

		Debug.Log(dbUrl);

		reference.Child("Users").SetRawJsonValueAsync(json);
	}	
}
