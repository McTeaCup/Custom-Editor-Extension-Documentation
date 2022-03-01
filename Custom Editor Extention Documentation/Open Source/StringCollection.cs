#region Enum Collection

public enum TestEnum
{
    Item1,
    Item2,
    Item3,
    Item4,
    Item5,
    Item6,
    Item7,
    Item8,
}

public enum FlagTestEnum
{
    None,
    A,
    B,
    Ab,
}

#endregion

///<summary>A class containing all important strings</summary>
/// <param name="n_">Navigation</param>
/// <param name="t_">Temporary/Display purposes</param>
/// <param name="d_">Documentation/URL</param>
public class StringCollection
{
    public readonly string[] n_MainTabs =
        {"EditorGUILayout", "GUIStyle", "Icon"};

    public readonly string[] n_EGLTabs =
        {"Navigation Utility", "Display Fields", "Value Fields", "Advanced Value Fields", "Sliders", "All"};
    
    public readonly string[] t_ItemString =
        {"Item 1", "Item 2", "Item 3", "Item 4", "Item 5", "Item 6", "Item 7", "Item 8", "Item 9"};

    public readonly string[] t_CatagoryName =
    {"EditorGUILayout", "GUIStyle", "Icon"};
    
    public readonly string[] t_CategoryDescription =
    {
        //EditorGUILayout
        "EditorGUILayout properties have the ability to display and modify objects and variables. Depending on the variable, " +
        "different fields can be used to provide easy modification and/or display.\n\n Most items returns values of type: " +
        "int, float and bool, but can also return other unique values. " +
        "All fields will auto adjust to the window/inspector height and width automatically.",
        
        //GUIStyle
        "GUI styles can be used with any field, it is recommended to use an appropriate " +
        "style to much more clearly display what the field does for maximum clarity.\n\n" +
        "This is just a simple showcase to show of how the stiles look.",
        
        //Icon
        "These icons can be used in combinations with buttons in case text seem inappropriate or unwanted.\n\n" +
        "They can only fill the form of 'EditorGUIUtility.IconContent' which is only compatible with a few fields. " +
        "Check the documentation of the field to find out if the field is compatible with icons.",
    };
    
    #region Editor GUI Layout
    
    public readonly string[] d_SingleCodeTemplate = new[]
    {
        #region Navigation Utility

        //Selection Grid
        "GUILayout.SelectionGrid(/*Current tab selected (int), what each tab is called (string[]), Max tabs on one row (int)*/)",

        //Toolbar
        "GUILayout.Toolbar(/*current tab selected (int), what each tab is called (string[])*/)",

        //Scroll
        #region Scroll

        "Vector2 scrollPos;\n" +
        "using (var scrollValue = new EditorGUILayout.ScrollViewScope(scrollPos, /*Always Show Vertical Bar, Always Show Horizontal Bar*/))\n" +
        "{\n" +
        "\tscrollPos = scrollValue.scrollPosition;\n" +
        "}",

        #endregion

        #endregion

        #region Display Field
        
        "EditorGUILayout.LabelField(/*Display Text (string)*/);",                                               //Label
        "/*showFoldout*/ = EditorGUILayout.Foldout(/*showFoldout (bool), Optional foldout name (string)*/);",   //Fold Out
        
        #endregion

        #region Value Fields

        "EditorGUILayout.IntField(/*int Value (int)*/);",               //Int
        "EditorGUILayout.FloatField(/*float Value (float)*/);",         //Float        
        "EditorGUILayout.DoubleField(/*double Value (double)*/);",      //Double
        "EditorGUILayout.Vector2Field(/*Vector2 Value (Vector2)*/);",   //Vector2
        "EditorGUILayout.Vector3Field(/*Vector3 Value (Vector3)*/);",   //Vector3
        "EditorGUILayout.Vector4Field(/*Vector4 Value (Vector4)*/);",   //Vector4
        "EditorGUILayout.TextArea(/*text value (string)*/);",           //Text Area
        "EditorGUILayout.Toggle(/*Active Value (bool)*/);",             //Toggle
        
        #region Button
        "if(GUILayout.Button(/*Text on button (string)*/))\n"+
        "{\n"+
        "\t//Implement action in here\n"+
        "}",
        #endregion

        #region Enum Popup
        "//CREATING YOUR OWN ENUM TYPE IS REQUIRED!\n" +
        "/*Enum Value*/ = (/*Enum*/)EditorGUILayout.EnumPopup(/*Enum Value (Enum)*/);",
        #endregion
        
        #region Enum Flag
        "//CREATING YOUR OWN ENUM TYPE IS REQUIRED!\n" +
        "/*Enum Value*/ = (/*Enum*/)EditorGUILayout.EnumFlagsField(/*Enum Value (Enum)*/)",
        #endregion
        
        "EditorGUILayout.LayerField(/*Layer Value (int)*/);",
        
        "EditorGUILayout.MaskField(/*Mask Value (int)*/, /*Items in the enum (string[]*/);",
        #endregion

        #region Advanced Value Fields

        "EditorGUILayout.BoundsField(/*Bounds Value (Bounds)*/);",
        
        "EditorGUILayout.RectField(/*Rect Value (Rect)*/);",
        
        "EditorGUILayout.ColorField(/*Color Value (Color)*/);",
        
        "EditorGUILayout.GradientField(/*Gradient Value (Gradient)*/);",
        
        "EditorGUILayout.CurveField(/*Curve Value (AnimationCurve)*/);",
        
        "EditorGUILayout.ObjectField(/*Object Value (Can be any type)*/);",
        
        #endregion
        
        #region Sliders

        "EditorGUILayout.Knob(/*Knob Size (Vector2), Knob Value (float), Min Value (float), Max Value (float), Type of Unit (string), Background Color (Color), Fill Color (Color), Show unit (String)*/);",
        "EditorGUILayout.MinMaxSlider(Lowest Range (ref float), Highest Range (ref float), Lowest Value (float), Highest Value (float));",
        "EditorGUILayout.Slider(/*Float Value (float), Min Value (float), Max Value (float)*/);",
        #endregion
        
    };

    public readonly string[] d_CodeTemplateMultible = new[]
    {
        "EditorGUILayout.HelpBox(/*Content (string)*/, MessageType.None, /*Is Wide*/);",             //Help Box (none)
        "EditorGUILayout.HelpBox(/*Content (string)*/, MessageType.Info, /*Is Wide*/);",             //Help Box (Info)
        "EditorGUILayout.HelpBox(/*Content (string)*/, MessageType.Warning, /*Is Wide*/);",          //Help Box (Warning)
        "EditorGUILayout.HelpBox(/*Content (string)*/, MessageType.Error, /*Is Wide*/);",            //Help Box (Error)
    };
    
    public readonly string[] d_DocURLSingle = new[]
    {
        "https://docs.unity3d.com/ScriptReference/GUILayout.SelectionGrid.html", //SelectionGrid     (0)
        "https://docs.unity3d.com/ScriptReference/GUILayout.Toolbar.html", //Toolbar           (1)
        "https://docs.unity3d.com/ScriptReference/EditorGUILayout.ScrollViewScope.html", //Scroll View       (2)

        "https://docs.unity3d.com/ScriptReference/EditorGUILayout.LabelField.html", //Label             (3)
        "https://docs.unity3d.com/ScriptReference/EditorGUILayout.Foldout.html", //Fold Out          (4)

        "https://docs.unity3d.com/ScriptReference/EditorGUILayout.IntField.html", //Int Field         (6)
        "https://docs.unity3d.com/ScriptReference/EditorGUILayout.FloatField.html", //Float Field       (7)
        "https://docs.unity3d.com/ScriptReference/EditorGUILayout.DoubleField.html", //Double Field      (8)

        "https://docs.unity3d.com/ScriptReference/EditorGUILayout.Vector2Field.html", // Vector 2         (9)
        "https://docs.unity3d.com/ScriptReference/EditorGUILayout.Vector3Field.html", // Vector 3         (10)
        "https://docs.unity3d.com/ScriptReference/EditorGUILayout.Vector4Field.html", // Vector 4         (11)
        "https://docs.unity3d.com/ScriptReference/EditorGUILayout.TextArea.html", // Text Area        (12)
        "https://docs.unity3d.com/ScriptReference/EditorGUILayout.Toggle.html", // Toggle           (13)
        "https://docs.unity3d.com/ScriptReference/GUILayout.Button.html", // Button           (14)
        "https://docs.unity3d.com/ScriptReference/EditorGUILayout.EnumPopup.html", // Enum popup       (15)
        "https://docs.unity3d.com/ScriptReference/EditorGUILayout.EnumFlagsField.html", // Enum flag        (16)
        "https://docs.unity3d.com/ScriptReference/EditorGUILayout.LayerField.html", // Layer            (17)
        "https://docs.unity3d.com/ScriptReference/EditorGUILayout.MaskField.html", // Mask             (18)

        "https://docs.unity3d.com/ScriptReference/EditorGUI.BoundsField.html", //Bounds            (19)
        "https://docs.unity3d.com/ScriptReference/EditorGUILayout.RectField.html", //Rect              (20)
        "https://docs.unity3d.com/ScriptReference/EditorGUILayout.ColorField.html", //Color             (21)
        "https://docs.unity3d.com/ScriptReference/EditorGUILayout.GradientField.html", //Gradient          (22)
        "https://docs.unity3d.com/ScriptReference/EditorGUILayout.CurveField.html", //Curve             (23)
        "https://docs.unity3d.com/ScriptReference/EditorGUILayout.ObjectField.html", //Object            (24)

        "NO URL", //Knob              (25)
        "https://docs.unity3d.com/ScriptReference/EditorGUILayout.Slider.html", //Slider            (26)
        "https://docs.unity3d.com/ScriptReference/EditorGUILayout.MinMaxSlider.html", //Min Max Slider    (27)
    };
    
    public readonly string[] d_DocURLMultible = new[]
    {
        "https://docs.unity3d.com/ScriptReference/EditorGUILayout.HelpBox.html", //Help Box          (0)
    };
    #endregion

    public readonly string[] d_GUIStyleTemplate =
    {
        "new GUIStyle(EditorStyles.label)",
        "new GUIStyle(EditorStyles.boldLabel)",
        "new GUIStyle(EditorStyles.largeLabel)",
        
        "new GUIStyle(EditorStyles.miniLabel)",
        "new GUIStyle(EditorStyles.miniBoldLabel)",
        "new GUIStyle(EditorStyles.whiteMiniLabel)",
        
        "new GUIStyle(EditorStyles.whiteLabel)",
        "new GUIStyle(EditorStyles.whiteBoldLabel)",
        "new GUIStyle(EditorStyles.whiteLargeLabel)",
        
        "new GUIStyle(EditorStyles.wordWrappedLabel)",
        "new GUIStyle(EditorStyles.linkLabel)",
        "new GUIStyle(EditorStyles.centeredGreyMiniLabel)",
        
        "new GUIStyle(EditorStyles.helpBox)",
        "new GUIStyle(EditorStyles.toolbar)",
        
        "new GUIStyle(EditorStyles.toggle)",
        "new GUIStyle(EditorStyles.toggleGroup)",
        "new GUIStyle(EditorStyles.radioButton)",
        
        "new GUIStyle(EditorStyles.foldout)",
        "new GUIStyle(EditorStyles.foldoutHeader)",
        "new GUIStyle(EditorStyles.popup)",
        "new GUIStyle(EditorStyles.miniPullDown)",
        "new GUIStyle(EditorStyles.layerMaskField)",
        
        "new GUIStyle(EditorStyles.miniButtonLeft)",
        "new GUIStyle(EditorStyles.miniButtonMid)",
        "new GUIStyle(EditorStyles.miniButtonRight)",
        "new GUIStyle(EditorStyles.miniButton)",
        
        "new GUIStyle(EditorStyles.toolbarDropDown)",
        "new GUIStyle(EditorStyles.toolbarButton)",    
        
        "new GUIStyle(EditorStyles.colorField)",        
        "new GUIStyle(EditorStyles.objectFieldMiniThumb)",        
        "new GUIStyle(EditorStyles.objectFieldThumb)",        
        
        "new GUIStyle(EditorStyles.numberField)",        
        "new GUIStyle(EditorStyles.objectField)",        
        "new GUIStyle(EditorStyles.textArea)",        
        "new GUIStyle(EditorStyles.miniTextField)",
        "new GUIStyle(EditorStyles.textField)",
        "new GUIStyle(EditorStyles.toolbarTextField)",
        "new GUIStyle(EditorStyles.toolbarSearchField)",
    };
    
    public readonly string[] d_IconNamesBigAndSmall =
    {
        //https://unitylist.com/p/5c3/Unity-editor-icons
        
        //Objects
        "PreMatCube", "PreMatCylinder", "PreMatSphere", "PreMatTorus",
        
        //Build Platforms
        "BuildSettings.Standalone.Small",
        "BuildSettings.Metro.Small","BuildSettings.XboxOne.Small","BuildSettings.PS4.Small",
        "BuildSettings.Stadia.small",
        "BuildSettings.N3DS.Small","BuildSettings.Switch.Small",
        "BuildSettings.Android.Small","BuildSettings.iPhone.Small","BuildSettings.tvOS.Small",
        "BuildSettings.Facebook.Small", "BuildSettings.WebGL.Small", "BuildSettings.Lumin.small", 
        
        //Paint
        "Grid.PaintTool","Grid.FillTool","Grid.EraserTool","Grid.PickingTool",
        "eyeDropper.Large", "Exposure", "PreTexR", "PreTexG", "PreTexB", "PreTexA",
        "PreTexRGB", "SceneView2D",
        
        //Video Play
        "PlayButton","PauseButton", "PreMatQuad", "back", "forward", "d_StepButton",
        "preAudioLoopOff", "Record Off",
        "Profiler.Audio", "SceneViewAudio Off", "SceneViewAudio", "preAudioAutoPlayOff", 
        "Profiler.Video", "FrameCapture",
        
        //Window Extensions
        "_Help", "_Menu", "d_Preset.Context", "Audio Mixer", "_Popup","MoreOptions", "AlphabeticalSorting",
        "CustomTool","Package Manager",
        "Linked", "Unlinked",
        "winbtn_win_close", "Toolbar Minus", "Toolbar Plus", "Toolbar Plus More", "Refresh",
        "winbtn_win_max", "winbtn_win_restore", 
        
        //Console
        "console.erroricon.inactive.sml", "console.erroricon.sml", "console.infoicon.inactive.sml",
        "console.infoicon.sml", "console.warnicon.inactive.sml", "console.warnicon.sml",
        "CacheServerConnected", "CacheServerDisabled", "CacheServerDisconnected",
        "DebuggerAttached", "DebuggerDisabled", "DebuggerEnabled","UnityEditor.AnimationWindow",
        
        //Unity Editor
        "UnityEditor.ConsoleWindow", "UnityEditor.GameView",
        "UnityEditor.Graphs.AnimatorControllerTool", "UnityEditor.InspectorWindow",
        "UnityEditor.SceneView", "UnityEditor.Timeline.TimelineWindow",
        
        //Profiler
        "UnityEditor.ProfilerWindow", "Profiler.GPU","Profiler.GlobalIllumination",
        "Profiler.Memory", "Profiler.NetworkOperations", "SaveAs", "Profiler.UI", "Profiler.UIDetails", 
        
        //Misc
        
        "Favorite", "FilterByLabel", "ViewToolZoom", "Lighting", "FilterByType",
        "animationvisibilitytoggleon", "animationvisibilitytoggleoff", "Grid.Default", "ViewToolMove",

    };
}
