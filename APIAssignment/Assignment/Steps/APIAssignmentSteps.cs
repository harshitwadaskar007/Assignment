using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace APIAssignment.Steps
{
    [Binding, Scope(Tag = "BindingsOnly")]
    public class APIAssignmentSteps
    {
        [Then(@"I verify promotionId and programType properties")]
        public void ThenIVerifyPromotionIdAndProgramTypeProperties()
        {
            JObject response     = (JObject)ScenarioContext.Current["response"];
            var promoIdType      = response["promotions"][0]["promotionId"].Value<string>().GetType();
            Assert.AreEqual(typeof(string), promoIdType);
            string[] programType = { "EPISODE", "MOVIE", "SERIES", "SEASON" };
            Assert.IsTrue(programType.Contains(response["promotions"][0]["properties"][0]["programType"].ToString().ToUpper()));
        }

        [Then(@"I verify status '(.*)'")]
        public void ThenIVerifyStatus(int status)
        {
            IRestResponse response = (IRestResponse)ScenarioContext.Current["restResponse"];
            Assert.AreEqual((int)response.StatusCode, status);
        }

        [Then(@"I verify promotion properties")]
        public void ThenIVerifyPromotionProperties()
        {
            JObject response  = (JObject)ScenarioContext.Current["response"];
            Assert.IsNotNull(response["promotions"].ToString());
            Assert.IsNotNull(response["promotions"][0]["promotionId"]);
            Assert.IsNotNull(response["promotions"][0]["orderId"]);
            Assert.IsNotNull(response["promotions"][0]["promoArea"]);
            Assert.IsNotNull(response["promotions"][0]["promoType"]);
            var showPriceType = response["promotions"][0]["showPrice"].Value<bool>().GetType();
            Assert.AreEqual(typeof(bool), showPriceType);
            var showTextType  = response["promotions"][0]["showText"].Value<bool>().GetType();
            Assert.AreEqual(typeof(bool), showTextType);
            Assert.IsNotNull(response["promotions"][0]["localizedTexts"]);
            Assert.IsNotNull(response["promotions"][0]["localizedTexts"]["ar"]);
            Assert.IsNotNull(response["promotions"][0]["localizedTexts"]["en"]);
        }

        [Then(@"I verify response with invalid api key")]
        public void ThenIVerifyResponseWithInvalidApiKey()
        {
            JObject response = (JObject)ScenarioContext.Current["response"];
            Assert.AreEqual((string)response["error"]["code"], "8001");
            Assert.IsNotNull(response["error"]["requestId"].ToString());
            Assert.AreEqual((string)response["error"]["message"], "invalid api key");
        }



    }
}
