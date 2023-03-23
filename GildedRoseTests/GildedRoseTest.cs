using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using static GildedRoseKata.Constants;
using GildedRoseKata.Factories.Resolvers;
using GildedRoseKata.Factories.Strategies;
using GildedRoseKata.Factories.Adjusters;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void QualityDecreasesByOneAndSellinDecreasesByOne()
        {
            var initialQuality = 11;
            var initialSellIn = 11;
            var itemName = "Test";
            var item = CreateItem(itemName, initialSellIn, initialQuality);

            var gildedRose = CreateApp(new List<Item>() { item });
            gildedRose.UpdateQuality();

            Assert.Equal(itemName, item.Name);
            Assert.Equal(initialQuality - 1, item.Quality);
            Assert.Equal(initialSellIn - 1, item.SellIn);
        }

        [Fact]
        public void QualityIncreasesByTwoWhenThereAreLessThanEqualToTenDaysToSellTheItemAndItemIsBackstagePasses()
        {
            var initialQuality = 11;
            var initialSellIn = 9;
            var itemName = BACKSTAGE_PASSES;
            var item = CreateItem(itemName, initialSellIn, initialQuality);

            var gildedRose = CreateApp(new List<Item>() { item });
            gildedRose.UpdateQuality();

            Assert.Equal(itemName, item.Name);
            Assert.Equal(initialQuality + 2, item.Quality);
            Assert.Equal(initialSellIn - 1, item.SellIn);
        }

        [Fact]
        public void QualityIncreasesByThreeWhenThereAreLessThanEqualToFiveDaysToSellTheItemAndItemIsBackstagePasses()
        {
            var initialQuality = 11;
            var initialSellIn = 5;
            var itemName = BACKSTAGE_PASSES;
            var item = CreateItem(itemName, initialSellIn, initialQuality);

            var gildedRose = CreateApp(new List<Item>() { item });
            gildedRose.UpdateQuality();

            Assert.Equal(itemName, item.Name);
            Assert.Equal(initialQuality + 3, item.Quality);
            Assert.Equal(initialSellIn - 1, item.SellIn);
        }

        [Fact]
        public void QualityDoesNotGoAboveFiftyWhenBackstageItemQualityIsIncreasedByThree()
        {
            var initialQuality = 48;
            var initialSellIn = 5;
            var itemName = BACKSTAGE_PASSES;
            var item = CreateItem(itemName, initialSellIn, initialQuality);

            var gildedRose = CreateApp(new List<Item>() { item });
            gildedRose.UpdateQuality();

            Assert.Equal(itemName, item.Name);
            Assert.Equal(MAX_ITEM_QUALITY, item.Quality);
            Assert.Equal(initialSellIn - 1, item.SellIn);
        }

        [Fact]
        public void QualityDoesNotGoAboveFiftyWhenBackstageItemQualityIsIncreasedByTwo()
        {
            var initialQuality = 49;
            var initialSellIn = 9;
            var itemName = BACKSTAGE_PASSES;
            var item = CreateItem(itemName, initialSellIn, initialQuality);

            var gildedRose = CreateApp(new List<Item>() { item });
            gildedRose.UpdateQuality();

            Assert.Equal(itemName, item.Name);
            Assert.Equal(MAX_ITEM_QUALITY, item.Quality);
            Assert.Equal(initialSellIn - 1, item.SellIn);
        }

        [Fact]
        public void QualityOfAnBackstageDropsToZeroWhenSellInDateHasExpired()
        {
            var initialQuality = 50;
            var initialSellIn = -1;
            var itemName = BACKSTAGE_PASSES;
            var item = CreateItem(itemName, initialSellIn, initialQuality);

            var gildedRose = CreateApp(new List<Item>() { item });
            gildedRose.UpdateQuality();

            Assert.Equal(itemName, item.Name);
            Assert.Equal(MIN_ITEM_QUALITY, item.Quality);
            Assert.Equal(initialSellIn - 1, item.SellIn);
        }

        [Fact]
        public void QualityDecreasesByTwoWhenTheSellInDateHasPassed()
        {
            var initialQuality = 11;
            var initialSellIn = 0;
            var itemName = "TEST";
            var item = CreateItem(itemName, initialSellIn, initialQuality);

            var gildedRose = CreateApp(new List<Item>() { item });
            gildedRose.UpdateQuality();

            Assert.Equal(itemName, item.Name);
            Assert.Equal(initialQuality - 2, item.Quality);
            Assert.Equal(initialSellIn - 1, item.SellIn);
        }

        [Fact]
        public void QualityDecreasesByTwoWhenTheSellInDateHasPassedAndDoesNotGoBelowZero()
        {
            var initialQuality = MIN_ITEM_QUALITY;
            var initialSellIn = 0;
            var itemName = "TEST";
            var item = CreateItem(itemName, initialSellIn, initialQuality);

            var gildedRose = CreateApp(new List<Item>() { item });
            gildedRose.UpdateQuality();

            Assert.Equal(itemName, item.Name);
            Assert.Equal(initialQuality, item.Quality);
            Assert.Equal(initialSellIn - 1, item.SellIn);
        }

        [Fact]
        public void QualityOfAnItemIsNeverNegative()
        {
            var initialQuality = MIN_ITEM_QUALITY;
            var initialSellIn = 10;
            var itemName = "TEST";
            var item = CreateItem(itemName, initialSellIn, initialQuality);

            var gildedRose = CreateApp(new List<Item>() { item });
            gildedRose.UpdateQuality();

            Assert.Equal(itemName, item.Name);
            Assert.Equal(initialQuality, item.Quality);
            Assert.Equal(initialSellIn - 1, item.SellIn);
        }

        [Fact]
        public void QualityOfAnAgedBrieIncreasesAsItsSellInDateDecreases()
        {
            var initialQuality = 10;
            var initialSellIn = 10;
            var itemName = AGED_BRIE;
            var item = CreateItem(itemName, initialSellIn, initialQuality);

            var gildedRose = CreateApp(new List<Item>() { item });
            gildedRose.UpdateQuality();

            Assert.Equal(itemName, item.Name);
            Assert.Equal(initialQuality + 1, item.Quality);
            Assert.Equal(initialSellIn - 1, item.SellIn);
        }

        [Fact]
        public void QualityOfAnAgedBrieIncreasesAsItsSellInDateDecreasesAndDoesNotGoAboveFifty()
        {
            var initialQuality = MAX_ITEM_QUALITY;
            var initialSellIn = 10;
            var itemName = AGED_BRIE;
            var item = CreateItem(itemName, initialSellIn, initialQuality);

            var gildedRose = CreateApp(new List<Item>() { item });
            gildedRose.UpdateQuality();

            Assert.Equal(itemName, item.Name);
            Assert.Equal(initialQuality, item.Quality);
            Assert.Equal(initialSellIn - 1, item.SellIn);
        }

        [Fact]
        public void QualityOfAnItemNeverGetsMoreThanFifty()
        {
            var initialQuality = MAX_ITEM_QUALITY;
            var initialSellIn = 10;
            var itemName = AGED_BRIE;
            var item = CreateItem(itemName, initialSellIn, initialQuality);

            var gildedRose = CreateApp(new List<Item>() { item });
            gildedRose.UpdateQuality();

            Assert.Equal(itemName, item.Name);
            Assert.Equal(initialQuality, item.Quality);
            Assert.Equal(initialSellIn - 1, item.SellIn);
        }

        [Fact]
        public void QualityOfAgedBrieIncreasesByTwoWhenTheSellInDateHasExpired()
        {
            var initialQuality = 10;
            var initialSellIn = -1;
            var itemName = AGED_BRIE;
            var item = CreateItem(itemName, initialSellIn, initialQuality);

            var gildedRose = CreateApp(new List<Item>() { item });
            gildedRose.UpdateQuality();

            Assert.Equal(itemName, item.Name);
            Assert.Equal(initialQuality + 2, item.Quality);
            Assert.Equal(initialSellIn - 1, item.SellIn);
        }

        [Fact]
        public void QualityAndSellInDateOfAnSulfurasNeverDecerase()
        {
            var initialQuality = 80;
            var initialSellIn = 10;
            var itemName = SULFURAS;
            var item = CreateItem(itemName, initialSellIn, initialQuality);

            var gildedRose = CreateApp(new List<Item>() { item });
            gildedRose.UpdateQuality();

            Assert.Equal(itemName, item.Name);
            Assert.Equal(initialQuality, item.Quality);
            Assert.Equal(initialSellIn, item.SellIn);
        }

        [Fact]
        public void QualityDecreasesTwiceAsFastForConjuredItem()
        {
            var initialQuality = 30;
            var initialSellIn = 10;
            var itemName = CONJURED;
            var item = CreateItem(itemName, initialSellIn, initialQuality);

            var gildedRose = CreateApp(new List<Item>() { item });
            gildedRose.UpdateQuality();

            Assert.Equal(itemName, item.Name);
            Assert.Equal(initialQuality - 2, item.Quality);
            Assert.Equal(initialSellIn - 1, item.SellIn);
        }

        [Fact]
        public void QualityDecreasesTwiceAsFastForConjuredItemAndWhenSellinDateHasExpired()
        {
            var initialQuality = 30;
            var initialSellIn = 0;
            var itemName = CONJURED;
            var item = CreateItem(itemName, initialSellIn, initialQuality);

            var gildedRose = CreateApp(new List<Item>() { item });
            gildedRose.UpdateQuality();

            Assert.Equal(itemName, item.Name);
            Assert.Equal(initialQuality - 4, item.Quality);
            Assert.Equal(initialSellIn - 1, item.SellIn);
        }

        private Item CreateItem(string name, int sellIn, int quality)
            => new Item() { Name = name, Quality = quality, SellIn = sellIn };

        private GildedRose2 CreateApp(List<Item> items)
        {
            var adjusterFactory = new AdjusterFactory();
            var strategyFactory = new StrategyFactory(adjusterFactory);
            var strategyResolverFactory = new UpdateStrategyResolverFactory(strategyFactory);
            return new GildedRose2(items, new ItemUpdater(strategyResolverFactory.CreateResolver()));
        }
    }
}
