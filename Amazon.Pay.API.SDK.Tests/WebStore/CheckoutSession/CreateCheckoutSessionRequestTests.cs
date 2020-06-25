﻿using Amazon.Pay.API.WebStore.CheckoutSession;
using Amazon.Pay.API.WebStore.Types;
using NUnit.Framework;

namespace Amazon.Pay.API.Tests.WebStore.CheckoutSession
{
    [TestFixture]
    public class CreateCheckoutSessionRequestTests
    {
        [Test]
        public void CanConstructWithAllPropertiesInitialized()
        {
            // act
            var request = new CreateCheckoutSessionRequest
            (
                checkoutReviewReturnUrl: "https://example.com/review.html",
                storeId: "amzn1.application-oa2-client.000000000000000000000000000000000"
            );

            // assert
            Assert.IsNotNull(request);
            Assert.IsNotNull(request.WebCheckoutDetails);
            Assert.IsNotNull(request.DeliverySpecifications);
            Assert.IsNotNull(request.MerchantMetadata);
            Assert.IsNotNull(request.PaymentDetails);
            Assert.IsNotNull(request.ProviderMetadata);
            Assert.AreEqual("https://example.com/review.html", request.WebCheckoutDetails.CheckoutReviewReturnUrl);
            Assert.AreEqual("amzn1.application-oa2-client.000000000000000000000000000000000", request.StoreId);
        }

        [Test]
        public void CanConvertToJsonMinimal()
        {
            // arrange
            var request = new CreateCheckoutSessionRequest
            (
                checkoutReviewReturnUrl: "https://example.com/review.html",
                storeId: "amzn1.application-oa2-client.000000000000000000000000000000000"
            );

            // act
            string json = request.ToJson();

            // assert
            Assert.AreEqual("{\"webCheckoutDetails\":{\"checkoutReviewReturnUrl\":\"https://example.com/review.html\"},\"storeId\":\"amzn1.application-oa2-client.000000000000000000000000000000000\"}", json);
        }

        [Test]
        public void CanConvertToJsonDeliverySpecifications()
        {
            // arrange
            var request = new CreateCheckoutSessionRequest
            (
                checkoutReviewReturnUrl: "https://example.com/review.html",
                storeId: "amzn1.application-oa2-client.000000000000000000000000000000000"
            );
            request.DeliverySpecifications.AddressRestrictions.Type = RestrictionType.Allowed;
            request.DeliverySpecifications.AddressRestrictions.AddCountryRestriction("US").AddZipCodesRestriction("12345");
            request.DeliverySpecifications.SpecialRestrictions.Add(SpecialRestriction.RestrictPackstations);
            request.DeliverySpecifications.SpecialRestrictions.Add(SpecialRestriction.RestrictPOBoxes);

            // act
            string json = request.ToJson();

            // assert
            Assert.AreEqual("{\"webCheckoutDetails\":{\"checkoutReviewReturnUrl\":\"https://example.com/review.html\"},\"storeId\":\"amzn1.application-oa2-client.000000000000000000000000000000000\",\"deliverySpecifications\":{\"specialRestrictions\":[\"RestrictPackstations\",\"RestrictPOBoxes\"],\"addressRestrictions\":{\"type\":\"Allowed\",\"restrictions\":{\"US\":{\"zipCodes\":[\"12345\"]}}}}}", json);
        }

        [Test]
        public void CanConvertToJsonMerchantMetaData()
        {
            // arrange
            var request = new CreateCheckoutSessionRequest
            (
                checkoutReviewReturnUrl: "https://example.com/review.html",
                storeId: "amzn1.application-oa2-client.000000000000000000000000000000000"
            );
            request.MerchantMetadata.CustomInformation = "foo";
            request.MerchantMetadata.MerchantReferenceId = "123";
            request.MerchantMetadata.MerchantStoreName = "myStore";
            request.MerchantMetadata.NoteToBuyer = "myBuyerNote";

            // act
            string json = request.ToJson();

            // assert
            Assert.AreEqual("{\"webCheckoutDetails\":{\"checkoutReviewReturnUrl\":\"https://example.com/review.html\"},\"storeId\":\"amzn1.application-oa2-client.000000000000000000000000000000000\",\"merchantMetadata\":{\"merchantReferenceId\":\"123\",\"merchantStoreName\":\"myStore\",\"noteToBuyer\":\"myBuyerNote\",\"customInformation\":\"foo\"}}", json);
        }


    }
}