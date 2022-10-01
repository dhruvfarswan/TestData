using DatacomTest.Drivers;


namespace DatacomTest.Hooks
{
    [Binding]
    public class HooksInitialization
    {
        private readonly ScenarioContext _scenarioContext;

        public HooksInitialization(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [BeforeScenario]
        public void BeforeScenario()
        {
            DriverHelper seleniumdriver = new DriverHelper();
            _scenarioContext.Set(seleniumdriver, "DriverHelper");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("Selenium webdriver exit");
            DriverHelper.Driver.Quit();
        }
    }
}