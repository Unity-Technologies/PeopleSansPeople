//using System.Collections;
//using System.Collections.Generic;
//using Unity.Simulation;
//using UnityEngine;
//using UnityEngine.Experimental.Rendering;

//public class SetRenderResolution : MonoBehaviour
//{
//    public GameObject mainCamera;

//    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
//    public static void SetResolution()
//    {
//        // Workaround for Nest to address resolution settings not being recognized in cloud rendering.
//#if PLATFORM_CLOUD_RENDERING
//        if (Configuration.Instance.IsSimulationRunningInCloud())
//        {
//            Camera cam = mainCamera.GetComponent<Camera>();
//            cam.targetTexture = new RenderTexture(1280, 960, 24, GraphicsFormat.R8G8B8A8_SRGB);
//        }
//#endif
//    }
//}
