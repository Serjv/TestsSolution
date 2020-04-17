using System;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace APITests
{
    [Binding]
    public class APITestsFeatureSteps
    {
        private string result;
        Actions _actions = new Actions();

        [Given(@"I have request (.*)")]
        public void GivenIHaveRequest(string p0)
        {
            _actions._url = p0;
        }
        
        [Given(@"I have keys (.*)")]
        public void GivenIHaveKeys(string p0)
        {
            _actions._postParameters = p0;
        }
        
        [When(@"I press Send")]
        public void WhenIPressSend()
        {
            result = _actions.Action();
        }
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(string expectedResult)
        {
            result.Should().Be(expectedResult);
        }
    }
}
