using System.Numerics;
using System.Windows.Controls;

namespace SomeBoringGenericMiningIdler.Core.Buildings;

public class BuildingBuilder
{
    BuildingName name;
    BigInteger basePower;
    BigInteger baseCost;
    double costFactor;
    TextBlock costBlock;
    TextBlock countBlock;

    public BuildingBuilder AsName(BuildingName toUse)
    {
        name = toUse;

        return this;
    }

    public BuildingBuilder WithPower(BigInteger desiredBase)
    {
        basePower = desiredBase;

        return this;
    }

    public BuildingBuilder WithCost(BigInteger desiredBase)
    {
        baseCost = desiredBase;

        return this;
    }

    public BuildingBuilder WithCostFactor(double desiredCostFactor)
    {
        costFactor = desiredCostFactor;

        return this;
    }

    public BuildingBuilder UsingCostText(in TextBlock costTextBlock)
    {
        costBlock = costTextBlock;

        return this;
    }

    public BuildingBuilder UsingCountText(in TextBlock countTextBlock)
    {
        countBlock = countTextBlock;

        return this;
    }
    
    public Building Build() => new
        ( name
        , basePower
        , baseCost
        , costFactor
        , costBlock
        , countBlock
        );
}