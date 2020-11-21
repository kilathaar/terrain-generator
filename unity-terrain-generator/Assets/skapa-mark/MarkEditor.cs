using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlaneGenerator))]
public class MarkEditor : Editor {
	public override void OnInspectorGUI() {
		PlaneGenerator planeGenerator = (PlaneGenerator) target;
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