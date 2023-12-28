using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class EnumTabsExample : MonoBehaviour
{
    public int health;
    public float speed;
    public int agility;
    public enum TabType
    {
        Tab1,
        Tab2,
        Tab3
    }

    private TabType selectedTab;

    //ѕеременна€ типа Enum дл€ отображени€ в виде вкладок

#if UNITY_EDITOR
       // Editor класс дл€ редактировани€ отображени€ Enum
       [CustomEditor(typeof(EnumTabsExample))]
        public class EnumTabsExampleEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            EnumTabsExample enumTabsExample = (EnumTabsExample)target;

            // ќтобразить Enum в виде вкладок
            enumTabsExample.selectedTab = (TabType)GUILayout.Toolbar((int)enumTabsExample.selectedTab, new string[] { "Mouse", "Touch", "Mouse&Touch" });

            // ¬ зависимости от выбранной вкладки, отобразить соответствующее содержимое
            switch (enumTabsExample.selectedTab)
            {
                case TabType.Tab1:
                    EditorGUILayout.LabelField("¬заимодействие с мышкой", EditorStyles.boldLabel);
                    enumTabsExample.agility = EditorGUILayout.IntField("Agility", enumTabsExample.agility);
                    break;
                case TabType.Tab2:
                    EditorGUILayout.LabelField("¬заимодействие с тачом", EditorStyles.boldLabel);
                    enumTabsExample.speed = EditorGUILayout.FloatField("Speed", enumTabsExample.speed);
                    break;
                case TabType.Tab3:
                    EditorGUILayout.LabelField("¬се режимимы сразу", EditorStyles.boldLabel);
                    enumTabsExample.health = EditorGUILayout.IntField("Health", enumTabsExample.health);
                    break;
            }
        }
    }
#endif
}
