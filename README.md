# LaylaVR
Meditation App for Oculus Quest 
![Error](https://github.com/kahveciozan/LaylaVR/blob/public/Assets/Sprites/LaylaLogo.png)
## What is LAYLA
Layla is a meditation application that aims to be published first on Applab(Sideqestvr.com) and then on Oculus Official Store.Target devices are Oculus Quest and Quest2. Currently, we have decided to consist of 3 main categories. Focus, Calm and Excitement. You can specify ideas for new category ideas. Each part should consist of 2 or 3 different parts(With different environments).
## Guidelines for Creating Content LAYLA
[Click here to become a contributor](https://forms.gle/XvepfJQD45Uu37mT7) <br/>
Layla were created using the Unity3D Game Engine
### How To Create a New Scene and Environment
1. Fork the project to your own github and clone your local Pc. (Use Unity Version 2019.4.X.X) 
2. Decide in which category you want to create a scene. Then create one new scene.
3. Delete Maincamera.
4. Add  `LaylaCameraRig.prefab` to Hierarchy. This prefab includes Darker Effect, some particle effects(virtual breahing etc.) UI(loading screen, mood tracker, rating panel and finish panel).
5. Desing and/or develop your original scene.
6. Push the repository to your github repo.
7. Create and pull request with new branch.
### Development Tools and SDKs
[Unity3D Game Engine](https://unity.com/) <br/>
[Oculus Integration SDK](https://assetstore.unity.com/packages/tools/integration/oculus-integration-82022) <br/>
[DOTween(HOTween v2)](https://assetstore.unity.com/packages/tools/visual-scripting/dotween-pro-32416) <br/>
### Concepst And Categories
- Decide what category your target scene will be in. There are 3 category offers from the team but you can feel free either to add a new category or contribute a stage in one existing category.
1. *Calm* 
2. *Focus* 
3. *Excitement*

- Be careful not to be too similar to scenes that have been made before. <br/>
- Make sure the gameplay length is longer than 5 minutes and less than 15 minutes.
### Avoid doing these
- Don't change any ready prefabs, you can use it in your scene but never change it.
- Don't call at any time  `Application.Quit()` `SceneManager.LoadScene()` `SceneManager.LoadSceneAsync()`
- Don't delete or modify any files in the project
- Don't use coptright audios, logos , 3D models and any assets.
### Configure Unity Project Settings
- Build Settings > Texture Compression : ASTC
- Switch Project to Android
-Project Settings > Player > XR Settings > Virtual Reality Supported: CLICK
Virtual Reality SDKs:  + Add Oculus
- Project Settings > Player > Other Settings > Graphics APIs : Remove Vulkan
- Project Settings > Player > Other Settings > Target API Level : API Level 23
### How To Create A New Canvas for VR ( You probably won't need to make this )
 - Create new Canvas
 - Layer : Default
 - Render Mode : WorldSpace
 - Canvas EventCamera : Assign here, CenterEyeAnchor
 - Canvas Pos X:0, Y:4, Z:0  (This may vary depending on your scene.)
 - Canvas Scale X: 0.01, Y:0.01, Z: 0.01
 - Add Canvas to OVRRaycaster.cs
 - UIHelper > LaserPointer > LineRenderer : Activate this (It may already active)
