using MainUI.CurrencyHelper;

namespace MainUI.Procedure.Test
{
    public class PressurizationTest(CancellationToken cancellationToken) : BaseTest
    {
        public override Task<bool> Execute()
        {
            //TestStatus(true);
            var TaskState = cancellationToken.IsCancellationRequested;
            Delay(90, 1000, delegate
            {
                string time = DateTime.Now.ToString();
                string voltage = OPCHelper.AIgrp[0].ToString();
                string current = OPCHelper.AIgrp[1].ToString();
               
                if (OPCHelper.DIgrp[25]) return false;
                return OPCHelper.DIgrp[26] == false;
            }, cancellationToken);
           
            TestStatus(false);
            return Task.FromResult(true);
        }
    }
}
