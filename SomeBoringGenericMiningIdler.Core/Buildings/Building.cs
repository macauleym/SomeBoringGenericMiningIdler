using System.Numerics;
using System.Windows.Controls;
using SomeBoringGenericMiningIdler.Core.Interfaces.Buildings;

namespace SomeBoringGenericMiningIdler.Core.Buildings;

public class Building
: IMineOre
, ICostOre
, ICanBeSold
, ICanHaveMultiple
, IHaveName
{
    public BuildingName Name { get; }
    
    public BigInteger BaseCost { get; }
    public BigInteger Cost { get; private set; }
    public double CostFactor { get; private set; }
    public TextBlock CostBlock { get; } 
    
    public BigInteger Owned { get; private set; }
    public TextBlock CountBlock { get; }
    
    public BigInteger BaseFactor { get; }
    public BigInteger Factor { get; private set; }

    public Building(
      BuildingName name
    , BigInteger inBasePowerFactor
    , BigInteger inBaseCost
    , double inCostFactor
    , in TextBlock costBlock
    , in TextBlock countBlock
    ) {
        Name = name;
        
        BaseCost       = inBaseCost;
        Cost           = BaseCost;
        CostFactor     = inCostFactor;
        CostBlock      = costBlock;
        CostBlock.Text = $"{Cost}";

        Owned           = 0;
        CountBlock      = countBlock;
        CountBlock.Text = $"{Owned}";
        
        BaseFactor = inBasePowerFactor;
        Factor     = BaseFactor;
    }

    BigInteger CalculateOwnedBonus() =>
         Owned >= 10 
         ? (Owned / 10) * 2 
         : 1;

    BigInteger CalculateUpgradesBonus()
    {
        return 1;
    }
    
    public BigInteger Mine() =>
        Factor 
        * CalculateOwnedBonus()
        * CalculateUpgradesBonus()
        * Owned;

    public BigInteger Purchase(BigInteger totalCurrency, BigInteger? amount = null)
    {
        amount ??= 1;
        var totalCost = amount.Value * Cost;
        if (totalCurrency < totalCost) 
            return totalCurrency;
        
        totalCurrency -= totalCost;
        Owned         += amount.Value;
        Cost          += (BigInteger)Math.Floor(Math.Pow((double)Cost, CostFactor));

        CountBlock.Text = $"{Owned}";
        CostBlock.Text  = $"{Cost}";

        return totalCurrency;
    }

    public BigInteger Sell(BigInteger? amount = null)
    {
        amount ??= 1;
        if (amount.Value > Owned)
            return 0;

        var recoveredCost = amount.Value * Cost;
        Owned -= amount.Value;
        Cost  -= (BigInteger)Math.Floor(Math.Pow((double)Cost, CostFactor));
        if (Cost < BaseCost)
            Cost = BaseCost;
        
        CountBlock.Text = $"{Owned}";
        CostBlock.Text  = $"{Cost}";
        
        return recoveredCost;
    }
}
