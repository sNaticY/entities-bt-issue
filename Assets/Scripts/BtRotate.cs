using EntitiesBT.Components;
using EntitiesBT.Core;
using EntitiesBT.Entities;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[BehaviorNode("F5C2EE7E-690A-4B5C-9489-FB362C949112")]
public struct BtNodeRotate : INodeData
{
    public float angularSpeed;
    
    [ReadOnly(typeof(Rotation))]
    public NodeState Tick<TNodeBlob, TBlackboard>(int index, ref TNodeBlob blob, ref TBlackboard bb)
        where TNodeBlob : struct, INodeBlob
        where TBlackboard : struct, IBlackboard
    {
        ref var rotation = ref bb.GetDataRef<Rotation>();
        rotation.Value = math.mul(quaternion.RotateZ(angularSpeed), rotation.Value);
        return NodeState.Success;
    }

    public void Reset<TNodeBlob, TBlackboard>(int index, ref TNodeBlob blob, ref TBlackboard bb)
        where TNodeBlob : struct, INodeBlob
        where TBlackboard : struct, IBlackboard
    {}
}

// builder and editor part of node
public class BtRotate : BTNode<BtNodeRotate>
{
    public float angularSpeed;
    
    protected override void Build(ref BtNodeRotate data, BlobBuilder _, ITreeNode<INodeDataBuilder>[] __)
    {
        data.angularSpeed = angularSpeed;
    }
}