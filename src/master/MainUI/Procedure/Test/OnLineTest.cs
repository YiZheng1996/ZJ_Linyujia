using MainUI.CurrencyHelper;
namespace MainUI.Procedure.Test
{
    public class OnLineTest(CancellationToken cancellationToken) : BaseTest
    {
        public override Task<bool> Execute()
        {
            TestStatus(true);
            TxtTips("试验开始");
            var TaskState = cancellationToken.IsCancellationRequested;
            Task.Delay(1000).Wait();
            Delay(90, 100, cancellationToken, () => OPCHelper.DIgrp[26].ToBool());
            
            TxtTips("试验完成");
            TestStatus(false);
            return Task.FromResult(true);
        }
    }
}
