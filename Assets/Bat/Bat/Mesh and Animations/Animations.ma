//Maya ASCII 2023 scene
//Name: Animations.ma
//Last modified: Tue, Jun 18, 2024 07:02:31 PM
//Codeset: 1252
file -rdi 1 -ns "Bat" -rfn "BatRN" -op "v=0;" -typ "mayaAscii" "C:/CreativeMedia/ProjectShowOff/Maya/ProjectShowOff//scenes/Bat.ma";
file -r -ns "Bat" -dr 1 -rfn "BatRN" -op "v=0;" -typ "mayaAscii" "C:/CreativeMedia/ProjectShowOff/Maya/ProjectShowOff//scenes/Bat.ma";
requires maya "2023";
requires "stereoCamera" "10.0";
requires -nodeType "aiOptions" -nodeType "aiAOVDriver" -nodeType "aiAOVFilter" "mtoa" "5.1.0";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2023";
fileInfo "version" "2023";
fileInfo "cutIdentifier" "202202161415-df43006fd3";
fileInfo "osv" "Windows 10 Home v2009 (Build: 19045)";
fileInfo "UUID" "90FB32D5-4B84-F9AF-DE47-958B3B96CE65";
createNode transform -s -n "persp";
	rename -uid "BAB64FFA-4116-0F75-9168-C0A1B06E650F";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 3.2985184290922227 5.4726103757110209 31.656819166989997 ;
	setAttr ".r" -type "double3" -9.5999999999876895 363.9999999998397 -4.9817519872447211e-17 ;
createNode camera -s -n "perspShape" -p "persp";
	rename -uid "2ACB88A3-47D9-CE40-A4FF-8289A7A1D548";
	setAttr -k off ".v" no;
	setAttr ".fl" 34.999999999999993;
	setAttr ".coi" 32.381322383903985;
	setAttr ".imn" -type "string" "persp";
	setAttr ".den" -type "string" "persp_depth";
	setAttr ".man" -type "string" "persp_mask";
	setAttr ".tp" -type "double3" 0 -4.3097179599563997 0 ;
	setAttr ".hc" -type "string" "viewSet -p %camera";
createNode transform -s -n "top";
	rename -uid "B72F93DB-48C3-5BE2-F838-579C2B33544F";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 1000.1 0 ;
	setAttr ".r" -type "double3" -90 0 0 ;
createNode camera -s -n "topShape" -p "top";
	rename -uid "7D40BEB9-4AF1-E30C-D7A8-A9BEE1C7D685";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "top";
	setAttr ".den" -type "string" "top_depth";
	setAttr ".man" -type "string" "top_mask";
	setAttr ".hc" -type "string" "viewSet -t %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -s -n "front";
	rename -uid "B7B0D7AF-4485-6116-5ACF-2FB31A959520";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 0 1000.1 ;
createNode camera -s -n "frontShape" -p "front";
	rename -uid "7DAAC670-4DD7-05B4-220A-858C84327FD6";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "front";
	setAttr ".den" -type "string" "front_depth";
	setAttr ".man" -type "string" "front_mask";
	setAttr ".hc" -type "string" "viewSet -f %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -s -n "side";
	rename -uid "A50AF227-4BEB-9C6D-B8B5-E781C1437599";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 1000.1 0 0 ;
	setAttr ".r" -type "double3" 0 90 0 ;
createNode camera -s -n "sideShape" -p "side";
	rename -uid "29A8893F-4E29-BB9A-BE8F-85BEA9226064";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "side";
	setAttr ".den" -type "string" "side_depth";
	setAttr ".man" -type "string" "side_mask";
	setAttr ".hc" -type "string" "viewSet -s %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode lightLinker -s -n "lightLinker1";
	rename -uid "7404257F-4871-0AC4-E1AC-8191D595E4B0";
	setAttr -s 5 ".lnk";
	setAttr -s 5 ".slnk";
createNode shapeEditorManager -n "shapeEditorManager";
	rename -uid "210F06F5-4886-9E21-D1AB-F99A6F22F6E5";
createNode poseInterpolatorManager -n "poseInterpolatorManager";
	rename -uid "0C492260-40A2-38B8-7778-F1B67D0D39D8";
createNode displayLayerManager -n "layerManager";
	rename -uid "FA30148F-450D-FEB0-4909-AB9DC4818250";
createNode displayLayer -n "defaultLayer";
	rename -uid "A78C011E-40B2-F1A1-37C0-6C98B1A67B27";
createNode renderLayerManager -n "renderLayerManager";
	rename -uid "AA3061BE-42DC-075A-10F8-13AE54A54A29";
createNode renderLayer -n "defaultRenderLayer";
	rename -uid "46E99D32-4D93-E056-818A-70981848D501";
	setAttr ".g" yes;
createNode script -n "uiConfigurationScriptNode";
	rename -uid "D30CDD3D-4AAF-02D5-1F46-5C82DD1E1D7E";
	setAttr ".b" -type "string" (
		"// Maya Mel UI Configuration File.\n//\n//  This script is machine generated.  Edit at your own risk.\n//\n//\n\nglobal string $gMainPane;\nif (`paneLayout -exists $gMainPane`) {\n\n\tglobal int $gUseScenePanelConfig;\n\tint    $useSceneConfig = $gUseScenePanelConfig;\n\tint    $nodeEditorPanelVisible = stringArrayContains(\"nodeEditorPanel1\", `getPanel -vis`);\n\tint    $nodeEditorWorkspaceControlOpen = (`workspaceControl -exists nodeEditorPanel1Window` && `workspaceControl -q -visible nodeEditorPanel1Window`);\n\tint    $menusOkayInPanels = `optionVar -q allowMenusInPanels`;\n\tint    $nVisPanes = `paneLayout -q -nvp $gMainPane`;\n\tint    $nPanes = 0;\n\tstring $editorName;\n\tstring $panelName;\n\tstring $itemFilterName;\n\tstring $panelConfig;\n\n\t//\n\t//  get current state of the UI\n\t//\n\tsceneUIReplacement -update $gMainPane;\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Top View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Top View\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"|top\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n"
		+ "            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n"
		+ "            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 0\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 776\n            -height 322\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n"
		+ "\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Side View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Side View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"|side\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n"
		+ "            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n"
		+ "            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 0\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 776\n            -height 321\n"
		+ "            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Front View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Front View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"|front\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n"
		+ "            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n"
		+ "            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n"
		+ "            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 0\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 776\n            -height 321\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Persp View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Persp View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"|persp\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n"
		+ "            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 1\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n"
		+ "            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n"
		+ "            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 0\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1295\n            -height 398\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"ToggledOutliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"ToggledOutliner\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -docTag \"isolOutln_fromSeln\" \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 1\n            -showReferenceMembers 1\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n"
		+ "            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -isSet 0\n            -isSetMember 0\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            -renderFilterIndex 0\n            -selectionOrder \"chronological\" \n"
		+ "            -expandAttribute 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"Outliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"Outliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 0\n            -showReferenceMembers 0\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n"
		+ "            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n"
		+ "            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"graphEditor\" (localizedPanelLabel(\"Graph Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Graph Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n"
		+ "                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 1\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showParentContainers 0\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 0\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 1\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 1\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -isSet 0\n                -isSetMember 0\n                -displayMode \"DAG\" \n"
		+ "                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 1\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n                -selectionOrder \"display\" \n                -expandAttribute 1\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"GraphEd\");\n            animCurveEditor -e \n                -displayValues 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -showPlayRangeShades \"on\" \n"
		+ "                -lockPlayRangeShades \"off\" \n                -smoothness \"fine\" \n                -resultSamples 1\n                -resultScreenSamples 0\n                -resultUpdate \"delayed\" \n                -showUpstreamCurves 1\n                -keyMinScale 1\n                -stackedCurvesMin -1\n                -stackedCurvesMax 1\n                -stackedCurvesSpace 0.2\n                -preSelectionHighlight 0\n                -constrainDrag 0\n                -valueLinesToggle 1\n                -outliner \"graphEditor1OutlineEd\" \n                -highlightAffectedCurves 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dopeSheetPanel\" (localizedPanelLabel(\"Dope Sheet\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dope Sheet\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n"
		+ "                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showParentContainers 0\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 0\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 0\n"
		+ "                -doNotSelectNewObjects 1\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n                $editorName;\n"
		+ "\n\t\t\t$editorName = ($panelName+\"DopeSheetEd\");\n            dopeSheetEditor -e \n                -displayValues 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -outliner \"dopeSheetPanel1OutlineEd\" \n                -showSummary 1\n                -showScene 0\n                -hierarchyBelow 0\n                -showTicks 1\n                -selectionWindow 0 0 0 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"timeEditorPanel\" (localizedPanelLabel(\"Time Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Time Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"clipEditorPanel\" (localizedPanelLabel(\"Trax Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n"
		+ "\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Trax Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = clipEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayValues 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"sequenceEditorPanel\" (localizedPanelLabel(\"Camera Sequencer\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Camera Sequencer\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = sequenceEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayValues 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 1 \n                $editorName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperGraphPanel\" (localizedPanelLabel(\"Hypergraph Hierarchy\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypergraph Hierarchy\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"HyperGraphEd\");\n            hyperGraph -e \n                -graphLayoutStyle \"hierarchicalLayout\" \n                -orientation \"horiz\" \n                -mergeConnections 0\n                -zoom 1\n                -animateTransition 0\n                -showRelationships 1\n                -showShapes 0\n                -showDeformers 0\n                -showExpressions 0\n                -showConstraints 0\n                -showConnectionFromSelected 0\n                -showConnectionToSelected 0\n                -showConstraintLabels 0\n                -showUnderworld 0\n                -showInvisible 0\n                -transitionFrames 1\n"
		+ "                -opaqueContainers 0\n                -freeform 0\n                -imagePosition 0 0 \n                -imageScale 1\n                -imageEnabled 0\n                -graphType \"DAG\" \n                -heatMapDisplay 0\n                -updateSelection 1\n                -updateNodeAdded 1\n                -useDrawOverrideColor 0\n                -limitGraphTraversal -1\n                -range 0 0 \n                -iconSize \"smallIcons\" \n                -showCachedConnections 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperShadePanel\" (localizedPanelLabel(\"Hypershade\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypershade\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"visorPanel\" (localizedPanelLabel(\"Visor\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Visor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"nodeEditorPanel\" (localizedPanelLabel(\"Node Editor\")) `;\n\tif ($nodeEditorPanelVisible || $nodeEditorWorkspaceControlOpen) {\n\t\tif (\"\" == $panelName) {\n\t\t\tif ($useSceneConfig) {\n\t\t\t\t$panelName = `scriptedPanel -unParent  -type \"nodeEditorPanel\" -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -connectNodeOnCreation 0\n                -connectOnDrop 0\n                -copyConnectionsOnPaste 0\n                -connectionStyle \"bezier\" \n                -defaultPinnedState 0\n"
		+ "                -additiveGraphingMode 0\n                -connectedGraphingMode 1\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -crosshairOnEdgeDragging 0\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n                -extendToShapes 1\n                -showUnitConversions 0\n                -editorMode \"default\" \n                -hasWatchpoint 0\n                $editorName;\n\t\t\t}\n\t\t} else {\n\t\t\t$label = `panel -q -label $panelName`;\n\t\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n"
		+ "                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -connectNodeOnCreation 0\n                -connectOnDrop 0\n                -copyConnectionsOnPaste 0\n                -connectionStyle \"bezier\" \n                -defaultPinnedState 0\n                -additiveGraphingMode 0\n                -connectedGraphingMode 1\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -crosshairOnEdgeDragging 0\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n"
		+ "                -extendToShapes 1\n                -showUnitConversions 0\n                -editorMode \"default\" \n                -hasWatchpoint 0\n                $editorName;\n\t\t\tif (!$useSceneConfig) {\n\t\t\t\tpanel -e -l $label $panelName;\n\t\t\t}\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"createNodePanel\" (localizedPanelLabel(\"Create Node\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Create Node\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"polyTexturePlacementPanel\" (localizedPanelLabel(\"UV Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"UV Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"renderWindowPanel\" (localizedPanelLabel(\"Render View\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Render View\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"shapePanel\" (localizedPanelLabel(\"Shape Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tshapePanel -edit -l (localizedPanelLabel(\"Shape Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"posePanel\" (localizedPanelLabel(\"Pose Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tposePanel -edit -l (localizedPanelLabel(\"Pose Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynRelEdPanel\" (localizedPanelLabel(\"Dynamic Relationships\")) `;\n\tif (\"\" != $panelName) {\n"
		+ "\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dynamic Relationships\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"relationshipPanel\" (localizedPanelLabel(\"Relationship Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Relationship Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"referenceEditorPanel\" (localizedPanelLabel(\"Reference Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Reference Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynPaintScriptedPanelType\" (localizedPanelLabel(\"Paint Effects\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Paint Effects\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"scriptEditorPanel\" (localizedPanelLabel(\"Script Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Script Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"profilerPanel\" (localizedPanelLabel(\"Profiler Tool\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Profiler Tool\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"contentBrowserPanel\" (localizedPanelLabel(\"Content Browser\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Content Browser\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"Stereo\" (localizedPanelLabel(\"Stereo\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Stereo\")) -mbv $menusOkayInPanels  $panelName;\n{ string $editorName = ($panelName+\"Editor\");\n            stereoCameraView -e \n                -camera \"|persp\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"smoothShaded\" \n                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -holdOuts 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 0\n"
		+ "                -backfaceCulling 0\n                -xray 0\n                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 16384\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -depthOfFieldPreview 1\n                -maxConstantTransparency 1\n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 4 4 \n                -bumpResolution 4 4 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n"
		+ "                -lowQualityLighting 0\n                -maximumNumHardwareLights 0\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -controllers 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -particleInstancers 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n"
		+ "                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -pluginShapes 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n                -clipGhosts 1\n                -greasePencils 0\n                -shadows 0\n                -captureSequenceNumber -1\n                -width 0\n                -height 0\n                -sceneRenderFilter 0\n                -displayMode \"centerEye\" \n                -viewColor 0 0 0 1 \n                -useCustomBackground 1\n                $editorName;\n            stereoCameraView -e -viewSelected 0 $editorName;\n            stereoCameraView -e \n                -pluginObjects \"gpuCacheDisplayFilter\" 1 \n                $editorName; };\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\tif ($useSceneConfig) {\n        string $configName = `getPanel -cwl (localizedPanelLabel(\"Current Layout\"))`;\n"
		+ "        if (\"\" != $configName) {\n\t\t\tpanelConfiguration -edit -label (localizedPanelLabel(\"Current Layout\")) \n\t\t\t\t-userCreated false\n\t\t\t\t-defaultImage \"vacantCell.xP:/\"\n\t\t\t\t-image \"\"\n\t\t\t\t-sc false\n\t\t\t\t-configString \"global string $gMainPane; paneLayout -e -cn \\\"single\\\" -ps 1 100 100 $gMainPane;\"\n\t\t\t\t-removeAllPanels\n\t\t\t\t-ap false\n\t\t\t\t\t(localizedPanelLabel(\"Persp View\")) \n\t\t\t\t\t\"modelPanel\"\n"
		+ "\t\t\t\t\t\"$panelName = `modelPanel -unParent -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 1\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 16384\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 0\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 1295\\n    -height 398\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 1\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 16384\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 0\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 1295\\n    -height 398\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t$configName;\n\n            setNamedPanelLayout (localizedPanelLabel(\"Current Layout\"));\n        }\n\n        panelHistory -e -clear mainPanelHistory;\n        sceneUIReplacement -clear;\n\t}\n\n\ngrid -spacing 0.0005 -size 0.0012 -divisions 5 -displayAxes yes -displayGridLines yes -displayDivisionLines yes -displayPerspectiveLabels no -displayOrthographicLabels no -displayAxesBold yes -perspectiveLabelPosition axis -orthographicLabelPosition edge;\nviewManip -drawCompass 0 -compassAngle 0 -frontParameters \"\" -homeParameters \"\" -selectionLockParameters \"\";\n}\n");
	setAttr ".st" 3;
createNode script -n "sceneConfigurationScriptNode";
	rename -uid "69E200ED-412D-9E52-CAF8-62A7F548E03F";
	setAttr ".b" -type "string" "playbackOptions -min 0 -max 9 -ast 0 -aet 9 ";
	setAttr ".st" 6;
createNode reference -n "BatRN";
	rename -uid "DC4C15B6-49A1-A4E2-47DD-B3B3BFE6657B";
	setAttr -s 146 ".phl";
	setAttr ".phl[1]" 0;
	setAttr ".phl[2]" 0;
	setAttr ".phl[3]" 0;
	setAttr ".phl[4]" 0;
	setAttr ".phl[5]" 0;
	setAttr ".phl[6]" 0;
	setAttr ".phl[7]" 0;
	setAttr ".phl[8]" 0;
	setAttr ".phl[9]" 0;
	setAttr ".phl[10]" 0;
	setAttr ".phl[11]" 0;
	setAttr ".phl[12]" 0;
	setAttr ".phl[13]" 0;
	setAttr ".phl[14]" 0;
	setAttr ".phl[15]" 0;
	setAttr ".phl[16]" 0;
	setAttr ".phl[17]" 0;
	setAttr ".phl[18]" 0;
	setAttr ".phl[19]" 0;
	setAttr ".phl[20]" 0;
	setAttr ".phl[21]" 0;
	setAttr ".phl[22]" 0;
	setAttr ".phl[23]" 0;
	setAttr ".phl[24]" 0;
	setAttr ".phl[25]" 0;
	setAttr ".phl[26]" 0;
	setAttr ".phl[27]" 0;
	setAttr ".phl[28]" 0;
	setAttr ".phl[29]" 0;
	setAttr ".phl[30]" 0;
	setAttr ".phl[31]" 0;
	setAttr ".phl[32]" 0;
	setAttr ".phl[33]" 0;
	setAttr ".phl[34]" 0;
	setAttr ".phl[35]" 0;
	setAttr ".phl[36]" 0;
	setAttr ".phl[37]" 0;
	setAttr ".phl[38]" 0;
	setAttr ".phl[39]" 0;
	setAttr ".phl[40]" 0;
	setAttr ".phl[41]" 0;
	setAttr ".phl[42]" 0;
	setAttr ".phl[43]" 0;
	setAttr ".phl[44]" 0;
	setAttr ".phl[45]" 0;
	setAttr ".phl[46]" 0;
	setAttr ".phl[47]" 0;
	setAttr ".phl[48]" 0;
	setAttr ".phl[49]" 0;
	setAttr ".phl[50]" 0;
	setAttr ".phl[51]" 0;
	setAttr ".phl[52]" 0;
	setAttr ".phl[53]" 0;
	setAttr ".phl[54]" 0;
	setAttr ".phl[55]" 0;
	setAttr ".phl[56]" 0;
	setAttr ".phl[57]" 0;
	setAttr ".phl[58]" 0;
	setAttr ".phl[59]" 0;
	setAttr ".phl[60]" 0;
	setAttr ".phl[61]" 0;
	setAttr ".phl[62]" 0;
	setAttr ".phl[63]" 0;
	setAttr ".phl[64]" 0;
	setAttr ".phl[65]" 0;
	setAttr ".phl[66]" 0;
	setAttr ".phl[67]" 0;
	setAttr ".phl[68]" 0;
	setAttr ".phl[69]" 0;
	setAttr ".phl[70]" 0;
	setAttr ".phl[71]" 0;
	setAttr ".phl[72]" 0;
	setAttr ".phl[73]" 0;
	setAttr ".phl[74]" 0;
	setAttr ".phl[75]" 0;
	setAttr ".phl[76]" 0;
	setAttr ".phl[77]" 0;
	setAttr ".phl[78]" 0;
	setAttr ".phl[79]" 0;
	setAttr ".phl[80]" 0;
	setAttr ".phl[81]" 0;
	setAttr ".phl[82]" 0;
	setAttr ".phl[83]" 0;
	setAttr ".phl[84]" 0;
	setAttr ".phl[85]" 0;
	setAttr ".phl[86]" 0;
	setAttr ".phl[87]" 0;
	setAttr ".phl[88]" 0;
	setAttr ".phl[89]" 0;
	setAttr ".phl[90]" 0;
	setAttr ".phl[91]" 0;
	setAttr ".phl[92]" 0;
	setAttr ".phl[93]" 0;
	setAttr ".phl[94]" 0;
	setAttr ".phl[95]" 0;
	setAttr ".phl[96]" 0;
	setAttr ".phl[97]" 0;
	setAttr ".phl[98]" 0;
	setAttr ".phl[99]" 0;
	setAttr ".phl[100]" 0;
	setAttr ".phl[101]" 0;
	setAttr ".phl[102]" 0;
	setAttr ".phl[103]" 0;
	setAttr ".phl[104]" 0;
	setAttr ".phl[105]" 0;
	setAttr ".phl[106]" 0;
	setAttr ".phl[107]" 0;
	setAttr ".phl[108]" 0;
	setAttr ".phl[109]" 0;
	setAttr ".phl[110]" 0;
	setAttr ".phl[111]" 0;
	setAttr ".phl[112]" 0;
	setAttr ".phl[113]" 0;
	setAttr ".phl[114]" 0;
	setAttr ".phl[115]" 0;
	setAttr ".phl[116]" 0;
	setAttr ".phl[117]" 0;
	setAttr ".phl[118]" 0;
	setAttr ".phl[119]" 0;
	setAttr ".phl[120]" 0;
	setAttr ".phl[121]" 0;
	setAttr ".phl[122]" 0;
	setAttr ".phl[123]" 0;
	setAttr ".phl[124]" 0;
	setAttr ".phl[125]" 0;
	setAttr ".phl[126]" 0;
	setAttr ".phl[127]" 0;
	setAttr ".phl[128]" 0;
	setAttr ".phl[129]" 0;
	setAttr ".phl[130]" 0;
	setAttr ".phl[131]" 0;
	setAttr ".phl[132]" 0;
	setAttr ".phl[133]" 0;
	setAttr ".phl[134]" 0;
	setAttr ".phl[135]" 0;
	setAttr ".phl[136]" 0;
	setAttr ".phl[137]" 0;
	setAttr ".phl[138]" 0;
	setAttr ".phl[139]" 0;
	setAttr ".phl[140]" 0;
	setAttr ".phl[141]" 0;
	setAttr ".phl[142]" 0;
	setAttr ".phl[143]" 0;
	setAttr ".phl[144]" 0;
	setAttr ".phl[145]" 0;
	setAttr ".phl[146]" 0;
	setAttr ".ed" -type "dataReferenceEdits" 
		"BatRN"
		"BatRN" 0
		"BatRN" 152
		2 "|Bat:Bat_Rig|Bat:joint1|Bat:joint10" "translate" " -type \"double3\" 0.24501805918777164 0.83604645664540544 0.23215677998787143"
		
		2 "|Bat:Bat_Rig|Bat:joint1|Bat:joint12" "translate" " -type \"double3\" -0.20954078289718681 -0.6294766868456273 -0.16256217856879393"
		
		2 "|Bat:Bat_Rig|Bat:joint1|Bat:joint12|Bat:joint13" "translate" " -type \"double3\" 0.86781094924419877 0.00081859482758977337 -0.22290558872429228"
		
		2 "|Bat:Bat_Rig|Bat:joint1|Bat:joint12|Bat:joint13" "translateX" " -av"
		2 "|Bat:Bat_Rig|Bat:joint1|Bat:joint12|Bat:joint13" "translateY" " -av"
		2 "|Bat:Bat_Rig|Bat:joint1|Bat:joint12|Bat:joint13" "translateZ" " -av"
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:joint1|Bat:joint12|Bat:joint13.translateX" 
		"BatRN.placeHolderList[1]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:joint1|Bat:joint12|Bat:joint13.translateX" 
		"BatRN.placeHolderList[2]" ""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:joint1|Bat:joint12|Bat:joint13.translateY" 
		"BatRN.placeHolderList[3]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:joint1|Bat:joint12|Bat:joint13.translateY" 
		"BatRN.placeHolderList[4]" ""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:joint1|Bat:joint12|Bat:joint13.translateZ" 
		"BatRN.placeHolderList[5]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:joint1|Bat:joint12|Bat:joint13.translateZ" 
		"BatRN.placeHolderList[6]" ""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:joint1|Bat:joint12|Bat:joint13.visibility" 
		"BatRN.placeHolderList[7]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:joint1|Bat:joint12|Bat:joint13.visibility" 
		"BatRN.placeHolderList[8]" ""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:joint1|Bat:joint12|Bat:joint13.rotateX" 
		"BatRN.placeHolderList[9]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:joint1|Bat:joint12|Bat:joint13.rotateX" 
		"BatRN.placeHolderList[10]" ""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:joint1|Bat:joint12|Bat:joint13.rotateY" 
		"BatRN.placeHolderList[11]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:joint1|Bat:joint12|Bat:joint13.rotateY" 
		"BatRN.placeHolderList[12]" ""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:joint1|Bat:joint12|Bat:joint13.rotateZ" 
		"BatRN.placeHolderList[13]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:joint1|Bat:joint12|Bat:joint13.rotateZ" 
		"BatRN.placeHolderList[14]" ""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:joint1|Bat:joint12|Bat:joint13.rotateOrder" 
		"BatRN.placeHolderList[15]" ""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:joint1|Bat:joint12|Bat:joint13.scaleX" 
		"BatRN.placeHolderList[16]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:joint1|Bat:joint12|Bat:joint13.scaleX" 
		"BatRN.placeHolderList[17]" ""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:joint1|Bat:joint12|Bat:joint13.scaleY" 
		"BatRN.placeHolderList[18]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:joint1|Bat:joint12|Bat:joint13.scaleY" 
		"BatRN.placeHolderList[19]" ""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:joint1|Bat:joint12|Bat:joint13.scaleZ" 
		"BatRN.placeHolderList[20]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:joint1|Bat:joint12|Bat:joint13.scaleZ" 
		"BatRN.placeHolderList[21]" ""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl.translateX" "BatRN.placeHolderList[22]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl.translateX" "BatRN.placeHolderList[23]" 
		""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl.translateY" "BatRN.placeHolderList[24]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl.translateY" "BatRN.placeHolderList[25]" 
		""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl.translateZ" "BatRN.placeHolderList[26]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl.translateZ" "BatRN.placeHolderList[27]" 
		""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl.rotateX" "BatRN.placeHolderList[28]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl.rotateX" "BatRN.placeHolderList[29]" 
		""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl.rotateY" "BatRN.placeHolderList[30]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl.rotateY" "BatRN.placeHolderList[31]" 
		""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl.rotateZ" "BatRN.placeHolderList[32]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl.rotateZ" "BatRN.placeHolderList[33]" 
		""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl.rotateOrder" "BatRN.placeHolderList[34]" 
		""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl.visibility" "BatRN.placeHolderList[35]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl.visibility" "BatRN.placeHolderList[36]" 
		""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl.instObjGroups" "BatRN.placeHolderList[37]" 
		""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:root_crtlShape.instObjGroups" 
		"BatRN.placeHolderList[38]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:head_crtl.translateX" "BatRN.placeHolderList[39]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:head_crtl.translateY" "BatRN.placeHolderList[40]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:head_crtl.translateZ" "BatRN.placeHolderList[41]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:head_crtl.rotateX" "BatRN.placeHolderList[42]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:head_crtl.rotateY" "BatRN.placeHolderList[43]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:head_crtl.rotateZ" "BatRN.placeHolderList[44]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:head_crtl.scaleX" "BatRN.placeHolderList[45]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:head_crtl.scaleY" "BatRN.placeHolderList[46]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:head_crtl.scaleZ" "BatRN.placeHolderList[47]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:head_crtl.visibility" "BatRN.placeHolderList[48]" 
		""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:head_crtl.instObjGroups" 
		"BatRN.placeHolderList[49]" ""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:head_crtl|Bat:head_crtlShape.instObjGroups" 
		"BatRN.placeHolderList[50]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1.translateX" "BatRN.placeHolderList[51]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1.translateY" "BatRN.placeHolderList[52]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1.translateZ" "BatRN.placeHolderList[53]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1.rotateX" "BatRN.placeHolderList[54]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1.rotateY" "BatRN.placeHolderList[55]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1.rotateZ" "BatRN.placeHolderList[56]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1.scaleX" "BatRN.placeHolderList[57]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1.scaleY" "BatRN.placeHolderList[58]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1.scaleZ" "BatRN.placeHolderList[59]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1.visibility" "BatRN.placeHolderList[60]" 
		""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1.instObjGroups" "BatRN.placeHolderList[61]" 
		""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_Shape1.instObjGroups" 
		"BatRN.placeHolderList[62]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2.translateX" 
		"BatRN.placeHolderList[63]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2.translateY" 
		"BatRN.placeHolderList[64]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2.translateZ" 
		"BatRN.placeHolderList[65]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2.rotateX" "BatRN.placeHolderList[66]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2.rotateY" "BatRN.placeHolderList[67]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2.rotateZ" "BatRN.placeHolderList[68]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2.scaleX" "BatRN.placeHolderList[69]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2.scaleY" "BatRN.placeHolderList[70]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2.scaleZ" "BatRN.placeHolderList[71]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2.visibility" 
		"BatRN.placeHolderList[72]" ""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2.instObjGroups" 
		"BatRN.placeHolderList[73]" ""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2|Bat:l_Shape2.instObjGroups" 
		"BatRN.placeHolderList[74]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2|Bat:l_3.translateX" 
		"BatRN.placeHolderList[75]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2|Bat:l_3.translateY" 
		"BatRN.placeHolderList[76]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2|Bat:l_3.translateZ" 
		"BatRN.placeHolderList[77]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2|Bat:l_3.rotateX" 
		"BatRN.placeHolderList[78]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2|Bat:l_3.rotateY" 
		"BatRN.placeHolderList[79]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2|Bat:l_3.rotateZ" 
		"BatRN.placeHolderList[80]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2|Bat:l_3.scaleX" 
		"BatRN.placeHolderList[81]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2|Bat:l_3.scaleY" 
		"BatRN.placeHolderList[82]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2|Bat:l_3.scaleZ" 
		"BatRN.placeHolderList[83]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2|Bat:l_3.visibility" 
		"BatRN.placeHolderList[84]" ""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2|Bat:l_3.instObjGroups" 
		"BatRN.placeHolderList[85]" ""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2|Bat:l_3|Bat:l_Shape3.instObjGroups" 
		"BatRN.placeHolderList[86]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2|Bat:l_3|Bat:l_4.translateX" 
		"BatRN.placeHolderList[87]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2|Bat:l_3|Bat:l_4.translateY" 
		"BatRN.placeHolderList[88]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2|Bat:l_3|Bat:l_4.translateZ" 
		"BatRN.placeHolderList[89]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2|Bat:l_3|Bat:l_4.rotateX" 
		"BatRN.placeHolderList[90]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2|Bat:l_3|Bat:l_4.rotateY" 
		"BatRN.placeHolderList[91]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2|Bat:l_3|Bat:l_4.rotateZ" 
		"BatRN.placeHolderList[92]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2|Bat:l_3|Bat:l_4.scaleX" 
		"BatRN.placeHolderList[93]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2|Bat:l_3|Bat:l_4.scaleY" 
		"BatRN.placeHolderList[94]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2|Bat:l_3|Bat:l_4.scaleZ" 
		"BatRN.placeHolderList[95]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2|Bat:l_3|Bat:l_4.visibility" 
		"BatRN.placeHolderList[96]" ""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2|Bat:l_3|Bat:l_4.instObjGroups" 
		"BatRN.placeHolderList[97]" ""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:l_1|Bat:l_2|Bat:l_3|Bat:l_4|Bat:l_Shape4.instObjGroups" 
		"BatRN.placeHolderList[98]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1.translateX" "BatRN.placeHolderList[99]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1.translateY" "BatRN.placeHolderList[100]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1.translateZ" "BatRN.placeHolderList[101]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1.rotateX" "BatRN.placeHolderList[102]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1.rotateY" "BatRN.placeHolderList[103]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1.rotateZ" "BatRN.placeHolderList[104]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1.scaleX" "BatRN.placeHolderList[105]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1.scaleY" "BatRN.placeHolderList[106]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1.scaleZ" "BatRN.placeHolderList[107]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1.visibility" "BatRN.placeHolderList[108]" 
		""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1.instObjGroups" "BatRN.placeHolderList[109]" 
		""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_1Shape.instObjGroups" 
		"BatRN.placeHolderList[110]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2.translateX" 
		"BatRN.placeHolderList[111]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2.translateY" 
		"BatRN.placeHolderList[112]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2.translateZ" 
		"BatRN.placeHolderList[113]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2.rotateX" "BatRN.placeHolderList[114]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2.rotateY" "BatRN.placeHolderList[115]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2.rotateZ" "BatRN.placeHolderList[116]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2.scaleX" "BatRN.placeHolderList[117]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2.scaleY" "BatRN.placeHolderList[118]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2.scaleZ" "BatRN.placeHolderList[119]" 
		""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2.visibility" 
		"BatRN.placeHolderList[120]" ""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2.instObjGroups" 
		"BatRN.placeHolderList[121]" ""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2|Bat:r_Shape2.instObjGroups" 
		"BatRN.placeHolderList[122]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2|Bat:r_3.translateX" 
		"BatRN.placeHolderList[123]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2|Bat:r_3.translateY" 
		"BatRN.placeHolderList[124]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2|Bat:r_3.translateZ" 
		"BatRN.placeHolderList[125]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2|Bat:r_3.rotateX" 
		"BatRN.placeHolderList[126]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2|Bat:r_3.rotateY" 
		"BatRN.placeHolderList[127]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2|Bat:r_3.rotateZ" 
		"BatRN.placeHolderList[128]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2|Bat:r_3.scaleX" 
		"BatRN.placeHolderList[129]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2|Bat:r_3.scaleY" 
		"BatRN.placeHolderList[130]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2|Bat:r_3.scaleZ" 
		"BatRN.placeHolderList[131]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2|Bat:r_3.visibility" 
		"BatRN.placeHolderList[132]" ""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2|Bat:r_3.instObjGroups" 
		"BatRN.placeHolderList[133]" ""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2|Bat:r_3|Bat:r_Shape3.instObjGroups" 
		"BatRN.placeHolderList[134]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2|Bat:r_3|Bat:r_4.translateX" 
		"BatRN.placeHolderList[135]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2|Bat:r_3|Bat:r_4.translateY" 
		"BatRN.placeHolderList[136]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2|Bat:r_3|Bat:r_4.translateZ" 
		"BatRN.placeHolderList[137]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2|Bat:r_3|Bat:r_4.rotateX" 
		"BatRN.placeHolderList[138]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2|Bat:r_3|Bat:r_4.rotateY" 
		"BatRN.placeHolderList[139]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2|Bat:r_3|Bat:r_4.rotateZ" 
		"BatRN.placeHolderList[140]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2|Bat:r_3|Bat:r_4.scaleX" 
		"BatRN.placeHolderList[141]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2|Bat:r_3|Bat:r_4.scaleY" 
		"BatRN.placeHolderList[142]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2|Bat:r_3|Bat:r_4.scaleZ" 
		"BatRN.placeHolderList[143]" ""
		5 4 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2|Bat:r_3|Bat:r_4.visibility" 
		"BatRN.placeHolderList[144]" ""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2|Bat:r_3|Bat:r_4.instObjGroups" 
		"BatRN.placeHolderList[145]" ""
		5 3 "BatRN" "|Bat:Bat_Rig|Bat:root_crtl|Bat:r_1|Bat:r_2|Bat:r_3|Bat:r_4|Bat:r_Shape4.instObjGroups" 
		"BatRN.placeHolderList[146]" "";
	setAttr ".ptag" -type "string" "";
lockNode -l 1 ;
createNode aiOptions -s -n "defaultArnoldRenderOptions";
	rename -uid "F8FC3311-42AD-EE77-5BBD-9CBE716B95EB";
	setAttr ".version" -type "string" "5.1.0";
createNode aiAOVFilter -s -n "defaultArnoldFilter";
	rename -uid "2126236E-45F3-007E-3E81-3AB093A6FE59";
	setAttr ".ai_translator" -type "string" "gaussian";
createNode aiAOVDriver -s -n "defaultArnoldDriver";
	rename -uid "3E1B6F0C-4C58-41F2-E26B-A19D6E5AFDF7";
	setAttr ".ai_translator" -type "string" "exr";
createNode aiAOVDriver -s -n "defaultArnoldDisplayDriver";
	rename -uid "44071AB2-487C-7C21-AC38-A69757E68B0F";
	setAttr ".output_mode" 0;
	setAttr ".ai_translator" -type "string" "maya";
createNode animLayer -n "BaseAnimation";
	rename -uid "82A70404-4A4B-D017-873A-B685CAD2126F";
	setAttr ".pref" yes;
	setAttr ".slct" yes;
	setAttr ".ovrd" yes;
createNode animLayer -n "AnimLayer1";
	rename -uid "3A2611C0-4966-0D11-DDD4-6ABA633B8008";
	setAttr -s 17 ".dsm";
	setAttr -s 13 ".bnds";
	setAttr ".lo" yes;
createNode animBlendNodeBoolean -n "Bat:joint13_visibility_AnimLayer1";
	rename -uid "7C4BFF53-4D1A-4843-8104-279152C6BFF9";
	setAttr ".ia" yes;
	setAttr ".ib" yes;
	setAttr ".o" yes;
createNode animBlendNodeAdditiveDL -n "Bat:joint13_translateX_AnimLayer1";
	rename -uid "A7653527-4008-EAF4-BD03-9A9575DA793A";
	setAttr ".ia" 0.86781094924419877;
	setAttr ".o" 0.86781094924419877;
createNode animBlendNodeAdditiveDL -n "Bat:joint13_translateY_AnimLayer1";
	rename -uid "EC3C9071-421F-FC22-8B30-20B50678A1E1";
	setAttr ".ia" 0.00081859482758977337;
	setAttr ".o" 0.00081859482758977337;
createNode animBlendNodeAdditiveDL -n "Bat:joint13_translateZ_AnimLayer1";
	rename -uid "2B8C01EC-44C0-8945-E389-C798A4761DDB";
	setAttr ".ia" -0.22290558872429228;
	setAttr ".o" -0.22290558872429228;
createNode animBlendNodeAdditiveRotation -n "Bat:joint13_rotate_AnimLayer1";
	rename -uid "8C13C78C-4EFF-1DAF-004A-93AD6F648E80";
createNode animBlendNodeAdditiveScale -n "Bat:joint13_scaleX_AnimLayer1";
	rename -uid "EB8CB252-44F7-EFC2-BB98-8B8FC6A410DF";
	setAttr ".ia" 1;
	setAttr ".ib" 1;
	setAttr ".o" 1;
createNode animBlendNodeAdditiveScale -n "Bat:joint13_scaleY_AnimLayer1";
	rename -uid "EE35F9D8-409A-AE44-1E66-0386A05CFEA9";
	setAttr ".ia" 1;
	setAttr ".ib" 1;
	setAttr ".o" 1;
createNode animBlendNodeAdditiveScale -n "Bat:joint13_scaleZ_AnimLayer1";
	rename -uid "60EEEF37-4E95-9A4F-6FE8-6693CF5EBBB1";
	setAttr ".ia" 1;
	setAttr ".ib" 1;
	setAttr ".o" 1;
createNode animBlendNodeBoolean -n "Bat:root_crtl_visibility_AnimLayer1";
	rename -uid "C56F0962-4480-18C2-89E7-9498284D892B";
	setAttr ".ib" yes;
	setAttr ".o" yes;
createNode animBlendNodeAdditiveDL -n "Bat:root_crtl_translateX_AnimLayer1";
	rename -uid "6A853405-4F79-8B29-A19E-DFAD2AA8AD13";
createNode animBlendNodeAdditiveDL -n "Bat:root_crtl_translateY_AnimLayer1";
	rename -uid "88C83AD3-4C4B-5234-5AC3-279107B17026";
createNode animBlendNodeAdditiveDL -n "Bat:root_crtl_translateZ_AnimLayer1";
	rename -uid "B2ABC999-416D-036A-973F-688E1727BA66";
createNode animBlendNodeAdditiveRotation -n "Bat:root_crtl_rotate_AnimLayer1";
	rename -uid "10085C26-4C51-6B07-CAD5-4E8372ED43D7";
createNode animCurveTL -n "root_crtl_translateX_AnimLayer1_inputA";
	rename -uid "90CF16B8-4003-AF2C-9800-27BEAAE01E3D";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 0 1 0 2 0 5 0 8 0 9 0;
createNode animCurveTL -n "root_crtl_translateY_AnimLayer1_inputA";
	rename -uid "DB31FA93-4BFD-0FA2-584E-0D9B426933FA";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 0 1 0 2 0 5 0.2669147767041844 8 0 9 0;
createNode animCurveTL -n "root_crtl_translateZ_AnimLayer1_inputA";
	rename -uid "06FA4EAD-4A2A-4A34-349B-D7B628348A25";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 0 1 0 2 0 5 0 8 0 9 0;
createNode animCurveTU -n "root_crtl_visibility_AnimLayer1_inputA";
	rename -uid "89DE9E95-4919-93C2-B401-B69E3C05D465";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 1 1 1 2 1 5 1 8 1 9 1;
	setAttr -s 6 ".kit[1:5]"  9 9 18 18 9;
	setAttr -s 6 ".kot[1:5]"  5 5 18 18 5;
createNode animCurveTA -n "root_crtl_rotate_AnimLayer1_inputAX";
	rename -uid "FC55EBE7-4893-BF68-9372-BFAF86FE1D20";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 0 1 0 2 0 5 0 8 0 9 0;
createNode animCurveTA -n "root_crtl_rotate_AnimLayer1_inputAY";
	rename -uid "9D8F9B06-48FE-3982-7C07-6485B458D851";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 0 1 0 2 0 5 0 8 0 9 0;
createNode animCurveTA -n "root_crtl_rotate_AnimLayer1_inputAZ";
	rename -uid "C99D1CA9-49AB-ACA8-482A-2EB816C63042";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 0 1 0 2 0 5 0 8 0 9 0;
createNode animCurveTL -n "head_crtl_translateX";
	rename -uid "B55882CC-4CAF-A393-4A1D-88AB47B6D8CD";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 -0.085023455079973276 1 -0.085023455079973276
		 2 -0.085023455079973276 4 -0.085023455079973276 8 -0.085023455079973276 9 -0.085023455079973276
		 11 -0.085023455079973276;
createNode animCurveTL -n "head_crtl_translateY";
	rename -uid "DF9F08FA-4F42-EE0C-F5E9-A5977E594B90";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 7.6505864603587987 1 7.6505864603587987
		 2 7.6505864603587987 4 7.6505864603587987 8 7.6505864603587987 9 7.6505864603587987
		 11 7.6505864603587987;
createNode animCurveTL -n "head_crtl_translateZ";
	rename -uid "E97268EB-4AC3-079F-4EFE-5BB039DFBF90";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 4.5871602266181739 1 4.5871602266181739
		 2 4.5871602266181739 4 4.5871602266181739 8 4.5871602266181739 9 4.5871602266181739
		 11 4.5871602266181739;
createNode animCurveTL -n "l_1_translateX";
	rename -uid "86E154EE-4839-8E5A-2C4E-9589BB212FA9";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 3.474035569337024 1 3.474035569337024
		 2 3.474035569337024 4 3.474035569337024 8 3.474035569337024 9 3.474035569337024 11 3.474035569337024;
createNode animCurveTL -n "l_1_translateY";
	rename -uid "6DC33B7B-446F-D8F7-61DA-E7A3E44F7E41";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 6.5813934680509725 1 6.5813934680509725
		 2 6.5813934680509725 4 6.5813934680509725 8 6.5813934680509725 9 6.5813934680509725
		 11 6.5813934680509725;
createNode animCurveTL -n "l_1_translateZ";
	rename -uid "53420902-44AE-F49C-12B9-B68176D4E069";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 0.75911181921329374 1 0.75911181921329374
		 2 0.75911181921329374 4 0.75911181921329374 8 0.75911181921329374 9 0.75911181921329374
		 11 0.75911181921329374;
createNode animCurveTL -n "l_2_translateX";
	rename -uid "9AF7A442-48E9-0A05-273E-0D87E958590B";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 0.24594133024206447 1 0.24594133024206447
		 2 0.24594133024206447 5 0.24594133024206447 9 0.24594133024206447 11 0.24594133024206447;
createNode animCurveTL -n "l_2_translateY";
	rename -uid "A43CCCFD-47AA-0C7D-1890-2FB2C17986DD";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 -1.2239160477780719 1 -1.2239160477780719
		 2 -1.2239160477780719 5 -1.2239160477780719 9 -1.2239160477780719 11 -1.2239160477780719;
createNode animCurveTL -n "l_2_translateZ";
	rename -uid "AAD1C7E1-4AAC-0CA8-CA57-6E8CFB39FA59";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 0.554333887503349 1 0.554333887503349
		 2 0.554333887503349 5 0.554333887503349 9 0.554333887503349 11 0.554333887503349;
createNode animCurveTL -n "l_3_translateX";
	rename -uid "BC722352-4795-2D10-1391-028F3DF69C89";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 -0.041436095765358227 1 -0.041436095765358227
		 2 -0.041436095765358227 6 -0.041436095765358227 9 -0.041436095765358227 10 -0.041436095765358227
		 11 -0.041436095765358227;
createNode animCurveTL -n "l_3_translateY";
	rename -uid "BE8FCAA3-4072-2CA4-6CF4-F7874F597400";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 -0.7062635245846578 1 -0.7062635245846578
		 2 -0.7062635245846578 6 -0.7062635245846578 9 -0.7062635245846578 10 -0.7062635245846578
		 11 -0.7062635245846578;
createNode animCurveTL -n "l_3_translateZ";
	rename -uid "2B0E9C79-406F-8531-BCFC-C3823B6F8CFE";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 0.14864796282559872 1 0.14864796282559872
		 2 0.14864796282559872 6 0.14864796282559872 9 0.14864796282559872 10 0.14864796282559872
		 11 0.14864796282559872;
createNode animCurveTL -n "l_4_translateX";
	rename -uid "57E5DA1A-4D1E-A226-4B15-FFB3389905F0";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 -0.12056648218844823 1 -0.12056648218844823
		 2 -0.12056648218844823 7 -0.12056648218844823 9 -0.12056648218844823 11 -0.12056648218844823;
createNode animCurveTL -n "l_4_translateY";
	rename -uid "8A493C79-4E5D-4C70-2FE3-EB8DD81E1442";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 -1.1499374067112673 1 -1.1499374067112673
		 2 -1.1499374067112673 7 -1.1499374067112673 9 -1.1499374067112673 11 -1.1499374067112673;
createNode animCurveTL -n "l_4_translateZ";
	rename -uid "62DC06CB-4673-D388-44AE-12A2D2BF51D3";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 -0.12899725366215764 1 -0.12899725366215764
		 2 -0.12899725366215764 7 -0.12899725366215764 9 -0.12899725366215764 11 -0.12899725366215764;
createNode animCurveTL -n "r_1_translateX";
	rename -uid "CC9D66E8-498A-D2AB-C124-D591F792D33E";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 -3.1758350084477005 1 -3.1758350084477005
		 2 -3.1758350084477005 4 -3.1758350084477005 8 -3.1758350084477005 9 -3.1758350084477005
		 11 -3.1758350084477005;
createNode animCurveTL -n "r_1_translateY";
	rename -uid "23006994-43ED-8904-41B4-909001FD4E33";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 6.5813934680509725 1 6.5813934680509725
		 2 6.5813934680509725 4 6.5813934680509725 8 6.5813934680509725 9 6.5813934680509725
		 11 6.5813934680509725;
createNode animCurveTL -n "r_1_translateZ";
	rename -uid "323C946A-422D-F6F2-D7EB-4ABBAF7CF272";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 0.75911181921329374 1 0.75911181921329374
		 2 0.75911181921329374 4 0.75911181921329374 8 0.75911181921329374 9 0.75911181921329374
		 11 0.75911181921329374;
createNode animCurveTL -n "r_2_translateX";
	rename -uid "D2D894EC-44D8-2BC4-C9DF-9CAD025493CD";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 0.18332317285078403 1 0.18332317285078403
		 2 0.18332317285078403 5 0.18332317285078403 9 0.18332317285078403 11 0.18332317285078403;
createNode animCurveTL -n "r_2_translateY";
	rename -uid "C78417D6-465F-9853-9F4A-BB93669F1001";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 1.1180594520487135 1 1.1180594520487135
		 2 1.1180594520487135 5 1.1180594520487135 9 1.1180594520487135 11 1.1180594520487135;
createNode animCurveTL -n "r_2_translateZ";
	rename -uid "EA85E9B4-49EA-24AF-F96F-71AF64FF2F61";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 0.46645168906000023 1 0.46645168906000023
		 2 0.46645168906000023 5 0.46645168906000023 9 0.46645168906000023 11 0.46645168906000023;
createNode animCurveTL -n "r_3_translateX";
	rename -uid "925F8131-4441-C913-16D8-D79DD11DB280";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 0.043500156580541766 1 0.043500156580541766
		 2 0.043500156580541766 6 0.043500156580541766 9 0.043500156580541766 10 0.043500156580541766
		 11 0.043500156580541766;
createNode animCurveTL -n "r_3_translateY";
	rename -uid "B325CF5F-469F-39B0-6BA1-56882DF3E789";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 0.80989333486693638 1 0.80989333486693638
		 2 0.80989333486693638 6 0.80989333486693638 9 0.80989333486693638 10 0.80989333486693638
		 11 0.80989333486693638;
createNode animCurveTL -n "r_3_translateZ";
	rename -uid "32C67433-49DC-93D1-63EC-BEB16F2FD829";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 0.25163374425391971 1 0.25163374425391971
		 2 0.25163374425391971 6 0.25163374425391971 9 0.25163374425391971 10 0.25163374425391971
		 11 0.25163374425391971;
createNode animCurveTL -n "r_4_translateX";
	rename -uid "2FFF5AD3-453F-E77C-9E18-2481730C1CC8";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 -0.20501153716619935 1 -0.20501153716619935
		 2 -0.20501153716619935 6 -0.20501153716619935 9 -0.20501153716619935 11 -0.20501153716619935;
createNode animCurveTL -n "r_4_translateY";
	rename -uid "9765AF84-441C-E037-7DBE-F4981B9BE62B";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 1.1514023692782245 1 1.1514023692782245
		 2 1.1514023692782245 6 1.1514023692782245 9 1.1514023692782245 11 1.1514023692782245;
createNode animCurveTL -n "r_4_translateZ";
	rename -uid "207E9B04-43CA-900C-F0FA-BD8D0792A99C";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 -0.20501153716619935 1 -0.20501153716619935
		 2 -0.20501153716619935 6 -0.20501153716619935 9 -0.20501153716619935 11 -0.20501153716619935;
createNode animCurveTU -n "head_crtl_visibility";
	rename -uid "8A95B841-45CE-60B1-843A-1A9E6D6AD9BE";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 1 1 1 2 1 4 1 8 1 9 1 11 1;
	setAttr -s 7 ".kit[1:6]"  9 9 18 18 9 18;
	setAttr -s 7 ".kot[1:6]"  5 5 18 18 5 18;
createNode animCurveTA -n "head_crtl_rotateX";
	rename -uid "0B4D3C2E-4521-22B0-1D5D-10A6DB07AB08";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 -90.000000000000028 1 -90.000000000000028
		 2 -90.000000000000028 4 -90.000000000000028 8 -90.000000000000028 9 -90.000000000000028
		 11 -90.000000000000028;
createNode animCurveTA -n "head_crtl_rotateY";
	rename -uid "C2796635-40E2-0A63-AE75-0D823E8A09FC";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 0 1 0 2 0 4 0 8 0 9 0 11 0;
createNode animCurveTA -n "head_crtl_rotateZ";
	rename -uid "8B9A87A9-4F1F-D195-7900-5999733067A6";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 0 1 0 2 0 4 0 8 0 9 0 11 0;
createNode animCurveTU -n "head_crtl_scaleX";
	rename -uid "CA9454CA-4390-B61A-AE6A-239ABFDCB0EA";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 2.3129156016760168 1 2.3129156016760168
		 2 2.3129156016760168 4 2.3129156016760168 8 2.3129156016760168 9 2.3129156016760168
		 11 2.3129156016760168;
createNode animCurveTU -n "head_crtl_scaleY";
	rename -uid "8141A091-414A-9124-F224-65965EA6745B";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 2.3129156016760168 1 2.3129156016760168
		 2 2.3129156016760168 4 2.3129156016760168 8 2.3129156016760168 9 2.3129156016760168
		 11 2.3129156016760168;
createNode animCurveTU -n "head_crtl_scaleZ";
	rename -uid "673C50B8-429E-8BE0-7E0C-1C8D5DD90213";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 2.3129156016760168 1 2.3129156016760168
		 2 2.3129156016760168 4 2.3129156016760168 8 2.3129156016760168 9 2.3129156016760168
		 11 2.3129156016760168;
createNode animCurveTU -n "l_1_visibility";
	rename -uid "3A8E623D-4E8E-2AA7-597F-408BBC5E9EE5";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 1 1 1 2 1 4 1 8 1 9 1 11 1;
	setAttr -s 7 ".kit[1:6]"  9 9 18 18 9 18;
	setAttr -s 7 ".kot[1:6]"  5 5 18 18 5 18;
createNode animCurveTA -n "l_1_rotateX";
	rename -uid "BD8B8700-4066-BE35-70ED-DD96415CABFE";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 0 1 0 2 0 4 0 8 0 9 0 11 0;
createNode animCurveTA -n "l_1_rotateY";
	rename -uid "AE999394-4B32-8412-CA0E-D08E3A4442CA";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 0 1 0 2 0 4 0 8 0 9 0 11 0;
createNode animCurveTA -n "l_1_rotateZ";
	rename -uid "596FDB37-4211-BEFD-A95B-8D8A197BD253";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 132.74733785774654 1 124.76973557817789
		 2 111.47373177889686 4 58.630164181760016 8 132.74733785774654 9 132.74733785774654
		 11 111.47373177889686;
	setAttr -s 7 ".kit[4:6]"  9 18 9;
	setAttr -s 7 ".kot[4:6]"  9 18 9;
createNode animCurveTU -n "l_1_scaleX";
	rename -uid "04277A28-4FA5-9456-EE8F-56AB66A83679";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 3.119146278050172 1 3.119146278050172
		 2 3.119146278050172 4 3.119146278050172 8 3.119146278050172 9 3.119146278050172 11 3.119146278050172;
createNode animCurveTU -n "l_1_scaleY";
	rename -uid "0DA642E2-4894-85DA-5C4A-ECBFA41DC8DF";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 3.119146278050172 1 3.119146278050172
		 2 3.119146278050172 4 3.119146278050172 8 3.119146278050172 9 3.119146278050172 11 3.119146278050172;
createNode animCurveTU -n "l_1_scaleZ";
	rename -uid "A34AA50C-4FEF-CCCC-9943-AB88006B091C";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 3.119146278050172 1 3.119146278050172
		 2 3.119146278050172 4 3.119146278050172 8 3.119146278050172 9 3.119146278050172 11 3.119146278050172;
createNode animCurveTU -n "l_2_visibility";
	rename -uid "2F937B9A-44BC-DE7A-90C7-1192A209C217";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 1 1 1 2 1 5 1 9 1 11 1;
	setAttr -s 6 ".kit[2:5]"  9 18 18 18;
	setAttr -s 6 ".kot[2:5]"  5 18 18 18;
createNode animCurveTA -n "l_2_rotateX";
	rename -uid "CF41ECA4-4D55-0144-C76C-77A59C12E111";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 0 1 0 2 0 5 0 9 0 11 0;
createNode animCurveTA -n "l_2_rotateY";
	rename -uid "5CDA9652-4FBB-801E-C7EE-F4B833EF6A94";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 0 1 0 2 0 5 0 9 0 11 0;
createNode animCurveTA -n "l_2_rotateZ";
	rename -uid "FFEF5855-4B67-72AF-A1F4-37892870DDFD";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 6.4737317788967719 1 6.4737317788967719
		 2 6.4737317788967719 5 -11.369835818240054 9 6.4737317788967719 11 6.4737317788967719;
createNode animCurveTU -n "l_2_scaleX";
	rename -uid "9F1A2BDD-4333-8779-6F23-818064F1ED70";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 1.6119069748078478 1 1.6119069748078478
		 2 1.6119069748078478 5 1.6119069748078478 9 1.6119069748078478 11 1.6119069748078478;
createNode animCurveTU -n "l_2_scaleY";
	rename -uid "54B53456-45A4-0030-DD70-A78E089A8123";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 1.6119069748078478 1 1.6119069748078478
		 2 1.6119069748078478 5 1.6119069748078478 9 1.6119069748078478 11 1.6119069748078478;
createNode animCurveTU -n "l_2_scaleZ";
	rename -uid "AFF40897-4CD7-C722-A196-B6916B4BB247";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 1.6119069748078476 1 1.6119069748078476
		 2 1.6119069748078476 5 1.6119069748078476 9 1.6119069748078476 11 1.6119069748078476;
createNode animCurveTU -n "l_3_visibility";
	rename -uid "3F1D239A-4C94-5DBE-9AAF-B9888405593B";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 1 1 1 2 1 6 1 9 1 10 1 11 1;
	setAttr -s 7 ".kit[1:6]"  9 18 18 9 18 18;
	setAttr -s 7 ".kot[1:6]"  5 18 18 5 18 18;
createNode animCurveTA -n "l_3_rotateX";
	rename -uid "D11FC4D3-49B0-503A-DC9A-DA83FFFC542C";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 0 1 0 2 0 6 0 9 0 10 0 11 0;
createNode animCurveTA -n "l_3_rotateY";
	rename -uid "422A30B2-4D45-4409-4BDE-29BCB55D90C2";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 0 1 0 2 0 6 0 9 0 10 0 11 0;
createNode animCurveTA -n "l_3_rotateZ";
	rename -uid "9CE1F31F-45C4-2772-3FDB-5E80A48BD708";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 -26.369835818240091 1 -8.5262682211032441
		 2 1.5475253517504701 6 -26.369835818240091 9 -26.369835818240091 10 -8.5262682211032441
		 11 -8.5262682211032441;
createNode animCurveTU -n "l_3_scaleX";
	rename -uid "B59BCAD8-46B9-985C-3E6A-64939136F0A7";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 0.69717307135314155 1 0.69717307135314155
		 2 0.69717307135314155 6 0.69717307135314155 9 0.69717307135314155 10 0.69717307135314155
		 11 0.69717307135314155;
createNode animCurveTU -n "l_3_scaleY";
	rename -uid "88706062-4676-465B-9F99-AA9C0BC9B5E2";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 0.69717307135314155 1 0.69717307135314155
		 2 0.69717307135314155 6 0.69717307135314155 9 0.69717307135314155 10 0.69717307135314155
		 11 0.69717307135314155;
createNode animCurveTU -n "l_3_scaleZ";
	rename -uid "5BC33140-4C89-3016-719B-7F9C15147E1C";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 0.69717307135314177 1 0.69717307135314177
		 2 0.69717307135314177 6 0.69717307135314177 9 0.69717307135314177 10 0.69717307135314177
		 11 0.69717307135314177;
createNode animCurveTU -n "l_4_visibility";
	rename -uid "72C02CE1-4406-DFE3-0AA3-7E96DCA12798";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 1 1 1 2 1 7 1 9 1 11 1;
	setAttr -s 6 ".kit[1:5]"  9 18 18 9 18;
	setAttr -s 6 ".kot[1:5]"  5 18 18 5 18;
createNode animCurveTA -n "l_4_rotateX";
	rename -uid "4C2EE2E2-46A3-2ABB-C175-08870A0148D0";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 1.2691315943333672 1 1.2777041018466377
		 2 1.2862766093599078 7 1.2691315943333672 9 1.2691315943333672 11 1.2862766093599078;
createNode animCurveTA -n "l_4_rotateY";
	rename -uid "F3CA2071-45C6-2676-5092-DF9DCD0FD1DA";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 0.25518401798152823 1 0.054620612430009069
		 2 -0.14594279312150973 7 0.25518401798152823 9 0.25518401798152823 11 -0.14594279312150973;
createNode animCurveTA -n "l_4_rotateZ";
	rename -uid "544197F1-4A33-288D-AEA4-5E901F93C024";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 -11.367009468026312 1 -2.4474579746508183
		 2 6.4720935187246615 7 -11.367009468026312 9 -11.367009468026312 11 6.4720935187246615;
createNode animCurveTU -n "l_4_scaleX";
	rename -uid "F6F83BBA-47F8-4148-C287-AEBFDAC90724";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 1 1 1 2 1 7 1 9 1 11 1;
createNode animCurveTU -n "l_4_scaleY";
	rename -uid "40AF6204-4C0E-003B-55A1-13B86086D70B";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 1 1 1 2 1 7 1 9 1 11 1;
createNode animCurveTU -n "l_4_scaleZ";
	rename -uid "F177AB19-4699-206D-7A8B-2BACCE9A8ACE";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 1 1 1 2 1 7 1 9 1 11 1;
createNode animCurveTU -n "r_1_visibility";
	rename -uid "8E211DDD-42ED-F585-2096-31934513C35C";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 1 1 1 2 1 4 1 8 1 9 1 11 1;
	setAttr -s 7 ".kit[1:6]"  9 9 18 18 9 18;
	setAttr -s 7 ".kot[1:6]"  5 5 18 18 5 18;
createNode animCurveTA -n "r_1_rotateX";
	rename -uid "1F63ACCB-45A7-BBC2-DBCF-EFB26477D5AC";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 0 1 0 2 0 4 0 8 0 9 0 11 0;
createNode animCurveTA -n "r_1_rotateY";
	rename -uid "5B24FC4D-4480-4235-770E-65AD6EE0F210";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 0 1 0 2 0 4 0 8 0 9 0 11 0;
createNode animCurveTA -n "r_1_rotateZ";
	rename -uid "97F3DF20-4902-F2E1-98C9-D4A83416F006";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 56.597489246833824 1 60.586290386618131
		 2 67.234292286258651 4 122.73606078849613 8 56.597489246833824 9 56.597489246833824
		 11 67.234292286258651;
	setAttr -s 7 ".kit[4:6]"  9 18 9;
	setAttr -s 7 ".kot[4:6]"  9 18 9;
createNode animCurveTU -n "r_1_scaleX";
	rename -uid "6496A0AC-49BE-2C1A-7A63-3AA5AFD2C831";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 3.1191462780501711 1 3.1191462780501711
		 2 3.1191462780501711 4 3.1191462780501711 8 3.1191462780501711 9 3.1191462780501711
		 11 3.1191462780501711;
createNode animCurveTU -n "r_1_scaleY";
	rename -uid "EF39EF50-495A-31A8-5CA3-3CAB3F5CA74E";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 3.1191462780501711 1 3.1191462780501711
		 2 3.1191462780501711 4 3.1191462780501711 8 3.1191462780501711 9 3.1191462780501711
		 11 3.1191462780501711;
createNode animCurveTU -n "r_1_scaleZ";
	rename -uid "65C8D073-4E94-A04C-90CD-419F8F3B058A";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 3.119146278050172 1 3.119146278050172
		 2 3.119146278050172 4 3.119146278050172 8 3.119146278050172 9 3.119146278050172 11 3.119146278050172;
createNode animCurveTU -n "r_2_visibility";
	rename -uid "4683410C-41EE-0EA0-BA09-45998CAD893C";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 1 1 1 2 1 5 1 9 1 11 1;
	setAttr -s 6 ".kit[2:5]"  9 18 18 18;
	setAttr -s 6 ".kot[2:5]"  5 18 18 18;
createNode animCurveTA -n "r_2_rotateX";
	rename -uid "1F598125-4382-D4AC-1B95-7DA43548D6F4";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 0 1 0 2 0 5 0 9 0 11 0;
createNode animCurveTA -n "r_2_rotateY";
	rename -uid "CC4EEA74-4C17-3F8D-B839-378963F063F8";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 0 1 0 2 0 5 0 9 0 11 0;
createNode animCurveTA -n "r_2_rotateZ";
	rename -uid "9DF9BC54-4817-4281-681C-6AB591EC2CE0";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 -7.7657077137414081 1 -7.7657077137414081
		 2 -7.7657077137414081 5 7.9083991205443294 9 -7.7657077137414081 11 -7.7657077137414081;
createNode animCurveTU -n "r_2_scaleX";
	rename -uid "AE53FF2A-4812-8E46-7783-3880FD575BC2";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 1.6119069748078481 1 1.6119069748078481
		 2 1.6119069748078481 5 1.6119069748078481 9 1.6119069748078481 11 1.6119069748078481;
createNode animCurveTU -n "r_2_scaleY";
	rename -uid "EBE3D2E6-4499-F2FE-273F-848714AA0DC3";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 1.6119069748078481 1 1.6119069748078481
		 2 1.6119069748078481 5 1.6119069748078481 9 1.6119069748078481 11 1.6119069748078481;
createNode animCurveTU -n "r_2_scaleZ";
	rename -uid "9F2C7C0B-41D3-5E04-5393-D59C472DB297";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 1.6119069748078476 1 1.6119069748078476
		 2 1.6119069748078476 5 1.6119069748078476 9 1.6119069748078476 11 1.6119069748078476;
createNode animCurveTU -n "r_3_visibility";
	rename -uid "7337E234-4E98-6D15-13BE-879AA1D9ED41";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 1 1 1 2 1 6 1 9 1 10 1 11 1;
	setAttr -s 7 ".kit[1:6]"  9 18 18 9 18 18;
	setAttr -s 7 ".kot[1:6]"  5 18 18 5 18 18;
createNode animCurveTA -n "r_3_rotateX";
	rename -uid "8DA9E9E6-4E66-9F50-C49E-1C8842D7F244";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 0 1 0 2 0 6 0 9 0 10 0 11 0;
createNode animCurveTA -n "r_3_rotateY";
	rename -uid "0C750002-4364-DC6F-0C10-0BBF1CCFD1D1";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 0 1 0 2 0 6 0 9 0 10 0 11 0;
createNode animCurveTA -n "r_3_rotateZ";
	rename -uid "D06492D6-4C6D-01EE-06AC-33BCBD0817FC";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 22.908399120544342 1 7.2342922862586088
		 2 -1.9466846443420551 6 22.908399120544342 9 22.908399120544342 10 7.2342922862586088
		 11 7.2342922862586088;
createNode animCurveTU -n "r_3_scaleX";
	rename -uid "69070AEE-41BB-8A6F-4C84-1F9320E88651";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 0.69717307135314122 1 0.69717307135314122
		 2 0.69717307135314122 6 0.69717307135314122 9 0.69717307135314122 10 0.69717307135314122
		 11 0.69717307135314122;
createNode animCurveTU -n "r_3_scaleY";
	rename -uid "4BA85E53-46CC-5D44-A0F7-BA8D4EFF8B70";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 0.69717307135314122 1 0.69717307135314122
		 2 0.69717307135314122 6 0.69717307135314122 9 0.69717307135314122 10 0.69717307135314122
		 11 0.69717307135314122;
createNode animCurveTU -n "r_3_scaleZ";
	rename -uid "BBB8B545-40E4-0910-8467-59A12B9BD144";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 7 ".ktv[0:6]"  0 0.69717307135314144 1 0.69717307135314144
		 2 0.69717307135314144 6 0.69717307135314144 9 0.69717307135314144 10 0.69717307135314144
		 11 0.69717307135314144;
createNode animCurveTU -n "r_4_visibility";
	rename -uid "0DBE43AC-4E61-76CF-80A5-8CB1FEDB0666";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 1 1 1 2 1 6 1 9 1 11 1;
	setAttr -s 6 ".kit[1:5]"  9 18 18 9 18;
	setAttr -s 6 ".kot[1:5]"  5 18 18 5 18;
createNode animCurveTA -n "r_4_rotateX";
	rename -uid "9313B749-4B0B-C7A2-15CA-7293D2FD3815";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 -28.480738868485226 1 -28.482599312661815
		 2 -28.48363655145053 6 -28.47540449757183 9 -28.480738868485226 11 -28.48363655145053;
createNode animCurveTA -n "r_4_rotateY";
	rename -uid "A973E2F5-4958-8597-856A-69AE7B93323D";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 -1.0775043232821513 1 -2.7748332702316265
		 2 -3.7211317096813326 6 3.7891733653163424 9 -1.0775043232821513 11 -3.7211317096813326;
createNode animCurveTA -n "r_4_rotateZ";
	rename -uid "2C9234EC-49F5-98A1-6C05-F8A9C0220C02";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 -1.9747467768849942 1 -5.0862074154242061
		 2 -6.8209155590345611 6 6.9466093902539887 9 -1.9747467768849942 11 -6.8209155590345611;
createNode animCurveTU -n "r_4_scaleX";
	rename -uid "09EFE4A3-4CE0-A1BC-37BF-79879D91646B";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 1.0000000000000002 1 1.0000000000000002
		 2 1.0000000000000002 6 1.0000000000000002 9 1.0000000000000002 11 1.0000000000000002;
createNode animCurveTU -n "r_4_scaleY";
	rename -uid "87A725F5-44F8-1C05-9F95-908850E9FFDA";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 1.0000000000000002 1 1.0000000000000002
		 2 1.0000000000000002 6 1.0000000000000002 9 1.0000000000000002 11 1.0000000000000002;
createNode animCurveTU -n "r_4_scaleZ";
	rename -uid "D729FCDD-42F5-412E-E4B5-2797FA54A03C";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  0 1.0000000000000002 1 1.0000000000000002
		 2 1.0000000000000002 6 1.0000000000000002 9 1.0000000000000002 11 1.0000000000000002;
createNode objectSet -n "set1";
	rename -uid "662569FC-4A62-CDF4-B4E3-6BA7D196B5C6";
	setAttr ".ihi" 0;
	setAttr -s 20 ".dsm";
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
	setAttr ".fprt" yes;
select -ne :renderPartition;
	setAttr -s 5 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 8 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderingList1;
	setAttr -s 2 ".r";
select -ne :initialShadingGroup;
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultRenderGlobals;
	addAttr -ci true -h true -sn "dss" -ln "defaultSurfaceShader" -dt "string";
	setAttr ".ren" -type "string" "arnold";
	setAttr ".dss" -type "string" "lambert1";
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :defaultColorMgtGlobals;
	setAttr ".cfe" yes;
	setAttr ".cfp" -type "string" "<MAYA_RESOURCES>/OCIO-configs/Maya2022-default/config.ocio";
	setAttr ".vtn" -type "string" "ACES 1.0 SDR-video (sRGB)";
	setAttr ".vn" -type "string" "ACES 1.0 SDR-video";
	setAttr ".dn" -type "string" "sRGB";
	setAttr ".wsn" -type "string" "ACEScg";
	setAttr ".otn" -type "string" "ACES 1.0 SDR-video (sRGB)";
	setAttr ".potn" -type "string" "ACES 1.0 SDR-video (sRGB)";
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
connectAttr "BatRN.phl[1]" "AnimLayer1.dsm" -na;
connectAttr "Bat:joint13_translateX_AnimLayer1.o" "BatRN.phl[2]";
connectAttr "BatRN.phl[3]" "AnimLayer1.dsm" -na;
connectAttr "Bat:joint13_translateY_AnimLayer1.o" "BatRN.phl[4]";
connectAttr "BatRN.phl[5]" "AnimLayer1.dsm" -na;
connectAttr "Bat:joint13_translateZ_AnimLayer1.o" "BatRN.phl[6]";
connectAttr "BatRN.phl[7]" "AnimLayer1.dsm" -na;
connectAttr "Bat:joint13_visibility_AnimLayer1.o" "BatRN.phl[8]";
connectAttr "BatRN.phl[9]" "AnimLayer1.dsm" -na;
connectAttr "Bat:joint13_rotate_AnimLayer1.ox" "BatRN.phl[10]";
connectAttr "BatRN.phl[11]" "AnimLayer1.dsm" -na;
connectAttr "Bat:joint13_rotate_AnimLayer1.oy" "BatRN.phl[12]";
connectAttr "BatRN.phl[13]" "AnimLayer1.dsm" -na;
connectAttr "Bat:joint13_rotate_AnimLayer1.oz" "BatRN.phl[14]";
connectAttr "BatRN.phl[15]" "Bat:joint13_rotate_AnimLayer1.ro";
connectAttr "BatRN.phl[16]" "AnimLayer1.dsm" -na;
connectAttr "Bat:joint13_scaleX_AnimLayer1.o" "BatRN.phl[17]";
connectAttr "BatRN.phl[18]" "AnimLayer1.dsm" -na;
connectAttr "Bat:joint13_scaleY_AnimLayer1.o" "BatRN.phl[19]";
connectAttr "BatRN.phl[20]" "AnimLayer1.dsm" -na;
connectAttr "Bat:joint13_scaleZ_AnimLayer1.o" "BatRN.phl[21]";
connectAttr "BatRN.phl[22]" "AnimLayer1.dsm" -na;
connectAttr "Bat:root_crtl_translateX_AnimLayer1.o" "BatRN.phl[23]";
connectAttr "BatRN.phl[24]" "AnimLayer1.dsm" -na;
connectAttr "Bat:root_crtl_translateY_AnimLayer1.o" "BatRN.phl[25]";
connectAttr "BatRN.phl[26]" "AnimLayer1.dsm" -na;
connectAttr "Bat:root_crtl_translateZ_AnimLayer1.o" "BatRN.phl[27]";
connectAttr "BatRN.phl[28]" "AnimLayer1.dsm" -na;
connectAttr "Bat:root_crtl_rotate_AnimLayer1.ox" "BatRN.phl[29]";
connectAttr "BatRN.phl[30]" "AnimLayer1.dsm" -na;
connectAttr "Bat:root_crtl_rotate_AnimLayer1.oy" "BatRN.phl[31]";
connectAttr "BatRN.phl[32]" "AnimLayer1.dsm" -na;
connectAttr "Bat:root_crtl_rotate_AnimLayer1.oz" "BatRN.phl[33]";
connectAttr "BatRN.phl[34]" "Bat:root_crtl_rotate_AnimLayer1.ro";
connectAttr "BatRN.phl[35]" "AnimLayer1.dsm" -na;
connectAttr "Bat:root_crtl_visibility_AnimLayer1.o" "BatRN.phl[36]";
connectAttr "BatRN.phl[37]" "set1.dsm" -na;
connectAttr "BatRN.phl[38]" "set1.dsm" -na;
connectAttr "head_crtl_translateX.o" "BatRN.phl[39]";
connectAttr "head_crtl_translateY.o" "BatRN.phl[40]";
connectAttr "head_crtl_translateZ.o" "BatRN.phl[41]";
connectAttr "head_crtl_rotateX.o" "BatRN.phl[42]";
connectAttr "head_crtl_rotateY.o" "BatRN.phl[43]";
connectAttr "head_crtl_rotateZ.o" "BatRN.phl[44]";
connectAttr "head_crtl_scaleX.o" "BatRN.phl[45]";
connectAttr "head_crtl_scaleY.o" "BatRN.phl[46]";
connectAttr "head_crtl_scaleZ.o" "BatRN.phl[47]";
connectAttr "head_crtl_visibility.o" "BatRN.phl[48]";
connectAttr "BatRN.phl[49]" "set1.dsm" -na;
connectAttr "BatRN.phl[50]" "set1.dsm" -na;
connectAttr "l_1_translateX.o" "BatRN.phl[51]";
connectAttr "l_1_translateY.o" "BatRN.phl[52]";
connectAttr "l_1_translateZ.o" "BatRN.phl[53]";
connectAttr "l_1_rotateX.o" "BatRN.phl[54]";
connectAttr "l_1_rotateY.o" "BatRN.phl[55]";
connectAttr "l_1_rotateZ.o" "BatRN.phl[56]";
connectAttr "l_1_scaleX.o" "BatRN.phl[57]";
connectAttr "l_1_scaleY.o" "BatRN.phl[58]";
connectAttr "l_1_scaleZ.o" "BatRN.phl[59]";
connectAttr "l_1_visibility.o" "BatRN.phl[60]";
connectAttr "BatRN.phl[61]" "set1.dsm" -na;
connectAttr "BatRN.phl[62]" "set1.dsm" -na;
connectAttr "l_2_translateX.o" "BatRN.phl[63]";
connectAttr "l_2_translateY.o" "BatRN.phl[64]";
connectAttr "l_2_translateZ.o" "BatRN.phl[65]";
connectAttr "l_2_rotateX.o" "BatRN.phl[66]";
connectAttr "l_2_rotateY.o" "BatRN.phl[67]";
connectAttr "l_2_rotateZ.o" "BatRN.phl[68]";
connectAttr "l_2_scaleX.o" "BatRN.phl[69]";
connectAttr "l_2_scaleY.o" "BatRN.phl[70]";
connectAttr "l_2_scaleZ.o" "BatRN.phl[71]";
connectAttr "l_2_visibility.o" "BatRN.phl[72]";
connectAttr "BatRN.phl[73]" "set1.dsm" -na;
connectAttr "BatRN.phl[74]" "set1.dsm" -na;
connectAttr "l_3_translateX.o" "BatRN.phl[75]";
connectAttr "l_3_translateY.o" "BatRN.phl[76]";
connectAttr "l_3_translateZ.o" "BatRN.phl[77]";
connectAttr "l_3_rotateX.o" "BatRN.phl[78]";
connectAttr "l_3_rotateY.o" "BatRN.phl[79]";
connectAttr "l_3_rotateZ.o" "BatRN.phl[80]";
connectAttr "l_3_scaleX.o" "BatRN.phl[81]";
connectAttr "l_3_scaleY.o" "BatRN.phl[82]";
connectAttr "l_3_scaleZ.o" "BatRN.phl[83]";
connectAttr "l_3_visibility.o" "BatRN.phl[84]";
connectAttr "BatRN.phl[85]" "set1.dsm" -na;
connectAttr "BatRN.phl[86]" "set1.dsm" -na;
connectAttr "l_4_translateX.o" "BatRN.phl[87]";
connectAttr "l_4_translateY.o" "BatRN.phl[88]";
connectAttr "l_4_translateZ.o" "BatRN.phl[89]";
connectAttr "l_4_rotateX.o" "BatRN.phl[90]";
connectAttr "l_4_rotateY.o" "BatRN.phl[91]";
connectAttr "l_4_rotateZ.o" "BatRN.phl[92]";
connectAttr "l_4_scaleX.o" "BatRN.phl[93]";
connectAttr "l_4_scaleY.o" "BatRN.phl[94]";
connectAttr "l_4_scaleZ.o" "BatRN.phl[95]";
connectAttr "l_4_visibility.o" "BatRN.phl[96]";
connectAttr "BatRN.phl[97]" "set1.dsm" -na;
connectAttr "BatRN.phl[98]" "set1.dsm" -na;
connectAttr "r_1_translateX.o" "BatRN.phl[99]";
connectAttr "r_1_translateY.o" "BatRN.phl[100]";
connectAttr "r_1_translateZ.o" "BatRN.phl[101]";
connectAttr "r_1_rotateX.o" "BatRN.phl[102]";
connectAttr "r_1_rotateY.o" "BatRN.phl[103]";
connectAttr "r_1_rotateZ.o" "BatRN.phl[104]";
connectAttr "r_1_scaleX.o" "BatRN.phl[105]";
connectAttr "r_1_scaleY.o" "BatRN.phl[106]";
connectAttr "r_1_scaleZ.o" "BatRN.phl[107]";
connectAttr "r_1_visibility.o" "BatRN.phl[108]";
connectAttr "BatRN.phl[109]" "set1.dsm" -na;
connectAttr "BatRN.phl[110]" "set1.dsm" -na;
connectAttr "r_2_translateX.o" "BatRN.phl[111]";
connectAttr "r_2_translateY.o" "BatRN.phl[112]";
connectAttr "r_2_translateZ.o" "BatRN.phl[113]";
connectAttr "r_2_rotateX.o" "BatRN.phl[114]";
connectAttr "r_2_rotateY.o" "BatRN.phl[115]";
connectAttr "r_2_rotateZ.o" "BatRN.phl[116]";
connectAttr "r_2_scaleX.o" "BatRN.phl[117]";
connectAttr "r_2_scaleY.o" "BatRN.phl[118]";
connectAttr "r_2_scaleZ.o" "BatRN.phl[119]";
connectAttr "r_2_visibility.o" "BatRN.phl[120]";
connectAttr "BatRN.phl[121]" "set1.dsm" -na;
connectAttr "BatRN.phl[122]" "set1.dsm" -na;
connectAttr "r_3_translateX.o" "BatRN.phl[123]";
connectAttr "r_3_translateY.o" "BatRN.phl[124]";
connectAttr "r_3_translateZ.o" "BatRN.phl[125]";
connectAttr "r_3_rotateX.o" "BatRN.phl[126]";
connectAttr "r_3_rotateY.o" "BatRN.phl[127]";
connectAttr "r_3_rotateZ.o" "BatRN.phl[128]";
connectAttr "r_3_scaleX.o" "BatRN.phl[129]";
connectAttr "r_3_scaleY.o" "BatRN.phl[130]";
connectAttr "r_3_scaleZ.o" "BatRN.phl[131]";
connectAttr "r_3_visibility.o" "BatRN.phl[132]";
connectAttr "BatRN.phl[133]" "set1.dsm" -na;
connectAttr "BatRN.phl[134]" "set1.dsm" -na;
connectAttr "r_4_translateX.o" "BatRN.phl[135]";
connectAttr "r_4_translateY.o" "BatRN.phl[136]";
connectAttr "r_4_translateZ.o" "BatRN.phl[137]";
connectAttr "r_4_rotateX.o" "BatRN.phl[138]";
connectAttr "r_4_rotateY.o" "BatRN.phl[139]";
connectAttr "r_4_rotateZ.o" "BatRN.phl[140]";
connectAttr "r_4_scaleX.o" "BatRN.phl[141]";
connectAttr "r_4_scaleY.o" "BatRN.phl[142]";
connectAttr "r_4_scaleZ.o" "BatRN.phl[143]";
connectAttr "r_4_visibility.o" "BatRN.phl[144]";
connectAttr "BatRN.phl[145]" "set1.dsm" -na;
connectAttr "BatRN.phl[146]" "set1.dsm" -na;
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
connectAttr "layerManager.dli[0]" "defaultLayer.id";
connectAttr "renderLayerManager.rlmi[0]" "defaultRenderLayer.rlid";
connectAttr "AnimLayer1.sl" "BaseAnimation.chsl[0]";
connectAttr "AnimLayer1.play" "BaseAnimation.cdly[0]";
connectAttr "BaseAnimation.csol" "AnimLayer1.sslo";
connectAttr "BaseAnimation.fgwt" "AnimLayer1.pwth";
connectAttr "BaseAnimation.omte" "AnimLayer1.pmte";
connectAttr "Bat:joint13_visibility_AnimLayer1.msg" "AnimLayer1.bnds[0]";
connectAttr "Bat:joint13_translateX_AnimLayer1.msg" "AnimLayer1.bnds[1]";
connectAttr "Bat:joint13_translateY_AnimLayer1.msg" "AnimLayer1.bnds[2]";
connectAttr "Bat:joint13_translateZ_AnimLayer1.msg" "AnimLayer1.bnds[3]";
connectAttr "Bat:joint13_rotate_AnimLayer1.msg" "AnimLayer1.bnds[7]";
connectAttr "Bat:joint13_scaleX_AnimLayer1.msg" "AnimLayer1.bnds[8]";
connectAttr "Bat:joint13_scaleY_AnimLayer1.msg" "AnimLayer1.bnds[9]";
connectAttr "Bat:joint13_scaleZ_AnimLayer1.msg" "AnimLayer1.bnds[10]";
connectAttr "Bat:root_crtl_visibility_AnimLayer1.msg" "AnimLayer1.bnds[11]";
connectAttr "Bat:root_crtl_translateX_AnimLayer1.msg" "AnimLayer1.bnds[12]";
connectAttr "Bat:root_crtl_translateY_AnimLayer1.msg" "AnimLayer1.bnds[13]";
connectAttr "Bat:root_crtl_translateZ_AnimLayer1.msg" "AnimLayer1.bnds[14]";
connectAttr "Bat:root_crtl_rotate_AnimLayer1.msg" "AnimLayer1.bnds[18]";
connectAttr "AnimLayer1.bgwt" "Bat:joint13_visibility_AnimLayer1.wa";
connectAttr "AnimLayer1.fgwt" "Bat:joint13_visibility_AnimLayer1.wb";
connectAttr "AnimLayer1.bgwt" "Bat:joint13_translateX_AnimLayer1.wa";
connectAttr "AnimLayer1.fgwt" "Bat:joint13_translateX_AnimLayer1.wb";
connectAttr "AnimLayer1.bgwt" "Bat:joint13_translateY_AnimLayer1.wa";
connectAttr "AnimLayer1.fgwt" "Bat:joint13_translateY_AnimLayer1.wb";
connectAttr "AnimLayer1.bgwt" "Bat:joint13_translateZ_AnimLayer1.wa";
connectAttr "AnimLayer1.fgwt" "Bat:joint13_translateZ_AnimLayer1.wb";
connectAttr "AnimLayer1.oram" "Bat:joint13_rotate_AnimLayer1.acm";
connectAttr "AnimLayer1.bgwt" "Bat:joint13_rotate_AnimLayer1.wa";
connectAttr "AnimLayer1.fgwt" "Bat:joint13_rotate_AnimLayer1.wb";
connectAttr "AnimLayer1.sam" "Bat:joint13_scaleX_AnimLayer1.acm";
connectAttr "AnimLayer1.bgwt" "Bat:joint13_scaleX_AnimLayer1.wa";
connectAttr "AnimLayer1.fgwt" "Bat:joint13_scaleX_AnimLayer1.wb";
connectAttr "AnimLayer1.sam" "Bat:joint13_scaleY_AnimLayer1.acm";
connectAttr "AnimLayer1.bgwt" "Bat:joint13_scaleY_AnimLayer1.wa";
connectAttr "AnimLayer1.fgwt" "Bat:joint13_scaleY_AnimLayer1.wb";
connectAttr "AnimLayer1.sam" "Bat:joint13_scaleZ_AnimLayer1.acm";
connectAttr "AnimLayer1.bgwt" "Bat:joint13_scaleZ_AnimLayer1.wa";
connectAttr "AnimLayer1.fgwt" "Bat:joint13_scaleZ_AnimLayer1.wb";
connectAttr "AnimLayer1.bgwt" "Bat:root_crtl_visibility_AnimLayer1.wa";
connectAttr "AnimLayer1.fgwt" "Bat:root_crtl_visibility_AnimLayer1.wb";
connectAttr "root_crtl_visibility_AnimLayer1_inputA.o" "Bat:root_crtl_visibility_AnimLayer1.ia"
		;
connectAttr "AnimLayer1.bgwt" "Bat:root_crtl_translateX_AnimLayer1.wa";
connectAttr "AnimLayer1.fgwt" "Bat:root_crtl_translateX_AnimLayer1.wb";
connectAttr "root_crtl_translateX_AnimLayer1_inputA.o" "Bat:root_crtl_translateX_AnimLayer1.ia"
		;
connectAttr "AnimLayer1.bgwt" "Bat:root_crtl_translateY_AnimLayer1.wa";
connectAttr "AnimLayer1.fgwt" "Bat:root_crtl_translateY_AnimLayer1.wb";
connectAttr "root_crtl_translateY_AnimLayer1_inputA.o" "Bat:root_crtl_translateY_AnimLayer1.ia"
		;
connectAttr "AnimLayer1.bgwt" "Bat:root_crtl_translateZ_AnimLayer1.wa";
connectAttr "AnimLayer1.fgwt" "Bat:root_crtl_translateZ_AnimLayer1.wb";
connectAttr "root_crtl_translateZ_AnimLayer1_inputA.o" "Bat:root_crtl_translateZ_AnimLayer1.ia"
		;
connectAttr "AnimLayer1.oram" "Bat:root_crtl_rotate_AnimLayer1.acm";
connectAttr "AnimLayer1.bgwt" "Bat:root_crtl_rotate_AnimLayer1.wa";
connectAttr "AnimLayer1.fgwt" "Bat:root_crtl_rotate_AnimLayer1.wb";
connectAttr "root_crtl_rotate_AnimLayer1_inputAX.o" "Bat:root_crtl_rotate_AnimLayer1.iax"
		;
connectAttr "root_crtl_rotate_AnimLayer1_inputAY.o" "Bat:root_crtl_rotate_AnimLayer1.iay"
		;
connectAttr "root_crtl_rotate_AnimLayer1_inputAZ.o" "Bat:root_crtl_rotate_AnimLayer1.iaz"
		;
connectAttr "defaultRenderLayer.msg" ":defaultRenderingList1.r" -na;
// End of Animations.ma
