using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;

[assembly: ModInfo("Hungry? Wake Up!",
    Authors = new[] { "Craluminum2413" })]

namespace HungryWakeUp;

public class Core : ModSystem
{
    public override void Start(ICoreAPI api)
    {
        base.Start(api);
        api.RegisterEntityBehaviorClass("HWU_EntityBehaviorHungryWakeUp", typeof(EntityBehaviorHungryWakeUp));
        api.Event.OnEntitySpawn += AddEntityBehaviors;
        api.World.Logger.Event("started 'Hungry? Wake Up!' mod");
    }

    private void AddEntityBehaviors(Entity entity)
    {
        if (entity is EntityPlayer) entity.AddBehavior(new EntityBehaviorHungryWakeUp(entity));
    }
}