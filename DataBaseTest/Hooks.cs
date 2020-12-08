using TechTalk.SpecFlow;

namespace DataBaseTest
{
    [Binding]
    public sealed class Hooks
    {
        [AfterTestRun]
        public static void ContextDispose()
        {
            StaticContext.context.Dispose();
        }
    }
}
