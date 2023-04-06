using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.GameContent;

namespace HungryWakeUp;

public class EntityBehaviorHungryWakeUp : EntityBehavior
{
    public EntityBehaviorHungryWakeUp(Entity entity) : base(entity) { }

    public override void OnGameTick(float deltaTime)
    {
        base.OnGameTick(deltaTime);

        switch (entity)
        {
            case EntityPlayer player:
                player?.WalkInventory(CheckSlot);
                break;
            case EntityAgent entityAgent:
                entityAgent?.WalkInventory(CheckSlot);
                break;
        }
    }

    private bool CheckSlot(ItemSlot slot)
    {
        if (entity is not EntityPlayer entityPlayer)
        {
            return true;
        }

        var behaviorTiredness = entity.GetBehavior<EntityBehaviorTiredness>();

        if (entityPlayer.MountedOn == null || behaviorTiredness?.IsSleeping != true)
        {
            return true;
        }

        if (entity.GetBehavior<EntityBehaviorHunger>().Saturation == 0)
        {
            entityPlayer.TryUnmount();
        }

        return true;
    }

    public override string PropertyName() => "hungrywakeup";
}