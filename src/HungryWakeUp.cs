using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Server;

[assembly: ModInfo("Hungry? Wake Up!",
    Authors = new[] { "Craluminum2413" })]

namespace HungryWakeUp;

public class Core : ModSystem
{
    public override bool ShouldLoad(EnumAppSide forSide) => forSide == EnumAppSide.Server;

    public override void StartServerSide(ICoreServerAPI api)
    {
        base.StartServerSide(api);
        api.RegisterEntityBehaviorClass("NWI_EntityBehaviorHungryWakeUp", typeof(EntityBehaviorHungryWakeUp));
        api.Event.OnEntitySpawn += AddEntityBehaviors;
        api.World.Logger.Event("started 'Hungry? Wake Up!' mod");
    }

    private void AddEntityBehaviors(Entity entity)
    {
        if (entity is EntityPlayer) entity.AddBehavior(new EntityBehaviorHungryWakeUp(entity));
    }
}