using System.Numerics;
using SomeBoringGenericMiningIdler.Core.Buildings;

namespace SomeBoringGenericMiningIdler.Core.Stores.Interfaces;

public interface ITransactBuildings
{
    /// <summary>
    /// Add the desired amount to the owned count of the building, if the
    /// player has the necessary amount of currency on hand.
    /// </summary>
    /// <param name="currentCurrency">Player's currency.</param>
    /// <param name="buildings">Reference to the buildings dictionary.</param>
    /// <param name="requested">The building type to purchase.</param>
    /// <param name="desiredAmount">The amount to buy.</param>
    /// <returns></returns>
    BigInteger HandlePurchase(          
      BigInteger currentCurrency
    , in Dictionary<BuildingName, Building> buildings
    , BuildingName requested
    , BigInteger? desiredAmount = null
    );

    /// <summary>
    /// Allows the player to sell the desired building by the
    /// given amount.
    /// </summary>
    /// <param name="buildings">Reference to the buildings dictionary.</param>
    /// <param name="requested">Type of building to be sold.</param>
    /// <param name="desiredAmount">Amount of the given building type to be sold.</param>
    /// <returns></returns>
    BigInteger HandleBuyback(      
      in Dictionary<BuildingName, Building> buildings
    , BuildingName requested
    , BigInteger? desiredAmount = null 
    );
}
