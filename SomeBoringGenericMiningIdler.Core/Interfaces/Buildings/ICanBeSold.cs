using System.Numerics;

namespace SomeBoringGenericMiningIdler.Core.Interfaces.Buildings;

public interface ICanBeSold
{
    /// <summary>
    /// Provides functionality for a building to be sold.
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    BigInteger Sell(BigInteger? amount = null);
}
