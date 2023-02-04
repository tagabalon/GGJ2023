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

    [MenuItem("Assets/Create/GGJ2023/Question")]
    public static void CreateQuestion()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Question", "new Question", "Asset", "Save Question", "Data");
        if (path != "")
        {
            Question que = ScriptableObject.CreateInstance<Question>();
            AssetDatabase.CreateAsset(que, path);
            AssetDatabase.ImportAsset(path);
        }
    }

    [MenuItem("Assets/Create/GGJ2023/Family Tree")]
    public static void CreateFamilyTree()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Family Tree", "new Family Tree", "Asset", "Save Family Tree", "Data");
        if (path != "")
        {
            FamilyTree ft = ScriptableObject.CreateInstance<FamilyTree>();
            AssetDatabase.CreateAsset(ft, path);
            AssetDatabase.ImportAsset(path);
        }
    }
}
