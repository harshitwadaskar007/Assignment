using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using APIAssignment.Assignment;
using System.Threading;
using APIAssignment.Pages;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;

namespace APIAssignment.Assignment
{
    [Binding]
    public class GenericAPISteps : API_ObjectFactory
    {
        [Given(@"I call API with key as '(.*)'")]
        public void GivenICallAPIWithKeyAs(string apiKey)
        {
            var response = genericAPI_Fucntions.PostAPI(apiKey);
            ScenarioContext.Current["RestResponse"] = response;
        }


    }
}
