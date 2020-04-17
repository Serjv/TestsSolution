using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TranslationTests
{
    [Binding]
    public class Screenshots
    {
        private readonly WebDriver _webDriver;

        public Screenshots(WebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [AfterStep]
        public void MakeScreenshotAfterStep()
        {
            if (!(_webDriver.Current is ITakesScreenshot takesScreenshot))
            {
                return;
            }

            var screenshot = takesScreenshot.GetScreenshot();

            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(Path.GetTempFileName());
            string fileName = $"{fileNameWithoutExtension}.png";
            string tempFileName = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            screenshot.SaveAsFile(tempFileName, ScreenshotImageFormat.Png);

            Console.WriteLine($"SCREENSHOT[ file:///{tempFileName} ]SCREENSHOT");
        }
    }
}
