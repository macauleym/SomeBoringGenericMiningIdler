using System.Numerics;
using SomeBoringGenericMiningIdler.Core.Buildings;
using SomeBoringGenericMiningIdler.Core.Stores.Interfaces;

namespace SomeBoringGenericMiningIdler.Core.Stores;

public class BuildingStore : ITransactBuildings
{
    public BigInteger HandlePurchase(
      BigInteger currentCurrency
    , in Dictionary<BuildingName, Building> buildings
    , BuildingName requested
    , BigInteger? desiredAmount = null 
    ) => buildings[requested].Purchase(currentCurrency, desiredAmount);

    public BigInteger HandleBuyback(
      in Dictionary<BuildingName, Building> buildings
    , BuildingName requested
    , BigInteger? desiredAmount = null
    ) => buildings[requested].Sell(desiredAmount);
}
