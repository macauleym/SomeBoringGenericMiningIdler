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
                .WithPower(2)
                .WithCost(5)
                .WithCostFactor(0.75d);
                break;
            case BuildingName.MiningCamp: builder
                .AsName(BuildingName.MiningCamp)
                .WithPower(12)
                .WithCost(70)
                .WithCostFactor(0.8d);
                break;
            case BuildingName.Excavator: builder
                .AsName(BuildingName.Excavator)
                .WithPower(48)
                .WithCost(210)
                .WithCostFactor(0.95d);
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
