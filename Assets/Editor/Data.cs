using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Data
{
	[MenuItem("Assets/Create/GGJ2023/Personality Trait")]
	public static void CreatePersonalityTrait()
	{
		string path = EditorUtility.SaveFilePanelInProject("Save Personality Trait", "new Personality Trait", "Asset", "Save Personality Trait", "Assets/Data");
		if (path != "")
		{
			PersonalityTrait pt = ScriptableObject.CreateInstance<PersonalityTrait>();
			AssetDatabase.CreateAsset(pt, path);
			AssetDatabase.ImportAsset(path);
		}
	}

    [MenuItem("Assets/Create/GGJ2023/Ancestor")]
    public static void CreateAncestor()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Ancestor", "new Ancestor", "Asset", "Save Ancestor", "Data");
        if (path != "")
        {
            Ancestor anc = ScriptableObject.CreateInstance<Ancestor>();
            AssetDatabase.CreateAsset(anc, path);
            AssetDatabase.ImportAsset(path);
        }
    }
}
