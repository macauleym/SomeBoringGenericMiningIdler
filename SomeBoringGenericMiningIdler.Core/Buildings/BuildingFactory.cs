using System.Windows.Controls;
using SomeBoringGenericMiningIdler.Core.Interfaces.Buildings;

namespace SomeBoringGenericMiningIdler.Core.Buildings;

public class BuildingFactory : IConstructBuilding
{
    public Building Construct(BuildingName toCreate, in TextBlock costBlock, in TextBlock countBlock)
    {
        var builder = new BuildingBuilder();
        switch(toCreate)
        { 
            case BuildingName.SentientShovel: builder
                .AsName(BuildingName.SentientShovel)
                .WithPower(1)
                .WithCost(10)
                .WithCostFactor(0.9d);
                break;
            case BuildingName.MiningCamp: builder
                .AsName(BuildingName.MiningCamp)
                .WithPower(6)
                .WithCost(210)
                .WithCostFactor(1.01d);
                break;
            case BuildingName.Excavator: builder
                .AsName(BuildingName.Excavator)
                .WithPower(24)
                .WithCost(600)
                .WithCostFactor(1.045d);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(toCreate)
                , toCreate
                , null
                );
        }

        builder.UsingCountText(countBlock);
        builder.UsingCostText(costBlock);
        
        return builder.Build();
    }
}
