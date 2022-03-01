using UnityEditor;
using UnityEngine;

public class InspectorItemShowcase : EditorWindow
{
    TextEditor textEditor = new TextEditor();
    StringCollection stringCollection = new StringCollection();

    //GUI Styles
    #region GUI Style

    GUIStyle subTitleStyle;
    GUIStyle titleStyle;
    GUIStyle copyButton;
    GUIStyle docLinkStyle;
    GUIStyle smallButtonStyle;
    GUIStyle mediumButtonStyle;
    GUIStyle largeButtonStyle;
    GUIStyle mediumPopupStyle;
    GUIStyle descriptiveStyle;

    #endregion

    //Test Values (Just to makes stuff work)
    #region Test Variables

    #region Structs (Vectors, Bounds, Rect, TestEnum, FlagEnum, Color)
    private Vector2 scrollPos;
    private Vector2 editorGUILayoutWindowScroll;
    private Vector2 editorGUIWindowScroll;
    private Vector2 iconScrollPos;
    
    private Vector2 minMaxSliderValue = new Vector2(0, 5);
    private Vector2 minMaxDisplayValue;

    private Vector2 testVector2;
    private Vector3 testVector3;
    private Vector4 testVector4;
    private Bounds testBounds;
    private Rect testRect;
    private TestEnum testEnum;
    private FlagTestEnum flagEnum;
    private Color testColorValue;

    #endregion

    #region Data Types

    private AnimationCurve testAnimationCurve = AnimationCurve.Constant(0, 1, 0.5f);
    private Gradient testGradient = new Gradient();
    private Object testObject;

    #endregion

    #region Primitive Variables

    private int testInt;
    private int testLayerFieldInt;
    private int testMaskLayerFieldInt;
    private int testToolbarIndex;
    private int testSelectionGridIndex;
    private float testFloat;
    private float testSliderFloat;
    private float testKnobFloat = 5;
    private double testDouble;
    private string testString;
    private string testPasswordString;
    private bool showFoldout;
    private bool testToogle;
    private bool testObjectFieldBool;

    #endregion

    #endregion
    
    //Variables required to use the window
    #region Window Variables

    //Navigation Values
    private int navigationIndex = 5;
    private int catagoryIndex;
    private int debugNavigationTab;

    //EditorGUILayout Item State
    private bool numberValueItems = true;
    private bool boolItems = true;
    private bool stringItems = true;
    private bool enumItems = true;
    private bool vectorItems = true;
    private bool uniquePropertiesItems = true;

    private bool useNavigationUtility = true;
    private bool useDisplayFields = true;
    private bool useValueFields = true;
    private bool useAdvnacedValueFields = true;
    private bool useSliders = true;

    //GUIStyle Item State
    private bool labelFieldItems = true;
    private bool buttonFieldItems = true;
    private bool variableField = true;
    
    //Icons State
    private bool objectIconsItems = true;
    private bool platformIconsItems = true;
    private bool paintIconsItems = true;
    private bool videoIconItems = true;
    private bool windowExtensionItems = true;
    private bool warningErrorItems = true;
    private bool unityEditorItems = true;
    private bool profilerItems = true;
    private bool miscItems = true;
    
    #endregion

    [MenuItem("Window/Custom Editor Extension Documentation")]
    public static void ShowWindow()
    {
        EditorWindow window = GetWindow<InspectorItemShowcase>("Showcase");
        window.minSize = new Vector2(730, 10);
    }
    private void OnGUI()
    {
        GUIStyleConstructor();
        SortedLayout();
        
        PromoSutff();
    }
    
    #region Standard Draw
    void SortedLayout()
    {
        EditorGUILayout.Space(5);
        if(GUILayout.Button("Custom Editor Extension Documentation (CEED)", titleStyle)) 
        { 
            Application.OpenURL("https://github.com/McTeaCup/Custom-Editor-Extension-Documentation");
        }
        
        EditorGUILayout.Space(20);
        catagoryIndex = GUILayout.Toolbar(catagoryIndex, stringCollection.n_MainTabs, new GUIStyle(EditorStyles.toolbarButton));

        //EditorGUILayout
        if (catagoryIndex == 0)
        {
            using (var winScroll = new EditorGUILayout.ScrollViewScope(editorGUILayoutWindowScroll, false, true))
            {
                EditorGUILayout.Space(5);
                if (GUILayout.Button(stringCollection.t_CatagoryName[catagoryIndex], titleStyle))
                {
                    Application.OpenURL("https://docs.unity3d.com/ScriptReference/EditorGUILayout.html");
                }
                EditorGUILayout.LabelField(stringCollection.t_CategoryDescription[catagoryIndex], descriptiveStyle); 
                EditorGUILayout.Space(10);
                
                editorGUILayoutWindowScroll = winScroll.scrollPosition;

                using (new EditorGUILayout.VerticalScope())
                {
                    //EditorGUILayout Navigation stuff
                    EditorGUILayoutNavigationTabs();

                    //Make things pretty
                    NavigationUtilities();

                    //Display Stuff
                    DisplayFields();

                    //Value Fields
                    ValueFields();

                    //Advanced Value Fields
                    AdvancedField();

                    //Sliders
                    Sliders();
                }
            }
        }

        //GUIStyle
        else if (catagoryIndex == 1)
        {
            using (var winScroll = new EditorGUILayout.ScrollViewScope(editorGUIWindowScroll, false, true))
            {
                EditorGUILayout.Space(5);
                if (GUILayout.Button(stringCollection.t_CatagoryName[catagoryIndex], titleStyle))
                {
                    Application.OpenURL("https://docs.unity3d.com/ScriptReference/GUIStyle.html");
                }
                EditorGUILayout.LabelField(stringCollection.t_CategoryDescription[catagoryIndex], descriptiveStyle); 
                EditorGUILayout.Space(10);
                
                editorGUIWindowScroll = winScroll.scrollPosition;

                using (new EditorGUILayout.VerticalScope())
                {
                    GUIStyleNavigationTabs();

                    EditorGUILayout.Space(10);

                    if (labelFieldItems)
                        LabelFields();

                    EditorGUILayout.Space(10);

                    if (buttonFieldItems)
                        ButtonFields();

                    EditorGUILayout.Space(10);

                    if (variableField)
                        VariableFields();
                }
            }
        }
        
        //Icons
        else if (catagoryIndex == 2)
        {
            EditorGUILayout.Space(5);
            if (GUILayout.Button(stringCollection.t_CatagoryName[catagoryIndex], titleStyle))
            {
                Application.OpenURL("https://unitylist.com/p/5c3/Unity-editor-icons");
            }
            EditorGUILayout.LabelField(stringCollection.t_CategoryDescription[catagoryIndex], descriptiveStyle); 
            EditorGUILayout.Space(10);
            
            Icons();
        }
    }
    void EditorGUILayoutNavigationTabs()
    {
        using (new EditorGUILayout.VerticalScope())
        {
            EditorGUILayout.Space(5);
            using (new EditorGUILayout.VerticalScope("helpbox"))
            {
                navigationIndex = GUILayout.SelectionGrid(navigationIndex, stringCollection.n_EGLTabs, 2);
                
                //When not on tab "All"
                if (navigationIndex != 5)
                {
                    EditorGUILayout.Space(2);

                    GUILayout.BeginHorizontal("helpbox");
                    GUILayout.FlexibleSpace();

                    #region Navigation Types
                        //Show all items involved with single numbers
                        if (navigationIndex == 0 || navigationIndex == 2 || navigationIndex == 4)
                        {
                            numberValueItems = GUILayout.Toggle(numberValueItems, "Number Items");
                        }
                        EditorGUILayout.Space(4);

                        //Show all items involved with bools
                        if (navigationIndex == 1 || navigationIndex == 2)
                        {
                            boolItems = GUILayout.Toggle(boolItems, "Bool Items");
                        }
                        EditorGUILayout.Space(4);

                        //Show all items involved with strings
                        if (navigationIndex == 1 || navigationIndex == 2)
                        {
                            stringItems = GUILayout.Toggle(stringItems, "String Items");
                        }
                        EditorGUILayout.Space(4);

                        //Show all items involved with enums
                        if (navigationIndex == 2)
                        {
                            enumItems = GUILayout.Toggle(enumItems, "Enum Items");
                        }
                        EditorGUILayout.Space(2);

                        //Show all items involved with vectors
                        if (navigationIndex == 2 || navigationIndex == 3 || navigationIndex == 4)
                        {
                            vectorItems = GUILayout.Toggle(vectorItems, "Vector Items");
                        }
                        EditorGUILayout.Space(4);

                        //Show all items involved with uniqueProperties
                        if (navigationIndex == 0 || navigationIndex == 1 || navigationIndex == 3)
                        {
                            uniquePropertiesItems = GUILayout.Toggle(uniquePropertiesItems, "Unique Properties Items");
                        }
                        #endregion

                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();
                    EditorGUILayout.Space(2);
                }
                //When on tab "All"
                else
                {
                    EditorGUILayout.Space(2);

                    GUILayout.BeginHorizontal();
                    GUILayout.FlexibleSpace();

                    //Tab tags
                    using (new EditorGUILayout.VerticalScope("helpbox"))
                    {
                                //Navigation Utility
                                useNavigationUtility = GUILayout.Toggle(useNavigationUtility, "Navigation Utility",largeButtonStyle);
                            
                                //Display Fields
                                useDisplayFields = GUILayout.Toggle(useDisplayFields, "Display Fields", largeButtonStyle);
                            
                                //Value Fields
                                useValueFields = GUILayout.Toggle(useValueFields, "Value Fields", largeButtonStyle);
                            
                                //Advanced Value Fields
                                useAdvnacedValueFields = GUILayout.Toggle(useAdvnacedValueFields, "Advanced Value Fields", largeButtonStyle);
                            
                                //Sliders
                                useSliders = GUILayout.Toggle(useSliders, "Sliders", largeButtonStyle);

                    }

                    //Type tags
                    if (useNavigationUtility || useDisplayFields || useValueFields || useAdvnacedValueFields || useSliders) 
                    {
                            using (new EditorGUILayout.VerticalScope("helpbox"))
                            {
                                //Show all items involved with single numbers
                                if (useNavigationUtility || useValueFields || useSliders)
                                {
                                    numberValueItems = GUILayout.Toggle(numberValueItems, "Number Items");
                                }

                                //Show all items involved with bools
                                if (useDisplayFields ||useValueFields)
                                {
                                    boolItems = GUILayout.Toggle(boolItems, "Bool Items");
                                }

                                //Show all items involved with strings
                                if (useDisplayFields ||useValueFields)
                                {
                                    stringItems = GUILayout.Toggle(stringItems, "String Items");
                                }

                                //Show all items involved with enums
                                if (useValueFields)
                                {
                                    enumItems = GUILayout.Toggle(enumItems, "Enum Items");
                                }

                                //Show all items involved with vectors
                                if (useValueFields || useAdvnacedValueFields || useSliders)
                                {
                                    vectorItems = GUILayout.Toggle(vectorItems, "Vector Items");
                                }

                                //Show all items involved with uniqueProperties
                                if (useNavigationUtility || useDisplayFields || useAdvnacedValueFields)
                                {
                                    uniquePropertiesItems = GUILayout.Toggle(uniquePropertiesItems, "Unique Properties Items");
                                }
                            }
                    }
                    
                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();
                    
                    EditorGUILayout.Space(2);
                }
            }
        }

        EditorGUILayout.Space(20);
    }
    void GUIStyleNavigationTabs()
    {
        GUILayout.BeginHorizontal("helpbox");
        GUILayout.FlexibleSpace();
        
        labelFieldItems = GUILayout.Toggle(labelFieldItems,"Labels", mediumButtonStyle);
        EditorGUILayout.Space(10);
        buttonFieldItems = GUILayout.Toggle(buttonFieldItems, "Buttons", mediumButtonStyle);
        EditorGUILayout.Space(10);
        variableField = GUILayout.Toggle(variableField, "Other", mediumButtonStyle);
            
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
    }
    
    #endregion

    #region EditorGUILayout

    void NavigationUtilities()
    {
        if (navigationIndex == 0 && numberValueItems ||
            navigationIndex == 0 && uniquePropertiesItems ||
            navigationIndex == 5 && numberValueItems && useNavigationUtility ||
            navigationIndex == 5 && uniquePropertiesItems && useNavigationUtility)
        {
            EditorGUILayout.LabelField("Navigation Utility", subTitleStyle);

            using (new GUILayout.VerticalScope("helpbox"))
            {
                //Selection Grid
                if (numberValueItems)
                {
                    GUILayout.BeginHorizontal("box");
                    MakeLayoutButtons(0);

                    GUILayout.Space(155);

                    using (new EditorGUILayout.VerticalScope())
                    {
                        EditorGUILayout.LabelField("Selection Grid");
                        testSelectionGridIndex =
                            GUILayout.SelectionGrid(testSelectionGridIndex, stringCollection.t_ItemString, 3);
                    }

                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();

                    EditorGUILayout.Space(5);
                }

                //Toolbar
                if (numberValueItems)
                {
                    GUILayout.BeginHorizontal("box");
                    MakeLayoutButtons(1);
                    GUILayout.Space(155);

                    using (new EditorGUILayout.VerticalScope())
                    {
                        EditorGUILayout.LabelField("Toolbar");
                        testToolbarIndex = GUILayout.Toolbar(testToolbarIndex, stringCollection.t_ItemString);
                    }

                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();

                    EditorGUILayout.Space(5);
                }

                //Scroll View
                if (uniquePropertiesItems)
                {
                    GUILayout.BeginHorizontal("box");
                    MakeLayoutButtons(2);
                    GUILayout.Space(155);

                    using (new EditorGUILayout.VerticalScope())
                    {
                        EditorGUILayout.LabelField("Scroll View");
                        using (var scroll = new EditorGUILayout.ScrollViewScope(scrollPos, true, true))
                        {
                            scrollPos = scroll.scrollPosition;

                            using (new GUILayout.VerticalScope("window"))
                            {
                                for (int i = 0; i < 20; i++)
                                {
                                    EditorGUILayout.LabelField("Dummy Field");
                                }
                            }
                        }
                    }

                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();

                    EditorGUILayout.Space(5);
                }
            }

            EditorGUILayout.Space(10);
        }
    }

    void DisplayFields()
    {
         
        if (
            navigationIndex == 1 && stringItems ||
            navigationIndex == 1 && uniquePropertiesItems ||
            navigationIndex == 1 && boolItems ||
            navigationIndex == 5 && stringItems && useDisplayFields ||
            navigationIndex == 5 && uniquePropertiesItems && useDisplayFields  ||
            navigationIndex == 5 && boolItems && useDisplayFields )
        {
            EditorGUILayout.LabelField("Display Fields", subTitleStyle);
            using (new GUILayout.VerticalScope("helpbox"))
            {
                //Label Field
                if (stringItems)
                {
                    GUILayout.BeginHorizontal("box");

                    #region Content

                    MakeLayoutButtons(3);
                    GUILayout.Space(155);
                    EditorGUILayout.LabelField("Label Field");

                    #endregion

                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();

                    EditorGUILayout.Space(5);
                }

                //Foldout
                if (boolItems)
                {
                    GUILayout.BeginHorizontal("box");

                    #region Content

                    MakeLayoutButtons(4);
                    GUILayout.Space(155);
                    using (new EditorGUILayout.VerticalScope())
                    {
                        showFoldout = EditorGUILayout.Foldout(showFoldout, "Foldout");
                        if (showFoldout)
                        {
                            EditorGUILayout.LabelField("Foldout it is open");
                        }
                    }
                    #endregion

                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();

                    EditorGUILayout.Space(5);
                }

                //Help Box
                if (uniquePropertiesItems)
                {
                    GUILayout.BeginHorizontal("box");
                    MakeLayoutButtonsMultiple(0, 4, new[] {"None", "Info", "Warning", "Error",});
                    
                    GUILayout.Space(155);

                    using (new EditorGUILayout.VerticalScope())
                    {
                        EditorGUILayout.HelpBox("Help Box (None)\n", MessageType.None, true);
                        EditorGUILayout.HelpBox("Help Box (Info)", MessageType.Info, true);
                        EditorGUILayout.HelpBox("Help Box (Warning)", MessageType.Warning, true);
                        EditorGUILayout.HelpBox("Help Box (Error)", MessageType.Error, true);
                    }

                    EditorGUILayout.Space(5);

                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();
                }
            }

            EditorGUILayout.Space(10);
        }
    }

    void ValueFields()
    {
        if (navigationIndex == 2 && numberValueItems ||
            navigationIndex == 2 && vectorItems ||
            navigationIndex == 2 && stringItems ||
            navigationIndex == 2 && enumItems ||
            navigationIndex == 2 && boolItems ||
            navigationIndex == 5 && numberValueItems && useValueFields||
            navigationIndex == 5 && vectorItems && useValueFields ||
            navigationIndex == 5 && stringItems && useValueFields ||
            navigationIndex == 5 && enumItems && useValueFields ||
            navigationIndex == 5 && boolItems && useValueFields)
        {
            EditorGUILayout.LabelField("Value Fields", subTitleStyle);
            using (new GUILayout.VerticalScope("helpbox"))
            {
                //Int/Float/Doubles
                if (numberValueItems)
                {
                    #region Int

                    GUILayout.BeginHorizontal("box");

                    MakeLayoutButtons(5);
                    GUILayout.Space(155);

                    using (new GUILayout.VerticalScope())
                    {
                        EditorGUILayout.LabelField("IntField");
                        testInt = EditorGUILayout.IntField(testInt);
                    }

                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();

                    GUILayout.Space(10);

                    #endregion

                    #region Float

                    GUILayout.BeginHorizontal("box");

                    MakeLayoutButtons(6);
                    GUILayout.Space(155);

                    using (new GUILayout.VerticalScope())
                    {
                        EditorGUILayout.LabelField("Float Field");
                        testFloat = EditorGUILayout.FloatField(testFloat);
                    }

                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();

                    GUILayout.Space(10);

                    #endregion

                    #region Double

                    GUILayout.BeginHorizontal("box");

                    MakeLayoutButtons(7);
                    GUILayout.Space(155);

                    using (new GUILayout.VerticalScope())
                    {
                        EditorGUILayout.LabelField("Double Field");
                        testDouble = EditorGUILayout.DoubleField(testDouble);
                    }

                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();

                    GUILayout.Space(10);

                    #endregion
                }

                //Vector Fields
                if (vectorItems)
                {
                    #region Vector 2
                    GUILayout.BeginHorizontal("box");
                    
                    MakeLayoutButtons(8);
                    GUILayout.Space(155);

                    using (new GUILayout.VerticalScope())
                    {
                        EditorGUILayout.LabelField("Vector 2 Field");
                        testVector2 = EditorGUILayout.Vector2Field("", testVector2);
                    }

                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();

                    GUILayout.Space(5);

                    #endregion

                    #region Vector 3

                    GUILayout.BeginHorizontal("box");
                    MakeLayoutButtons(9);
                    GUILayout.Space(155);

                    using (new GUILayout.VerticalScope())
                    {
                        EditorGUILayout.LabelField("Vector 3 Field");
                        testVector3 = EditorGUILayout.Vector3Field("", testVector3);
                    }

                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();

                    GUILayout.Space(5);

                    #endregion

                    #region Vector 4

                    GUILayout.BeginHorizontal("box");
                    MakeLayoutButtons(10);

                    GUILayout.Space(155);

                    using (new GUILayout.VerticalScope())
                    {
                        EditorGUILayout.LabelField("Vector 4 Field");
                        testVector4 = EditorGUILayout.Vector4Field("", testVector4);
                    }

                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();

                    EditorGUILayout.Space(5);

                    #endregion
                }

                //Text Area
                if (stringItems)
                {
                    GUILayout.BeginHorizontal("box");

                    MakeLayoutButtons(11);
                    GUILayout.Space(155);

                    using (new EditorGUILayout.VerticalScope())
                    {
                        EditorGUILayout.LabelField("Text Area");
                        testString = EditorGUILayout.TextArea(testString);
                    }

                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();

                    EditorGUILayout.Space(5);
                }

                //Toggle
                if (boolItems)
                {
                    GUILayout.BeginHorizontal("box");

                    MakeLayoutButtons(12);
                    GUILayout.Space(155);

                    using (new GUILayout.VerticalScope())
                    {
                        EditorGUILayout.LabelField("Toggle");
                        testToogle = EditorGUILayout.Toggle(testToogle);
                    }

                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();

                    EditorGUILayout.Space(5);
                }

                //Button
                if (boolItems)
                {
                    GUILayout.BeginHorizontal("box");

                    MakeLayoutButtons(13);
                    GUILayout.Space(155);

                    using (new EditorGUILayout.VerticalScope())
                    {
                        EditorGUILayout.LabelField("Button");
                        GUILayout.Button("New Button", mediumButtonStyle);
                    }

                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();

                    EditorGUILayout.Space(5);
                }

                //Enum Popup
                if (enumItems)
                {
                    GUILayout.BeginHorizontal("box");

                    MakeLayoutButtons(14);
                    GUILayout.Space(155);
                    using (new EditorGUILayout.VerticalScope())
                    {
                        EditorGUILayout.LabelField("Enum Popup Field");
                        testEnum = (TestEnum) EditorGUILayout.EnumPopup(testEnum, mediumPopupStyle);
                    }

                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();

                    EditorGUILayout.Space(5);
                }

                //Enum Flag Field
                if (enumItems)
                {
                    GUILayout.BeginHorizontal("box");

                    MakeLayoutButtons(15);
                    GUILayout.Space(155);

                    using (new EditorGUILayout.VerticalScope())
                    {
                        EditorGUILayout.LabelField("Enum Flags Field");
                        flagEnum = (FlagTestEnum) EditorGUILayout.EnumFlagsField(flagEnum, mediumPopupStyle);
                    }

                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();

                    EditorGUILayout.Space(5);
                }

                //Layer Field
                if (enumItems)
                {
                    GUILayout.BeginHorizontal("box");

                    MakeLayoutButtons(16);
                    GUILayout.Space(155);

                    using (new EditorGUILayout.VerticalScope())
                    {
                        EditorGUILayout.LabelField("Layer Field");
                        testLayerFieldInt = EditorGUILayout.LayerField(testLayerFieldInt, mediumPopupStyle);
                    }

                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();

                    EditorGUILayout.Space(5);
                }

                //Mask Field
                if (enumItems)
                {
                    GUILayout.BeginHorizontal("box");

                    MakeLayoutButtons(17);
                    GUILayout.Space(155);

                    using (new EditorGUILayout.VerticalScope())
                    {
                        EditorGUILayout.LabelField("Mask Field");
                        testMaskLayerFieldInt = EditorGUILayout.MaskField(testMaskLayerFieldInt,
                            stringCollection.t_ItemString, mediumPopupStyle);
                    }
                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();

                    EditorGUILayout.Space(5);
                }
            }
        }

        EditorGUILayout.Space(10);
    }

    void AdvancedField()
    {
        if (navigationIndex == 3 && vectorItems ||
            navigationIndex == 3 && uniquePropertiesItems ||
            navigationIndex == 5 && vectorItems && useAdvnacedValueFields ||
            navigationIndex == 5 && uniquePropertiesItems && useAdvnacedValueFields)
        {
            EditorGUILayout.LabelField("Advanced Value Fields", subTitleStyle);
            using (new GUILayout.VerticalScope("helpbox"))
            {
                //Bounds
                if (vectorItems)
                {
                    GUILayout.BeginHorizontal("box");

                    MakeLayoutButtons(18);
                    GUILayout.Space(155);
                    testBounds = EditorGUILayout.BoundsField("Bounds", testBounds);

                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();

                    EditorGUILayout.Space(5);
                }

                //Rect Field
                if (vectorItems)
                {
                    GUILayout.BeginHorizontal("box");

                    MakeLayoutButtons(19);
                    GUILayout.Space(155);
                    testRect = EditorGUILayout.RectField("Rect Field", testRect);

                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();

                    EditorGUILayout.Space(5);
                }

                //Color Field
                if (vectorItems)
                {
                    GUILayout.BeginHorizontal("box");

                    MakeLayoutButtons(20);
                    GUILayout.Space(155);

                    using (new EditorGUILayout.VerticalScope())
                    {
                        EditorGUILayout.LabelField("Color Field");
                        testColorValue = EditorGUILayout.ColorField(testColorValue);
                    }

                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();

                    EditorGUILayout.Space(5);
                }

                //Gradient Field
                if (uniquePropertiesItems)
                {
                    GUILayout.BeginHorizontal("box");

                    MakeLayoutButtons(21);
                    GUILayout.Space(155);

                    using (new EditorGUILayout.VerticalScope())
                    {
                        EditorGUILayout.LabelField("Gradient Field");
                        testGradient = EditorGUILayout.GradientField(testGradient);
                    }

                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();

                    EditorGUILayout.Space(5);
                }

                //Curve Field
                if (uniquePropertiesItems)
                {
                    GUILayout.BeginHorizontal("box");

                    MakeLayoutButtons(22);
                    GUILayout.Space(155);
                    using (new EditorGUILayout.VerticalScope())
                    {
                        EditorGUILayout.LabelField("Curve Field");
                        testAnimationCurve = EditorGUILayout.CurveField(testAnimationCurve);
                    }

                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();

                    EditorGUILayout.Space(5);
                }

                //Object Field
                if (uniquePropertiesItems)
                {
                    GUILayout.BeginHorizontal("box");
                    MakeLayoutButtons(23);

                    GUILayout.Space(155);
                    using (new EditorGUILayout.VerticalScope())
                    {
                        EditorGUILayout.LabelField("Object Field");
                        EditorGUILayout.ObjectField(testObject, typeof(Object), true);
                    }

                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();

                    EditorGUILayout.Space(5);
                }
            }
        }

        EditorGUILayout.Space(10);
    }

    void Sliders()
    {
        if (navigationIndex == 4 && numberValueItems ||
            navigationIndex == 4 && vectorItems ||
            navigationIndex == 5 && numberValueItems && useSliders ||
            navigationIndex == 5 && vectorItems && useSliders)
        {
            EditorGUILayout.LabelField("Sliders", subTitleStyle);
            using (new GUILayout.VerticalScope("helpbox"))
            {
                //Knob
                if (numberValueItems)
                {
                    GUILayout.BeginHorizontal("box");
                    MakeLayoutButtons(24);
                    GUILayout.Space(155);

                    using (new EditorGUILayout.VerticalScope())
                    {
                        EditorGUILayout.LabelField("Knob");
                        testKnobFloat = EditorGUILayout.Knob(
                            new Vector2(50, 50), testKnobFloat, 0, 10, "'Unit'",
                            Color.black, Color.white, true);
                    }

                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();
                    EditorGUILayout.Space(5);
                }

                //Slider
                if (numberValueItems)
                {
                    GUILayout.BeginHorizontal("box");
                    MakeLayoutButtons(25);
                    GUILayout.Space(155);
                    using (new EditorGUILayout.VerticalScope())
                    {
                        EditorGUILayout.LabelField("Slider");
                        testSliderFloat = EditorGUILayout.Slider(testSliderFloat, 0, 10);
                    }

                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();

                    EditorGUILayout.Space(5);
                }

                //Max Min Slider
                if (vectorItems)
                {
                    using (new GUILayout.HorizontalScope("box"))
                    {
                        GUILayout.BeginHorizontal();
                        MakeLayoutButtons(26);
                        GUILayout.Space(155);

                        using (new EditorGUILayout.VerticalScope())
                        {
                            EditorGUILayout.LabelField("Min Max Slider");
                            EditorGUILayout.MinMaxSlider(ref minMaxSliderValue.x, ref minMaxSliderValue.y,
                                0, 10);
                            EditorGUILayout.LabelField(minMaxSliderValue.ToString());
                        }

                        GUILayout.FlexibleSpace();
                        GUILayout.EndHorizontal();
                    }

                    EditorGUILayout.Space(5);
                }
            }
        }

        EditorGUILayout.Space(10);
    }

    
    #endregion

    #region GUIStyle

    void LabelFields()
    {
        EditorGUILayout.LabelField("Label Styles", subTitleStyle);

        using (new EditorGUILayout.VerticalScope("helpbox"))
        {
            #region Label

            GUILayout.BeginHorizontal("box");

            MakeStyleTemplateButton(2);
            EditorGUILayout.LabelField("Label", new GUIStyle(EditorStyles.label));
            
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();


            #endregion
            
            #region Bold Label
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(1);
            EditorGUILayout.LabelField("Bold Label", new GUIStyle(EditorStyles.boldLabel));
            
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion
            
            #region Large Label
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(2);
            EditorGUILayout.LabelField("Large Label", new GUIStyle(EditorStyles.largeLabel));
            
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion
            
            EditorGUILayout.Space(5);
        }

        EditorGUILayout.Space(5);
        
        using (new EditorGUILayout.VerticalScope("helpbox"))
        {
            #region Min Label
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(3);
            EditorGUILayout.LabelField("Min Label", new GUIStyle(EditorStyles.miniLabel));
            
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion
            
            #region Mini Bold Label
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(4);
            EditorGUILayout.LabelField("Mini Bold Label", new GUIStyle(EditorStyles.miniBoldLabel));

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion
            
            #region White Mini Label
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(5);
            EditorGUILayout.LabelField("White Mini Label", new GUIStyle(EditorStyles.whiteMiniLabel));

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion
            
            EditorGUILayout.Space(5);
        }
        
        EditorGUILayout.Space(5);

        using (new EditorGUILayout.VerticalScope("helpbox"))
        {
            #region White Label
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(6);
            EditorGUILayout.LabelField("White Label", new GUIStyle(EditorStyles.whiteLabel));

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion

            #region White Bold Label
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(7);
            EditorGUILayout.LabelField("White Bold Label", new GUIStyle(EditorStyles.whiteBoldLabel));

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion
            
            #region White Large Label
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(8);
            EditorGUILayout.LabelField("White Large Label", new GUIStyle(EditorStyles.whiteLargeLabel));

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion

            EditorGUILayout.Space(5);
        }
        
        EditorGUILayout.Space(5);

        using (new EditorGUILayout.VerticalScope("helpbox"))
        {
            #region Word Wrapped Label
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(9);
            EditorGUILayout.LabelField("Word Wrapped Label (Auto-wraping)", new GUIStyle(EditorStyles.wordWrappedLabel));
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion

            #region Linked Label
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(10);
            EditorGUILayout.LabelField("Linked Label", new GUIStyle(EditorStyles.linkLabel));
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion
            
            #region Centered Gray Mini Label
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(11);
            EditorGUILayout.LabelField("Centered Gray Mini Label", new GUIStyle(EditorStyles.centeredGreyMiniLabel));
            GUILayout.EndHorizontal();
            #endregion
            
            EditorGUILayout.Space(5);
        }
        
        EditorGUILayout.Space(5);

        using (new EditorGUILayout.VerticalScope("helpbox"))
        {
            #region Word Wrapped Label
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(12);
            EditorGUILayout.LabelField("Help Box", new GUIStyle(EditorStyles.helpBox));
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion

            #region Toolbar
            GUILayout.BeginHorizontal();
            
            MakeStyleTemplateButton(13);
            EditorGUILayout.LabelField("Toolbar", new GUIStyle(EditorStyles.toolbar));
            
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion
            
            EditorGUILayout.Space(5);
        }
        
        EditorGUILayout.Space(5);
    }

    void ButtonFields()
    {
        EditorGUILayout.LabelField("Button Styles", subTitleStyle);
        using (new EditorGUILayout.VerticalScope("Helpbox"))
        {
            #region Toggle
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(14);
            GUILayout.Toggle(false, "", new GUIStyle(EditorStyles.toggle));
            GUILayout.Toggle(true, "Toggle", new GUIStyle(EditorStyles.toggle));

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion
            
            #region Toggle Group
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(15);
            GUILayout.Toggle(false, "", new GUIStyle(EditorStyles.toggleGroup));
            GUILayout.Toggle(true, "Toggle Group", new GUIStyle(EditorStyles.toggleGroup));
            
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion
            
            #region Radio Button
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(16);
            GUILayout.Toggle(false, "", new GUIStyle(EditorStyles.radioButton));
            GUILayout.Toggle(true, " Radio Button", new GUIStyle(EditorStyles.radioButton));

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion
            
            EditorGUILayout.Space(5);
        }
        
        EditorGUILayout.Space(5);

        using (new EditorGUILayout.VerticalScope("Helpbox"))
        {
            #region Foldout
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(17);
            EditorGUILayout.LabelField("Foldout", new GUIStyle(EditorStyles.foldout));

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion

            #region Foldout Header
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(18);
            EditorGUILayout.LabelField("Foldout Header", new GUIStyle(EditorStyles.foldoutHeader));

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion
            
            #region Popup
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(19);
            EditorGUILayout.LabelField("Popup", new GUIStyle(EditorStyles.popup));

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion
            
            #region Mini Pull Down
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(20);
            EditorGUILayout.LabelField("Mini Pull Down", new GUIStyle(EditorStyles.miniPullDown));

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion

            #region Layer Mask Field
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(21);
            EditorGUILayout.LabelField("Layer Mask Field", new GUIStyle(EditorStyles.layerMaskField));

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion
            
            EditorGUILayout.Space(5);
        }
        
        EditorGUILayout.Space(5);

        using (new EditorGUILayout.VerticalScope("Helpbox"))
        {
            #region Mini Button Left
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(22);
            EditorGUILayout.LabelField("Mini Button Left", new GUIStyle(EditorStyles.miniButtonLeft));

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion

            #region Mini Button Mid
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(23);
            EditorGUILayout.LabelField("Mini Button Mid", new GUIStyle(EditorStyles.miniButtonMid));

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion

            #region Min Button Right
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(24);
            EditorGUILayout.LabelField("Min Button Right", new GUIStyle(EditorStyles.miniButtonRight));

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion

            #region Min Button
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(25);
            EditorGUILayout.LabelField("Min Button", new GUIStyle(EditorStyles.miniButton));
            
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion
            
            EditorGUILayout.Space(5);
        }
        
        EditorGUILayout.Space(5);

        using (new EditorGUILayout.VerticalScope("Helpbox"))
        {
            #region Toolbar Drop Down
            GUILayout.BeginHorizontal();
            
            MakeStyleTemplateButton(26);
            EditorGUILayout.LabelField("Toolbar Drop Down", new GUIStyle(EditorStyles.toolbarDropDown));

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion

            EditorGUILayout.Space(5);

            #region Toolbar Button
            GUILayout.BeginHorizontal();
            
            MakeStyleTemplateButton(27);
            EditorGUILayout.LabelField("Toolbar Button", new GUIStyle(EditorStyles.toolbarButton));

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion
            
            EditorGUILayout.Space(5);
        }
    }

    void VariableFields()
    {
        EditorGUILayout.LabelField("Variable Styles", subTitleStyle);

        using (new GUILayout.VerticalScope("helpbox"))
        {
            #region Color Field
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(28);
            EditorGUILayout.LabelField("Color Field", new GUIStyle(EditorStyles.colorField));

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion
            
            #region Object Field Mini Thumb
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(29);
            EditorGUILayout.LabelField("\tObject Field Mini Thumb", new GUIStyle(EditorStyles.objectFieldMiniThumb));

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion
            
            #region Object Field Thumb
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(30);
            EditorGUILayout.LabelField("Object Field Thumb", new GUIStyle(EditorStyles.objectFieldThumb));

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion
            
            EditorGUILayout.Space(5);
        }

        EditorGUILayout.Space(5);

        using (new GUILayout.VerticalScope("helpbox"))
        {
            #region Number Field
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(31);
            EditorGUILayout.LabelField("Number Field", new GUIStyle(EditorStyles.numberField));
            
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion

            #region Object Field
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(32);
            EditorGUILayout.LabelField("Object Field", new GUIStyle(EditorStyles.objectField));

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion
            
            #region Text Area
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(33);
            EditorGUILayout.LabelField("Text Area", new GUIStyle(EditorStyles.textArea));

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion
            
            #region Mini Text Field
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(34);
            EditorGUILayout.LabelField("Mini Text Field", new GUIStyle(EditorStyles.miniTextField));

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion
            
            #region Text Field
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(35);
            EditorGUILayout.LabelField("Text Field", new GUIStyle(EditorStyles.textField));

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion
            
            #region Toolbar Text Field
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(36);
            EditorGUILayout.LabelField("Toolbar Text Field", new GUIStyle(EditorStyles.toolbarTextField));

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion
            
            #region Toolbar Search Field
            GUILayout.BeginHorizontal("box");
            
            MakeStyleTemplateButton(37);
            EditorGUILayout.LabelField("Toolbar Search Field", new GUIStyle(EditorStyles.toolbarSearchField));

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            #endregion
            
            EditorGUILayout.Space(5);
        }
    }
    
    #endregion

    void Icons()
    {
        #region Icon Collections

        GUILayout.BeginHorizontal("helpbox");
        GUILayout.FlexibleSpace();
        
        using (new EditorGUILayout.VerticalScope())
        {
            #region Objects

            objectIconsItems =
                GUILayout.Toggle(objectIconsItems, "Objects", mediumButtonStyle);

            #endregion

            #region Platforms

            platformIconsItems = 
                GUILayout.Toggle(platformIconsItems, "Platforms", mediumButtonStyle);

            #endregion

            #region Paint

            paintIconsItems = 
                GUILayout.Toggle(paintIconsItems, "Paint", mediumButtonStyle);

            #endregion
        }
        
        using (new EditorGUILayout.VerticalScope())
        {
            #region Video

            videoIconItems = 
                GUILayout.Toggle(videoIconItems, "Video", mediumButtonStyle);

            #endregion

            #region Settings

            windowExtensionItems = 
                GUILayout.Toggle(windowExtensionItems, "Settings", mediumButtonStyle);

            #endregion

            #region Console Signs

            warningErrorItems = 
                GUILayout.Toggle(warningErrorItems, "Console Signs", mediumButtonStyle);

            #endregion
        }

        using (new EditorGUILayout.VerticalScope())
        {
            #region Unity Editor

            unityEditorItems = 
                GUILayout.Toggle(unityEditorItems, "Unity Editor", mediumButtonStyle);

            #endregion
            
            #region Profiler

            profilerItems = 
                GUILayout.Toggle(profilerItems, "Profiler", mediumButtonStyle);

            #endregion
            
            #region Misc

            miscItems = 
                GUILayout.Toggle(miscItems, "Misc", mediumButtonStyle);

            #endregion
        }
        
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        #endregion

        using (var scrollValue = new EditorGUILayout.ScrollViewScope(iconScrollPos,false, true))
        {
            iconScrollPos = scrollValue.scrollPosition;

            if (objectIconsItems)
            {
                MakeIconCollection(0,3, "Objects");
                EditorGUILayout.Space(10);
            }
            if (platformIconsItems)
            {
                MakeIconCollection(4,16, "Build Platforms");
                EditorGUILayout.Space(10);
            }
            if (paintIconsItems)
            {
                MakeIconCollection(17,28, "Paint Icons");
                EditorGUILayout.Space(10);
            }
            if (videoIconItems)
            {
                MakeIconCollection(29,42, "Video Icons");
                EditorGUILayout.Space(10);
            }
            if (windowExtensionItems)
            {
                MakeIconCollection(43,60, "Settings");
                EditorGUILayout.Space(10);
            }
            if (warningErrorItems)
            {
                MakeIconCollection(61,72, "Console Signs");
                EditorGUILayout.Space(10);
            }
            if (unityEditorItems)
            {
                MakeIconCollection(73,79, "Unity Editor Icons");
                EditorGUILayout.Space(10);
            }
            if (profilerItems)
            {
                MakeIconCollection(80,87, "Profiler Icons");
                EditorGUILayout.Space(10);
            }
            if (miscItems)
            {
                MakeIconCollection(88,96, "Misc");
                EditorGUILayout.Space(10);
            }
        }

    }

    #region Utility Functions
    
    void GUIStyleConstructor()
    {
        subTitleStyle = new GUIStyle(EditorStyles.boldLabel)
        {
            fontStyle = FontStyle.BoldAndItalic, fontSize = 15
        };

        titleStyle = new GUIStyle(EditorStyles.boldLabel)
        {
            fontSize = 25,
            fixedHeight = 28,
        };

        copyButton = new GUIStyle(EditorStyles.miniButton)
        {
            fontStyle = FontStyle.Bold,
            fixedWidth = 120
        };

        docLinkStyle = new GUIStyle(EditorStyles.miniButton)
        {
            fontStyle = FontStyle.Italic,
            fixedWidth = 50
        };

        mediumButtonStyle = new GUIStyle(EditorStyles.miniButtonMid)
        {
            fixedWidth = 100,
        };

        mediumPopupStyle = new GUIStyle(EditorStyles.popup)
        {
            fixedWidth = 120,
        };

        largeButtonStyle = new GUIStyle(EditorStyles.miniButton)
        {
            fontStyle = FontStyle.Bold,
            fixedWidth = 150,
        };

        descriptiveStyle = new GUIStyle(EditorStyles.label)
        {
            fontStyle = FontStyle.Italic,
            wordWrap = true,
            
        };

        smallButtonStyle = new GUIStyle(EditorStyles.miniButtonLeft)
        {
            fixedWidth = 50,
        };
    }

    void CopyToClipboard(string textToCopy)
    {
        textEditor.text = textToCopy;
        textEditor.SelectAll();
        textEditor.Copy();
    }

    /// <summary>
    /// Creates two buttons.
    /// <para>- Button one will copy the code sample to the clipboard for easy implementation</para>
    /// <para>- Button two will open a web URL referring to Unity's own documentation</para>
    /// </summary>
    /// <param name="index">The index of the code sample and documentation URL string arrays</param>
    void MakeLayoutButtons(int index)
    {
        using (new EditorGUILayout.VerticalScope())
        {
            //Copy the code to clipboard
            if (GUILayout.Button("Copy Template", copyButton) && stringCollection.d_SingleCodeTemplate.Length >= index)
                CopyToClipboard(stringCollection.d_SingleCodeTemplate[index]);

            //Open documentation
            if (GUILayout.Button(EditorGUIUtility.IconContent("Profiler.GlobalIllumination@2x").image, docLinkStyle))
            {
                if (index < stringCollection.d_DocURLSingle.Length || stringCollection.d_DocURLSingle[index] != "")
                    Application.OpenURL(stringCollection.d_DocURLSingle[index]);
                else
                    EditorUtility.DisplayDialog("Documentation Not Found",
                        "Documentation for this object is not available.\n\n" +
                        "Try searching for the object on your internet browser in case the object is not implemented.",
                        "Close");
            }
        }
    }

    /// <summary>
    /// Creates two buttons.
    /// <para>- Button one will copy the code sample to the clipboard for easy implementation</para>
    /// <para>- Button two will open a web URL referring to Unity's own documentation</para>
    /// </summary>
    /// <param name="index">The index of the code sample and documentation URL string arrays</param>
    /// <param name="copyCount">How Many copy templates should show</param>
    /// <param name="itemNames">Specific sames</param>
    void MakeLayoutButtonsMultiple(int index, int copyCount, string[] itemNames)
    {
        using (new EditorGUILayout.VerticalScope())
        {
            //Open documentation
            for (int i = 0; i < copyCount; i++)
            {
                using (new GUILayout.HorizontalScope())
                {
                    if (GUILayout.Button(itemNames[i] + " Template", copyButton))
                    {
                        if (index < stringCollection.d_CodeTemplateMultible.Length || stringCollection.d_CodeTemplateMultible[index + i] != "")
                            CopyToClipboard(stringCollection.d_CodeTemplateMultible[index + i]);
                        else
                            EditorUtility.DisplayDialog("Documentation Not Found",
                                "Documentation for this object is not available.\n\n" +
                                "Try searching for the object on your internet browser in case the object is not implemented.",
                                "Close");
                    }
                }
            }
            EditorGUILayout.Space(5);

            //Copy the code to clipboard
            if (GUILayout.Button(EditorGUIUtility.IconContent("Profiler.GlobalIllumination@2x").image, docLinkStyle)
                && stringCollection.d_DocURLMultible.Length >= index)
                Application.OpenURL(stringCollection.d_DocURLMultible[index]);
        }
    }

    void MakeStyleTemplateButton(int index)
    {
        //Copy the code to clipboard
        if (GUILayout.Button("Copy Template", copyButton))
        {
            CopyToClipboard(stringCollection.d_GUIStyleTemplate[index]);
        }
    }

    void MakeIconCollection(int startIndex, int endIndex, string collectionName)
    {
        EditorGUILayout.LabelField(collectionName, subTitleStyle);
        for (int i = startIndex; i < endIndex +1; i++)
        {
            GUILayout.BeginHorizontal("helpbox");

            GUILayout.Label(EditorGUIUtility.IconContent($"{stringCollection.d_IconNamesBigAndSmall[i]}@2x"));
            GUILayout.Label(EditorGUIUtility.IconContent(stringCollection.d_IconNamesBigAndSmall[i]));
            GUILayout.Space(10);

            using (new EditorGUILayout.VerticalScope())
            {
                GUILayout.Label($"{stringCollection.d_IconNamesBigAndSmall[i]} ({i})");
                using (new EditorGUILayout.HorizontalScope())
                {
                    if (GUILayout.Button("BIG", smallButtonStyle))
                    {
                        CopyToClipboard("EditorGUIUtility.IconContent" +
                                        $"({stringCollection.d_IconNamesBigAndSmall[i]}@2x),");
                    }
                    if (GUILayout.Button("SMALL", smallButtonStyle))
                    {
                        CopyToClipboard("EditorGUIUtility.IconContent" +
                                        $"({stringCollection.d_IconNamesBigAndSmall[i]}),");
                    }
                }
            }

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }
    }
    
    void PromoSutff()
    {
        EditorGUILayout.Space(2);
        if (GUILayout.Button("Made by Daniel Redelius 2022", new GUIStyle(EditorStyles.centeredGreyMiniLabel)))
        {
            Application.OpenURL("https://www.danielredelius.com");
        }
        EditorGUILayout.Space(2);
    }

    #endregion
}