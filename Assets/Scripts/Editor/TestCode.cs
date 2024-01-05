using System.Collections.Generic;
using System.Linq;
using Spine;
using Spine.Unity;
using Spine.Unity.Editor;
using UnityEditor;
using UnityEngine;


public class TestCode : Editor
{
    // [MenuItem("Tools/Spine2D/Fade System3")]
    // private static void Apply3()
    // {
    //     if (Selection.gameObjects.Length == 0)
    //         return;
    //
    //     GameObject go = Selection.gameObjects[0];
    //     
    //     // go의 자식에 있는 SkeletonPartsRenderer를 모두 가져온다.
    //     SkeletonPartsRenderer[] pp = go.GetComponentsInChildren<SkeletonPartsRenderer>();
    //
    //     List<int> sortingOrders = new List<int>();
    //
    //     foreach (SkeletonPartsRenderer renderer in pp)
    //         sortingOrders.Add(renderer.MeshRenderer.sortingOrder);
    //
    //     // sortingOrders을 리버스한 다음 다시 sortingOrders에 넣는다.
    //     sortingOrders = sortingOrders.Reverse<int>().ToList<int>();
    //
    //     for (int i = 0; i < sortingOrders.Count; i++)
    //         pp[i].MeshRenderer.sortingOrder = sortingOrders[i];
    // }

    [MenuItem("Tools/Spine2D/Apply Fade")]
    private static void Apply()
    {
        if (Selection.gameObjects.Length == 0)
            return;

        GameObject go = Selection.gameObjects[0];

        if (go.TryGetComponent(out SkeletonAnimation skeletonAnimation))
        {
            // 초기화
            skeletonAnimation.separatorSlots.Clear();

            // 이름 추가
            var separatorSlotNames = skeletonAnimation.skeleton.Slots.Items.Select(x => x.Data.Name).ToArray();
            SkeletonRendererInspector.SetSeparatorSlotNames(skeletonAnimation, separatorSlotNames);

            // 분리 추가
            foreach (Slot skeletonSlot in skeletonAnimation.skeleton.Slots)
                skeletonAnimation.separatorSlots.Add(skeletonSlot);

            // 적용
            SkeletonRenderSeparator.AddToSkeletonRenderer(skeletonAnimation);
        }

        // go의 자식에 있는 SkeletonPartsRenderer를 모두 가져온다.
        SkeletonPartsRenderer[] pp = go.GetComponentsInChildren<SkeletonPartsRenderer>();
        
        List<int> sortingOrders = new List<int>();
        
        foreach (SkeletonPartsRenderer renderer in pp)
            sortingOrders.Add(renderer.MeshRenderer.sortingOrder);
        
        // sortingOrders을 리버스한 다음 다시 sortingOrders에 넣는다.
        sortingOrders = sortingOrders.Reverse<int>().ToList<int>();
        
        for (int i = 0; i < sortingOrders.Count; i++)
            pp[i].MeshRenderer.sortingOrder = sortingOrders[i];
    }
}
