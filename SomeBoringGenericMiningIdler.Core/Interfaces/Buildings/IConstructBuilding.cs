using System.Windows.Controls;
using SomeBoringGenericMiningIdler.Core.Buildings;

namespace SomeBoringGenericMiningIdler.Core.Interfaces.Buildings;

public interface IConstructBuilding
{
    Building Construct(BuildingName toCreate, in TextBlock costBlock, in TextBlock countBlock);
}
