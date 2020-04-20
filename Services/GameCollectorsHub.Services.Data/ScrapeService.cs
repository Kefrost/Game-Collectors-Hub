using GameCollectorsHub.Web.ViewModels.ScrapeData;
using HtmlAgilityPack;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameCollectorsHub.Services.Data
{
    public class ScrapeService : IScrapeService
    {
        public PriceScrapeDataViewModel GetPrices(string url)
        {
            ScrapingBrowser browser = new ScrapingBrowser();

            var model = new PriceScrapeDataViewModel();

            var webpage = browser.NavigateToPage(new Uri(url)).Html;

            HtmlNode used = webpage.OwnerDocument.DocumentNode.SelectSingleNode("//*[@id=\"used_price\"]/span");

            model.UsedPrice = used == null ? "N/A" : used.InnerText;

            HtmlNode complete = webpage.OwnerDocument.DocumentNode.SelectSingleNode("//*[@id=\"complete_price\"]/span");

            model.CompletePrice = complete == null ? "N/A" : complete.InnerText;

            HtmlNode newPrice = webpage.OwnerDocument.DocumentNode.SelectSingleNode("//*[@id=\"new_price\"]/span");

            model.NewPrice = newPrice == null ? "N/A" : newPrice.InnerText;

            return model;
        }
    }
}
