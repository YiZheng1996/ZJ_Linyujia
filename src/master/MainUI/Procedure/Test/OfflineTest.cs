namespace MainUI.Procedure.Test
{
    public class OfflineTest(CancellationToken cancellationToken) : BaseTest
    {
        public override Task<bool> Execute()
        {
            TestStatus(true);
            TxtTips("试验开始");
            Debug.WriteLine("----------------------试验开始----------------------");

            Debug.WriteLine("----------------------试验结束----------------------");
            TxtTips("试验结束");
            TestStatus(false);
            return Task.FromResult(true);
        }
    }
}
