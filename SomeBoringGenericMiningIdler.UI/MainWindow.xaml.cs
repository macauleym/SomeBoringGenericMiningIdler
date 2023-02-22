using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SomeBoringGenericMiningIdler.Core;
using SomeBoringGenericMiningIdler.Core.Buildings;
using SomeBoringGenericMiningIdler.Core.Interfaces.Buildings;
using SomeBoringGenericMiningIdler.Core.Stores;
using SomeBoringGenericMiningIdler.Core.Stores.Interfaces;

namespace SomeBoringGenericMiningIdler.UI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    bool shouldRun = true;
        
    GameState gameState;
    Dictionary<BuildingName, Building> buildings;
    BigInteger minedAmount;

    IConstructBuilding buildingFactory;
    ITransactBuildings buildingStore;
    ITransactUpgrades upgradeStore;

    void OnInit()
    {
        buildingStore   = new BuildingStore();
        buildingFactory = new BuildingFactory();

        upgradeStore = new UpgradeStore();
            
        gameState     = new();
        buildings = new()
        { [BuildingName.SentientShovel] = buildingFactory.Construct(BuildingName.SentientShovel
            , in sentientShovelCost
            , in sentientShovelCount
            )
        , [BuildingName.MiningCamp] = buildingFactory.Construct(BuildingName.MiningCamp
            , in miningCampCost
            , in miningCampCount
            )
        , [BuildingName.Excavator]  = buildingFactory.Construct(BuildingName.Excavator
            , in excavatorCost
            , in excavatorCount
            )
        };
        minedAmount = new BigInteger(0);

        totalCurrency.DataContext = gameState.Currency;
    }
    
    async Task Tick()
    {
        totalMining.Text   = $"+ {minedAmount}";
        gameState.Currency    += minedAmount;
        totalCurrency.Text = $"{gameState.Currency}";
    }

    async void RunLoop()
    {
        do
        {
            await Tick();
            await Task.Delay(TimeSpan.FromSeconds(gameState.TimeFactor));
        } while (shouldRun);
    }

    public MainWindow()
    {
        InitializeComponent();
        OnInit();
        RunLoop();
    }

    BigInteger CalculatePlayerPower(in BigInteger mined) =>
        mined >= 10 ? mined / 10 * 2 : 1;
    
    void MineOre_OnClick(object sender, RoutedEventArgs e)
    {
        gameState.Currency += gameState.PlayerPower;
        totalCurrency.Text = $"{gameState.Currency}";
    }

    void PurchaseBuilding_OnClick(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        if (!Enum.TryParse<BuildingName>((string)button.Tag, out var requestedBuilding))
            return;
            
        gameState.Currency = buildingStore.HandlePurchase(
          gameState.Currency
        , in buildings
        , requestedBuilding
        );

        var newPower = CalculatePlayerPower(in minedAmount);
        gameState.PlayerPower = newPower;
        mineOre.Content = $"Mine {gameState.PlayerPower} Ore";
        minedAmount = buildings
            .Select(b => b.Value)
            .Aggregate(new BigInteger(0)
                , (oreAmount, building) => oreAmount + building.Mine()
            );
        totalCurrency.Text = $"{gameState.Currency}";
    }
}
