using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GroundGenerator))]
public class GroundEditor : Editor {
	public override void OnInspectorGUI() {
		GroundGenerator planeGenerator = (GroundGenerator) target;
		if(DrawDefaultInspector()) {
			if(planeGenerator.updateAutomatically) {
				planeGenerator.GeneratePlane();
			}
		}
		if(GUILayout.Button("Generate")) {
			planeGenerator.GeneratePlane();
		}
	}
}