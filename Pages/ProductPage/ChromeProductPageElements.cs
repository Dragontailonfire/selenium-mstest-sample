﻿namespace Pages.ProductPage
{
    public class ChromeProductPageElements : IProductPageElements
    {
        public string QuantityTextBoxId => "quantity_wanted";

        public string ProductHeadingXpath => "//h1[@itemprop='name']";

        public string SizeDropDownId => "group_1";

        public string AddToCartButtonXpath => "//*[text()[contains(.,'Add to cart')]]";
    }
}