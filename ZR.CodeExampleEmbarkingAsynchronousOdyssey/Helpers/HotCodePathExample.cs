namespace ZR.CodeExampleEmbarkingAsynchronousOdyssey.Helpers
{
    public class HotCodePathExample
    {
        public async Task<int> ProcessHotPathAsync()
        {
            // Simulate intensive work
            await Task.Delay(TimeSpan.FromSeconds(2));

            return CalculateResult();
        }

        private int CalculateResult()
        {
            // Perform calculations
            return 42;
        }
    }

}
