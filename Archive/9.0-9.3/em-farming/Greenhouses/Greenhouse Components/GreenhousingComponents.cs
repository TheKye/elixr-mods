using Eco.Gameplay.Objects;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using Vox = Eco.Shared.Voxel.World;

namespace Eco.EM.Greenhousing
{
    [Serialized]
    public abstract class ValidPositionComponent : WorldObjectComponent
    {
        public abstract bool IsValid(Vector3i pos);
    }

    [Serialized]
    public abstract class IrrigationComponent : ValidPositionComponent { }

    [Serialized]
    public class HeatLampComponent : ValidPositionComponent
    {
        private float radius;

        public HeatLampComponent() { }

        public void Initialize(float radius)
        {
            this.radius = radius;    
        }

        public override bool IsValid(Vector3i pos) 
        {
            var parentPos = Parent.Position;
            return  parentPos.y > pos.y && Vox.WrappedDistance(pos, parentPos) < radius; 
        }
    }

    [Serialized]
    public class SprinklerComponent: IrrigationComponent
    {
        private float radius;

        public SprinklerComponent() { }

        public void Initialize(float radius)
        {
            this.radius = radius;
        }

        public override bool IsValid(Vector3i pos)
        {
            var parentPos = Parent.Position;
            return parentPos.y > pos.y && Vox.WrappedDistance(pos, parentPos) < radius;
        }
    }
}
