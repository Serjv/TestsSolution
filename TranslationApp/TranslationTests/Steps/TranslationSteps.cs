using TechTalk.SpecFlow;
using TranslationTests;

namespace SeleniumTests
{
    [Binding]
    public class TranslationSteps
    {
        private readonly PageDriver _PageDriver;
        public TranslationSteps(PageDriver PageDriver)
        {
            _PageDriver = PageDriver;
        }

        [Given(@"I navigated to translation page")]
        public void GivenInavigatedToTranslationPage()
        {
            _PageDriver.GoToTranslationPage();
        }

        [When(@"I have entered (\D+) into the translator")]
        public void WhenIHaveEnteredIntoTheTranslator(string p0)
        {
            _PageDriver.EnterText(p0);
        }

        [When(@"I choosen translate on (.*)")]
        public void WhenIChoosenTranslateOn(string p0)
        {
            _PageDriver.EnterLanguage(p0);
            
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(string expectedResult)
        {
            _PageDriver.ValidateResultShouldBe(expectedResult);
        }
    }
}
