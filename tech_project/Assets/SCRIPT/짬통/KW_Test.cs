/* using UnityEngine;
using UnityEditor;

public class AddScriptToSelectedObjects : EditorWindow
{
    private MonoScript scriptToAdd;

    [MenuItem("Tools/Add Script To Selected Objects")]
    public static void ShowWindow()
    {
        GetWindow<AddScriptToSelectedObjects>("Add Script");
    }

    private void OnGUI()
    {
        scriptToAdd = (MonoScript)EditorGUILayout.ObjectField("추가할 스크립트 옆에 넣기", scriptToAdd, typeof(MonoScript), false);

        if (GUILayout.Button("선택된 오브젝트들에 스크립트 삽입"))
        {
            AddScript();
        }
    }

    private void AddScript()
    {
        if (scriptToAdd == null)
        {
            Debug.LogError("Please assign a script to add.");
            return;
        }

        foreach (var gameObject in Selection.gameObjects)
        {
            Undo.AddComponent(gameObject, scriptToAdd.GetClass());
        }
    }
} */